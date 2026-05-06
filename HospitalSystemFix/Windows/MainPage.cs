using Domain;
using HospitalSystemFix.Core;
using HospitalSystemFix.Utils;
using HospitalSystemFix.Windows;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace HospitalSystemFix
{
    public delegate void UiUpdateHandler();

    public partial class MainPage : MaterialForm
    {
        private HospitalDatabase _db = new HospitalDatabase();
        private readonly IRepository<Doctor> _doctorRepo;
        private readonly IRepository<HospitalPatient> _patientRepo;

        private readonly string _dbFilePath = "hospital_data.json";
        private readonly JsonSerializerOptions _jsonOptions;

        public MainPage()
        {
            InitializeComponent();

            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            _doctorRepo = new LocalRepository<Doctor>(_db.Doctors);
            _patientRepo = new LocalRepository<HospitalPatient>(_db.Patients);

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            DoctorList.Columns.Add("Doctor Name", 200);
            PatientList.Columns.Add("Patient Name", 200);

            EventHandler viewPatientsDel = new EventHandler(ViewPatientsByDoctor);
            EventHandler viewDoctorsDel = new EventHandler(ViewDoctorsByPatient);
            EventHandler connectDel = new EventHandler(ConnectButton_Click);
            EventHandler resetDel = new EventHandler(ResetLists_Click);
            EventHandler exampleDelegat = new EventHandler(exampleDelegateSnackBar);
            EventHandler deleteDel = new EventHandler(DeleteButton_Click);

            DeleteButton.Click += deleteDel;
            viewAllDoctorsPatientButton.Click += viewPatientsDel;
            viewAllPatientDoctorsButton.Click += viewDoctorsDel;
            ConnectButton.Click += connectDel;
            ResetLists.Click += resetDel;
            ResetLists.Click += exampleDelegat;

            LoadData();
        }

        private void exampleDelegateSnackBar(object? sender, EventArgs e)
        {
            new MaterialSnackBar("Testing Delegate", "OK", true).Show(this);
        }

        private void btnOpenAddDoctor_Click(object? sender, EventArgs e)
        {
            using (var form = new AddDoctor() { StartPosition = FormStartPosition.CenterParent })
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.NewDoctor != null)
                {
                    if (form.NewDoctor.IsValid())
                    {
                        _doctorRepo.Add(form.NewDoctor);
                        SaveData();
                    }
                }
            }
        }

        private void btnOpenAddPatient_Click(object? sender, EventArgs e)
        {
            using (var form = new AddHospitalPatient() { StartPosition = FormStartPosition.CenterParent })
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.NewPatient != null)
                {
                    if (form.NewPatient.IsValid())
                    {
                        _patientRepo.Add(form.NewPatient);
                        SaveData();
                    }
                }
            }
        }

        private void ConnectButton_Click(object? sender, EventArgs e)
        {
            if (DoctorList.SelectedItems.Count == 0 || PatientList.SelectedItems.Count == 0)
            {
                new MaterialSnackBar("Select both doctor and patient to link!", "OK", true).Show(this);
                return;
            }

            var doc = (Doctor)DoctorList.SelectedItems[0].Tag;
            var pat = (HospitalPatient)PatientList.SelectedItems[0].Tag;

            if (doc.HasPatient(pat.Id))
            {
                new MaterialSnackBar("This link already exists!", "OK", true).Show(this);
                return;
            }

            _db.AddLink(doc, pat);

            SaveData();
            new MaterialSnackBar("Successfully linked!", "OK", true).Show(this);
        }

        private void ViewPatientsByDoctor(object? sender, EventArgs e)
        {
            if (DoctorList.SelectedItems.Count > 0)
            {
                int selectedIndex = DoctorList.SelectedIndices[0];
                Doctor doc = _db[selectedIndex]; 

                RefreshUI(_db.Doctors, doc.Patients);
            }
            else new MaterialSnackBar("Select a doctor!", "OK", true).Show(this);
        }

        private void ViewDoctorsByPatient(object? sender, EventArgs e)
        {
            if (PatientList.SelectedItems.Count > 0 && PatientList.SelectedItems[0].Tag is HospitalPatient pat)
            {
                RefreshUI(pat.Doctors, _db.Patients);
            }
            else new MaterialSnackBar("Select a patient!", "OK", true).Show(this);
        }

        private void ResetLists_Click(object? sender, EventArgs e)
        {
            RefreshUI(_db.Doctors, _db.Patients);
        }

        private void RefreshUI(IEnumerable<Doctor> docs, IEnumerable<HospitalPatient> pats)
        {
            UiHelper.PopulateListView(DoctorList, docs, d => d.FullName);
            UiHelper.PopulateListView(PatientList, pats, p => p.FullName);
        }

        private void ExecuteOnSelected<T>(ListView listView, Action<T> action) where T : class
        {
            if (listView.SelectedItems.Count > 0 && listView.SelectedItems[0].Tag is T item)
            {
                action(item);
            }
            else
            {
                new MaterialSnackBar($"Select an item in {listView.Name}!", "OK", true).Show(this);
            }
        }

        private void SaveData()
        {
            RefreshUI(_db.Doctors, _db.Patients);

            string json = JsonSerializer.Serialize(_db, _jsonOptions);
            File.WriteAllText(_dbFilePath, json);
        }

        private void LoadData()
        {
            if (File.Exists(_dbFilePath))
            {
                string json = File.ReadAllText(_dbFilePath);
                var loadedDb = JsonSerializer.Deserialize<HospitalDatabase>(json, _jsonOptions);

                if (loadedDb != null)
                {
                    _db = loadedDb;
                    // Re-initialize repositories with new data
                    ((LocalRepository<Doctor>)_doctorRepo).SetData(_db.Doctors);
                    ((LocalRepository<HospitalPatient>)_patientRepo).SetData(_db.Patients);
                }
            }

            RefreshUI(_doctorRepo.GetAll(), _patientRepo.GetAll());
        }

        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            bool isDeleted = false;

            ExecuteOnSelected<Doctor>(DoctorList, doc =>
            {
                _db.Patients.ToList().ForEach(p => _db.RemoveLink(doc, p));
                _doctorRepo.Remove(doc);
                isDeleted = true;
            });

            ExecuteOnSelected<HospitalPatient>(PatientList, pat =>
            {
                _db.Doctors.ToList().ForEach(d => _db.RemoveLink(d, pat));
                _patientRepo.Remove(pat);
                isDeleted = true;
            });

            if (isDeleted)
            {
                SaveData();
                new MaterialSnackBar("Successfully deleted!", "OK", true).Show(this);
            }
        }
    }
}
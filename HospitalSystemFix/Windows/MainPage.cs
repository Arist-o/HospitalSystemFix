using Domain;
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

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            DoctorList.Columns.Add("ПІБ Лікаря", 200);
            PatientList.Columns.Add("ПІБ Пацієнта", 200);

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
            new MaterialSnackBar("Тестуємо", "ОК", true).Show(this);
        }
        private void btnOpenAddDoctor_Click(object? sender, EventArgs e)
        {
            using (var form = new AddDoctor() { StartPosition = FormStartPosition.CenterParent })
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.NewDoctor != null)
                {
                    _db.Doctors.Add(form.NewDoctor);
                    SaveData();
                }
            }
        }

        private void btnOpenAddPatient_Click(object? sender, EventArgs e)
        {
            using (var form = new AddHospitalPatient() { StartPosition = FormStartPosition.CenterParent })
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.NewPatient != null)
                {
                    _db.Patients.Add(form.NewPatient);
                    SaveData();
                }
            }
        }

        private void ConnectButton_Click(object? sender, EventArgs e)
        {
            if (DoctorList.SelectedItems.Count == 0 || PatientList.SelectedItems.Count == 0)
            {
                new MaterialSnackBar("Оберіть і лікаря, і пацієнта для зв'язку!", "ОК", true).Show(this);
                return;
            }

            var doc = (Doctor)DoctorList.SelectedItems[0].Tag;
            var pat = (HospitalPatient)PatientList.SelectedItems[0].Tag;

            if (doc.Patients.Any(p => p.Id == pat.Id))
            {
                new MaterialSnackBar("Цей зв'язок вже існує!", "ОК", true).Show(this);
                return;
            }

            doc.Patients.Add(pat);
            pat.Doctors.Add(doc);

            SaveData();
            new MaterialSnackBar("Успішно пов'язано!", "ОК", true).Show(this);
        }

        private void ViewPatientsByDoctor(object? sender, EventArgs e)
        {
            if (DoctorList.SelectedItems.Count > 0)
            {
                int selectedIndex = DoctorList.SelectedIndices[0];
                Doctor doc = _db[selectedIndex];

                RefreshUI(_db.Doctors, doc.Patients);
            }
            else new MaterialSnackBar("Оберіть лікаря!", "ОК", true).Show(this);
        }

        private void ViewDoctorsByPatient(object? sender, EventArgs e)
        {
            if (PatientList.SelectedItems.Count > 0 && PatientList.SelectedItems[0].Tag is HospitalPatient pat)
            {
                RefreshUI(pat.Doctors, _db.Patients);
            }
            else new MaterialSnackBar("Оберіть пацієнта!", "ОК", true).Show(this);
        }

        private void ResetLists_Click(object? sender, EventArgs e)
        {
            RefreshUI(_db.Doctors, _db.Patients);
        }

        private void RefreshUI(IEnumerable<Doctor> docs, IEnumerable<HospitalPatient> pats)
        {
            DoctorList.Items.Clear();
            foreach (var doc in docs)
            {
                DoctorList.Items.Add(new ListViewItem(doc.FullName) { Tag = doc });
            }

            PatientList.Items.Clear();
            foreach (var pat in pats)
            {
                PatientList.Items.Add(new ListViewItem(pat.FullName) { Tag = pat });
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
                }
            }

            RefreshUI(_db.Doctors, _db.Patients);
        }
        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            bool isDeleted = false;

            if (DoctorList.SelectedItems.Count > 0)
            {
                var selectedDoctor = (Doctor)DoctorList.SelectedItems[0].Tag;

                foreach (var patient in _db.Patients)
                {
                    patient.Doctors.RemoveAll(d => d.Id == selectedDoctor.Id);
                }

                _db.Doctors.Remove(selectedDoctor);
                isDeleted = true;
            }

            if (PatientList.SelectedItems.Count > 0)
            {
                var selectedPatient = (HospitalPatient)PatientList.SelectedItems[0].Tag;

                foreach (var doctor in _db.Doctors)
                {
                    doctor.Patients.RemoveAll(p => p.Id == selectedPatient.Id);
                }
                foreach (var doctor in _db.Doctors)
                {
                    doctor.Patients.RemoveAll(p => p.Id == selectedPatient.Id);
                }

                _db.Patients.Remove(selectedPatient);
                isDeleted = true;
            }

            if (isDeleted)
            {
                SaveData();
                new MaterialSnackBar("Успішно видалено!", "ОК", true).Show(this);
            }
            else
            {
                new MaterialSnackBar("Оберіть лікаря або пацієнта для видалення!", "ОК", true).Show(this);
            }
        }
    }
}
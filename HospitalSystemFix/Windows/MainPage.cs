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
    public partial class MainPage : MaterialForm
    {
        private List<Doctor> _doctors = new();
        private List<HospitalPatient> _patients = new();

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

            viewAllDoctorsPatientButton.Click += ViewPatientsByDoctor;
            viewAllPatientDoctorsButton.Click += ViewDoctorsByPatient;
            ResetLists.Click += (s, e) => RefreshUI(_doctors, _patients);

            ConnectButton.Click += ConnectButton_Click;

            LoadData();
        }

    
        private void btnOpenAddDoctor_Click(object? sender, EventArgs e)
        {
            using (var form = new AddDoctor() { StartPosition = FormStartPosition.CenterParent })
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.NewDoctor != null)
                {
                    _doctors.Add(form.NewDoctor);
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
                    _patients.Add(form.NewPatient);
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
            if (DoctorList.SelectedItems.Count > 0 && DoctorList.SelectedItems[0].Tag is Doctor doc)
            {
                RefreshUI(_doctors, doc.Patients);
            }
            else new MaterialSnackBar("Оберіть лікаря!", "ОК", true).Show(this);
        }

        private void ViewDoctorsByPatient(object? sender, EventArgs e)
        {
            if (PatientList.SelectedItems.Count > 0 && PatientList.SelectedItems[0].Tag is HospitalPatient pat)
            {
                RefreshUI(pat.Doctors, _patients);
            }
            else new MaterialSnackBar("Оберіть пацієнта!", "ОК", true).Show(this);
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
            RefreshUI(_doctors, _patients);

            var db = new HospitalDatabase { Doctors = _doctors, Patients = _patients };
            string json = JsonSerializer.Serialize(db, _jsonOptions);
            File.WriteAllText(_dbFilePath, json);
        }

        private void LoadData()
        {
            if (File.Exists(_dbFilePath))
            {
                string json = File.ReadAllText(_dbFilePath);
                var db = JsonSerializer.Deserialize<HospitalDatabase>(json, _jsonOptions);

                if (db != null)
                {
                    _doctors = db.Doctors ?? new List<Doctor>();
                    _patients = db.Patients ?? new List<HospitalPatient>();
                }
            }

            RefreshUI(_doctors, _patients); 
        }
    }
}
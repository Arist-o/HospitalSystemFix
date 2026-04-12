using Domain;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace HospitalSystemFix.Windows
{
    public partial class AddHospitalPatient : MaterialForm
    {
        public HospitalPatient NewPatient { get; private set; }

        public AddHospitalPatient()
        {
            InitializeComponent();
            btnAddDoctor.Click += btnSavePatient_Click; 
        }

        private void btnSavePatient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                new MaterialSnackBar("Помилка: Введіть ПІБ!", "ОК", true).Show(this);
                return;
            }

            NewPatient = new HospitalPatient
            {
                FullName = txtFullName.Text,
                Diagnosis = "Обстеження"
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
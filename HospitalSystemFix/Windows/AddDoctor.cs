using Domain;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace HospitalSystemFix.Windows
{
    public partial class AddDoctor : MaterialForm
    {
        public Doctor NewDoctor { get; private set; }

        public AddDoctor()
        {
            InitializeComponent();
            btnAddDoctor.Click += btnAddDoctor_Click;
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                new MaterialSnackBar("Error: Enter Full Name!", "OK", true).Show(this);
                return;
            }

            NewDoctor = new Doctor(txtFullName.Text, "General Practice");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
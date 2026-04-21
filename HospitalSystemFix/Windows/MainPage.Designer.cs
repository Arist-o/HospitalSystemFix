namespace HospitalSystemFix
{
    partial class MainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOpenAddDoctor = new MaterialSkin.Controls.MaterialButton();
            btnOpenAddPatient = new MaterialSkin.Controls.MaterialButton();
            viewAllDoctorsPatientButton = new MaterialSkin.Controls.MaterialButton();
            viewAllPatientDoctorsButton = new MaterialSkin.Controls.MaterialButton();
            ResetLists = new MaterialSkin.Controls.MaterialButton();
            PatientList = new MaterialSkin.Controls.MaterialListView();
            DoctorList = new MaterialSkin.Controls.MaterialListView();
            ConnectButton = new MaterialSkin.Controls.MaterialButton();
            DeleteButton = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // btnOpenAddDoctor
            // 
            btnOpenAddDoctor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOpenAddDoctor.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOpenAddDoctor.Depth = 0;
            btnOpenAddDoctor.HighEmphasis = true;
            btnOpenAddDoctor.Icon = null;
            btnOpenAddDoctor.Location = new Point(45, 95);
            btnOpenAddDoctor.Margin = new Padding(4, 6, 4, 6);
            btnOpenAddDoctor.MouseState = MaterialSkin.MouseState.HOVER;
            btnOpenAddDoctor.Name = "btnOpenAddDoctor";
            btnOpenAddDoctor.NoAccentTextColor = Color.Empty;
            btnOpenAddDoctor.Size = new Size(155, 36);
            btnOpenAddDoctor.TabIndex = 0;
            btnOpenAddDoctor.Text = "Add Doctor";
            btnOpenAddDoctor.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnOpenAddDoctor.UseAccentColor = false;
            btnOpenAddDoctor.UseVisualStyleBackColor = true;
            btnOpenAddDoctor.Click += btnOpenAddDoctor_Click;
            // 
            // btnOpenAddPatient
            // 
            btnOpenAddPatient.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOpenAddPatient.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOpenAddPatient.Depth = 0;
            btnOpenAddPatient.HighEmphasis = true;
            btnOpenAddPatient.Icon = null;
            btnOpenAddPatient.Location = new Point(45, 143);
            btnOpenAddPatient.Margin = new Padding(4, 6, 4, 6);
            btnOpenAddPatient.MouseState = MaterialSkin.MouseState.HOVER;
            btnOpenAddPatient.Name = "btnOpenAddPatient";
            btnOpenAddPatient.NoAccentTextColor = Color.Empty;
            btnOpenAddPatient.Size = new Size(161, 36);
            btnOpenAddPatient.TabIndex = 1;
            btnOpenAddPatient.Text = "Add Patient";
            btnOpenAddPatient.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnOpenAddPatient.UseAccentColor = false;
            btnOpenAddPatient.UseVisualStyleBackColor = true;
            btnOpenAddPatient.Click += btnOpenAddPatient_Click;
            // 
            // viewAllDoctorsPatientButton
            // 
            viewAllDoctorsPatientButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            viewAllDoctorsPatientButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            viewAllDoctorsPatientButton.Depth = 0;
            viewAllDoctorsPatientButton.HighEmphasis = true;
            viewAllDoctorsPatientButton.Icon = null;
            viewAllDoctorsPatientButton.Location = new Point(235, 241);
            viewAllDoctorsPatientButton.Margin = new Padding(4, 6, 4, 6);
            viewAllDoctorsPatientButton.MouseState = MaterialSkin.MouseState.HOVER;
            viewAllDoctorsPatientButton.Name = "viewAllDoctorsPatientButton";
            viewAllDoctorsPatientButton.NoAccentTextColor = Color.Empty;
            viewAllDoctorsPatientButton.Size = new Size(254, 36);
            viewAllDoctorsPatientButton.TabIndex = 4;
            viewAllDoctorsPatientButton.Text = "Show patient doctor";
            viewAllDoctorsPatientButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            viewAllDoctorsPatientButton.UseAccentColor = false;
            viewAllDoctorsPatientButton.UseVisualStyleBackColor = true;
            // 
            // viewAllPatientDoctorsButton
            // 
            viewAllPatientDoctorsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            viewAllPatientDoctorsButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            viewAllPatientDoctorsButton.Depth = 0;
            viewAllPatientDoctorsButton.HighEmphasis = true;
            viewAllPatientDoctorsButton.Icon = null;
            viewAllPatientDoctorsButton.Location = new Point(539, 241);
            viewAllPatientDoctorsButton.Margin = new Padding(4, 6, 4, 6);
            viewAllPatientDoctorsButton.MouseState = MaterialSkin.MouseState.HOVER;
            viewAllPatientDoctorsButton.Name = "viewAllPatientDoctorsButton";
            viewAllPatientDoctorsButton.NoAccentTextColor = Color.Empty;
            viewAllPatientDoctorsButton.Size = new Size(254, 36);
            viewAllPatientDoctorsButton.TabIndex = 5;
            viewAllPatientDoctorsButton.Text = "show doctor`s patient";
            viewAllPatientDoctorsButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            viewAllPatientDoctorsButton.UseAccentColor = false;
            viewAllPatientDoctorsButton.UseVisualStyleBackColor = true;
            // 
            // ResetLists
            // 
            ResetLists.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ResetLists.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ResetLists.Depth = 0;
            ResetLists.HighEmphasis = true;
            ResetLists.Icon = null;
            ResetLists.Location = new Point(584, 335);
            ResetLists.Margin = new Padding(4, 6, 4, 6);
            ResetLists.MouseState = MaterialSkin.MouseState.HOVER;
            ResetLists.Name = "ResetLists";
            ResetLists.NoAccentTextColor = Color.Empty;
            ResetLists.Size = new Size(158, 36);
            ResetLists.TabIndex = 6;
            ResetLists.Text = "unload filters";
            ResetLists.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ResetLists.UseAccentColor = false;
            ResetLists.UseVisualStyleBackColor = true;
            // 
            // PatientList
            // 
            PatientList.AutoSizeTable = false;
            PatientList.BackColor = Color.FromArgb(255, 255, 255);
            PatientList.BorderStyle = BorderStyle.None;
            PatientList.Depth = 0;
            PatientList.FullRowSelect = true;
            PatientList.Location = new Point(533, 95);
            PatientList.MinimumSize = new Size(200, 100);
            PatientList.MouseLocation = new Point(-1, -1);
            PatientList.MouseState = MaterialSkin.MouseState.OUT;
            PatientList.Name = "PatientList";
            PatientList.OwnerDraw = true;
            PatientList.Size = new Size(250, 125);
            PatientList.TabIndex = 3;
            PatientList.UseCompatibleStateImageBehavior = false;
            PatientList.View = View.Details;
            // 
            // DoctorList
            // 
            DoctorList.AutoSizeTable = false;
            DoctorList.BackColor = Color.FromArgb(255, 255, 255);
            DoctorList.BorderStyle = BorderStyle.None;
            DoctorList.Depth = 0;
            DoctorList.FullRowSelect = true;
            DoctorList.Location = new Point(239, 95);
            DoctorList.MinimumSize = new Size(200, 100);
            DoctorList.MouseLocation = new Point(-1, -1);
            DoctorList.MouseState = MaterialSkin.MouseState.OUT;
            DoctorList.Name = "DoctorList";
            DoctorList.OwnerDraw = true;
            DoctorList.Size = new Size(250, 125);
            DoctorList.TabIndex = 2;
            DoctorList.UseCompatibleStateImageBehavior = false;
            DoctorList.View = View.Details;
            // 
            // ConnectButton
            // 
            ConnectButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ConnectButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ConnectButton.Depth = 0;
            ConnectButton.HighEmphasis = true;
            ConnectButton.Icon = null;
            ConnectButton.Location = new Point(443, 335);
            ConnectButton.Margin = new Padding(4, 6, 4, 6);
            ConnectButton.MouseState = MaterialSkin.MouseState.HOVER;
            ConnectButton.Name = "ConnectButton";
            ConnectButton.NoAccentTextColor = Color.Empty;
            ConnectButton.Size = new Size(103, 36);
            ConnectButton.TabIndex = 7;
            ConnectButton.Text = "Connect";
            ConnectButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ConnectButton.UseAccentColor = false;
            ConnectButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            DeleteButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DeleteButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            DeleteButton.Depth = 0;
            DeleteButton.HighEmphasis = true;
            DeleteButton.Icon = null;
            DeleteButton.Location = new Point(264, 335);
            DeleteButton.Margin = new Padding(4, 6, 4, 6);
            DeleteButton.MouseState = MaterialSkin.MouseState.HOVER;
            DeleteButton.Name = "DeleteButton";
            DeleteButton.NoAccentTextColor = Color.Empty;
            DeleteButton.Size = new Size(158, 36);
            DeleteButton.TabIndex = 8;
            DeleteButton.Text = "Delete";
            DeleteButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            DeleteButton.UseAccentColor = false;
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DeleteButton);
            Controls.Add(ConnectButton);
            Controls.Add(ResetLists);
            Controls.Add(viewAllPatientDoctorsButton);
            Controls.Add(viewAllDoctorsPatientButton);
            Controls.Add(PatientList);
            Controls.Add(DoctorList);
            Controls.Add(btnOpenAddPatient);
            Controls.Add(btnOpenAddDoctor);
            Name = "MainPage";
            Text = "MainPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnOpenAddDoctor;
        private MaterialSkin.Controls.MaterialButton btnOpenAddPatient;
        private MaterialSkin.Controls.MaterialButton viewAllDoctorsPatientButton;
        private MaterialSkin.Controls.MaterialButton viewAllPatientDoctorsButton;
        private MaterialSkin.Controls.MaterialButton ResetLists;
        private MaterialSkin.Controls.MaterialListView PatientList;
        private MaterialSkin.Controls.MaterialListView DoctorList;
        private MaterialSkin.Controls.MaterialButton ConnectButton;
        private MaterialSkin.Controls.MaterialButton DeleteButton;
    }
}

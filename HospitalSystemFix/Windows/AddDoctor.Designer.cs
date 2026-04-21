namespace HospitalSystemFix.Windows
{
    partial class AddDoctor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFullName = new MaterialSkin.Controls.MaterialTextBox();
            btnAddDoctor = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.AnimateReadOnly = false;
            txtFullName.BorderStyle = BorderStyle.None;
            txtFullName.Depth = 0;
            txtFullName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFullName.LeadingIcon = null;
            txtFullName.Location = new Point(46, 79);
            txtFullName.MaxLength = 50;
            txtFullName.MouseState = MaterialSkin.MouseState.OUT;
            txtFullName.Multiline = false;
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(106, 50);
            txtFullName.TabIndex = 0;
            txtFullName.Text = "";
            txtFullName.TrailingIcon = null;
            // 
            // btnAddDoctor
            // 
            btnAddDoctor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddDoctor.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddDoctor.Depth = 0;
            btnAddDoctor.HighEmphasis = true;
            btnAddDoctor.Icon = null;
            btnAddDoctor.Location = new Point(24, 152);
            btnAddDoctor.Margin = new Padding(4, 6, 4, 6);
            btnAddDoctor.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddDoctor.Name = "btnAddDoctor";
            btnAddDoctor.NoAccentTextColor = Color.Empty;
            btnAddDoctor.Size = new Size(158, 36);
            btnAddDoctor.TabIndex = 1;
            btnAddDoctor.Text = "Add Doctor";
            btnAddDoctor.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddDoctor.UseAccentColor = false;
            btnAddDoctor.UseVisualStyleBackColor = true;
            // 
            // AddDoctor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(207, 210);
            Controls.Add(btnAddDoctor);
            Controls.Add(txtFullName);
            Name = "AddDoctor";
            Text = "AddDoctor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txtFullName;
        private MaterialSkin.Controls.MaterialButton btnAddDoctor;
    }
}
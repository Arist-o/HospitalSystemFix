using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace HospitalSystemFix.Windows
{
    public class BaseAddForm<T> : MaterialForm where T : class
    {
        public T NewEntity { get; protected set; }
        
        protected TextBox txtFullName;
        protected Button btnSave;
        private readonly Func<string, T> _entityFactory;

        public BaseAddForm(Func<string, T> entityFactory)
        {
            _entityFactory = entityFactory;
        }

        protected void HandleSave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                new MaterialSnackBar("Error: Enter Full Name!", "OK", true).Show(this);
                return;
            }

            NewEntity = _entityFactory(txtFullName.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

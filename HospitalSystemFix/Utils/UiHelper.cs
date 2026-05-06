using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalSystemFix.Utils
{
    public static class UiHelper
    {
        public static void PopulateListView<T>(ListView listView, IEnumerable<T> items, System.Func<T, string> getSummary)
        {
            listView.Items.Clear();
            foreach (var item in items)
            {
                var lvItem = new ListViewItem(getSummary(item)) { Tag = item };
                listView.Items.Add(lvItem);
            }
        }

        public static void ClearControls<T>(Control.ControlCollection controls) where T : Control
        {
            foreach (Control control in controls)
            {
                if (control is T t)
                {
                    if (t is TextBox textBox) textBox.Clear();
                    if (t is ComboBox comboBox) comboBox.SelectedIndex = -1;
                }
                
                if (control.HasChildren)
                {
                    ClearControls<T>(control.Controls);
                }
            }
        }
    }
}

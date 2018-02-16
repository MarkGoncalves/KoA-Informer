using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CCVD.Core;

namespace KoA_Informer.Forms
{
    public class FormBase : Form
    {
        public IEnumerable<T> GetAll<T>(Control control)
            where T : Control
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(GetAll<T>)
                .Concat(controls)
                .Where(c => c.GetType() == typeof(T))
                .Select(a => (T)a);

        }

        public FormBase()
        {
            Load += (sender, args) =>
            {
                GetAll<ComboBox>(this)
                .ForEach(a =>
                    {
                        a.AutoCompleteMode = AutoCompleteMode.Suggest;
                        a.AutoCompleteSource = AutoCompleteSource.ListItems;
                    });
            };
        }
    }
}

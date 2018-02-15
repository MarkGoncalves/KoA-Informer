using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CCVD.Win.Design
{
    public interface ICCVDComponent
    {
        Label Label { get; set; }
    }
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultBindingProperty("Text")]
    [DefaultEvent("SelectedIndexChanged")]
    [DefaultProperty("Items")]
    [Designer("System.Windows.Forms.Design.ComboBoxDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class CCVDComboBox : ComboBox, ICCVDComponent
    {
        private Label _label;
        [Category("Label")]
        public Label Label
        {
            get => _label;
            set
            {
                _label = value;
                AlinhaLabel();
            }
        }

        private void AlinhaLabel()
        {
            if (Label != null)
                if (Location.X > 3 && Location.Y > 16)
                    Label.Location = new Point(Location.X - 3, Location.Y - 16);
        }

        private Color backColor;
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!Enabled) return;
            backColor = BackColor;
            BackColor = Color.LightYellow;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (!Enabled) return;
            BackColor = backColor;
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e); ;
            AlinhaLabel();
        }
    }
}
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CCVD.Win.Design;

namespace CCVD.Design
{
    [DisplayName("Text Input")]
    [Description("Controle para qualquer texto.")]
    [ToolboxItem(true)]
    public class CCVDTextInput : TextBox, ICCVDComponent
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
            if (Label == null) return;
            if (Location.X > 3 && Location.Y > 16)
                Label.Location = new Point(Location.X - 3, Location.Y - 16);
        }

        private Color backColor;
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (ReadOnly) return;
            backColor = BackColor;
            BackColor = Color.LightYellow;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (ReadOnly) return;
            BackColor = backColor;
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            AlinhaLabel();
        }
    }
}

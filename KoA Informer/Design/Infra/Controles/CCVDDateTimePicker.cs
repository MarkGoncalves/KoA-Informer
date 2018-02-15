using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCVD.Win.Design
{
    [DisplayName("DateTime Input")]
    [Description("Controle para qualquer texto.")]
    [ToolboxItem(true)]
    public class CCVDDateTimePicker : DateTimePicker, ICCVDComponent
    {
        private bool _setOriginal = false;
        private Color _backColor;
        private string _customFormat;
        private DateTime? _valor;
        private DateTimePickerFormat _format;

        public CCVDDateTimePicker()
        {
            Format = DateTimePickerFormat.Short;
            CustomFormat = string.Empty;
        }

        [Category("Label")]
        public Label Label { get; set; }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            //if (ReadOnly) return;
            _backColor = BackColor;
            BackColor = Color.LightYellow;
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
            _valor = base.Value;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            //if (ReadOnly) return;
            BackColor = _backColor;
        }

        [Bindable(true)]
        [RefreshProperties(RefreshProperties.All)]
        public new DateTime? Value
        {
            get => _valor == null ? null : (DateTime?)base.Value;
            set
            {
                if (DesignMode && value != null)
                {
                    base.Value = value.Value;
                    return;
                }

                if (DesignMode) return;

                _valor = value;
                if (value == null)
                {
                    if (!_setOriginal)
                    {
                        _format = Format;
                        _customFormat = CustomFormat;
                        _setOriginal = true;

                    }
                    Format = DateTimePickerFormat.Custom;
                    CustomFormat = @" ";
                }
                else
                {
                    if (_format != 0)
                        Format = _format;
                    CustomFormat = _customFormat;
                    base.Value = value.Value;
                }
            }
        }
    }
}
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using CCVD.Core;
using CCVD.Design;

namespace CCVD.Win.Design
{
    public class CCVDDocumentoInputBox : CCVDTextInput
    {
        [TypeConverter(typeof(TipoDocumento)), Category("Validação")]
        public TipoDocumento TipoCampo { get; set; } = TipoDocumento.CPFCNPJ;

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            if (Text.OnlyNumbers().Length <= 0) return;

            switch (TipoCampo)
            {
                case TipoDocumento.CPFCNPJ:
                    if (Text.OnlyNumbers().Length == 11)
                    {
                        if (!Text.ValidarCPF())
                        {
                            MessageBox.Show(@"CPF Inválido!!");
                            Focus();
                        }
                    }
                    else if (Text.OnlyNumbers().Length == 14)
                    {
                        if (!Text.ValidarCNPJ())
                        {
                            MessageBox.Show(@"CNPJ Inválido!!");
                            Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Documento Inválido!!");
                        Focus();
                    }
                    break;
                case TipoDocumento.PIS:
                    if (!Text.ValidarPIS())
                    {
                        MessageBox.Show(@"PIS Inválido!!");
                        Focus();
                    }
                    break;
                default:
                    break;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            try
            {
                if (Text.OnlyNumbers().Length > 0)
                {
                    switch (TipoCampo)
                    {
                        case TipoDocumento.CPFCNPJ:
                            Text = Text.OnlyNumbers().Length <= 11 ? Text.FormataCPF() : Text.FormataCNPJ();
                            break;
                        case TipoDocumento.PIS:
                            break;
                    }
                }

                SelectionStart = Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Valores com problemas.");
            }

        }

        // Restricts the entry of characters to digits (including hex), the negative sign,
        // the decimal point, and editing keystrokes (backspace).
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            var numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            var decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            var groupSeparator = numberFormatInfo.NumberGroupSeparator;
            var negativeSign = numberFormatInfo.NegativeSign;

            var keyInput = e.KeyChar.ToString();

            if (char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            else if (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
                     keyInput.Equals(negativeSign))
            {
                // Decimal separator is OK
            }
            else if (e.KeyChar == '\b')
            {
                // Backspace key is OK
            }
            //    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
            //    {
            //     // Let the edit control handle control and alt key combinations
            //    }
            else if (AllowSpace && e.KeyChar == ' ')
            {

            }
            else
            {
                // Consume this invalid key and beep
                e.Handled = true;
                //    MessageBeep();
            }
        }

        [Browsable(false)]
        public int IntValue => (Text.Length > 0) ? int.Parse(Text) : 0;

        [Browsable(false)]
        public decimal DecimalValue => (Text.Length > 0) ? decimal.Parse(Text) : 0;

        public bool AllowSpace { set; get; }
    }
}
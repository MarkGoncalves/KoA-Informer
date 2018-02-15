using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using CCVD.Core;
using CCVD.Design;

namespace CCVD.Win.Design
{
    [DefaultBindingProperty("Value")]
    public class CCVDNumeroInput : CCVDTextInput
    {
        [TypeConverter(typeof(Tipo)), Category("Validação")]
        public class Tipo : StringConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                return new StandardValuesCollection(new[] { "DECIMAL", "INTEIRO", "MOEDA" });
            }
        }

        [Category("Validação")]
        public int CasasDecimais { get; set; } = 2;
        [TypeConverter(typeof(TipoNumero)), Category("Validação")]
        public TipoNumero TipoCampo { get; set; } = TipoNumero.Inteiro;
        public bool AllowSpace { set; get; }

        [Category("Validação")]
        public object Value
        {
            get => Text;
            set => Text = FormatText(value?.ToString() ?? string.Empty, CasasDecimais, true);
        }

        public CCVDNumeroInput()
        {
            TextAlign = HorizontalAlignment.Right;
        }

        public int AsInteger
        {
            get
            {
                if (decimal.TryParse(Text, NumberStyles.Any, Application.CurrentCulture, out decimal valor))
                {
                    return (int)Math.Truncate(valor);
                }

                return 0;
            }
        }

        public decimal AsDecimal => decimal.TryParse(Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal valor) ? valor : 0;

        private readonly string _decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        private string FormatText(string texto, int decimais, bool ignorarVirgula = false)
        {
            while (true)
            {
                switch (TipoCampo)
                {
                    case TipoNumero.Decimal:
                        if (texto.Length != 0)
                        {
                            var negativo = texto.Contains("-") ? "-" : "0";

                            if (ignorarVirgula || texto.Contains(_decimalSeparator))
                            {
                                var quebrado = texto.Split(_decimalSeparator[0]);

                                if (ignorarVirgula && quebrado.Length <= 1)
                                    return $@"{decimal.Parse($"{negativo}{quebrado[0].OnlyNumbers()}").ToString($"N{decimais}", CultureInfo.CurrentCulture)}";
                                    //return $@"{decimal.Parse($"{quebrado[0]}").ToString($"N{decimais}", CultureInfo.CurrentCulture)}";

                                var valor = decimal.Parse($"{negativo}{quebrado[0].OnlyNumbers()}{_decimalSeparator}{quebrado[1]}");
                                //var valor = decimal.Parse($"{quebrado[0]}{_decimalSeparator}{quebrado[1]}");
                                var virgula = quebrado[1].Length == 0 ? _decimalSeparator : "";
                                return $@"{valor.ToString($"N{decimais}", CultureInfo.CurrentCulture)}{virgula}";
                            }
                            else
                            {
                                var valor = decimal.Parse(texto.OnlyNumbers());
                                return valor.ToString("N0", CultureInfo.CurrentCulture);
                            }
                        }
                        break;
                    case TipoNumero.Inteiro:
                        if (texto.Length != 0)
                        {
                            var negativo = texto.Contains("-") ? "-" : "0";
                            var valor = int.Parse($"{negativo}{texto.OnlyNumbers()}");
                            //var valor = int.Parse(texto);
                            return valor.ToString("N0", CultureInfo.CurrentCulture);
                        }
                        break;
                    case TipoNumero.Moeda:
                        if (texto.Length != 0)
                        {
                            var negativo = texto.Contains("-") ? "-" : "0";

                            if (ignorarVirgula || texto.Contains(_decimalSeparator))
                            {
                                var quebrado = texto.Split(_decimalSeparator[0]);

                                if (ignorarVirgula && quebrado.Length <= 1)
                                    return $@"{decimal.Parse($"{negativo}{quebrado[0].OnlyNumbers()}").ToString($"C{decimais}", CultureInfo.CurrentCulture)}";
                                    //return $@"{decimal.Parse($"{quebrado[0]}").ToString($"C{decimais}", CultureInfo.CurrentCulture)}";

                                var valor = decimal.Parse($"{negativo}{quebrado[0].OnlyNumbers()}{_decimalSeparator}{quebrado[1]}");
                                //var valor = decimal.Parse($"{quebrado[0]}{_decimalSeparator}{quebrado[1]}");
                                var virgula = (quebrado[1].Length == 0) ? _decimalSeparator : "";
                                return $@"{valor.ToString($"C{decimais}", CultureInfo.CurrentCulture)}{virgula}";
                            }
                            else
                            {
                                var valor = decimal.Parse(texto.OnlyNumbers());
                                //var valor = decimal.Parse(texto);
                                return valor.ToString("C0", CultureInfo.CurrentCulture);
                            }
                        }
                        break;
                    default:
                        return string.Empty;
                }
                texto = "0";
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            Text = FormatText(Text, CasasDecimais, true);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            try
            {
                if (Text.OnlyNumbers().Length > 0)
                {
                    Text = FormatText(Text, Text.Contains(_decimalSeparator) ? Text.Split(_decimalSeparator[0])[1].Length : 0);
                }

                SelectionStart = Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Valores moedas com problemas.");
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            var numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            var groupSeparator = numberFormatInfo.NumberGroupSeparator;
            var negativeSign = numberFormatInfo.NegativeSign;

            var keyInput = e.KeyChar.ToString();

            if (e.KeyChar == '\b')
            {
                // Backspace key is OK
            }
            else if (char.IsDigit(e.KeyChar) && !ValidaQuantidadeDigitos())
            {
                e.Handled = SelectionLength == 0;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            else if (keyInput.Equals(_decimalSeparator) || keyInput.Equals(groupSeparator) ||
                     keyInput.Equals(negativeSign))
            {
                // Decimal separator is OK
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
                e.Handled = true;
            }
            //*/
        }

        private bool ValidaQuantidadeDigitos()
        {
            if (!Text.Contains(_decimalSeparator)) return true;
            var quebrado = Text.Split(_decimalSeparator[0]);
            return TipoCampo == TipoNumero.Inteiro || quebrado[1].Length < CasasDecimais;
        }

    }
}
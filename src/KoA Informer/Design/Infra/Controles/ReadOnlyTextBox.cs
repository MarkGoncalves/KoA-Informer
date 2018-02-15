using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCVD.Win.Design
{
    internal partial class ReadOnlyTextBox : Control
    {
        readonly StringFormat _format;
        public ReadOnlyTextBox()
        {            
            InitializeComponent();

            _format = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces)
            {
                LineAlignment = StringAlignment.Center
            };

            Height = 10;
            Width = 10;

            Padding = new Padding(2);            
        }

        public ReadOnlyTextBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            TextChanged += ReadOnlyTextBox_TextChanged;
        }

        private void ReadOnlyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FormatString) && !string.IsNullOrEmpty(Text))
            {
                Text = string.Format(FormatString, Text);
            }
        }

        public bool IsSummary { get; set; }

        public bool IsLastColumn { get; set; }

        public string FormatString { get; set; }


        private HorizontalAlignment _textAlign = HorizontalAlignment.Left;
        [DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment TextAlign
        {
            get => _textAlign;
            set 
            {
                _textAlign = value;
                SetFormatFlags();
            }
        }

        private StringTrimming _trimming = StringTrimming.None;
        [DefaultValue(StringTrimming.None)]
        public StringTrimming Trimming
        {
            get => _trimming;
            set
            {
                _trimming = value;
                SetFormatFlags();
            }
        }

        private void SetFormatFlags()
        {
            _format.Alignment = TextHelper.TranslateAligment(TextAlign);
            _format.Trimming = _trimming;                
        }

        public Color BorderColor { get; set; } = Color.Black;

        protected override void OnPaint(PaintEventArgs e)
        {
            var subWidth = 0;

            if (!string.IsNullOrEmpty(FormatString) && !string.IsNullOrEmpty(Text))
            {
                Text = string.Format("{0:" + FormatString + "}", Convert.ToDecimal(Text));
            }

            var textBounds = new Rectangle(ClientRectangle.X + 2, ClientRectangle.Y + 2, ClientRectangle.Width - 2 , ClientRectangle.Height - 2 );
            using(var pen = new Pen(BorderColor))
            {
                if (IsLastColumn)
                    subWidth = 1;

                e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
                e.Graphics.DrawRectangle(pen, ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - subWidth , ClientRectangle.Height - 1);             
                e.Graphics.DrawString(Text, Font, Brushes.Black, textBounds , _format );
            }
        }
    }
}



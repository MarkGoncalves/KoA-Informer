using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCVD.Win.Design
{
    public partial class AguardeBox : UserControl
    {
        public AguardeBox()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                BackColor = Color.Transparent;
                Visible = false;
            }
        }

        public override string Text
        {
            get => label1.Text;
            set
            {
                label1.Text = value;
            }
        }

        private void AlinharTela(Control controle)
        {
            controle.Resize += (sender, args) =>
            {
                AlinharTela(controle);
            };

            Parent = controle;
            var centroHorizontal =
                controle.Parent != null
                ? controle.Left + (controle.Width / 2)
                : (controle.Width / 2);
            var centroVertical =
                controle.Parent != null
                ? controle.Top + (controle.Height / 2)
                : (controle.Height / 2);

            Left = centroHorizontal - (Width / 2);
            Top = centroVertical - (Height / 2);
            BringToFront();
        }

        public void Run(Control controle, Action<Action<string>> acao)
        {
            try
            {
                AlinharTela(controle);
                Visible = true;
                Refresh();

                acao.Invoke(str => { Text = str; });
            }
            finally
            {
                Visible = false;
            }
        }

        public void Run(Control controle, Action acao)
        {
            try
            {
                AlinharTela(controle);
                Visible = true;
                Refresh();

                acao.Invoke();
            }
            finally
            {
                Visible = false;
            }
        }

        public async Task RunAsync(Control controle, Func<Task> acao)
        {
            try
            {
                AlinharTela(controle);
                Visible = true;

                await acao.Invoke(); //.ContinueWith(a => a);

            }
            catch (Exception)
            {

            }
            finally
            {
                Visible = false;
            }
        }
    }
}

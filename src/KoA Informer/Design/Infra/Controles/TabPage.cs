using System.ComponentModel;
using System.Windows.Forms;

namespace CCVD.Design
{
    /// <summary>
    ///     Summary description for TabPage.
    /// </summary>
    public class TabPageEx : TabPage
    {
        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private Container _components;

        public TabPageEx(IContainer container)
        {
            //
            // Required for Windows.Forms Class Composition Designer support
            //
            container.Add(this);
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public TabPageEx()
        {
            //
            // Required for Windows.Forms Class Composition Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _components?.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _components = new Container();
        }

        //public override string Text
        //{
        //    get { return base.Text + "   "; }
        //    set { base.Text = value; }
        //}

        public ContextMenu Menu { get; set; } = null;

        #endregion
    }
}
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CCVD.Design
{
    /// <summary>
    /// Summary description for UserControl1.
    /// </summary>
    public class TabControlEx : TabControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container _components;
        public delegate void OnHeaderCloseDelegate(object sender, CloseEventArgs e);
        public event OnHeaderCloseDelegate OnClose;
        public TabControlEx()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            TabStop = false;
            SizeMode = TabSizeMode.Fixed;
            // TODO: Add any initialization after the InitComponent call

        }

        public bool ConfirmOnClose { get; set; } = true;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _components?.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _components = new System.ComponentModel.Container();
            SetStyle(ControlStyles.DoubleBuffer, true);
            TabStop = false;
            DrawMode = TabDrawMode.OwnerDrawFixed;
            Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            ItemSize = new Size(230, 24);
            //this.Controls.Add(this.btnClose); 
        }
        #endregion
        //private Stream GetContentFromResource(string filename)
        //{
        //   Assembly asm = Assembly.GetExecutingAssembly();
        //   Stream stream =  asm.GetManifestResourceStream("MyControlLibrary."+filename); 
        //   return stream;

        //}

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Bounds == RectangleF.Empty) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            for (var nIndex = 0; nIndex < TabCount; nIndex++)
            {
                RectangleF tabTextArea;
                if (nIndex != SelectedIndex)
                {
                    tabTextArea = GetTabRect(nIndex);
                    var path = new GraphicsPath();
                    path.AddRectangle(tabTextArea);
                    using (var brush = new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight, LinearGradientMode.Vertical))
                    {
                        var colorBlend = new ColorBlend(3)
                        {
                            Colors = new[]
                            {
                                SystemColors.ControlLightLight,
                                Color.FromArgb(255, SystemColors.ControlLight), SystemColors.ControlDark,
                                SystemColors.ControlLightLight
                            },
                            Positions = new[] { 0f, .4f, 0.5f, 1f }
                        };

                        brush.InterpolationColors = colorBlend;

                        e.Graphics.FillPath(brush, path);
                        using (var pen = new Pen(SystemColors.ActiveBorder))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }


                        colorBlend.Colors = new[]{  SystemColors.ActiveBorder,
                            SystemColors.ActiveBorder,SystemColors.ActiveBorder,
                            SystemColors.ActiveBorder};

                        colorBlend.Positions = new[] { 0f, .4f, 0.5f, 1f };
                        brush.InterpolationColors = colorBlend;
                        e.Graphics.FillRectangle(brush, tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                        e.Graphics.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 20, 6, tabTextArea.Height - 8, tabTextArea.Height - 9);
                        using (var pen = new Pen(Color.White, 2))
                        {
                            e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 9, tabTextArea.X + tabTextArea.Width - 7, 17);
                            e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 17, tabTextArea.X + tabTextArea.Width - 7, 9);
                        }
                        if (CanDrawMenuButton(nIndex))
                        {
                            colorBlend.Positions = new[] { 0f, .4f, 0.5f, 1f };
                            brush.InterpolationColors = colorBlend;
                            colorBlend.Positions = new[] { 0f, .4f, 0.5f, 1f };
                            // assign the color blend to the pathgradientbrush
                            brush.InterpolationColors = colorBlend;

                            e.Graphics.FillRectangle(brush, tabTextArea.X + tabTextArea.Width - 43, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                            // e.Graphics.DrawRectangle(SystemPens.GradientInactiveCaption, tabTextArea.X + tabTextArea.Width - 37, 7, 13, 13);
                            e.Graphics.DrawRectangle(new Pen(Color.White), tabTextArea.X + tabTextArea.Width - 41, 6, tabTextArea.Height - 7, tabTextArea.Height - 9);
                            using (var pen = new Pen(Color.White, 2))
                            {
                                e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 36, 11, tabTextArea.X + tabTextArea.Width - 33, 16);
                                e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 33, 16, tabTextArea.X + tabTextArea.Width - 30, 11);
                            }
                        }
                    }
                    path.Dispose();

                }
                else
                {

                    tabTextArea = GetTabRect(nIndex);
                    var path = new GraphicsPath();
                    path.AddRectangle(tabTextArea);
                    using (var brush = new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight, LinearGradientMode.Vertical))
                    {
                        var colorBlend = new ColorBlend(3)
                        {
                            Colors = new[]
                            {
                                SystemColors.ControlLightLight,
                                Color.FromArgb(255, SystemColors.Control), SystemColors.ControlLight,
                                SystemColors.Control
                            },
                            Positions = new[] { 0f, .4f, 0.5f, 1f }
                        };
                        brush.InterpolationColors = colorBlend;
                        e.Graphics.FillPath(brush, path);
                        using (var pen = new Pen(SystemColors.ActiveBorder))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }
                        //Drawing Close Button
                        colorBlend.Colors = new[]{Color.FromArgb(255,231,164,152),
                            Color.FromArgb(255,231,164,152),Color.FromArgb(255,197,98,79),
                            Color.FromArgb(255,197,98,79)};
                        brush.InterpolationColors = colorBlend;
                        e.Graphics.FillRectangle(brush, tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                        e.Graphics.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 20, 6, tabTextArea.Height - 8, tabTextArea.Height - 9);
                        using (var pen = new Pen(Color.White, 2))
                        {
                            e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 9, tabTextArea.X + tabTextArea.Width - 7, 17);
                            e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 17, tabTextArea.X + tabTextArea.Width - 7, 9);
                        }
                        if (CanDrawMenuButton(nIndex))
                        {
                            //Drawing menu button
                            colorBlend.Colors = new[]{SystemColors.ControlLightLight,
                                Color.FromArgb(255,SystemColors.ControlLight),SystemColors.ControlDark,
                                SystemColors.ControlLightLight};
                            colorBlend.Positions = new[] { 0f, .4f, 0.5f, 1f };
                            brush.InterpolationColors = colorBlend;
                            colorBlend.Colors = new[]{Color.FromArgb(255,170,213,243),
                                Color.FromArgb(255,170,213,243),Color.FromArgb(255,44,137,191),
                                Color.FromArgb(255,44,137,191)};
                            brush.InterpolationColors = colorBlend;
                            e.Graphics.FillRectangle(brush, tabTextArea.X + tabTextArea.Width - 43, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                            e.Graphics.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 41, 6, tabTextArea.Height - 7, tabTextArea.Height - 9);
                            using (var pen = new Pen(Color.White, 2))
                            {
                                e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 36, 11, tabTextArea.X + tabTextArea.Width - 33, 16);
                                e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 33, 16, tabTextArea.X + tabTextArea.Width - 30, 11);
                            }
                        }
                    }
                    path.Dispose();
                }
                var str = TabPages[nIndex].Text;
                var stringFormat = new StringFormat { Alignment = StringAlignment.Center };
                e.Graphics.DrawString(str, Font, new SolidBrush(TabPages[nIndex].ForeColor), tabTextArea, stringFormat);


            }
        }

        private bool CanDrawMenuButton(int nIndex)
        {
            return (TabPages[nIndex] as TabPageEx)?.Menu != null;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            var g = CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            for (var nIndex = 0; nIndex < TabCount; nIndex++)
            {
                RectangleF tabTextArea;
                if (nIndex != SelectedIndex)
                {
                    tabTextArea = GetTabRect(nIndex);
                    var path = new GraphicsPath();
                    path.AddRectangle(tabTextArea);
                    using (var brush = new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight, LinearGradientMode.Vertical))
                    {
                        var colorBlend = new ColorBlend(3)
                        {
                            Colors = new[]
                            {
                                SystemColors.ActiveBorder,
                                SystemColors.ActiveBorder, SystemColors.ActiveBorder,
                                SystemColors.ActiveBorder
                            },
                            Positions = new[] { 0f, .4f, 0.5f, 1f }
                        };


                        brush.InterpolationColors = colorBlend;
                        g.FillRectangle(brush, tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 2, tabTextArea.Height - 5);
                        g.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 20, 6, tabTextArea.Height - 8, tabTextArea.Height - 9);
                        using (var pen = new Pen(Color.White, 2))
                        {
                            g.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 9, tabTextArea.X + tabTextArea.Width - 7, 17);
                            g.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 17, tabTextArea.X + tabTextArea.Width - 7, 9);
                        }
                        if (CanDrawMenuButton(nIndex))
                        {
                            colorBlend.Positions = new[] { 0f, .4f, 0.5f, 1f };
                            // assign the color blend to the pathgradientbrush
                            brush.InterpolationColors = colorBlend;

                            g.FillRectangle(brush, tabTextArea.X + tabTextArea.Width - 43, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                            // e.Graphics.DrawRectangle(SystemPens.GradientInactiveCaption, tabTextArea.X + tabTextArea.Width - 37, 7, 13, 13);
                            g.DrawRectangle(new Pen(Color.White), tabTextArea.X + tabTextArea.Width - 41, 6, tabTextArea.Height - 7, tabTextArea.Height - 9);
                            using (var pen = new Pen(Color.White, 2))
                            {
                                g.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 36, 11, tabTextArea.X + tabTextArea.Width - 33, 16);
                                g.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 33, 16, tabTextArea.X + tabTextArea.Width - 30, 11);
                            }
                        }
                    }
                    path.Dispose();

                }
                else
                {

                    tabTextArea = GetTabRect(nIndex);
                    var path = new GraphicsPath();
                    path.AddRectangle(tabTextArea);
                    using (var brush = new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight, LinearGradientMode.Vertical))
                    {
                        var colorBlend = new ColorBlend(3)
                        {
                            Positions = new[] { 0f, .4f, 0.5f, 1f },
                            Colors = new[]
                            {
                                Color.FromArgb(255, 231, 164, 152),
                                Color.FromArgb(255, 231, 164, 152), Color.FromArgb(255, 197, 98, 79),
                                Color.FromArgb(255, 197, 98, 79)
                            }
                        };

                        brush.InterpolationColors = colorBlend;
                        g.FillRectangle(brush, tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                        g.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 20, 6, tabTextArea.Height - 8, tabTextArea.Height - 9);
                        using (var pen = new Pen(Color.White, 2))
                        {
                            g.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 9, tabTextArea.X + tabTextArea.Width - 7, 17);
                            g.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 17, tabTextArea.X + tabTextArea.Width - 7, 9);
                        }
                        if (CanDrawMenuButton(nIndex))
                        {
                            //Drawing menu button
                            colorBlend.Colors = new[]{SystemColors.ControlLightLight,
                                                     Color.FromArgb(255,SystemColors.ControlLight),SystemColors.ControlDark,
                                                     SystemColors.ControlLightLight};
                            colorBlend.Positions = new[] { 0f, .4f, 0.5f, 1f };
                            brush.InterpolationColors = colorBlend;
                            colorBlend.Colors = new[]{Color.FromArgb(255,170,213,243),
                                                      Color.FromArgb(255,170,213,243),Color.FromArgb(255,44,137,191),
                                                      Color.FromArgb(255,44,137,191)};
                            brush.InterpolationColors = colorBlend;
                            g.FillRectangle(brush, tabTextArea.X + tabTextArea.Width - 43, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                            g.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 41, 6, tabTextArea.Height - 7, tabTextArea.Height - 9);
                            using (var pen = new Pen(Color.White, 2))
                            {
                                g.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 36, 11, tabTextArea.X + tabTextArea.Width - 33, 16);
                                g.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 33, 16, tabTextArea.X + tabTextArea.Width - 30, 11);
                            }
                        }
                    }
                    path.Dispose();
                }
            }

            g.Dispose();


        }

        protected override void OnMouseMove(MouseEventArgs e)
        {

            if (!DesignMode)
            {
                var g = CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                for (var nIndex = 0; nIndex < TabCount; nIndex++)
                {
                    var tabTextArea = (RectangleF)GetTabRect(nIndex);
                    tabTextArea =
                        new RectangleF(tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3,
                                       tabTextArea.Height - 5);

                    var pt = new Point(e.X, e.Y);
                    if (tabTextArea.Contains(pt))
                    {
                        using (
                            var brush =
                                new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight,
                                                        LinearGradientMode.Vertical))
                        {
                            var colorBlend = new ColorBlend(3)
                            {
                                Colors = new[]
                                {
                                    Color.FromArgb(255, 252, 193, 183),
                                    Color.FromArgb(255, 252, 193, 183), Color.FromArgb(255, 210, 35, 2),
                                    Color.FromArgb(255, 210, 35, 2)
                                },
                                Positions = new[] { 0f, .4f, 0.5f, 1f }
                            };
                            brush.InterpolationColors = colorBlend;

                            g.FillRectangle(brush, tabTextArea);
                            g.DrawRectangle(Pens.White, tabTextArea.X + 2, 6, tabTextArea.Height - 3,
                                            tabTextArea.Height - 4);
                            using (var pen = new Pen(Color.White, 2))
                            {
                                g.DrawLine(pen, tabTextArea.X + 6, 9, tabTextArea.X + 15, 17);
                                g.DrawLine(pen, tabTextArea.X + 6, 17, tabTextArea.X + 15, 9);
                            }
                        }
                    }
                    else
                    {
                        if (nIndex != SelectedIndex)
                        {
                            using (
                                var brush =
                                    new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight,
                                                            LinearGradientMode.Vertical))
                            {
                                var colorBlend = new ColorBlend(3)
                                {
                                    Colors = new[]
                                    {
                                        SystemColors.ActiveBorder,
                                        SystemColors.ActiveBorder, SystemColors.ActiveBorder,
                                        SystemColors.ActiveBorder
                                    },
                                    Positions = new[] { 0f, .4f, 0.5f, 1f }
                                };
                                brush.InterpolationColors = colorBlend;

                                g.FillRectangle(brush, tabTextArea);
                                g.DrawRectangle(Pens.White, tabTextArea.X + 2, 6, tabTextArea.Height - 3,
                                                tabTextArea.Height - 4);
                                using (var pen = new Pen(Color.White, 2))
                                {
                                    g.DrawLine(pen, tabTextArea.X + 6, 9, tabTextArea.X + 15, 17);
                                    g.DrawLine(pen, tabTextArea.X + 6, 17, tabTextArea.X + 15, 9);
                                }
                            }
                        }
                    }
                    if (CanDrawMenuButton(nIndex))
                    {
                        var tabMenuArea = (RectangleF)GetTabRect(nIndex);
                        tabMenuArea =
                            new RectangleF(tabMenuArea.X + tabMenuArea.Width - 43, 4, tabMenuArea.Height - 3,
                                           tabMenuArea.Height - 5);
                        pt = new Point(e.X, e.Y);
                        if (tabMenuArea.Contains(pt))
                        {
                            using (
                                var brush =
                                    new LinearGradientBrush(tabMenuArea, SystemColors.Control, SystemColors.ControlLight,
                                                            LinearGradientMode.Vertical))
                            {
                                var colorBlend = new ColorBlend(3)
                                {
                                    Colors = new[]
                                    {
                                        Color.FromArgb(255, 170, 213, 255),
                                        Color.FromArgb(255, 170, 213, 255), Color.FromArgb(255, 44, 157, 250),
                                        Color.FromArgb(255, 44, 157, 250)
                                    },
                                    Positions = new[] { 0f, .4f, 0.5f, 1f }
                                };
                                brush.InterpolationColors = colorBlend;

                                g.FillRectangle(brush, tabMenuArea);
                                g.DrawRectangle(Pens.White, tabMenuArea.X + 2, 6, tabMenuArea.Height - 2,
                                                tabMenuArea.Height - 4);
                                using (var pen = new Pen(Color.White, 2))
                                {
                                    g.DrawLine(pen, tabMenuArea.X + 7, 11, tabMenuArea.X + 10, 16);
                                    g.DrawLine(pen, tabMenuArea.X + 10, 16, tabMenuArea.X + 13, 11);
                                }
                            }
                        }
                        else
                        {
                            if (nIndex != SelectedIndex)
                            {
                                using (
                                    var brush =
                                        new LinearGradientBrush(tabMenuArea, SystemColors.Control,
                                                                SystemColors.ControlLight, LinearGradientMode.Vertical))
                                {
                                    var colorBlend = new ColorBlend(3)
                                    {
                                        Colors = new[]
                                        {
                                            SystemColors.ActiveBorder,
                                            SystemColors.ActiveBorder, SystemColors.ActiveBorder,
                                            SystemColors.ActiveBorder
                                        },
                                        Positions = new[] { 0f, .4f, 0.5f, 1f }
                                    };
                                    brush.InterpolationColors = colorBlend;

                                    g.FillRectangle(brush, tabMenuArea);
                                    g.DrawRectangle(Pens.White, tabMenuArea.X + 2, 6, tabMenuArea.Height - 2,
                                                    tabMenuArea.Height - 4);
                                    using (var pen = new Pen(Color.White, 2))
                                    {
                                        g.DrawLine(pen, tabMenuArea.X + 7, 11, tabMenuArea.X + 10, 16);
                                        g.DrawLine(pen, tabMenuArea.X + 10, 16, tabMenuArea.X + 13, 11);
                                    }
                                }
                            }
                        }
                    }

                }
                g.Dispose();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!DesignMode)
            {
                var tabTextArea = (RectangleF)GetTabRect(SelectedIndex);
                tabTextArea =
                    new RectangleF(tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3,
                        tabTextArea.Height - 5);
                var pt = new Point(e.X, e.Y);
                if (tabTextArea.Contains(pt))
                {
                    if (ConfirmOnClose)
                    {
                        if (
                            MessageBox.Show(
                                $@"Deseja fechar {TabPages[SelectedIndex].Text.TrimEnd()}?", @"Confirmar fechamento", MessageBoxButtons.YesNo) ==
                            DialogResult.No)
                            return;
                    }
                    //Fire Event to Client
                    OnClose?.Invoke(this, new CloseEventArgs(SelectedIndex));
                }
                if (!CanDrawMenuButton(SelectedIndex)) return;
                var tabMenuArea = (RectangleF)GetTabRect(SelectedIndex);
                tabMenuArea =
                    new RectangleF(tabMenuArea.X + tabMenuArea.Width - 43, 4, tabMenuArea.Height - 3,
                        tabMenuArea.Height - 5);
                pt = new Point(e.X, e.Y);
                if (!tabMenuArea.Contains(pt)) return;
                if (((TabPageEx)TabPages[SelectedIndex]).Menu != null)
                {
                    ((TabPageEx)TabPages[SelectedIndex]).Menu.Show(this,
                        new Point((int)tabMenuArea.X,
                            (int)
                            (tabMenuArea.Y +
                             tabMenuArea.Height)));
                }
            }
        }
    }

    public class CloseEventArgs : EventArgs
    {
        public CloseEventArgs(int nTabIndex)
        {
            TabIndex = nTabIndex;
        }
        /// <summary>
        /// Get/Set the tab index value where the close button is clicked
        /// </summary>
        public int TabIndex { get; set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CCVD.Design
{
    public class SummaryControlContainer : Control
    {

        #region Declare variables
        private readonly Hashtable _sumBoxHash;
        private readonly CCVDDataGridView _dgv;
        private readonly Label _sumRowHeaderLabel;


        public int InitialHeight { get; set; }

        public bool LastVisibleState { get; set; }

        public Color SummaryRowBackColor { get; set; }


        /// <summary>
        /// Event is raised when visibility changes and the
        /// lastVisibleState is not the new visible state
        /// </summary>
        public event EventHandler VisibilityChanged;

        #endregion

        #region Constructors

        public SummaryControlContainer(CCVDDataGridView dgv)
        {
            _dgv = dgv ?? throw new Exception("DataGridView is null!");

            _sumBoxHash = new Hashtable();
            _sumRowHeaderLabel = new Label();


            _dgv.CreateSummary += dgv_CreateSummary;
            _dgv.DataGridView.RowsAdded += dgv_RowsAdded;
            _dgv.DataGridView.RowsRemoved += dgv_RowsRemoved;
            _dgv.DataGridView.CellValueChanged += dgv_CellValueChanged;

            _dgv.Scroll += dgv_Scroll;
            _dgv.DataGridView.ColumnWidthChanged += dgv_ColumnWidthChanged;
            _dgv.DataGridView.RowHeadersWidthChanged += dgv_RowHeadersWidthChanged;
            VisibleChanged += SummaryControlContainer_VisibleChanged;

            _dgv.DataGridView.ColumnAdded += dgv_ColumnAdded;
            _dgv.DataGridView.ColumnRemoved += dgv_ColumnRemoved;
            _dgv.DataGridView.ColumnStateChanged += dgv_ColumnStateChanged;
            _dgv.DataGridView.ColumnDisplayIndexChanged += dgv_ColumnDisplayIndexChanged;

        }

        private void dgv_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //resizeSumBoxes();
            ReCreateSumBoxes();
        }

        private void dgv_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            ResizeSumBoxes();
        }

        private void dgv_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            ReCreateSumBoxes();
        }

        private void dgv_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            ReCreateSumBoxes();
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            var roTextBox = (ReadOnlyTextBox)_sumBoxHash[_dgv.Columns[e.ColumnIndex]];
            if (roTextBox == null) return;
            if (roTextBox.IsSummary)
                CalcSummaries();
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalcSummaries();
        }

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalcSummaries();
        }

        private void SummaryControlContainer_VisibleChanged(object sender, EventArgs e)
        {
            if (LastVisibleState != Visible)
            {
                OnVisiblityChanged(sender, e);
            }
        }

        protected void OnVisiblityChanged(object sender, EventArgs e)
        {
            VisibilityChanged?.Invoke(sender, e);

            LastVisibleState = Visible;
        }

        #endregion

        #region Events and delegates

        private void dgv_CreateSummary(object sender, EventArgs e)
        {
            ReCreateSumBoxes();
            CalcSummaries();
        }

        private void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            ResizeSumBoxes();
        }

        private void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            ResizeSumBoxes();
        }

        private void dgv_RowHeadersWidthChanged(object sender, EventArgs e)
        {
            ResizeSumBoxes();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeSumBoxes();
        }

        private void dgv_Resize(object sender, EventArgs e)
        {
            ResizeSumBoxes();
        }

        #endregion

        #region Functions

        /// <summary>
        /// Checks if passed object is of type of integer
        /// </summary>
        /// <param name="o">object</param>
        /// <returns>true/ false</returns>
        protected bool IsInteger(object o)
        {
            if (o is Int64)
                return true;
            if (o is Int32)
                return true;
            if (o is Int16)
                return true;
            return false;
        }

        /// <summary>
        /// Checks if passed object is of type of decimal/ double
        /// </summary>
        /// <param name="o">object</param>
        /// <returns>true/ false</returns>
        protected bool IsDecimal(object o)
        {
            switch (o)
            {
                case decimal _:
                    return true;
                case float _:
                    return true;
                case double _:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Enable manual refresh of the SummaryDataGridView
        /// </summary>
        internal void RefreshSummary()
        {
            CalcSummaries();
        }

        /// <summary>
        /// Calculate the Sums of the summary columns
        /// </summary>
        private void CalcSummaries()
        {
            foreach (ReadOnlyTextBox roTextBox in _sumBoxHash.Values)
            {
                if (!roTextBox.IsSummary) continue;
                roTextBox.Tag = 0;
                roTextBox.Text = "0";
                roTextBox.Invalidate();
            }

            if (_dgv.SummaryColumns == null || _dgv.SummaryColumns.Length <= 0 || _sumBoxHash.Count <= 0)
                return;

            foreach (DataGridViewRow dgvRow in _dgv.DataGridView.Rows)
            {
                foreach (DataGridViewCell dgvCell in dgvRow.Cells)
                {
                    foreach (DataGridViewColumn dgvColumn in _sumBoxHash.Keys)
                    {
                        if (!dgvCell.OwningColumn.Equals(dgvColumn)) continue;
                        var sumBox = (ReadOnlyTextBox)_sumBoxHash[dgvColumn];

                        if (sumBox == null || !sumBox.IsSummary) continue;
                        if (dgvCell.Value == null || dgvCell.Value is DBNull) continue;
                        if (IsInteger(dgvCell.Value))
                        {
                            sumBox.Tag = Convert.ToInt64(sumBox.Tag) + Convert.ToInt64(dgvCell.Value);
                        }
                        else if (IsDecimal(dgvCell.Value))
                        {
                            sumBox.Tag = Convert.ToDecimal(sumBox.Tag) + Convert.ToDecimal(dgvCell.Value);
                        }

                        sumBox.Text = $"{sumBox.Tag}";
                        sumBox.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// Create summary boxes for each Column of the DataGridView        
        /// </summary>
        private void ReCreateSumBoxes()
        {
            ReadOnlyTextBox sumBox;

            foreach (Control control in _sumBoxHash.Values)
            {
                Controls.Remove(control);
            }
            _sumBoxHash.Clear();

            var iCnt = 0;

            var sortedColumns = SortedColumns;
            foreach (var dgvColumn in sortedColumns)
            {
                sumBox = new ReadOnlyTextBox();
                _sumBoxHash.Add(dgvColumn, sumBox);

                sumBox.Top = 0;
                sumBox.Height = _dgv.DataGridView.RowTemplate.Height;
                sumBox.BorderColor = _dgv.DataGridView.GridColor;
                if (SummaryRowBackColor == null)
                    sumBox.BackColor = _dgv.DataGridView.DefaultCellStyle.BackColor;
                else
                    sumBox.BackColor = SummaryRowBackColor;
                sumBox.BringToFront();

                if (_dgv.DataGridView.ColumnCount - iCnt == 1)
                    sumBox.IsLastColumn = true;

                if (_dgv.SummaryColumns != null && _dgv.SummaryColumns.Length > 0)
                {
                    for (var iCntX = 0; iCntX < _dgv.SummaryColumns.Length; iCntX++)
                    {
                        if (_dgv.SummaryColumns[iCntX] == dgvColumn.DataPropertyName ||
                            _dgv.SummaryColumns[iCntX] == dgvColumn.Name)
                        {
                            dgvColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            dgvColumn.CellTemplate.Style.Format = _dgv.FormatString;
                            sumBox.TextAlign = TextHelper.TranslateGridColumnAligment(dgvColumn.DefaultCellStyle.Alignment);
                            sumBox.IsSummary = true;

                            sumBox.FormatString = dgvColumn.CellTemplate.Style.Format;
                            if (dgvColumn.ValueType == typeof(Int32) || dgvColumn.ValueType == typeof(Int16) ||
                                dgvColumn.ValueType == typeof(Int64) || dgvColumn.ValueType == typeof(Single) ||
                                dgvColumn.ValueType == typeof(Double) || dgvColumn.ValueType == typeof(Single) ||
                                dgvColumn.ValueType == typeof(Decimal))
                                sumBox.Tag = Activator.CreateInstance(dgvColumn.ValueType);
                        }
                    }
                }

                sumBox.BringToFront();
                Controls.Add(sumBox);

                iCnt++;
            }

            if (_dgv.DisplaySumRowHeader)
            {
                _sumRowHeaderLabel.Font = new Font(_dgv.DataGridView.DefaultCellStyle.Font, _dgv.SumRowHeaderTextBold ? FontStyle.Bold : FontStyle.Regular);
                _sumRowHeaderLabel.Anchor = AnchorStyles.Left;
                _sumRowHeaderLabel.TextAlign = ContentAlignment.MiddleLeft;
                _sumRowHeaderLabel.Height = _sumRowHeaderLabel.Font.Height;
                _sumRowHeaderLabel.Top = Convert.ToInt32(Convert.ToDouble(InitialHeight - _sumRowHeaderLabel.Height) / 2F);
                _sumRowHeaderLabel.Text = _dgv.SumRowHeaderText;

                _sumRowHeaderLabel.ForeColor = _dgv.DataGridView.DefaultCellStyle.ForeColor;
                _sumRowHeaderLabel.Margin = new Padding(0);
                _sumRowHeaderLabel.Padding = new Padding(0);

                Controls.Add(_sumRowHeaderLabel);
            }
            CalcSummaries();
            ResizeSumBoxes();
        }

        /// <summary>
        /// Order the columns in the way they are displayed
        /// </summary>
        private List<DataGridViewColumn> SortedColumns
        {
            get
            {
                var result = new List<DataGridViewColumn>();
                var column = _dgv.Columns.GetFirstColumn(DataGridViewElementStates.None);
                if (column == null)
                    return result;
                result.Add(column);
                while ((column = _dgv.Columns.GetNextColumn(column, DataGridViewElementStates.None, DataGridViewElementStates.None)) != null)
                    result.Add(column);

                return result;
            }
        }

        /// <summary>
        /// Resize the summary Boxes depending on the 
        /// width of the Columns of the DataGridView
        /// </summary>
        private void ResizeSumBoxes()
        {
            SuspendLayout();
            if (_sumBoxHash.Count > 0)
                try
                {
                    var rowHeaderWidth = _dgv.DataGridView.RowHeadersVisible ? _dgv.DataGridView.RowHeadersWidth - 1 : 0;
                    var sumLabelWidth = _dgv.DataGridView.RowHeadersVisible ? _dgv.DataGridView.RowHeadersWidth - 1 : 0;
                    var curPos = rowHeaderWidth;

                    if (_dgv.DisplaySumRowHeader && sumLabelWidth > 0)
                    {
                        if (_dgv.RightToLeft == RightToLeft.Yes)
                        {
                            if (_sumRowHeaderLabel.Dock != DockStyle.Right)
                                _sumRowHeaderLabel.Dock = DockStyle.Right;
                        }
                        else
                        {
                            if (_sumRowHeaderLabel.Dock != DockStyle.Left)
                                _sumRowHeaderLabel.Dock = DockStyle.Left;

                        }
                    }
                    else
                    {
                        if (_sumRowHeaderLabel.Visible)
                            _sumRowHeaderLabel.Visible = false;
                    }

                    var iCnt = 0;
                    Rectangle oldBounds;

                    foreach (var dgvColumn in SortedColumns) //dgv.Columns)
                    {
                        var sumBox = (ReadOnlyTextBox)_sumBoxHash[dgvColumn];


                        if (sumBox != null)
                        {
                            oldBounds = sumBox.Bounds;
                            if (!dgvColumn.Visible)
                            {
                                sumBox.Visible = false;
                                continue;
                            }

                            var from = curPos - _dgv.DataGridView.HorizontalScrollingOffset;

                            var width = dgvColumn.Width + (iCnt == 0 ? 0 : 0);

                            if (from < rowHeaderWidth)
                            {
                                width -= rowHeaderWidth - from;
                                from = rowHeaderWidth;
                            }

                            if (from + width > Width)
                                width = Width - from;

                            if (width < 4)
                            {
                                if (sumBox.Visible)
                                    sumBox.Visible = false;
                            }
                            else
                            {
                                if (RightToLeft == RightToLeft.Yes)
                                    from = Width - from - width;


                                if (sumBox.Left != from || sumBox.Width != width)
                                    sumBox.SetBounds(from, 0, width, 0, BoundsSpecified.X | BoundsSpecified.Width);

                                if (!sumBox.Visible)
                                    sumBox.Visible = true;
                            }

                            curPos += dgvColumn.Width + (iCnt == 0 ? 0 : 0);
                            if (oldBounds != sumBox.Bounds)
                                sumBox.Invalidate();

                        }
                        iCnt++;
                    }
                }
                finally
                {
                    ResumeLayout();
                }
        }

        #endregion
    }
}

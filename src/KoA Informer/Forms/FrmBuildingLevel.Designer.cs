namespace KoA_Informer.Forms
{
    partial class FrmBuildingLevel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label levelLabel;
            System.Windows.Forms.Label timeLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.panel2 = new System.Windows.Forms.Panel();
            this.ccvdNumeroInput2 = new CCVD.Win.Design.CCVDNumeroInput();
            this.BsDados = new System.Windows.Forms.BindingSource(this.components);
            this.ccvdNumeroInput1 = new CCVD.Win.Design.CCVDNumeroInput();
            this.BtnGravar = new System.Windows.Forms.Button();
            this.timeCCVDTextInput = new CCVD.Design.CCVDTextInput();
            this.levelCCVDNumeroInput = new CCVD.Win.Design.CCVDNumeroInput();
            this.BsBuiding = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel6 = new System.Windows.Forms.Panel();
            this.GridBuildRequirements = new System.Windows.Forms.DataGridView();
            this.BsBuildRequirements = new System.Windows.Forms.BindingSource(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.BtnDelBuildRequirement = new System.Windows.Forms.Button();
            this.BtnNewBuildRequirement = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GridMaterialRequirements = new System.Windows.Forms.DataGridView();
            this.ColMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BsBuildMaterials = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnDelMaterial = new System.Windows.Forms.Button();
            this.BtnNewMaterial = new System.Windows.Forms.Button();
            this.BsMaterials = new System.Windows.Forms.BindingSource(this.components);
            this.BsBuildings = new System.Windows.Forms.BindingSource(this.components);
            this.ccvdComboBoxColumn1 = new CCVD.Win.Design.CCVDComboBoxColumn();
            this.Building = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            levelLabel = new System.Windows.Forms.Label();
            timeLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsDados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsBuiding)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridBuildRequirements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsBuildRequirements)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridMaterialRequirements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsBuildMaterials)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsBuildings)).BeginInit();
            this.SuspendLayout();
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.Location = new System.Drawing.Point(9, 18);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new System.Drawing.Size(36, 13);
            levelLabel.TabIndex = 0;
            levelLabel.Text = "Level:";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new System.Drawing.Point(327, 18);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new System.Drawing.Size(33, 13);
            timeLabel.TabIndex = 2;
            timeLabel.Text = "Time:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(115, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(50, 13);
            label1.TabIndex = 6;
            label1.Text = "Hero XP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(221, 18);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(40, 13);
            label2.TabIndex = 8;
            label2.Text = "Power:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(label2);
            this.panel2.Controls.Add(this.ccvdNumeroInput2);
            this.panel2.Controls.Add(label1);
            this.panel2.Controls.Add(this.ccvdNumeroInput1);
            this.panel2.Controls.Add(this.BtnGravar);
            this.panel2.Controls.Add(timeLabel);
            this.panel2.Controls.Add(this.timeCCVDTextInput);
            this.panel2.Controls.Add(levelLabel);
            this.panel2.Controls.Add(this.levelCCVDNumeroInput);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(621, 84);
            this.panel2.TabIndex = 1;
            // 
            // ccvdNumeroInput2
            // 
            this.ccvdNumeroInput2.AllowSpace = false;
            this.ccvdNumeroInput2.CasasDecimais = 2;
            this.ccvdNumeroInput2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BsDados, "Power", true));
            this.ccvdNumeroInput2.Label = label2;
            this.ccvdNumeroInput2.Location = new System.Drawing.Point(224, 34);
            this.ccvdNumeroInput2.Name = "ccvdNumeroInput2";
            this.ccvdNumeroInput2.Size = new System.Drawing.Size(100, 20);
            this.ccvdNumeroInput2.TabIndex = 2;
            this.ccvdNumeroInput2.Text = "0";
            this.ccvdNumeroInput2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ccvdNumeroInput2.TipoCampo = CCVD.Win.Design.TipoNumero.Inteiro;
            this.ccvdNumeroInput2.Value = "0";
            // 
            // BsDados
            // 
            this.BsDados.DataSource = typeof(Koa.Model.BuildingLevel);
            this.BsDados.CurrentChanged += new System.EventHandler(this.BsData_CurrentChanged);
            // 
            // ccvdNumeroInput1
            // 
            this.ccvdNumeroInput1.AllowSpace = false;
            this.ccvdNumeroInput1.CasasDecimais = 2;
            this.ccvdNumeroInput1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BsDados, "HeroXP", true));
            this.ccvdNumeroInput1.Label = label1;
            this.ccvdNumeroInput1.Location = new System.Drawing.Point(118, 34);
            this.ccvdNumeroInput1.Name = "ccvdNumeroInput1";
            this.ccvdNumeroInput1.Size = new System.Drawing.Size(100, 20);
            this.ccvdNumeroInput1.TabIndex = 1;
            this.ccvdNumeroInput1.Text = "0";
            this.ccvdNumeroInput1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ccvdNumeroInput1.TipoCampo = CCVD.Win.Design.TipoNumero.Inteiro;
            this.ccvdNumeroInput1.Value = "0";
            // 
            // BtnGravar
            // 
            this.BtnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGravar.Location = new System.Drawing.Point(534, 9);
            this.BtnGravar.Name = "BtnGravar";
            this.BtnGravar.Size = new System.Drawing.Size(75, 69);
            this.BtnGravar.TabIndex = 4;
            this.BtnGravar.Text = "Gravar";
            this.BtnGravar.UseVisualStyleBackColor = true;
            this.BtnGravar.Click += new System.EventHandler(this.BtnGravar_Click);
            // 
            // timeCCVDTextInput
            // 
            this.timeCCVDTextInput.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BsDados, "Time", true));
            this.timeCCVDTextInput.Label = timeLabel;
            this.timeCCVDTextInput.Location = new System.Drawing.Point(330, 34);
            this.timeCCVDTextInput.Name = "timeCCVDTextInput";
            this.timeCCVDTextInput.Size = new System.Drawing.Size(100, 20);
            this.timeCCVDTextInput.TabIndex = 3;
            // 
            // levelCCVDNumeroInput
            // 
            this.levelCCVDNumeroInput.AllowSpace = false;
            this.levelCCVDNumeroInput.CasasDecimais = 2;
            this.levelCCVDNumeroInput.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BsDados, "Level", true));
            this.levelCCVDNumeroInput.Label = levelLabel;
            this.levelCCVDNumeroInput.Location = new System.Drawing.Point(12, 34);
            this.levelCCVDNumeroInput.Name = "levelCCVDNumeroInput";
            this.levelCCVDNumeroInput.Size = new System.Drawing.Size(100, 20);
            this.levelCCVDNumeroInput.TabIndex = 0;
            this.levelCCVDNumeroInput.Text = "0";
            this.levelCCVDNumeroInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.levelCCVDNumeroInput.TipoCampo = CCVD.Win.Design.TipoNumero.Inteiro;
            this.levelCCVDNumeroInput.Value = "0";
            // 
            // BsBuiding
            // 
            this.BsBuiding.DataSource = typeof(Koa.Model.Building);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 364);
            this.panel1.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel6);
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(621, 364);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.GridBuildRequirements);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 44);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(314, 320);
            this.panel6.TabIndex = 5;
            // 
            // GridBuildRequirements
            // 
            this.GridBuildRequirements.AllowUserToAddRows = false;
            this.GridBuildRequirements.AllowUserToDeleteRows = false;
            this.GridBuildRequirements.AutoGenerateColumns = false;
            this.GridBuildRequirements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridBuildRequirements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Building,
            this.Level});
            this.GridBuildRequirements.DataSource = this.BsBuildRequirements;
            this.GridBuildRequirements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridBuildRequirements.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.GridBuildRequirements.Location = new System.Drawing.Point(0, 0);
            this.GridBuildRequirements.MultiSelect = false;
            this.GridBuildRequirements.Name = "GridBuildRequirements";
            this.GridBuildRequirements.ReadOnly = true;
            this.GridBuildRequirements.RowHeadersWidth = 20;
            this.GridBuildRequirements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridBuildRequirements.ShowEditingIcon = false;
            this.GridBuildRequirements.Size = new System.Drawing.Size(314, 320);
            this.GridBuildRequirements.TabIndex = 1;
            this.GridBuildRequirements.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridBuildRequirements_CellFormatting);
            // 
            // BsBuildRequirements
            // 
            this.BsBuildRequirements.AllowNew = false;
            this.BsBuildRequirements.DataSource = typeof(Koa.Model.BuildingLevel);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.BtnDelBuildRequirement);
            this.panel5.Controls.Add(this.BtnNewBuildRequirement);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(314, 44);
            this.panel5.TabIndex = 4;
            // 
            // BtnDelBuildRequirement
            // 
            this.BtnDelBuildRequirement.Location = new System.Drawing.Point(91, 6);
            this.BtnDelBuildRequirement.Name = "BtnDelBuildRequirement";
            this.BtnDelBuildRequirement.Size = new System.Drawing.Size(75, 30);
            this.BtnDelBuildRequirement.TabIndex = 7;
            this.BtnDelBuildRequirement.Text = "Erase";
            this.BtnDelBuildRequirement.UseVisualStyleBackColor = true;
            this.BtnDelBuildRequirement.Click += new System.EventHandler(this.BtnDelBuildRequirement_Click);
            // 
            // BtnNewBuildRequirement
            // 
            this.BtnNewBuildRequirement.Location = new System.Drawing.Point(10, 6);
            this.BtnNewBuildRequirement.Name = "BtnNewBuildRequirement";
            this.BtnNewBuildRequirement.Size = new System.Drawing.Size(75, 30);
            this.BtnNewBuildRequirement.TabIndex = 5;
            this.BtnNewBuildRequirement.Text = "New";
            this.BtnNewBuildRequirement.UseVisualStyleBackColor = true;
            this.BtnNewBuildRequirement.Click += new System.EventHandler(this.BtnNewBuildRequirement_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.GridMaterialRequirements);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(303, 320);
            this.panel3.TabIndex = 4;
            // 
            // GridMaterialRequirements
            // 
            this.GridMaterialRequirements.AllowUserToAddRows = false;
            this.GridMaterialRequirements.AllowUserToDeleteRows = false;
            this.GridMaterialRequirements.AutoGenerateColumns = false;
            this.GridMaterialRequirements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridMaterialRequirements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMaterial,
            this.amountDataGridViewTextBoxColumn});
            this.GridMaterialRequirements.DataSource = this.BsBuildMaterials;
            this.GridMaterialRequirements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridMaterialRequirements.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.GridMaterialRequirements.Location = new System.Drawing.Point(0, 0);
            this.GridMaterialRequirements.MultiSelect = false;
            this.GridMaterialRequirements.Name = "GridMaterialRequirements";
            this.GridMaterialRequirements.ReadOnly = true;
            this.GridMaterialRequirements.RowHeadersWidth = 20;
            this.GridMaterialRequirements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridMaterialRequirements.ShowEditingIcon = false;
            this.GridMaterialRequirements.Size = new System.Drawing.Size(303, 320);
            this.GridMaterialRequirements.TabIndex = 2;
            this.GridMaterialRequirements.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridMaterialRequirements_CellFormatting);
            // 
            // ColMaterial
            // 
            this.ColMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColMaterial.DataPropertyName = "Material";
            this.ColMaterial.HeaderText = "Material";
            this.ColMaterial.Name = "ColMaterial";
            this.ColMaterial.ReadOnly = true;
            this.ColMaterial.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.FillWeight = 50F;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 50;
            // 
            // BsBuildMaterials
            // 
            this.BsBuildMaterials.AllowNew = false;
            this.BsBuildMaterials.DataSource = typeof(Koa.Model.MaterialRequirement);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BtnDelMaterial);
            this.panel4.Controls.Add(this.BtnNewMaterial);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(303, 44);
            this.panel4.TabIndex = 3;
            // 
            // BtnDelMaterial
            // 
            this.BtnDelMaterial.Location = new System.Drawing.Point(93, 6);
            this.BtnDelMaterial.Name = "BtnDelMaterial";
            this.BtnDelMaterial.Size = new System.Drawing.Size(75, 30);
            this.BtnDelMaterial.TabIndex = 6;
            this.BtnDelMaterial.Text = "Erase";
            this.BtnDelMaterial.UseVisualStyleBackColor = true;
            this.BtnDelMaterial.Click += new System.EventHandler(this.BtnDelMaterial_Click);
            // 
            // BtnNewMaterial
            // 
            this.BtnNewMaterial.Location = new System.Drawing.Point(12, 6);
            this.BtnNewMaterial.Name = "BtnNewMaterial";
            this.BtnNewMaterial.Size = new System.Drawing.Size(75, 30);
            this.BtnNewMaterial.TabIndex = 5;
            this.BtnNewMaterial.Text = "New";
            this.BtnNewMaterial.UseVisualStyleBackColor = true;
            this.BtnNewMaterial.Click += new System.EventHandler(this.BtnNewMaterial_Click);
            // 
            // BsMaterials
            // 
            this.BsMaterials.AllowNew = false;
            this.BsMaterials.DataSource = typeof(Koa.Model.Material);
            // 
            // BsBuildings
            // 
            this.BsBuildings.AllowNew = false;
            this.BsBuildings.DataSource = typeof(Koa.Model.Building);
            // 
            // ccvdComboBoxColumn1
            // 
            this.ccvdComboBoxColumn1.DataPropertyName = "Building";
            this.ccvdComboBoxColumn1.DataSource = this.BsBuildings;
            this.ccvdComboBoxColumn1.DisplayMember = "Name";
            this.ccvdComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ccvdComboBoxColumn1.HeaderText = "Building";
            this.ccvdComboBoxColumn1.Name = "ccvdComboBoxColumn1";
            this.ccvdComboBoxColumn1.Padrao = true;
            this.ccvdComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ccvdComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Building
            // 
            this.Building.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Building.DataPropertyName = "Building";
            this.Building.HeaderText = "Building";
            this.Building.Name = "Building";
            this.Building.ReadOnly = true;
            this.Building.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Level
            // 
            this.Level.DataPropertyName = "Level";
            this.Level.FillWeight = 50F;
            this.Level.HeaderText = "Level";
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            this.Level.Width = 50;
            // 
            // FrmBuildingLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 448);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmBuildingLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Building Level";
            this.Load += new System.EventHandler(this.FrmBuildingLevel_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsDados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsBuiding)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridBuildRequirements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsBuildRequirements)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridMaterialRequirements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsBuildMaterials)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BsMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsBuildings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource BsDados;
        private System.Windows.Forms.BindingSource BsBuiding;
        private CCVD.Win.Design.CCVDNumeroInput levelCCVDNumeroInput;
        private CCVD.Design.CCVDTextInput timeCCVDTextInput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView GridBuildRequirements;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView GridMaterialRequirements;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BtnNewMaterial;
        private System.Windows.Forms.Button BtnGravar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BtnNewBuildRequirement;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.BindingSource BsBuildRequirements;
        private System.Windows.Forms.BindingSource BsBuildings;
        private CCVD.Win.Design.CCVDComboBoxColumn ccvdComboBoxColumn1;
        private System.Windows.Forms.BindingSource BsMaterials;
        private System.Windows.Forms.BindingSource BsBuildMaterials;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button BtnDelMaterial;
        private System.Windows.Forms.Button BtnDelBuildRequirement;
        private CCVD.Win.Design.CCVDNumeroInput ccvdNumeroInput2;
        private CCVD.Win.Design.CCVDNumeroInput ccvdNumeroInput1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Building;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
    }
}
namespace KoA_Informer.Forms
{
    partial class FrmBuildingRequirement
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.BsDados = new System.Windows.Forms.BindingSource(this.components);
            this.BsBuidingLevel = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.CbLeveis = new CCVD.Win.Design.CCVDComboBox();
            this.CbBuildings = new CCVD.Win.Design.CCVDComboBox();
            this.BsBuildings = new System.Windows.Forms.BindingSource(this.components);
            this.BtnGravar = new System.Windows.Forms.Button();
            this.BsLeveis = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BsDados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsBuidingLevel)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsBuildings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsLeveis)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 13);
            label1.TabIndex = 7;
            label1.Text = "Building";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(145, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(36, 13);
            label2.TabIndex = 9;
            label2.Text = "Level:";
            // 
            // BsDados
            // 
            this.BsDados.DataSource = typeof(Koa.Model.BuildingRequirement);
            this.BsDados.CurrentChanged += new System.EventHandler(this.BsDados_CurrentChanged);
            // 
            // BsBuidingLevel
            // 
            this.BsBuidingLevel.DataSource = typeof(Koa.Model.BuildingLevel);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(label2);
            this.panel2.Controls.Add(this.CbLeveis);
            this.panel2.Controls.Add(label1);
            this.panel2.Controls.Add(this.CbBuildings);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(237, 96);
            this.panel2.TabIndex = 2;
            // 
            // CbLeveis
            // 
            this.CbLeveis.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.BsDados, "Requirement", true));
            this.CbLeveis.DataSource = this.BsBuidingLevel;
            this.CbLeveis.DisplayMember = "Level";
            this.CbLeveis.FormattingEnabled = true;
            this.CbLeveis.Label = label2;
            this.CbLeveis.Location = new System.Drawing.Point(148, 25);
            this.CbLeveis.Name = "CbLeveis";
            this.CbLeveis.Size = new System.Drawing.Size(76, 21);
            this.CbLeveis.TabIndex = 8;
            this.CbLeveis.ValueMember = "Id";
            // 
            // CbBuildings
            // 
            this.CbBuildings.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CbBuildings.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbBuildings.DataSource = this.BsBuildings;
            this.CbBuildings.DisplayMember = "Name";
            this.CbBuildings.FormattingEnabled = true;
            this.CbBuildings.Label = label1;
            this.CbBuildings.Location = new System.Drawing.Point(6, 25);
            this.CbBuildings.Name = "CbBuildings";
            this.CbBuildings.Size = new System.Drawing.Size(136, 21);
            this.CbBuildings.TabIndex = 6;
            this.CbBuildings.ValueMember = "Id";
            this.CbBuildings.SelectedIndexChanged += new System.EventHandler(this.CbBuildings_SelectedIndexChanged);
            // 
            // BsBuildings
            // 
            this.BsBuildings.DataSource = typeof(Koa.Model.Building);
            // 
            // BtnGravar
            // 
            this.BtnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGravar.Location = new System.Drawing.Point(150, 3);
            this.BtnGravar.Name = "BtnGravar";
            this.BtnGravar.Size = new System.Drawing.Size(75, 31);
            this.BtnGravar.TabIndex = 5;
            this.BtnGravar.Text = "Save";
            this.BtnGravar.UseVisualStyleBackColor = true;
            this.BtnGravar.Click += new System.EventHandler(this.BtnGravar_Click);
            // 
            // BsLeveis
            // 
            this.BsLeveis.DataSource = typeof(Koa.Model.BuildingLevel);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnGravar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 39);
            this.panel1.TabIndex = 6;
            // 
            // FrmBuildingRequirement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 96);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBuildingRequirement";
            this.Text = "Building Requirement";
            ((System.ComponentModel.ISupportInitialize)(this.BsDados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsBuidingLevel)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsBuildings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsLeveis)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource BsDados;
        private System.Windows.Forms.BindingSource BsBuidingLevel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnGravar;
        private CCVD.Win.Design.CCVDComboBox CbBuildings;
        private System.Windows.Forms.BindingSource BsBuildings;
        private CCVD.Win.Design.CCVDComboBox CbLeveis;
        private System.Windows.Forms.BindingSource BsLeveis;
        private System.Windows.Forms.Panel panel1;
    }
}
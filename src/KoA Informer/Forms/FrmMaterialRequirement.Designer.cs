namespace KoA_Informer.Forms
{
    partial class FrmMaterialRequirement
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
            System.Windows.Forms.Label levelLabel;
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnGravar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EdtAmount = new CCVD.Win.Design.CCVDNumeroInput();
            this.BsDados = new System.Windows.Forms.BindingSource(this.components);
            this.CbMaterial = new CCVD.Win.Design.CCVDComboBox();
            this.BsMaterial = new System.Windows.Forms.BindingSource(this.components);
            label1 = new System.Windows.Forms.Label();
            levelLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsDados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 13);
            label1.TabIndex = 7;
            label1.Text = "Material:";
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.Location = new System.Drawing.Point(109, 10);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new System.Drawing.Size(43, 13);
            levelLabel.TabIndex = 8;
            levelLabel.Text = "Amount";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnGravar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 39);
            this.panel1.TabIndex = 8;
            // 
            // BtnGravar
            // 
            this.BtnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGravar.Location = new System.Drawing.Point(146, 3);
            this.BtnGravar.Name = "BtnGravar";
            this.BtnGravar.Size = new System.Drawing.Size(75, 31);
            this.BtnGravar.TabIndex = 5;
            this.BtnGravar.Text = "Save";
            this.BtnGravar.UseVisualStyleBackColor = true;
            this.BtnGravar.Click += new System.EventHandler(this.BtnGravar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(levelLabel);
            this.panel2.Controls.Add(this.EdtAmount);
            this.panel2.Controls.Add(label1);
            this.panel2.Controls.Add(this.CbMaterial);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(233, 98);
            this.panel2.TabIndex = 7;
            // 
            // EdtAmount
            // 
            this.EdtAmount.AllowSpace = false;
            this.EdtAmount.CasasDecimais = 2;
            this.EdtAmount.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BsDados, "Amount", true));
            this.EdtAmount.Label = levelLabel;
            this.EdtAmount.Location = new System.Drawing.Point(112, 26);
            this.EdtAmount.Name = "EdtAmount";
            this.EdtAmount.Size = new System.Drawing.Size(100, 20);
            this.EdtAmount.TabIndex = 9;
            this.EdtAmount.Text = "0";
            this.EdtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.EdtAmount.TipoCampo = CCVD.Win.Design.TipoNumero.Inteiro;
            this.EdtAmount.Value = "0";
            // 
            // BsDados
            // 
            this.BsDados.DataSource = typeof(Koa.Model.MaterialRequirement);
            // 
            // CbMaterial
            // 
            this.CbMaterial.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.BsDados, "Material", true));
            this.CbMaterial.DataSource = this.BsMaterial;
            this.CbMaterial.DisplayMember = "Name";
            this.CbMaterial.FormattingEnabled = true;
            this.CbMaterial.Label = label1;
            this.CbMaterial.Location = new System.Drawing.Point(6, 25);
            this.CbMaterial.Name = "CbMaterial";
            this.CbMaterial.Size = new System.Drawing.Size(100, 21);
            this.CbMaterial.TabIndex = 6;
            this.CbMaterial.ValueMember = "Id";
            // 
            // BsMaterial
            // 
            this.BsMaterial.DataSource = typeof(Koa.Model.Material);
            // 
            // FrmMaterialRequirement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 98);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMaterialRequirement";
            this.Text = "Material Requirement";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsDados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsMaterial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnGravar;
        private System.Windows.Forms.Panel panel2;
        private CCVD.Win.Design.CCVDComboBox CbMaterial;
        private System.Windows.Forms.BindingSource BsDados;
        private System.Windows.Forms.BindingSource BsMaterial;
        private CCVD.Win.Design.CCVDNumeroInput EdtAmount;
    }
}
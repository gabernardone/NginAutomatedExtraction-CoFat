namespace Ngin___Automated_Extraction_CoFat_Pré_pago
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiOpcoes = new System.Windows.Forms.ToolStripMenuItem();
            this.pgbStatus = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExtrair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpcoes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(484, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiOpcoes
            // 
            this.tsmiOpcoes.Name = "tsmiOpcoes";
            this.tsmiOpcoes.Size = new System.Drawing.Size(71, 24);
            this.tsmiOpcoes.Text = "Opções";
            this.tsmiOpcoes.Click += new System.EventHandler(this.tsmiOpcoes_Click);
            // 
            // pgbStatus
            // 
            this.pgbStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbStatus.Location = new System.Drawing.Point(0, 163);
            this.pgbStatus.Name = "pgbStatus";
            this.pgbStatus.Size = new System.Drawing.Size(484, 25);
            this.pgbStatus.TabIndex = 10;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(0, 139);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(484, 24);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Aguardando Inicio";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Ngin___Automated_Extraction_CoFat_Pré_pago.Properties.Resources.accenture_operation;
            this.pictureBox1.Location = new System.Drawing.Point(340, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnExtrair
            // 
            this.btnExtrair.Image = global::Ngin___Automated_Extraction_CoFat_Pré_pago.Properties.Resources.if_download_alt_173001__2_;
            this.btnExtrair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExtrair.Location = new System.Drawing.Point(162, 68);
            this.btnExtrair.Margin = new System.Windows.Forms.Padding(4);
            this.btnExtrair.Name = "btnExtrair";
            this.btnExtrair.Size = new System.Drawing.Size(157, 36);
            this.btnExtrair.TabIndex = 7;
            this.btnExtrair.Text = "Iniciar";
            this.btnExtrair.UseVisualStyleBackColor = true;
            this.btnExtrair.Click += new System.EventHandler(this.btnExtrair_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Ngin___Automated_Extraction_CoFat_Pré_pago.Properties.Resources.if_6___Cross_1815573;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(162, 68);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(157, 36);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 188);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pgbStatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnExtrair);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.Text = "Ngin - Automated CoFat Pré-Pago";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExtrair;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpcoes;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.ProgressBar pgbStatus;
    }
}


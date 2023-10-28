namespace hastene_otomasyon
{
    partial class frmhastagiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmhastagiris));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MSKTC = new System.Windows.Forms.MaskedTextBox();
            this.txthastasifre = new System.Windows.Forms.TextBox();
            this.btnhastagiris = new System.Windows.Forms.Button();
            this.lnkhastaüyelik = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hasta Giriş Paneli";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "T.C :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "ŞİFRE:";
            // 
            // MSKTC
            // 
            this.MSKTC.Location = new System.Drawing.Point(117, 97);
            this.MSKTC.Mask = "00000000000";
            this.MSKTC.Name = "MSKTC";
            this.MSKTC.Size = new System.Drawing.Size(186, 31);
            this.MSKTC.TabIndex = 1;
            this.MSKTC.ValidatingType = typeof(int);
            // 
            // txthastasifre
            // 
            this.txthastasifre.Location = new System.Drawing.Point(117, 146);
            this.txthastasifre.Name = "txthastasifre";
            this.txthastasifre.Size = new System.Drawing.Size(186, 31);
            this.txthastasifre.TabIndex = 2;
            this.txthastasifre.UseSystemPasswordChar = true;
            // 
            // btnhastagiris
            // 
            this.btnhastagiris.Location = new System.Drawing.Point(190, 211);
            this.btnhastagiris.Name = "btnhastagiris";
            this.btnhastagiris.Size = new System.Drawing.Size(112, 33);
            this.btnhastagiris.TabIndex = 5;
            this.btnhastagiris.Text = "GİRİŞ";
            this.btnhastagiris.UseVisualStyleBackColor = true;
            this.btnhastagiris.Click += new System.EventHandler(this.btnhastagiris_Click);
            // 
            // lnkhastaüyelik
            // 
            this.lnkhastaüyelik.AutoSize = true;
            this.lnkhastaüyelik.Location = new System.Drawing.Point(323, 153);
            this.lnkhastaüyelik.Name = "lnkhastaüyelik";
            this.lnkhastaüyelik.Size = new System.Drawing.Size(92, 24);
            this.lnkhastaüyelik.TabIndex = 6;
            this.lnkhastaüyelik.TabStop = true;
            this.lnkhastaüyelik.Text = "KAYIT OL";
            this.lnkhastaüyelik.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkhastaüyelik_LinkClicked);
            // 
            // frmhastagiris
            // 
            this.AcceptButton = this.btnhastagiris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(612, 327);
            this.Controls.Add(this.lnkhastaüyelik);
            this.Controls.Add(this.btnhastagiris);
            this.Controls.Add(this.txthastasifre);
            this.Controls.Add(this.MSKTC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmhastagiris";
            this.Text = "Hasta Griş Ekranı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox MSKTC;
        private System.Windows.Forms.TextBox txthastasifre;
        private System.Windows.Forms.Button btnhastagiris;
        private System.Windows.Forms.LinkLabel lnkhastaüyelik;
    }
}
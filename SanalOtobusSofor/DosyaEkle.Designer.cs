namespace SanalOtobusSofor
{
    partial class DosyaEkle
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
            this.background = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBelgeEkle = new System.Windows.Forms.Label();
            this.btnFotografEkle = new System.Windows.Forms.Label();
            this.btnVideoEkle = new System.Windows.Forms.Label();
            this.dsyEkleBaslik = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerDosyalariCek = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.background.SuspendLayout();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.Controls.Add(this.listBox1);
            this.background.Controls.Add(this.label2);
            this.background.Controls.Add(this.btnBelgeEkle);
            this.background.Controls.Add(this.btnFotografEkle);
            this.background.Controls.Add(this.btnVideoEkle);
            this.background.Location = new System.Drawing.Point(12, 45);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(814, 549);
            this.background.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // btnBelgeEkle
            // 
            this.btnBelgeEkle.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBelgeEkle.Enabled = false;
            this.btnBelgeEkle.Font = new System.Drawing.Font("Lucida Sans Unicode", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnBelgeEkle.Location = new System.Drawing.Point(4, 213);
            this.btnBelgeEkle.Name = "btnBelgeEkle";
            this.btnBelgeEkle.Size = new System.Drawing.Size(805, 79);
            this.btnBelgeEkle.TabIndex = 2;
            this.btnBelgeEkle.Text = "BELGELERİ AKTAR";
            this.btnBelgeEkle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBelgeEkle.Click += new System.EventHandler(this.btnBelgeEkle_Click);
            this.btnBelgeEkle.MouseLeave += new System.EventHandler(this.btnBelgeEkle_MouseLeave);
            this.btnBelgeEkle.MouseHover += new System.EventHandler(this.btnBelgeEkle_MouseHover);
            // 
            // btnFotografEkle
            // 
            this.btnFotografEkle.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFotografEkle.Enabled = false;
            this.btnFotografEkle.Font = new System.Drawing.Font("Lucida Sans Unicode", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnFotografEkle.Location = new System.Drawing.Point(4, 120);
            this.btnFotografEkle.Name = "btnFotografEkle";
            this.btnFotografEkle.Size = new System.Drawing.Size(805, 79);
            this.btnFotografEkle.TabIndex = 1;
            this.btnFotografEkle.Text = "FOTOGRAFLARI AKTAR";
            this.btnFotografEkle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFotografEkle.Click += new System.EventHandler(this.btnFotografEkle_Click);
            this.btnFotografEkle.MouseLeave += new System.EventHandler(this.btnFotografEkle_MouseLeave);
            this.btnFotografEkle.MouseHover += new System.EventHandler(this.btnFotografEkle_MouseHover);
            // 
            // btnVideoEkle
            // 
            this.btnVideoEkle.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVideoEkle.Font = new System.Drawing.Font("Lucida Sans Unicode", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnVideoEkle.Location = new System.Drawing.Point(4, 26);
            this.btnVideoEkle.Name = "btnVideoEkle";
            this.btnVideoEkle.Size = new System.Drawing.Size(805, 79);
            this.btnVideoEkle.TabIndex = 0;
            this.btnVideoEkle.Text = "VİDEOLARI AKTAR";
            this.btnVideoEkle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVideoEkle.Click += new System.EventHandler(this.btnVideoEkle_Click);
            this.btnVideoEkle.MouseLeave += new System.EventHandler(this.btnVideoEkle_MouseLeave);
            this.btnVideoEkle.MouseHover += new System.EventHandler(this.btnVideoEkle_MouseHover);
            // 
            // dsyEkleBaslik
            // 
            this.dsyEkleBaslik.BackColor = System.Drawing.Color.Transparent;
            this.dsyEkleBaslik.Font = new System.Drawing.Font("Lucida Sans Unicode", 20.25F, System.Drawing.FontStyle.Bold);
            this.dsyEkleBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.dsyEkleBaslik.Location = new System.Drawing.Point(12, 0);
            this.dsyEkleBaslik.Name = "dsyEkleBaslik";
            this.dsyEkleBaslik.Size = new System.Drawing.Size(814, 42);
            this.dsyEkleBaslik.TabIndex = 1;
            this.dsyEkleBaslik.Text = "DOSYA EKLEME PANELİ";
            this.dsyEkleBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(797, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // timerDosyalariCek
            // 
            this.timerDosyalariCek.Tick += new System.EventHandler(this.timerDosyalariCek_Tick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(443, 320);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 4;
            // 
            // DosyaEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 606);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dsyEkleBaslik);
            this.Controls.Add(this.background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DosyaEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DosyaEkle";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DosyaEkle_Load);
            this.background.ResumeLayout(false);
            this.background.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel background;
        private System.Windows.Forms.Label dsyEkleBaslik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnBelgeEkle;
        private System.Windows.Forms.Label btnFotografEkle;
        private System.Windows.Forms.Label btnVideoEkle;
        private System.Windows.Forms.Timer timerDosyalariCek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
    }
}
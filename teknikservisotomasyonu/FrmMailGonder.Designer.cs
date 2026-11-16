namespace teknikservisotomasyonu
{
    partial class FrmMailGonder
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
            this.GrpGonderici = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtGondericiMail = new System.Windows.Forms.TextBox();
            this.GrpAlıcı = new System.Windows.Forms.GroupBox();
            this.TxtAliciMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtKonu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtMesaj = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Grpİmza = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Txtİmza = new System.Windows.Forms.RichTextBox();
            this.ChcDuzenle = new System.Windows.Forms.CheckBox();
            this.BtnGonder = new System.Windows.Forms.Button();
            this.BtnKapat = new System.Windows.Forms.Button();
            this.GrpGonderici.SuspendLayout();
            this.GrpAlıcı.SuspendLayout();
            this.Grpİmza.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpGonderici
            // 
            this.GrpGonderici.Controls.Add(this.TxtGondericiMail);
            this.GrpGonderici.Controls.Add(this.label1);
            this.GrpGonderici.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpGonderici.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GrpGonderici.ForeColor = System.Drawing.Color.White;
            this.GrpGonderici.Location = new System.Drawing.Point(0, 0);
            this.GrpGonderici.Name = "GrpGonderici";
            this.GrpGonderici.Size = new System.Drawing.Size(1044, 100);
            this.GrpGonderici.TabIndex = 0;
            this.GrpGonderici.TabStop = false;
            this.GrpGonderici.Text = "Gönderici Bilgileri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gönderici Mail:";
            // 
            // TxtGondericiMail
            // 
            this.TxtGondericiMail.Location = new System.Drawing.Point(188, 42);
            this.TxtGondericiMail.Name = "TxtGondericiMail";
            this.TxtGondericiMail.Size = new System.Drawing.Size(803, 28);
            this.TxtGondericiMail.TabIndex = 1;
            // 
            // GrpAlıcı
            // 
            this.GrpAlıcı.Controls.Add(this.label4);
            this.GrpAlıcı.Controls.Add(this.TxtMesaj);
            this.GrpAlıcı.Controls.Add(this.TxtKonu);
            this.GrpAlıcı.Controls.Add(this.label3);
            this.GrpAlıcı.Controls.Add(this.TxtAliciMail);
            this.GrpAlıcı.Controls.Add(this.label2);
            this.GrpAlıcı.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpAlıcı.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GrpAlıcı.ForeColor = System.Drawing.Color.White;
            this.GrpAlıcı.Location = new System.Drawing.Point(0, 100);
            this.GrpAlıcı.Name = "GrpAlıcı";
            this.GrpAlıcı.Size = new System.Drawing.Size(1044, 272);
            this.GrpAlıcı.TabIndex = 1;
            this.GrpAlıcı.TabStop = false;
            this.GrpAlıcı.Text = "Alıcı Bilgileri ve Mesaj İçeriği";
            // 
            // TxtAliciMail
            // 
            this.TxtAliciMail.Location = new System.Drawing.Point(188, 42);
            this.TxtAliciMail.Name = "TxtAliciMail";
            this.TxtAliciMail.Size = new System.Drawing.Size(803, 28);
            this.TxtAliciMail.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Alıcı Mail:";
            // 
            // TxtKonu
            // 
            this.TxtKonu.Location = new System.Drawing.Point(188, 102);
            this.TxtKonu.Name = "TxtKonu";
            this.TxtKonu.Size = new System.Drawing.Size(803, 28);
            this.TxtKonu.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Konu:";
            // 
            // TxtMesaj
            // 
            this.TxtMesaj.Location = new System.Drawing.Point(188, 153);
            this.TxtMesaj.Name = "TxtMesaj";
            this.TxtMesaj.Size = new System.Drawing.Size(803, 96);
            this.TxtMesaj.TabIndex = 4;
            this.TxtMesaj.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mesaj:";
            // 
            // Grpİmza
            // 
            this.Grpİmza.Controls.Add(this.ChcDuzenle);
            this.Grpİmza.Controls.Add(this.label5);
            this.Grpİmza.Controls.Add(this.Txtİmza);
            this.Grpİmza.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.Grpİmza.ForeColor = System.Drawing.Color.White;
            this.Grpİmza.Location = new System.Drawing.Point(0, 378);
            this.Grpİmza.Name = "Grpİmza";
            this.Grpİmza.Size = new System.Drawing.Size(1044, 108);
            this.Grpİmza.TabIndex = 6;
            this.Grpİmza.TabStop = false;
            this.Grpİmza.Text = "İmza İçeriği";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "İmza:";
            // 
            // Txtİmza
            // 
            this.Txtİmza.Location = new System.Drawing.Point(188, 27);
            this.Txtİmza.Name = "Txtİmza";
            this.Txtİmza.Size = new System.Drawing.Size(803, 64);
            this.Txtİmza.TabIndex = 6;
            this.Txtİmza.Text = "";
            // 
            // ChcDuzenle
            // 
            this.ChcDuzenle.AutoSize = true;
            this.ChcDuzenle.Enabled = false;
            this.ChcDuzenle.Location = new System.Drawing.Point(62, 66);
            this.ChcDuzenle.Name = "ChcDuzenle";
            this.ChcDuzenle.Size = new System.Drawing.Size(92, 25);
            this.ChcDuzenle.TabIndex = 6;
            this.ChcDuzenle.Text = "Düzenle";
            this.ChcDuzenle.UseVisualStyleBackColor = true;
            // 
            // BtnGonder
            // 
            this.BtnGonder.BackColor = System.Drawing.Color.Green;
            this.BtnGonder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnGonder.Location = new System.Drawing.Point(845, 505);
            this.BtnGonder.Name = "BtnGonder";
            this.BtnGonder.Size = new System.Drawing.Size(177, 40);
            this.BtnGonder.TabIndex = 7;
            this.BtnGonder.Text = "Gönder";
            this.BtnGonder.UseVisualStyleBackColor = false;
            this.BtnGonder.Click += new System.EventHandler(this.BtnGonder_Click_1);
            // 
            // BtnKapat
            // 
            this.BtnKapat.BackColor = System.Drawing.Color.Maroon;
            this.BtnKapat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnKapat.Location = new System.Drawing.Point(28, 505);
            this.BtnKapat.Name = "BtnKapat";
            this.BtnKapat.Size = new System.Drawing.Size(177, 40);
            this.BtnKapat.TabIndex = 8;
            this.BtnKapat.Text = "İptal";
            this.BtnKapat.UseVisualStyleBackColor = false;
            this.BtnKapat.Click += new System.EventHandler(this.BtnKapat_Click_1);
            // 
            // FrmMailGonder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1044, 557);
            this.Controls.Add(this.BtnKapat);
            this.Controls.Add(this.BtnGonder);
            this.Controls.Add(this.Grpİmza);
            this.Controls.Add(this.GrpAlıcı);
            this.Controls.Add(this.GrpGonderici);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMailGonder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMailGonder";
            this.GrpGonderici.ResumeLayout(false);
            this.GrpGonderici.PerformLayout();
            this.GrpAlıcı.ResumeLayout(false);
            this.GrpAlıcı.PerformLayout();
            this.Grpİmza.ResumeLayout(false);
            this.Grpİmza.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpGonderici;
        private System.Windows.Forms.TextBox TxtGondericiMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GrpAlıcı;
        private System.Windows.Forms.TextBox TxtKonu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtAliciMail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox TxtMesaj;
        private System.Windows.Forms.GroupBox Grpİmza;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox Txtİmza;
        private System.Windows.Forms.CheckBox ChcDuzenle;
        private System.Windows.Forms.Button BtnGonder;
        private System.Windows.Forms.Button BtnKapat;
    }
}
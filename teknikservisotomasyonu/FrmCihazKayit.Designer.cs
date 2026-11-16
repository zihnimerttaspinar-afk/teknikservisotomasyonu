namespace teknikservisotomasyonu
{
    partial class FrmCihazKayit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnKapat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbDurum = new System.Windows.Forms.ComboBox();
            this.TxtArizaTahmin = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbMarka = new System.Windows.Forms.ComboBox();
            this.TxtSikayet = new System.Windows.Forms.RichTextBox();
            this.TxtModel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbCihazTuru = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtAdres = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.MskTelefon = new System.Windows.Forms.MaskedTextBox();
            this.TxtMail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtAdSoyad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtTc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnCihazKaydet = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.BtnKapat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 43);
            this.panel1.TabIndex = 0;
            // 
            // BtnKapat
            // 
            this.BtnKapat.BackColor = System.Drawing.Color.Maroon;
            this.BtnKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKapat.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnKapat.FlatAppearance.BorderSize = 0;
            this.BtnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKapat.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKapat.ForeColor = System.Drawing.Color.White;
            this.BtnKapat.Location = new System.Drawing.Point(1088, 0);
            this.BtnKapat.Name = "BtnKapat";
            this.BtnKapat.Size = new System.Drawing.Size(75, 43);
            this.BtnKapat.TabIndex = 1;
            this.BtnKapat.Text = "X";
            this.BtnKapat.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CmbDurum);
            this.groupBox1.Controls.Add(this.TxtArizaTahmin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CmbMarka);
            this.groupBox1.Controls.Add(this.TxtSikayet);
            this.groupBox1.Controls.Add(this.TxtModel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CmbCihazTuru);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 452);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cihaz Bilgileri";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 396);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Durumu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 63);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tahmini Arza:\r\n(Personel\r\nDolduracak)\r\n";
            // 
            // CmbDurum
            // 
            this.CmbDurum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CmbDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDurum.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbDurum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CmbDurum.FormattingEnabled = true;
            this.CmbDurum.Location = new System.Drawing.Point(164, 396);
            this.CmbDurum.Name = "CmbDurum";
            this.CmbDurum.Size = new System.Drawing.Size(157, 26);
            this.CmbDurum.TabIndex = 10;
       
            // 
            // TxtArizaTahmin
            // 
            this.TxtArizaTahmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtArizaTahmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtArizaTahmin.Font = new System.Drawing.Font("Tahoma", 9.2F);
            this.TxtArizaTahmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtArizaTahmin.Location = new System.Drawing.Point(164, 284);
            this.TxtArizaTahmin.MaxLength = 255;
            this.TxtArizaTahmin.Name = "TxtArizaTahmin";
            this.TxtArizaTahmin.Size = new System.Drawing.Size(157, 96);
            this.TxtArizaTahmin.TabIndex = 11;
            this.TxtArizaTahmin.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Şikayet:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Model:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Marka:";
            // 
            // CmbMarka
            // 
            this.CmbMarka.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CmbMarka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMarka.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbMarka.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CmbMarka.FormattingEnabled = true;
            this.CmbMarka.Location = new System.Drawing.Point(164, 88);
            this.CmbMarka.Name = "CmbMarka";
            this.CmbMarka.Size = new System.Drawing.Size(157, 26);
            this.CmbMarka.TabIndex = 8;
            // 
            // TxtSikayet
            // 
            this.TxtSikayet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtSikayet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtSikayet.Font = new System.Drawing.Font("Tahoma", 9.2F);
            this.TxtSikayet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtSikayet.Location = new System.Drawing.Point(164, 168);
            this.TxtSikayet.MaxLength = 255;
            this.TxtSikayet.Name = "TxtSikayet";
            this.TxtSikayet.Size = new System.Drawing.Size(157, 96);
            this.TxtSikayet.TabIndex = 6;
            this.TxtSikayet.Text = "";
            // 
            // TxtModel
            // 
            this.TxtModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtModel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtModel.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.TxtModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtModel.Location = new System.Drawing.Point(164, 132);
            this.TxtModel.Name = "TxtModel";
            this.TxtModel.Size = new System.Drawing.Size(157, 21);
            this.TxtModel.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cihaz Türü:";
            // 
            // CmbCihazTuru
            // 
            this.CmbCihazTuru.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CmbCihazTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCihazTuru.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbCihazTuru.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CmbCihazTuru.FormattingEnabled = true;
            this.CmbCihazTuru.Location = new System.Drawing.Point(164, 43);
            this.CmbCihazTuru.Name = "CmbCihazTuru";
            this.CmbCihazTuru.Size = new System.Drawing.Size(157, 26);
            this.CmbCihazTuru.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TxtAdres);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.MskTelefon);
            this.groupBox2.Controls.Add(this.TxtMail);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TxtAdSoyad);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TxtTc);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(476, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 452);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Müşteri Bilgileri";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(64, 205);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 21);
            this.label11.TabIndex = 19;
            this.label11.Text = "Adres :";
            // 
            // TxtAdres
            // 
            this.TxtAdres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtAdres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtAdres.Font = new System.Drawing.Font("Tahoma", 9.2F);
            this.TxtAdres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtAdres.Location = new System.Drawing.Point(146, 207);
            this.TxtAdres.MaxLength = 255;
            this.TxtAdres.Name = "TxtAdres";
            this.TxtAdres.Size = new System.Drawing.Size(157, 96);
            this.TxtAdres.TabIndex = 18;
            this.TxtAdres.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(52, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 21);
            this.label10.TabIndex = 17;
            this.label10.Text = "Telefon :";
            // 
            // MskTelefon
            // 
            this.MskTelefon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MskTelefon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MskTelefon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MskTelefon.Location = new System.Drawing.Point(146, 168);
            this.MskTelefon.Mask = "(999) 000-0000";
            this.MskTelefon.Name = "MskTelefon";
            this.MskTelefon.Size = new System.Drawing.Size(157, 21);
            this.MskTelefon.TabIndex = 16;
            // 
            // TxtMail
            // 
            this.TxtMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtMail.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.TxtMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtMail.Location = new System.Drawing.Point(146, 132);
            this.TxtMail.MaxLength = 11;
            this.TxtMail.Name = "TxtMail";
            this.TxtMail.Size = new System.Drawing.Size(157, 21);
            this.TxtMail.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(61, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 21);
            this.label9.TabIndex = 14;
            this.label9.Text = "E-Mail :";
            // 
            // TxtAdSoyad
            // 
            this.TxtAdSoyad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtAdSoyad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtAdSoyad.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.TxtAdSoyad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtAdSoyad.Location = new System.Drawing.Point(146, 93);
            this.TxtAdSoyad.MaxLength = 11;
            this.TxtAdSoyad.Name = "TxtAdSoyad";
            this.TxtAdSoyad.Size = new System.Drawing.Size(157, 21);
            this.TxtAdSoyad.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 21);
            this.label8.TabIndex = 12;
            this.label8.Text = "Adı Soyadı :";
            // 
            // TxtTc
            // 
            this.TxtTc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtTc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTc.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.TxtTc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtTc.Location = new System.Drawing.Point(146, 43);
            this.TxtTc.MaxLength = 11;
            this.TxtTc.Name = "TxtTc";
            this.TxtTc.Size = new System.Drawing.Size(157, 21);
            this.TxtTc.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "Müşteri T.C :";
            // 
            // BtnCihazKaydet
            // 
            this.BtnCihazKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnCihazKaydet.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCihazKaydet.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnCihazKaydet.Location = new System.Drawing.Point(855, 495);
            this.BtnCihazKaydet.Name = "BtnCihazKaydet";
            this.BtnCihazKaydet.Size = new System.Drawing.Size(197, 41);
            this.BtnCihazKaydet.TabIndex = 20;
            this.BtnCihazKaydet.Text = "Cihaz Girişini Kaydet";
            this.BtnCihazKaydet.UseVisualStyleBackColor = false;
            this.BtnCihazKaydet.Click += new System.EventHandler(this.BtnCihazKaydet_Click);
            // 
            // FrmCihazKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1163, 600);
            this.Controls.Add(this.BtnCihazKaydet);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCihazKayit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cihaz İşlemleri";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmCihazKayit_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnKapat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox TxtSikayet;
        private System.Windows.Forms.TextBox TxtModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbCihazTuru;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbMarka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox TxtArizaTahmin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbDurum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtTc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox MskTelefon;
        private System.Windows.Forms.TextBox TxtMail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtAdSoyad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox TxtAdres;
        private System.Windows.Forms.Button BtnCihazKaydet;
    }
}
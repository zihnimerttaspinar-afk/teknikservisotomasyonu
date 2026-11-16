using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace teknikservisotomasyonu
{
    public partial class FrmMailGonder : Form
    {
        string gondericiMail = "";
        string gondericiMailSifre = "";
        string sirketAdi = "";

        public FrmMailGonder()
        {
            InitializeComponent();

            // Olay (Event) bağlantılarını otomatik kur
            this.Load -= FrmMailGonder_Load;
            this.Load += FrmMailGonder_Load;

            ChcDuzenle.CheckedChanged -= ChcDuzenle_CheckedChanged;
            ChcDuzenle.CheckedChanged += ChcDuzenle_CheckedChanged;

            BtnKapat.Click -= BtnKapat_Click;
            BtnKapat.Click += BtnKapat_Click;

            BtnGonder.Click -= BtnGonder_Click;
            BtnGonder.Click += BtnGonder_Click;
        }

        void doldur()
        {
            try
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();

                SqlCommand kmd = new SqlCommand("Select * from Sistem", Ayar.con);
                Ayar.con.Open();
                SqlDataReader dr = kmd.ExecuteReader();
                if (dr.Read())
                {
                    TxtGondericiMail.Text = dr["SirketGonderenMail"].ToString();
                    gondericiMail = dr["SirketGonderenMail"].ToString();
                    sirketAdi = dr["SirketAdi"].ToString();
                    gondericiMailSifre = dr["GonderenMailSifre"].ToString();

                    Txtİmza.Text = dr["SirketAdi"].ToString() + "\n" +
                                   "Telefon : " + dr["SirketTelefon"].ToString() + "\n" +
                                   "Fax : " + dr["SirketFax"].ToString() + "\n" +
                                   "Mail : " + dr["SirketMail"].ToString() + "\n" +
                                   "Adres : " + dr["SirketAdres"].ToString();
                }
                dr.Close();
                Ayar.con.Close();
            }
            catch (Exception ex)
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                MessageBox.Show("Sistem bilgileri çekilirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMailGonder_Load(object sender, EventArgs e)
        {
            TxtGondericiMail.Text = "";
            TxtAliciMail.Text = "";
            TxtKonu.Text = "";
            TxtMesaj.Text = "";
            doldur();
        }

        private void ChcDuzenle_CheckedChanged(object sender, EventArgs e)
        {
            if (ChcDuzenle.Checked == true)
                Txtİmza.Enabled = true;
            else
                Txtİmza.Enabled = false;
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtAliciMail.Text) || string.IsNullOrWhiteSpace(TxtKonu.Text) || string.IsNullOrWhiteSpace(TxtMesaj.Text))
            {
                MessageBox.Show("Lütfen alıcı mail, konu ve mesaj alanlarını doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MailMessage ePosta = new MailMessage();
                ePosta.From = new MailAddress(gondericiMail, sirketAdi);
                ePosta.To.Add(TxtAliciMail.Text.Trim());
                ePosta.Subject = TxtKonu.Text;
                ePosta.Body = TxtMesaj.Text + Environment.NewLine + Environment.NewLine + Txtİmza.Text;

                SmtpClient smtp = new SmtpClient();
                string cozulmusSifre = Ayar.sifreCoz(gondericiMailSifre, Ayar.anahtarkelime);
                smtp.Credentials = new NetworkCredential(gondericiMail, cozulmusSifre);
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;

                smtp.Send(ePosta);
                MessageBox.Show("Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderilemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnKapat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGonder_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtAliciMail.Text) || string.IsNullOrWhiteSpace(TxtKonu.Text) || string.IsNullOrWhiteSpace(TxtMesaj.Text))
            {
                MessageBox.Show("Lütfen alıcı mail, konu ve mesaj alanlarını doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MailMessage ePosta = new MailMessage();
                ePosta.From = new MailAddress(gondericiMail, sirketAdi);
                ePosta.To.Add(TxtAliciMail.Text.Trim());
                ePosta.Subject = TxtKonu.Text;
                ePosta.Body = TxtMesaj.Text + Environment.NewLine + Environment.NewLine + Txtİmza.Text;

                SmtpClient smtp = new SmtpClient();
                string cozulmusSifre = Ayar.sifreCoz(gondericiMailSifre, Ayar.anahtarkelime);
                smtp.Credentials = new NetworkCredential(gondericiMail, cozulmusSifre);
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;

                smtp.Send(ePosta);
                MessageBox.Show("Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderilemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
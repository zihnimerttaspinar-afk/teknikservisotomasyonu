using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace teknikservisotomasyonu
{
    public partial class FrmAnasayfa : Form
    {
        bool iletisimvar = false;

        public FrmAnasayfa()
        {
            InitializeComponent();

            // Olay (Event) bağlantılarını otomatik kur
            LstPersonelDuzenlePersoneller.DoubleClick -= LstPersonelDuzenlePersoneller_DoubleClick;
            LstPersonelDuzenlePersoneller.DoubleClick += LstPersonelDuzenlePersoneller_DoubleClick;

            BtnPersonelDuzenleGuncelle.Click -= BtnPersonelDuzenleGuncelle_Click;
            BtnPersonelDuzenleGuncelle.Click += BtnPersonelDuzenleGuncelle_Click;

            BtnPersonelDuzenleSil.Click -= BtnPersonelDuzenleSil_Click;
            BtnPersonelDuzenleSil.Click += BtnPersonelDuzenleSil_Click;

            BtnPersonelEkleKaydet.Click -= BtnPersonelEkleKaydet_Click;
            BtnPersonelEkleKaydet.Click += BtnPersonelEkleKaydet_Click;

            BtnSirketBilgileriveLimitler.Click -= BtnSirketBilgileriveLimitler_Click;
            BtnSirketBilgileriveLimitler.Click += BtnSirketBilgileriveLimitler_Click;

            BtnBilgiKaydet.Click -= BtnBilgiKaydet_Click;
            BtnBilgiKaydet.Click += BtnBilgiKaydet_Click;

            BtnCariGuncelle.Click -= BtnCariGuncelle_Click;
            BtnCariGuncelle.Click += BtnCariGuncelle_Click;

            BtnIslemEkle.Click -= BtnIslemEkle_Click;
            BtnIslemEkle.Click += BtnIslemEkle_Click;

            BtnIslemSil.Click -= BtnIslemSil_Click;
            BtnIslemSil.Click += BtnIslemSil_Click;

            BtnCihazKayit.Click -= BtnCihazKayit_Click;
            BtnCihazKayit.Click += BtnCihazKayit_Click;

            BtnMailGonder.Click -= BtnMailGonder_Click;
            BtnMailGonder.Click += BtnMailGonder_Click;
        }

        void yetkidoldur()
        {
            if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Yetkilendirme", Ayar.con);
            Ayar.con.Open();
            DataTable table = new DataTable();
            adtr.Fill(table);

            CmbYetkiler.DataSource = null;
            CmbYetkiler.DisplayMember = "YetkiAdi";
            CmbYetkiler.ValueMember = "Yetkiid";
            CmbYetkiler.DataSource = table;
            CmbYetkiler.SelectedValue = -1;

            CmbPersonelEkleYetki.DataSource = null;
            CmbPersonelEkleYetki.DisplayMember = "YetkiAdi";
            CmbPersonelEkleYetki.ValueMember = "Yetkiid";
            CmbPersonelEkleYetki.DataSource = table;
            CmbPersonelEkleYetki.SelectedValue = -1;

            CmbPersonelDuzenleYetki.DataSource = null;
            CmbPersonelDuzenleYetki.DisplayMember = "YetkiAdi";
            CmbPersonelDuzenleYetki.ValueMember = "Yetkiid";
            CmbPersonelDuzenleYetki.DataSource = table;
            CmbPersonelDuzenleYetki.SelectedValue = -1;

            ChcCarilIslemler.Checked = false;
            ChcKayitAcma.Checked = false;
            ChcKayitTamamlama.Checked = false;
            ChcPersonelEkleme.Checked = false;
            ChcPersonelSilme.Checked = false;
            ChcSistemAyarlari.Checked = false;
            ChcYedekParca.Checked = false;

            Ayar.con.Close();
        }

        void personeldoldur()
        {
            if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Personel WHERE Silindi = 0 OR Silindi IS NULL", Ayar.con);
            Ayar.con.Open();
            DataTable table = new DataTable();
            adtr.Fill(table);

            LstPersonelDuzenlePersoneller.DataSource = null;
            LstPersonelDuzenlePersoneller.DisplayMember = "AdiSoyadi";
            LstPersonelDuzenlePersoneller.ValueMember = "PersonelNo";
            LstPersonelDuzenlePersoneller.DataSource = table;

            Ayar.con.Close();
        }

        void personelekletemizle()
        {
            TxtPersonelEkleTC.Clear();
            TxtPersonelEkleKullaniciAdi.Clear();
            PersonelEkleAdiSoyadi.Clear();
            PersonelEkleTelefon.Clear();
            PersonelEkleEmail.Clear();
            PersonelEkleGorevi.Clear();
            CmbPersonelEkleYetki.SelectedValue = -1;
            PersonelEkleAdres.Clear();
            PersonelEklemaas.Clear();
            PersonelEkleSifre.Clear();
        }

        void personelduzenletemizle()
        {
            TxtPersonelDuzenleNo.Clear();
            TxtPersonelDuzenleTC.Clear();
            TxtPersonelDuzenleKullaniciAdi.Clear();
            TxtPersonelDuzenleAdiSoyadi.Clear();
            TxtPersonelDuzenleTelefon.Clear();
            TxtPersonelDuzenleEmail.Clear();
            TxtPersonelDuzenleGorevi.Clear();
            CmbPersonelDuzenleYetki.SelectedValue = -1;
            TxtPersonelDuzenleMaas.Clear();
            TxtPersonelDuzenleSifre.Clear();
        }

        void cihazdoldur()
        {
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Cihazlar WHERE Silindi = 0", Ayar.con);
            Ayar.con.Open();
            DataTable table = new DataTable();
            adtr.Fill(table);
            LstCihazİslemleriCihazAdi.DataSource = null;
            LstCihazİslemleriCihazAdi.DisplayMember = "CihazAdi";
            LstCihazİslemleriCihazAdi.ValueMember = "cihazid";
            LstCihazİslemleriCihazAdi.DataSource = table;
            Ayar.con.Close();
        }

        void kategoridoldur()
        {
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From YedekParcaKategori WHERE Silindi = 0", Ayar.con);
            Ayar.con.Open();
            DataTable table = new DataTable();
            adtr.Fill(table);
            lstYedekParcaKategoriİslemleri.DisplayMember = "KategoriAdi";
            lstYedekParcaKategoriİslemleri.ValueMember = "KategoriId";
            lstYedekParcaKategoriİslemleri.DataSource = table;

            LstYedekParcaİslemleri.DataSource = null;
            LstYedekParcaİslemleri.DisplayMember = "KategoriAdi";
            LstYedekParcaİslemleri.ValueMember = "KategoriId";
            LstYedekParcaİslemleri.DataSource = table;

            CmbYedekParçaİslemleriKategori.DataSource = null;
            CmbYedekParçaİslemleriKategori.DisplayMember = "KategoriAdi";
            CmbYedekParçaİslemleriKategori.ValueMember = "KategoriId";
            CmbYedekParçaİslemleriKategori.DataSource = table;

            CmbYedekParçaİslemleriKategori.SelectedValue = -1;
            Ayar.con.Close();
        }

        void markadoldur()
        {
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Marka WHERE Silindi = 0", Ayar.con);
            Ayar.con.Open();
            DataTable table = new DataTable();
            adtr.Fill(table);

            LstMarkaIslemleriMarkalar.DataSource = null;
            LstMarkaIslemleriMarkalar.DisplayMember = "MarkaAdi";
            LstMarkaIslemleriMarkalar.ValueMember = "Markaid";
            LstMarkaIslemleriMarkalar.DataSource = table;

            CmbYedekParçaİslemleriMarka.DataSource = null;
            CmbYedekParçaİslemleriMarka.DisplayMember = "MarkaAdi";
            CmbYedekParçaİslemleriMarka.ValueMember = "Markaid";
            CmbYedekParçaİslemleriMarka.DataSource = table;

            CmbYedekParçaİslemleriMarka.SelectedValue = -1;
            Ayar.con.Close();
        }

        void panellerikapat()
        {
            PnlMarkaIslemleri.Visible = false;
            PnlCihazIslemleri.Visible = false;
            PnlYedekParcaKategori.Visible = false;
            PnlYedekParcaIslemleri.Visible = false;
            PnlYetkiIslemleri.Visible = false;
            PnlPersonelDuzenle.Visible = false;
            PnlPersonelEkle.Visible = false;
            PnlSirketBilgileri.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PnlCihaz.Visible == true)
            {
                PnlCihaz.Visible = false;
                button1.BackColor = Color.FromArgb(30, 30, 40);
            }
            else
            {
                button2.BackColor = Color.Linen;
                button1.BackColor = Color.Linen;
                button2.BackColor = Color.FromArgb(30, 30, 40);
                button3.BackColor = Color.FromArgb(30, 30, 40);
                button4.BackColor = Color.FromArgb(30, 30, 40);
                button5.BackColor = Color.FromArgb(30, 30, 40);
                PnlCihaz.Visible = true;
                PnlPersonel.Visible = false;
                PnlSistem.Visible = false;
                PnlCari.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (PnlCari.Visible == true)
            {
                PnlCari.Visible = false;
                button5.BackColor = Color.FromArgb(30, 30, 40);
            }
            else
            {
                button5.BackColor = Color.Linen;
                button1.BackColor = Color.FromArgb(30, 30, 40);
                button3.BackColor = Color.FromArgb(30, 30, 40);
                button4.BackColor = Color.FromArgb(30, 30, 40);
                button2.BackColor = Color.FromArgb(30, 30, 40);
                PnlCihaz.Visible = false;
                PnlPersonel.Visible = false;
                PnlSistem.Visible = false;
                PnlCari.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PnlPersonel.Visible == true)
            {
                PnlPersonel.Visible = false;
                button2.BackColor = Color.FromArgb(30, 30, 40);
            }
            else
            {
                button2.BackColor = Color.Linen;
                button1.BackColor = Color.FromArgb(30, 30, 40);
                button3.BackColor = Color.FromArgb(30, 30, 40);
                button4.BackColor = Color.FromArgb(30, 30, 40);
                button5.BackColor = Color.FromArgb(30, 30, 40);
                PnlCihaz.Visible = false;
                PnlPersonel.Visible = true;
                PnlSistem.Visible = false;
                PnlCari.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (PnlSistem.Visible == true)
            {
                PnlSistem.Visible = false;
                button4.BackColor = Color.FromArgb(30, 30, 40);
            }
            else
            {
                button4.BackColor = Color.Linen;
                button1.BackColor = Color.FromArgb(30, 30, 40);
                button3.BackColor = Color.FromArgb(30, 30, 40);
                button2.BackColor = Color.FromArgb(30, 30, 40);
                button5.BackColor = Color.FromArgb(30, 30, 40);
                PnlCihaz.Visible = false;
                PnlPersonel.Visible = false;
                PnlSistem.Visible = true;
                PnlCari.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        private void BtnCihazKaydi_Click(object sender, EventArgs e)
        {
            FrmCihazKayit frm = new FrmCihazKayit();
            frm.Show();
        }

        private void BtnMarkaIslemleri_Click(object sender, EventArgs e)
        {
            markadoldur();
            TxtMarkaIslemleriMarkaAdi.Text = "";
            LblMarkaIslemleriMarkaId.Text = "";
            panellerikapat();
            PnlMarkaIslemleri.Visible = true;

            BtnMarkaGuncelle.Enabled = false;
            BtnMarkaSil.Enabled = false;
            BtnYeniMarka.Enabled = true;
        }

        private void BtnModelIslemleri_Click(object sender, EventArgs e)
        {
            panellerikapat();
        }

        private void BtnCihazIslemleri_Click(object sender, EventArgs e)
        {
            cihazdoldur();
            TxtCihazİslemleriCihazAdi.Text = "";
            LblCihazİslemleriCihazId.Text = "";
            panellerikapat();
            PnlCihazIslemleri.Visible = true;

            BtnCihazİslemleriCihazGuncelle.Enabled = false;
            BtnCihazİslemleriCihazSil.Enabled = false;
            BtnCihazİslemleriYeniCihaz.Enabled = true;
        }

        private void BtnYedekParcaKategori_Click(object sender, EventArgs e)
        {
            kategoridoldur();
            markadoldur();
            TxtYedekParcaKategoriİslemleriKtAdi.Text = "";
            LblYedekParcaKategoriİslemleriKtid.Text = "";
            panellerikapat();
            PnlYedekParcaKategori.Visible = true;

            BtnYedekParcaKategoriİslemleriGuncelle.Enabled = false;
            BtnYedekParcaKategoriİslemleriSil.Enabled = false;
            BtnYedekParcaKategoriİslemleriYeniKategori.Enabled = true;
        }

        private void BtnYedekParcaIslemleri_Click(object sender, EventArgs e)
        {
            kategoridoldur();
            LblYedekParcaİslemleriİslemler.Text = "KATEGORİLER";
            LblYedekParcaİslemleriİslemler.BackColor = Color.Tomato;

            LblYedekParcaİslemleriYedekParcaId.Text = "";
            TxtYedekParcaİslemleriModel.Text = "";
            TxtYedekParcaİslemleriStok.Text = "";
            TxtYedekParcaİşlemleriEkÖzellikler.Text = "";

            BtnYedekParcaGüncelle.Enabled = false;
            BtnYedekParcaİslemlerSil.Enabled = false;
            BtnYedekParcaİslemleriYeniYedekParca.Enabled = true;

            panellerikapat();
            PnlYedekParcaIslemleri.Visible = true;
        }

        private void BtnYetkiIslemleri_Click(object sender, EventArgs e)
        {
            yetkidoldur();
            panellerikapat();
            PnlYetkiIslemleri.Visible = true;
        }

        private void LstMarkaIslemleriMarkalar_DoubleClick(object sender, EventArgs e)
        {
            BtnMarkaGuncelle.Enabled = true;
            BtnMarkaSil.Enabled = true;
            BtnYeniMarka.Enabled = false;
            TxtMarkaIslemleriMarkaAdi.Text = LstMarkaIslemleriMarkalar.Text;
            LblMarkaIslemleriMarkaId.Text = LstMarkaIslemleriMarkalar.SelectedValue.ToString();
        }

        private void BtnMarkaSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Marka set Silindi = 1 where Markaid = @p1", Ayar.con);
            cmd.Parameters.AddWithValue("@p1", LblMarkaIslemleriMarkaId.Text);
            Ayar.con.Open();
            cmd.ExecuteNonQuery();
            Ayar.con.Close();
            TxtMarkaIslemleriMarkaAdi.Text = "";
            LblMarkaIslemleriMarkaId.Text = "";
            BtnMarkaGuncelle.Enabled = false;
            BtnMarkaSil.Enabled = false;
            BtnYeniMarka.Enabled = true;

            markadoldur();
        }

        private void BtnYeniMarka_Click(object sender, EventArgs e)
        {
            if (TxtMarkaIslemleriMarkaAdi.Text == "")
            {
                MessageBox.Show("Lütfen marka adı alanını doldurunuz.", "Boş Alan Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into Marka (MarkaAdi) values (@p1)", Ayar.con);
                    cmd.Parameters.AddWithValue("@p1", TxtMarkaIslemleriMarkaAdi.Text.ToUpper());
                    Ayar.con.Open();
                    cmd.ExecuteNonQuery();
                    Ayar.con.Close();
                    markadoldur();
                    TxtMarkaIslemleriMarkaAdi.Text = "";
                    LblMarkaIslemleriMarkaId.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemsel hata oluştu. Daha sonra tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnMarkaGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtMarkaIslemleriMarkaAdi.Text == "" || LblMarkaIslemleriMarkaId.Text == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz yada marka seçiniz.", "Boş Alan Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Update Marka Set MarkaAdi = @p1 where Markaid = @p2", Ayar.con);
                    cmd.Parameters.AddWithValue("@p1", TxtMarkaIslemleriMarkaAdi.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@p2", LblMarkaIslemleriMarkaId.Text);
                    Ayar.con.Open();
                    cmd.ExecuteNonQuery();
                    Ayar.con.Close();
                    markadoldur();
                    TxtMarkaIslemleriMarkaAdi.Text = "";
                    LblMarkaIslemleriMarkaId.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemsel hata oluştu. Daha sonra tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LstCihazİslemleriCihazAdi_DoubleClick(object sender, EventArgs e)
        {
            BtnCihazİslemleriCihazGuncelle.Enabled = true;
            BtnCihazİslemleriCihazSil.Enabled = true;
            BtnCihazİslemleriYeniCihaz.Enabled = false;
            TxtCihazİslemleriCihazAdi.Text = LstCihazİslemleriCihazAdi.Text;
            LblCihazİslemleriCihazId.Text = LstCihazİslemleriCihazAdi.SelectedValue.ToString();
        }

        private void BtnCihazİslemleriYeniCihaz_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Insert into Cihazlar (CihazAdi) values (@p1)", Ayar.con);
                cmd.Parameters.AddWithValue("@p1", TxtCihazİslemleriCihazAdi.Text.ToUpper());
                Ayar.con.Open();
                cmd.ExecuteNonQuery();
                Ayar.con.Close();
                TxtCihazİslemleriCihazAdi.Text = "";
                LblCihazİslemleriCihazId.Text = "";
                cihazdoldur();
            }
            catch (Exception)
            {
                Ayar.con.Close();
                MessageBox.Show("Sistemsel hata oluştu, lütfen daha sonra tekrar deneyin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCihazİslemleriCihazGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblCihazİslemleriCihazId.Text == "" || TxtCihazİslemleriCihazAdi.Text == "")
                {
                    MessageBox.Show("Boş alan bırakmayınız", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Update Cihazlar set CihazAdi = @p1 Where cihazid = @p2", Ayar.con);
                    cmd.Parameters.AddWithValue("@p1", TxtCihazİslemleriCihazAdi.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@p2", LblCihazİslemleriCihazId.Text);
                    Ayar.con.Open();
                    cmd.ExecuteNonQuery();
                    Ayar.con.Close();
                    TxtCihazİslemleriCihazAdi.Text = "";
                    LblCihazİslemleriCihazId.Text = "";
                    cihazdoldur();
                }
            }
            catch (Exception)
            {
                Ayar.con.Close();
                MessageBox.Show("Sistemsel hata oluştu, lütfen daha sonra tekrar deneyin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCihazİslemleriCihazSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblCihazİslemleriCihazId.Text == "" || TxtCihazİslemleriCihazAdi.Text == "")
                {
                    MessageBox.Show("Boş alan bırakmayınız", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Update Cihazlar set Silindi = @p1 Where cihazid = @p2", Ayar.con);
                    cmd.Parameters.AddWithValue("@p1", "1");
                    cmd.Parameters.AddWithValue("@p2", LblCihazİslemleriCihazId.Text);
                    Ayar.con.Open();
                    cmd.ExecuteNonQuery();
                    Ayar.con.Close();
                    TxtCihazİslemleriCihazAdi.Text = "";
                    LblCihazİslemleriCihazId.Text = "";
                    cihazdoldur();
                }
            }
            catch (Exception)
            {
                Ayar.con.Close();
                MessageBox.Show("Sistemsel hata oluştu, lütfen daha sonra tekrar deneyin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LstCihazİslemleriCihazAdi_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void lstYedekParcaKategoriİslemleri_SelectedIndexChanged(object sender, EventArgs e) { }

        private void lstYedekParcaKategoriİslemleri_DoubleClick(object sender, EventArgs e)
        {
            BtnYedekParcaKategoriİslemleriGuncelle.Enabled = true;
            BtnYedekParcaKategoriİslemleriSil.Enabled = true;
            BtnYedekParcaKategoriİslemleriYeniKategori.Enabled = false;
            TxtYedekParcaKategoriİslemleriKtAdi.Text = lstYedekParcaKategoriİslemleri.Text;
            LblYedekParcaKategoriİslemleriKtid.Text = lstYedekParcaKategoriİslemleri.SelectedValue.ToString();
        }

        private void BtnYedekParcaKategoriİslemleriYeniKategori_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtYedekParcaKategoriİslemleriKtAdi.Text == "")
                {
                    MessageBox.Show("Boş alan bırakmayınız", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Insert into YedekParcaKategori (KategoriAdi) values (@p1)", Ayar.con);
                    cmd.Parameters.AddWithValue("@p1", TxtYedekParcaKategoriİslemleriKtAdi.Text.ToUpper());
                    Ayar.con.Open();
                    cmd.ExecuteNonQuery();
                    Ayar.con.Close();
                    TxtYedekParcaKategoriİslemleriKtAdi.Text = "";
                    LblYedekParcaKategoriİslemleriKtid.Text = "";
                    kategoridoldur();
                }
            }
            catch (Exception)
            {
                Ayar.con.Close();
                MessageBox.Show("Sistemsel hata oluştu, lütfen daha sonra tekrar deneyin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnYedekParcaKategoriİslemleriGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblYedekParcaKategoriİslemleriKtid.Text == "" || TxtYedekParcaKategoriİslemleriKtAdi.Text == "")
                {
                    MessageBox.Show("Boş alan bırakmayınız", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Update YedekParcaKategori set KategoriAdi = @p1 Where KategoriId = @p2", Ayar.con);
                    cmd.Parameters.AddWithValue("@p1", TxtYedekParcaKategoriİslemleriKtAdi.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@p2", LblYedekParcaKategoriİslemleriKtid.Text);
                    Ayar.con.Open();
                    cmd.ExecuteNonQuery();
                    Ayar.con.Close();
                    TxtYedekParcaKategoriİslemleriKtAdi.Text = "";
                    LblYedekParcaKategoriİslemleriKtid.Text = "";
                    kategoridoldur();
                }
            }
            catch (Exception)
            {
                Ayar.con.Close();
                MessageBox.Show("Sistemsel hata oluştu, lütfen daha sonra tekrar deneyin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnYedekParcaKategoriİslemleriSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblYedekParcaKategoriİslemleriKtid.Text == "" || TxtYedekParcaKategoriİslemleriKtAdi.Text == "")
                {
                    MessageBox.Show("Boş alan bırakmayınız", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Update YedekParcaKategori set Silindi = @p1 Where KategoriId = @p2", Ayar.con);
                    cmd.Parameters.AddWithValue("@p1", "1");
                    cmd.Parameters.AddWithValue("@p2", LblYedekParcaKategoriİslemleriKtid.Text);
                    Ayar.con.Open();
                    cmd.ExecuteNonQuery();
                    Ayar.con.Close();
                    TxtYedekParcaKategoriİslemleriKtAdi.Text = "";
                    LblYedekParcaKategoriİslemleriKtid.Text = "";
                    kategoridoldur();
                }
            }
            catch (Exception)
            {
                Ayar.con.Close();
                MessageBox.Show("Sistemsel hata oluştu, lütfen daha sonra tekrar deneyin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }

        private void LstYedekParcaİslemleri_DoubleClick(object sender, EventArgs e)
        {
            if (LblYedekParcaİslemleriİslemler.Text == "KATEGORİLER")
            {
                int id = int.Parse(LstYedekParcaİslemleri.SelectedValue.ToString());
                LstYedekParcaİslemleri.DataSource = null;
                LblYedekParcaİslemleriİslemler.Text = "MODELLER";
                LblYedekParcaİslemleriİslemler.BackColor = Color.DarkGreen;
                SqlDataAdapter adtr = new SqlDataAdapter("Select * From YedekParca where Kategori =" + id + "", Ayar.con);
                DataTable table = new DataTable();
                Ayar.con.Open();
                adtr.Fill(table);
                LstYedekParcaİslemleri.DisplayMember = "Model";
                LstYedekParcaİslemleri.ValueMember = "YedekParcaId";
                LstYedekParcaİslemleri.DataSource = table;
                Ayar.con.Close();
            }
            else if (LblYedekParcaİslemleriİslemler.Text == "MODELLER")
            {
                LblYedekParcaİslemleriYedekParcaId.Text = LstYedekParcaİslemleri.SelectedValue.ToString();
                SqlCommand cmd = new SqlCommand("Select * From YedekParca Where YedekParcaId = @p1", Ayar.con);
                Ayar.con.Open();
                cmd.Parameters.AddWithValue("@p1", LblYedekParcaİslemleriYedekParcaId.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    TxtYedekParcaİslemleriModel.Text = dr["Model"].ToString();
                    TxtYedekParcaİslemleriStok.Text = dr["Stok"].ToString();
                    TxtYedekParcaİşlemleriEkÖzellikler.Text = dr["EkÖzellikler"].ToString();
                    CmbYedekParçaİslemleriKategori.SelectedValue = dr["Kategori"].ToString();
                    CmbYedekParçaİslemleriMarka.SelectedValue = dr["Marka"].ToString();
                    BtnYedekParcaGüncelle.Enabled = true;
                    BtnYedekParcaİslemlerSil.Enabled = true;
                    BtnYedekParcaİslemleriYeniYedekParca.Enabled = false;
                }
                Ayar.con.Close();
            }
        }

        private void BtnYedekParcaİslemleriYeniYedekParca_Click(object sender, EventArgs e)
        {
            if (TxtYedekParcaİslemleriModel.Text != "" && TxtYedekParcaİslemleriStok.Text != "" && TxtYedekParcaİşlemleriEkÖzellikler.Text != "" && CmbYedekParçaİslemleriKategori.Text != "" && CmbYedekParçaİslemleriMarka.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Insert into YedekParca (Kategori,Marka,Model,Stok,EkÖzellikler) values (@p1,@p2,@p3,@p4,@p5)", Ayar.con);
                cmd.Parameters.AddWithValue("@p1", CmbYedekParçaİslemleriKategori.SelectedValue);
                cmd.Parameters.AddWithValue("@p2", CmbYedekParçaİslemleriMarka.SelectedValue);
                cmd.Parameters.AddWithValue("@p3", TxtYedekParcaİslemleriModel.Text.ToUpper());
                cmd.Parameters.AddWithValue("@p4", TxtYedekParcaİslemleriStok.Text);
                cmd.Parameters.AddWithValue("@p5", TxtYedekParcaİşlemleriEkÖzellikler.Text);
                Ayar.con.Open();
                cmd.ExecuteNonQuery();
                Ayar.con.Close();
                kategoridoldur();
                markadoldur();
                LblYedekParcaİslemleriİslemler.Text = "KATEGORİLER";
                LblYedekParcaİslemleriİslemler.BackColor = Color.Tomato;
                LblYedekParcaİslemleriYedekParcaId.Text = "";
                TxtYedekParcaİslemleriModel.Text = "";
                TxtYedekParcaİslemleriStok.Text = "";
                TxtYedekParcaİşlemleriEkÖzellikler.Text = "";
                BtnYedekParcaGüncelle.Enabled = false;
                BtnYedekParcaİslemlerSil.Enabled = false;
                BtnYedekParcaİslemleriYeniYedekParca.Enabled = true;
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnYedekParcaGüncelle_Click(object sender, EventArgs e)
        {
            if (LblYedekParcaİslemleriYedekParcaId.Text != "" && TxtYedekParcaİslemleriModel.Text != "" && TxtYedekParcaİslemleriStok.Text != "" && TxtYedekParcaİşlemleriEkÖzellikler.Text != "" && CmbYedekParçaİslemleriKategori.Text != "" && CmbYedekParçaİslemleriMarka.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Update YedekParca Set Kategori = @p1, Marka=@p2, Model=@p3, Stok=@p4, EkÖzellikler = @p5 where YedekParcaId = @p6", Ayar.con);
                cmd.Parameters.AddWithValue("@p1", CmbYedekParçaİslemleriKategori.SelectedValue);
                cmd.Parameters.AddWithValue("@p2", CmbYedekParçaİslemleriMarka.SelectedValue);
                cmd.Parameters.AddWithValue("@p3", TxtYedekParcaİslemleriModel.Text.ToUpper());
                cmd.Parameters.AddWithValue("@p4", TxtYedekParcaİslemleriStok.Text);
                cmd.Parameters.AddWithValue("@p5", TxtYedekParcaİşlemleriEkÖzellikler.Text);
                cmd.Parameters.AddWithValue("@p6", LblYedekParcaİslemleriYedekParcaId.Text);
                Ayar.con.Open();
                cmd.ExecuteNonQuery();
                Ayar.con.Close();
                kategoridoldur();
                markadoldur();
                LblYedekParcaİslemleriİslemler.Text = "KATEGORİLER";
                LblYedekParcaİslemleriİslemler.BackColor = Color.Tomato;
                LblYedekParcaİslemleriYedekParcaId.Text = "";
                TxtYedekParcaİslemleriModel.Text = "";
                TxtYedekParcaİslemleriStok.Text = "";
                TxtYedekParcaİşlemleriEkÖzellikler.Text = "";
                BtnYedekParcaGüncelle.Enabled = false;
                BtnYedekParcaİslemlerSil.Enabled = false;
                BtnYedekParcaİslemleriYeniYedekParca.Enabled = true;
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnYedekParcaİslemlerSil_Click(object sender, EventArgs e)
        {
            if (LblYedekParcaİslemleriYedekParcaId.Text != "" && TxtYedekParcaİslemleriModel.Text != "" && TxtYedekParcaİslemleriStok.Text != "" && TxtYedekParcaİşlemleriEkÖzellikler.Text != "" && CmbYedekParçaİslemleriKategori.Text != "" && CmbYedekParçaİslemleriMarka.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Delete From YedekParca where YedekParcaId = @p1", Ayar.con);
                cmd.Parameters.AddWithValue("@p1", LblYedekParcaİslemleriYedekParcaId.Text);
                Ayar.con.Open();
                cmd.ExecuteNonQuery();
                Ayar.con.Close();
                kategoridoldur();
                markadoldur();
                LblYedekParcaİslemleriİslemler.Text = "KATEGORİLER";
                LblYedekParcaİslemleriİslemler.BackColor = Color.Tomato;
                LblYedekParcaİslemleriYedekParcaId.Text = "";
                TxtYedekParcaİslemleriModel.Text = "";
                TxtYedekParcaİslemleriStok.Text = "";
                TxtYedekParcaİşlemleriEkÖzellikler.Text = "";
                BtnYedekParcaGüncelle.Enabled = false;
                BtnYedekParcaİslemlerSil.Enabled = false;
                BtnYedekParcaİslemleriYeniYedekParca.Enabled = true;
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CmbYetkiler_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Yetkilendirme where Yetkiid = @p1", Ayar.con);
            cmd.Parameters.AddWithValue("@p1", CmbYetkiler.SelectedValue);
            Ayar.con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ChcPersonelEkleme.Checked = dr[2].ToString() == "True";
                ChcPersonelSilme.Checked = dr[3].ToString() == "True";
                ChcKayitAcma.Checked = dr[4].ToString() == "True";
                ChcKayitTamamlama.Checked = dr[5].ToString() == "True";
                ChcYedekParca.Checked = dr[6].ToString() == "True";
                ChcCarilIslemler.Checked = dr[7].ToString() == "True";
                ChcSistemAyarlari.Checked = dr[8].ToString() == "True";
            }
            Ayar.con.Close();
        }

        private void CmbYetkiler_SelectedValueChanged(object sender, EventArgs e) { }

        private void BtnYetkiyiKaydet_Click(object sender, EventArgs e)
        {
            string carislem = ChcCarilIslemler.Checked ? "1" : "0";
            string kayitac = ChcKayitAcma.Checked ? "1" : "0";
            string kayittamamla = ChcKayitTamamlama.Checked ? "1" : "0";
            string personelekle = ChcPersonelEkleme.Checked ? "1" : "0";
            string personelsil = ChcPersonelSilme.Checked ? "1" : "0";
            string sistemayarlari = ChcSistemAyarlari.Checked ? "1" : "0";
            string yedekparca = ChcYedekParca.Checked ? "1" : "0";

            int id = 0;
            if (CmbYetkiler.SelectedValue != null)
            {
                int.TryParse(CmbYetkiler.SelectedValue.ToString(), out id);
            }

            SqlCommand cmd = new SqlCommand("Select * from Yetkilendirme Where Yetkiid = @p1", Ayar.con);
            cmd.Parameters.AddWithValue("@p1", id);

            Ayar.con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            bool kayitVarMi = dr.Read();
            dr.Close();
            Ayar.con.Close();

            string islem;
            if (kayitVarMi)
            {
                islem = "Update Yetkilendirme set PersonelEkleme = @pekle, PersonelSilme = @psil, KayitAcma = @kac, KayitTamamlama = @ktamamla, YedekParca = @yparca, CariIslemleri = @cislem, SistemAyarlari = @sAyar Where Yetkiid = @id";
            }
            else
            {
                islem = "Insert into Yetkilendirme (YetkiAdi, PersonelEkleme, PersonelSilme, KayitAcma, KayitTamamlama, YedekParca, CariIslemleri, SistemAyarlari) values (@yadi, @pekle, @psil, @kac, @ktamamla, @yparca, @cislem, @sAyar)";
            }

            SqlCommand komut = new SqlCommand(islem, Ayar.con);
            komut.Parameters.AddWithValue("@pekle", personelekle);
            komut.Parameters.AddWithValue("@psil", personelsil);
            komut.Parameters.AddWithValue("@kac", kayitac);
            komut.Parameters.AddWithValue("@ktamamla", kayittamamla);
            komut.Parameters.AddWithValue("@yparca", yedekparca);
            komut.Parameters.AddWithValue("@cislem", carislem);
            komut.Parameters.AddWithValue("@sAyar", sistemayarlari);

            if (kayitVarMi)
            {
                komut.Parameters.AddWithValue("@id", id);
            }
            else
            {
                komut.Parameters.AddWithValue("@yadi", TxtYetkiAdi.Text);
            }

            Ayar.con.Open();
            komut.ExecuteNonQuery();
            Ayar.con.Close();

            yetkidoldur();
            TxtYetkiAdi.Visible = false;
            CmbYetkiler.Visible = true;
            BtnYetkiGrubuEkle.Text = "Yetki Grubu Eklemek İstiyorum";
        }

        private void BtnYetkiGrubuEkle_Click(object sender, EventArgs e)
        {
            if (TxtYetkiAdi.Visible == false)
            {
                TxtYetkiAdi.Visible = true;
                CmbYetkiler.Visible = false;
                BtnYetkiGrubuEkle.Text = "Mevcut Yetkilerden Seç";

                CmbYetkiler.SelectedIndex = -1;
                CmbYetkiler.Text = "";
                TxtYetkiAdi.Clear();
                TxtYetkiAdi.Focus();

                ChcPersonelEkleme.Checked = false;
                ChcPersonelSilme.Checked = false;
                ChcKayitAcma.Checked = false;
                ChcKayitTamamlama.Checked = false;
                ChcYedekParca.Checked = false;
                ChcCarilIslemler.Checked = false;
                ChcSistemAyarlari.Checked = false;
            }
            else
            {
                TxtYetkiAdi.Visible = false;
                CmbYetkiler.Visible = true;
                BtnYetkiGrubuEkle.Text = "Yetki Grubu Eklemek İstiyorum";
                yetkidoldur();
            }
        }

        // --- PERSONEL EKLEME İŞLEMLERİ ---

        private void BtnPersonelEkle_Click(object sender, EventArgs e)
        {
            panellerikapat();
            yetkidoldur();
            personelekletemizle();
            PnlPersonelEkle.Visible = true;
        }

        private void BtnPersonelEkleKaydet_Click(object sender, EventArgs e)
        {
            if (!TxtPersonelEkleTC.MaskCompleted ||
                string.IsNullOrWhiteSpace(TxtPersonelEkleKullaniciAdi.Text) ||
                string.IsNullOrWhiteSpace(PersonelEkleAdiSoyadi.Text) ||
                !PersonelEkleTelefon.MaskCompleted ||
                string.IsNullOrWhiteSpace(PersonelEkleEmail.Text) ||
                string.IsNullOrWhiteSpace(PersonelEkleGorevi.Text) ||
                CmbPersonelEkleYetki.SelectedValue == null ||
                string.IsNullOrWhiteSpace(PersonelEklemaas.Text) ||
                string.IsNullOrWhiteSpace(PersonelEkleSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string temizTelefon = PersonelEkleTelefon.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            if (!temizTelefon.StartsWith("0"))
            {
                temizTelefon = "0" + temizTelefon;
            }

            try
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                Ayar.con.Open();

                SqlCommand kontrolCmd = new SqlCommand("Select Count(*) From Personel Where (TC = @tc OR KullaniciAdi = @kadi) AND (Silindi = 0 OR Silindi IS NULL)", Ayar.con);
                kontrolCmd.Parameters.AddWithValue("@tc", TxtPersonelEkleTC.Text);
                kontrolCmd.Parameters.AddWithValue("@kadi", TxtPersonelEkleKullaniciAdi.Text.Trim());

                if ((int)kontrolCmd.ExecuteScalar() > 0)
                {
                    Ayar.con.Close();
                    MessageBox.Show("Bu T.C. Kimlik Numarası veya Kullanıcı Adı zaten kayıtlı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlCommand cmd = new SqlCommand("Insert into Personel (TC, KullaniciAdi, AdiSoyadi, Telefon, Mail, Görevi, Yetkisi, Maas, Sifre, Silindi) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, 0)", Ayar.con);
                cmd.Parameters.AddWithValue("@p1", TxtPersonelEkleTC.Text);
                cmd.Parameters.AddWithValue("@p2", TxtPersonelEkleKullaniciAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@p3", PersonelEkleAdiSoyadi.Text.Trim());
                cmd.Parameters.AddWithValue("@p4", temizTelefon);
                cmd.Parameters.AddWithValue("@p5", PersonelEkleEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@p6", PersonelEkleGorevi.Text.Trim());
                cmd.Parameters.AddWithValue("@p7", CmbPersonelEkleYetki.SelectedValue);
                cmd.Parameters.AddWithValue("@p8", decimal.Parse(PersonelEklemaas.Text));
                cmd.Parameters.AddWithValue("@p9", PersonelEkleSifre.Text);

                cmd.ExecuteNonQuery();
                Ayar.con.Close();

                MessageBox.Show("Personel başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                personelekletemizle();
                personeldoldur();
            }
            catch (FormatException)
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                MessageBox.Show("Maaş alanına sadece sayısal değer giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- PERSONEL DÜZENLEME VE SİLME İŞLEMLERİ ---

        private void BtnPersonelDüzenle_Click(object sender, EventArgs e)
        {
            panellerikapat();
            yetkidoldur();
            personeldoldur();
            personelduzenletemizle();
            PnlPersonelDuzenle.Visible = true;
        }

        private void LstPersonelDuzenlePersoneller_DoubleClick(object sender, EventArgs e)
        {
            if (LstPersonelDuzenlePersoneller.SelectedValue == null) return;

            if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
            SqlCommand cmd = new SqlCommand("Select * From Personel Where PersonelNo = @p1", Ayar.con);
            cmd.Parameters.AddWithValue("@p1", LstPersonelDuzenlePersoneller.SelectedValue);

            Ayar.con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TxtPersonelDuzenleNo.Text = dr["PersonelNo"].ToString();
                TxtPersonelDuzenleTC.Text = dr["TC"].ToString();
                TxtPersonelDuzenleKullaniciAdi.Text = dr["KullaniciAdi"].ToString();
                TxtPersonelDuzenleAdiSoyadi.Text = dr["AdiSoyadi"].ToString();
                TxtPersonelDuzenleTelefon.Text = dr["Telefon"].ToString();
                TxtPersonelDuzenleEmail.Text = dr["Mail"].ToString();
                TxtPersonelDuzenleGorevi.Text = dr["Görevi"].ToString();
                CmbPersonelDuzenleYetki.SelectedValue = dr["Yetkisi"];
                TxtPersonelDuzenleMaas.Text = dr["Maas"].ToString();
                TxtPersonelDuzenleSifre.Text = dr["Sifre"].ToString();
            }
            dr.Close();
            Ayar.con.Close();
        }

        private void BtnPersonelDuzenleGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPersonelDuzenleNo.Text) ||
                string.IsNullOrWhiteSpace(TxtPersonelDuzenleTC.Text) ||
                string.IsNullOrWhiteSpace(TxtPersonelDuzenleKullaniciAdi.Text) ||
                string.IsNullOrWhiteSpace(TxtPersonelDuzenleAdiSoyadi.Text) ||
                string.IsNullOrWhiteSpace(TxtPersonelDuzenleTelefon.Text) ||
                string.IsNullOrWhiteSpace(TxtPersonelDuzenleEmail.Text) ||
                string.IsNullOrWhiteSpace(TxtPersonelDuzenleGorevi.Text) ||
                CmbPersonelDuzenleYetki.SelectedValue == null ||
                string.IsNullOrWhiteSpace(TxtPersonelDuzenleMaas.Text) ||
                string.IsNullOrWhiteSpace(TxtPersonelDuzenleSifre.Text))
            {
                MessageBox.Show("Lütfen listeden bir personel seçiniz ve boş alan bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string temizTelefon = TxtPersonelDuzenleTelefon.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            if (!temizTelefon.StartsWith("0"))
            {
                temizTelefon = "0" + temizTelefon;
            }

            try
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                Ayar.con.Open();

                SqlCommand kontrolCmd = new SqlCommand("Select Count(*) From Personel Where (TC = @tc OR KullaniciAdi = @kadi) AND PersonelNo != @pno AND (Silindi = 0 OR Silindi IS NULL)", Ayar.con);
                kontrolCmd.Parameters.AddWithValue("@tc", TxtPersonelDuzenleTC.Text.Trim());
                kontrolCmd.Parameters.AddWithValue("@kadi", TxtPersonelDuzenleKullaniciAdi.Text.Trim());
                kontrolCmd.Parameters.AddWithValue("@pno", TxtPersonelDuzenleNo.Text);

                if ((int)kontrolCmd.ExecuteScalar() > 0)
                {
                    Ayar.con.Close();
                    MessageBox.Show("Bu T.C. Kimlik Numarası veya Kullanıcı Adı başka bir personele ait!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlCommand cmd = new SqlCommand("Update Personel set TC = @p1, KullaniciAdi = @p2, AdiSoyadi = @p3, Telefon = @p4, Mail = @p5, Görevi = @p6, Yetkisi = @p7, Maas = @p8, Sifre = @p9 Where PersonelNo = @p10", Ayar.con);
                cmd.Parameters.AddWithValue("@p1", TxtPersonelDuzenleTC.Text.Trim());
                cmd.Parameters.AddWithValue("@p2", TxtPersonelDuzenleKullaniciAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@p3", TxtPersonelDuzenleAdiSoyadi.Text.Trim());
                cmd.Parameters.AddWithValue("@p4", temizTelefon);
                cmd.Parameters.AddWithValue("@p5", TxtPersonelDuzenleEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@p6", TxtPersonelDuzenleGorevi.Text.Trim());
                cmd.Parameters.AddWithValue("@p7", CmbPersonelDuzenleYetki.SelectedValue);
                cmd.Parameters.AddWithValue("@p8", decimal.Parse(TxtPersonelDuzenleMaas.Text));
                cmd.Parameters.AddWithValue("@p9", TxtPersonelDuzenleSifre.Text);
                cmd.Parameters.AddWithValue("@p10", TxtPersonelDuzenleNo.Text);

                cmd.ExecuteNonQuery();
                Ayar.con.Close();

                MessageBox.Show("Personel bilgileri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                personeldoldur();
                personelduzenletemizle();
            }
            catch (FormatException)
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                MessageBox.Show("Maaş alanına sadece sayısal değer giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPersonelDuzenleSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPersonelDuzenleNo.Text))
            {
                MessageBox.Show("Lütfen listeden silinecek personeli seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult onay = MessageBox.Show("Seçili personeli silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                SqlCommand cmd = new SqlCommand("Update Personel set Silindi = 1 Where PersonelNo = @p1", Ayar.con);
                cmd.Parameters.AddWithValue("@p1", TxtPersonelDuzenleNo.Text);

                Ayar.con.Open();
                cmd.ExecuteNonQuery();
                Ayar.con.Close();

                MessageBox.Show("Personel silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                personeldoldur();
                personelduzenletemizle();
            }
        }

        // --- SİSTEM AYARLARI, ŞİRKET BİLGİLERİ VE LİMİT İŞLEMLERİ (#14) ---

        private void BtnSirketBilgileriveLimitler_Click(object sender, EventArgs e)
        {
            panellerikapat();
            PnlSirketBilgileri.Visible = true;

            if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();

            // İşlemler ComboBox'ını doldur
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Islemler Where Silindi = 0 OR Silindi IS NULL", Ayar.con);
            DataTable table = new DataTable();
            Ayar.con.Open();
            adtr.Fill(table);
            CmbIslem.DataSource = null;
            CmbIslem.DisplayMember = "Islem";
            CmbIslem.ValueMember = "Islemid";
            CmbIslem.DataSource = table;
            CmbIslem.SelectedIndex = -1;
            Ayar.con.Close();

            // Sistem tablosundan mevcut şirket ve limit bilgilerini çek
            iletisimvar = false;
            SqlCommand cmd = new SqlCommand("Select * From Sistem", Ayar.con);
            Ayar.con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                iletisimvar = true;
                TxtSirketAdi.Text = dr["SirketAdi"].ToString();
                TxtVergiNo.Text = dr["SirketVergiNo"].ToString();
                TxtTelefon.Text = dr["SirketTelefon"].ToString();
                TxtFax.Text = dr["SirketFax"].ToString();
                TxtAdres.Text = dr["SirketAdres"].ToString();
                TxtEmail.Text = dr["SirketMail"].ToString();
                TxtGEmail.Text = dr["SirketGonderenMail"].ToString();
                TxtCariLimit.Text = dr["MaximumCariTutari"].ToString();

                if (!string.IsNullOrEmpty(dr["GonderenMailSifre"].ToString()))
                {
                    TxtGEmailSifre.Text = Ayar.sifreCoz(dr["GonderenMailSifre"].ToString(), Ayar.anahtarkelime);
                }
            }
            dr.Close();
            Ayar.con.Close();
        }

        private void BtnBilgiKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                if (iletisimvar)
                {
                    sql = "Update Sistem set SirketAdi = @p1, SirketVergiNo = @p2, SirketTelefon = @p3, SirketFax = @p4, SirketAdres = @p5, SirketMail = @p6, SirketGonderenMail = @p7, GonderenMailSifre = @p8";
                }
                else
                {
                    sql = "Insert into Sistem (SirketAdi, SirketVergiNo, SirketTelefon, SirketFax, SirketAdres, SirketMail, SirketGonderenMail, GonderenMailSifre) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)";
                }

                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                SqlCommand cmd = new SqlCommand(sql, Ayar.con);
                cmd.Parameters.AddWithValue("@p1", TxtSirketAdi.Text);
                cmd.Parameters.AddWithValue("@p2", TxtVergiNo.Text);
                cmd.Parameters.AddWithValue("@p3", TxtTelefon.Text);
                cmd.Parameters.AddWithValue("@p4", TxtFax.Text);
                cmd.Parameters.AddWithValue("@p5", TxtAdres.Text);
                cmd.Parameters.AddWithValue("@p6", TxtEmail.Text);
                cmd.Parameters.AddWithValue("@p7", TxtGEmail.Text);
                cmd.Parameters.AddWithValue("@p8", Ayar.sifrele(TxtGEmailSifre.Text, Ayar.anahtarkelime));

                Ayar.con.Open();
                cmd.ExecuteNonQuery();
                Ayar.con.Close();

                MessageBox.Show("İşlem başarılı, değişiklikler kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panellerikapat();
            }
            catch (Exception ex)
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCariGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                if (iletisimvar)
                {
                    sql = "Update Sistem set MaximumCariTutari = @p1";
                }
                else
                {
                    sql = "Insert into Sistem (MaximumCariTutari) values (@p1)";
                }

                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                SqlCommand cmd = new SqlCommand(sql, Ayar.con);
                cmd.Parameters.AddWithValue("@p1", TxtCariLimit.Text);

                Ayar.con.Open();
                cmd.ExecuteNonQuery();
                Ayar.con.Close();

                MessageBox.Show("İşlem başarılı, değişiklikler kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIslemEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtIslem.Text))
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                SqlCommand cmd = new SqlCommand("Insert into Islemler (Islem, Silindi) values (@p1, 0)", Ayar.con);
                cmd.Parameters.AddWithValue("@p1", TxtIslem.Text.ToUpper());

                Ayar.con.Open();
                cmd.ExecuteNonQuery();
                Ayar.con.Close();

                TxtIslem.Clear();
                MessageBox.Show("İşlem başarılı, değişiklikler kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panellerikapat();
            }
            else
            {
                MessageBox.Show("İşleminizi yazmalısınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnIslemSil_Click(object sender, EventArgs e)
        {
            if (CmbIslem.SelectedValue != null && CmbIslem.Text != "")
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                SqlCommand cmd = new SqlCommand("Update Islemler set Silindi = 1 Where Islemid = @p1", Ayar.con);
                cmd.Parameters.AddWithValue("@p1", CmbIslem.SelectedValue);

                Ayar.con.Open();
                cmd.ExecuteNonQuery();
                Ayar.con.Close();

                MessageBox.Show("İşlem başarılı, değişiklikler kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panellerikapat();
            }
            else
            {
                MessageBox.Show("İşleminizi seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCihazKayit_Click(object sender, EventArgs e)
        {
            FrmCihazKayit frm = new FrmCihazKayit();
            frm.Show();
        }

        private void BtnMailGonder_Click(object sender, EventArgs e)
        {
            FrmMailGonder mail = new FrmMailGonder();
            mail.Show();
        }
    }
}
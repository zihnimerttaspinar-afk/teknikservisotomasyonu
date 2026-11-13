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
        public FrmAnasayfa()
        {
            InitializeComponent();
        }
        void yetkidoldur()
        {
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Yetkilendirme", Ayar.con);
            Ayar.con.Open();
            DataTable table = new DataTable();
            adtr.Fill(table);
            CmbYetkiler.DataSource = null;
            CmbYetkiler.DisplayMember = "YetkiAdi";
            CmbYetkiler.ValueMember = "Yetkiid";
            CmbYetkiler.DataSource = table;

            CmbYetkiler.SelectedValue = -1;
           
            ChcCarilIslemler.Checked = false;
            ChcKayitAcma.Checked = false;
            ChcKayitTamamlama.Checked = false;
            ChcPersonelEkleme.Checked = false;
            ChcPersonelSilme.Checked = false;
            ChcSistemAyarlari.Checked = false;
            ChcYedekParca.Checked = false;

            Ayar.con.Close();
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

        private void BtnMarkaIslemleri_Click(object sender, EventArgs e)
        {
            markadoldur();
            TxtMarkaIslemleriMarkaAdi.Text = "";
            LblMarkaIslemleriMarkaId.Text = "";
            PnlMarkaIslemleri.Visible = true;
            PnlCihazIslemleri.Visible = false;
            PnlYedekParcaKategori.Visible = false;
            PnlYedekParcaIslemleri.Visible = false;
            PnlYetkiIslemleri.Visible = false;
            
            BtnMarkaGuncelle.Enabled = false;
            BtnMarkaSil.Enabled = false;
            BtnYeniMarka.Enabled = true;
        }

        private void BtnModelIslemleri_Click(object sender, EventArgs e)
        {
            PnlMarkaIslemleri.Visible = false;
            PnlCihazIslemleri.Visible = false;
            PnlYedekParcaKategori.Visible = false;
            PnlYedekParcaIslemleri.Visible = false;
            PnlYetkiIslemleri.Visible = false;
        }

        private void BtnCihazIslemleri_Click(object sender, EventArgs e)
        {
            cihazdoldur();
            TxtCihazİslemleriCihazAdi.Text = "";
            LblCihazİslemleriCihazId.Text = "";
            PnlMarkaIslemleri.Visible = false;
            PnlCihazIslemleri.Visible = true;
            PnlYedekParcaKategori.Visible = false;
            PnlYedekParcaIslemleri.Visible = false;
            PnlYetkiIslemleri.Visible = false;

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
            PnlMarkaIslemleri.Visible = false;
            PnlCihazIslemleri.Visible = false;
            PnlYedekParcaKategori.Visible = true;
            PnlYedekParcaIslemleri.Visible = false;
            PnlYetkiIslemleri.Visible = false;
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

            PnlMarkaIslemleri.Visible = false;
            PnlCihazIslemleri.Visible = false;
            PnlYedekParcaKategori.Visible = false;
            PnlYedekParcaIslemleri.Visible = true;
            PnlYetkiIslemleri.Visible = false;
        }

        private void BtnYetkiIslemleri_Click(object sender, EventArgs e)
        {
            yetkidoldur();

            PnlMarkaIslemleri.Visible = false; 
            PnlCihazIslemleri.Visible = false;
            PnlYedekParcaKategori.Visible = false;
            PnlYedekParcaIslemleri.Visible = false;
            PnlYetkiIslemleri.Visible = true;
        }

        private void LstMarkaIslemleriMarkalar_DoubleClick(object sender, EventArgs e)
        {
            BtnMarkaGuncelle.Enabled = true;
            BtnMarkaSil.Enabled = true;
            BtnYeniMarka.Enabled = false;
            TxtMarkaIslemleriMarkaAdi.Text=LstMarkaIslemleriMarkalar.Text;
            LblMarkaIslemleriMarkaId.Text=LstMarkaIslemleriMarkalar.SelectedValue.ToString();
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
            if(TxtMarkaIslemleriMarkaAdi.Text == "")
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

                    MessageBox.Show("Sistemsel hata oluştu. Daha sonra tekrar deneyin.", "Hata", MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                    cmd.Parameters.AddWithValue("@p2",LblMarkaIslemleriMarkaId.Text);
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

        private void LstCihazİslemleriCihazAdi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstYedekParcaKategoriİslemleri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

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
         if(TxtYedekParcaİslemleriModel.Text != "" && TxtYedekParcaİslemleriStok.Text != "" && TxtYedekParcaİşlemleriEkÖzellikler.Text != "" && CmbYedekParçaİslemleriKategori.Text != "" && CmbYedekParçaİslemleriMarka.Text != "" )
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
                if (dr[2].ToString() == "True")
                {
                    ChcPersonelEkleme.Checked = true;
                }
                else
                {
                    ChcPersonelEkleme.Checked = false;
                }

                if (dr[3].ToString() == "True")
                {
                    ChcPersonelSilme.Checked = true;
                }
                else
                {
                    ChcPersonelSilme.Checked = false;
                }

                if (dr[4].ToString() == "True")
                {
                    ChcKayitAcma.Checked = true;
                }
                else
                {
                    ChcKayitAcma.Checked = false;
                }
                if (dr[5].ToString() == "True")
                {
                    ChcKayitTamamlama.Checked = true;
                }
                else
                {
                    ChcKayitTamamlama.Checked = false;
                }
                if (dr[6].ToString() == "True")
                {
                    ChcYedekParca.Checked = true;
                }
                else
                {
                    ChcYedekParca.Checked = false;
                }
                if (dr[7].ToString() == "True")
                {
                    ChcCarilIslemler.Checked = true;
                }
                else
                {
                    ChcCarilIslemler.Checked = false;
                }
                if (dr[8].ToString() == "True")
                {
                    ChcSistemAyarlari.Checked = true;
                }
                else
                {
                    ChcSistemAyarlari.Checked = false;
                }
            }
            Ayar.con.Close();
        }

        private void CmbYetkiler_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnYetkiyiKaydet_Click(object sender, EventArgs e)
        {
            string carislem = ChcCarilIslemler.Checked ? "1" : "0";
            string kayitac = ChcKayitAcma.Checked ? "1" : "0";
            string kayittamamla = ChcKayitTamamlama.Checked ? "1" : "0"; // CheckBox adı düzeltildi
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
            cmd.Parameters.AddWithValue("@p1", id); // SelectedValue yerine güvenli 'id' verildi

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
            yetkidoldur();

            // Kaydetme bittikten sonra ekranı tekrar seçim moduna döndür
            TxtYetkiAdi.Visible = false;
            CmbYetkiler.Visible = true;
        }
        

        private void BtnYetkiGrubuEkle_Click(object sender, EventArgs e)
        {
            if (TxtYetkiAdi.Visible == false)
            {
                // Yeni ekleme moduna geç
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
                // Tekrar ComboBox seçim moduna dön
                TxtYetkiAdi.Visible = false;
                CmbYetkiler.Visible = true;
                BtnYetkiGrubuEkle.Text = "Yetki Grubu Eklemek İstiyorum";
                yetkidoldur();

            }
        }
    }
    
}

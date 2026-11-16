using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace teknikservisotomasyonu
{
    public partial class FrmCihazKayit : Form
    {
        bool varmi = false;

        public FrmCihazKayit()
        {
            InitializeComponent();

            // Form ve buton olaylarını otomatik bağla
            this.Load -= FrmCihazKayit_Load;
            this.Load += FrmCihazKayit_Load;

            BtnKapat.Click -= BtnKapat_Click;
            BtnKapat.Click += BtnKapat_Click;

            TxtTc.TextChanged -= TxtTc_TextChanged;
            TxtTc.TextChanged += TxtTc_TextChanged;

            BtnCihazKaydet.Click -= BtnCihazKaydet_Click;
            BtnCihazKaydet.Click += BtnCihazKaydet_Click;
        }

        void doldur()
        {
            try
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();

                // 1. Marka Doldur
                SqlDataAdapter adtr = new SqlDataAdapter("Select * From Marka Where Silindi = 0 OR Silindi IS NULL", Ayar.con);
                Ayar.con.Open();
                DataTable table = new DataTable();
                adtr.Fill(table);
                CmbMarka.DataSource = null;
                CmbMarka.DisplayMember = "MarkaAdi";
                CmbMarka.ValueMember = "Markaid";
                CmbMarka.DataSource = table;
                CmbMarka.SelectedIndex = -1;
                Ayar.con.Close();

                // 2. Cihaz Türü Doldur
                adtr = new SqlDataAdapter("Select * From Cihazlar Where Silindi = 0 OR Silindi IS NULL", Ayar.con);
                Ayar.con.Open();
                table = new DataTable();
                adtr.Fill(table);
                CmbCihazTuru.DataSource = null;
                CmbCihazTuru.DisplayMember = "CihazAdi";
                CmbCihazTuru.ValueMember = "cihazid";
                CmbCihazTuru.DataSource = table;
                CmbCihazTuru.SelectedIndex = -1;
                Ayar.con.Close();

                // 3. Durum (İşlemler) Doldur
                adtr = new SqlDataAdapter("Select * From Islemler", Ayar.con);
                Ayar.con.Open();
                table = new DataTable();
                adtr.Fill(table);
                CmbDurum.DataSource = null;
                CmbDurum.DisplayMember = "Islem";
                CmbDurum.ValueMember = "Islemid";
                CmbDurum.DataSource = table;
                CmbDurum.SelectedIndex = -1;
                Ayar.con.Close();
            }
            catch (Exception ex)
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                MessageBox.Show("Listeler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void temizle()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox) item.Text = "";
            }
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox || item is MaskedTextBox) item.Text = "";
            }
            varmi = false;
        }

        private void FrmCihazKayit_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtTc_TextChanged(object sender, EventArgs e)
        {
            if (TxtTc.Text.Length == 11)
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                SqlCommand cmd = new SqlCommand("Select * From Musteriler Where TC = @p1", Ayar.con);
                cmd.Parameters.AddWithValue("@p1", TxtTc.Text);
                Ayar.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    varmi = true;
                    TxtAdSoyad.Text = dr["AdiSoyadi"].ToString();
                    TxtMail.Text = dr["Mail"].ToString();
                    MskTelefon.Text = dr["Telefon"].ToString();
                    TxtAdres.Text = dr["Adres"].ToString();
                }
                else
                {
                    varmi = false;
                }
                dr.Close();
                Ayar.con.Close();
            }
            else
            {
                varmi = false;
            }
        }

        private void BtnCihazKaydet_Click(object sender, EventArgs e)
        {
            bool durum1 = true;
            bool durum2 = true;

            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox || item is ComboBox)
                {
                    if (string.IsNullOrWhiteSpace(item.Text))
                    {
                        durum1 = false;
                        break;
                    }
                }
            }

            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(item.Text))
                    {
                        durum2 = false;
                        break;
                    }
                }
                else if (item is MaskedTextBox msk && !msk.MaskCompleted)
                {
                    durum2 = false;
                    break;
                }
            }

            if (!durum1 || !durum2)
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();

                // 1. ARIZA KAYIT TABLOSUNA EKLE VE SON KAYIT ID'SİNİ AL
                SqlCommand ariza = new SqlCommand("Insert into ArızaKayıt (Cihaz, Marka, Model, Sikayet, TahminiArızaSebebi, KayitTarihi, Durumu) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7); SELECT SCOPE_IDENTITY();", Ayar.con);
                ariza.Parameters.AddWithValue("@p1", CmbCihazTuru.SelectedValue);
                ariza.Parameters.AddWithValue("@p2", CmbMarka.SelectedValue);
                ariza.Parameters.AddWithValue("@p3", TxtModel.Text.ToUpper());
                ariza.Parameters.AddWithValue("@p4", TxtSikayet.Text);
                ariza.Parameters.AddWithValue("@p5", TxtArizaTahmin.Text);
                ariza.Parameters.AddWithValue("@p6", DateTime.Now);
                ariza.Parameters.AddWithValue("@p7", CmbDurum.SelectedValue);

                Ayar.con.Open();
                int kayitId = Convert.ToInt32(ariza.ExecuteScalar());
                Ayar.con.Close();

                // 2. ARIZA DETAY TABLOSUNA EKLE
                SqlCommand arizaDetay = new SqlCommand("Insert into ArızaDetay (KayitId, IslemTarihi, Islem, IslemiYapan) values (@p1, @p2, @p3, @p4)", Ayar.con);
                arizaDetay.Parameters.AddWithValue("@p1", kayitId);
                arizaDetay.Parameters.AddWithValue("@p2", DateTime.Now);
                arizaDetay.Parameters.AddWithValue("@p3", CmbDurum.SelectedValue);
                arizaDetay.Parameters.AddWithValue("@p4", Ayar.kullaniciid);

                Ayar.con.Open();
                arizaDetay.ExecuteNonQuery();
                Ayar.con.Close();

                // 3. MÜŞTERİLER TABLOSUNA EKLE VEYA GÜNCELLE
                string sqlMusteri;
                if (!varmi)
                {
                    sqlMusteri = "Insert into Musteriler (TC, AdiSoyadi, Mail, Telefon, Adres, UyelikTarihi, KayitEdenPersonel) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7)";
                }
                else
                {
                    sqlMusteri = "Update Musteriler set AdiSoyadi = @p2, Mail = @p3, Telefon = @p4, Adres = @p5, UyelikTarihi = @p6, KayitEdenPersonel = @p7 Where TC = @p1";
                }

                SqlCommand musteri = new SqlCommand(sqlMusteri, Ayar.con);
                musteri.Parameters.AddWithValue("@p1", TxtTc.Text);
                musteri.Parameters.AddWithValue("@p2", TxtAdSoyad.Text.ToUpper());
                musteri.Parameters.AddWithValue("@p3", TxtMail.Text);
                musteri.Parameters.AddWithValue("@p4", MskTelefon.Text);
                musteri.Parameters.AddWithValue("@p5", TxtAdres.Text);
                musteri.Parameters.AddWithValue("@p6", DateTime.Now);
                musteri.Parameters.AddWithValue("@p7", Ayar.kullaniciid);

                Ayar.con.Open();
                musteri.ExecuteNonQuery();
                Ayar.con.Close();

                MessageBox.Show("Cihaz kaydı başarıyla gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                doldur();
                temizle();
            }
            catch (Exception ex)
            {
                if (Ayar.con.State == ConnectionState.Open) Ayar.con.Close();
                MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.IO;

namespace teknikservisotomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void database()
        {
            string sunucuadi = "";
            string veritabaniAdi = "";
            string VtKullaniciAdi = "";
            string VtSifre = "";
            XDocument XDoc = XDocument.Load(Application.StartupPath + "//settings.xml");
            XElement rootelement = XDoc.Root;
            foreach(XElement rehberberimiz in rootelement.Elements() )
            {
                sunucuadi=rehberberimiz.Element("ServerName").Value;
                veritabaniAdi= rehberberimiz.Element("DataBaseName").Value;
                VtKullaniciAdi = rehberberimiz.Element("UserID").Value;
                VtSifre = rehberberimiz.Element("Password").Value;

            }
            Ayar.con=new SqlConnection("Data Source ="+ sunucuadi +";Initial Catalog="+ veritabaniAdi + ";Persist Security Info=True; User ID=" + VtKullaniciAdi + ";Password=" + VtSifre + "" );

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string dosya_dizi = Application.StartupPath + "\\settings.xml";
            if (File.Exists(dosya_dizi) == true)
            {
                //varsa yapılacka işlemler
                //veritabanı baglantısı yapıalcak login işlemleri yapılacak
                database();
         
                
            }
            else
            {
                //database bilgileri formu acıkalacak..
                DataBaseBilgileri dt = new DataBaseBilgileri();
                dt.Show();
                this.Hide();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtKullaniciAdi.Text != "" && TxtSifre.Text != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from Personel Where KullaniciAdi = @p1 And Sifre = @p2", Ayar.con);
                    cmd.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
                    cmd.Parameters.AddWithValue("@p2", TxtSifre.Text);
                    Ayar.con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        FrmAnasayfa ans = new FrmAnasayfa();
                        ans.Lblkullaniciadi.Text=dr["KullaniciAdi"].ToString();
                        this.Hide();
                        ans.Show();

                    }
                    else
                    {
                        LblUyari.Text = "Kullanıcı adı veya şifre hatalı, kontrol edip tekrar deneyin";
                    }
                    Ayar.con.Close();
                }
                catch (Exception ex)
                {
                    LblUyari.Text = "İşlem gerçekleştirilirken hata oluştu, Daha sonra tekrar deneyin.";
                }
            }
            else
            {
                LblUyari.Text = "Tüm alanları doldurmanız gerekir.";
            }
        }
    }
}

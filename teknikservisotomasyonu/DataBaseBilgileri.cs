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
    public partial class DataBaseBilgileri : Form
    {
        public DataBaseBilgileri()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtAnahtar.Text != "" && TxtKullanici.Text != "" && TxtSifre.Text != "" && TxtSunucuAdi.Text != "" && TxtVeritabani.Text != "")
            {
                XmlTextWriter yaz = new XmlTextWriter(Application.StartupPath + "\\settings.xml", System.Text.UTF8Encoding.UTF8);
                yaz.Formatting = Formatting.Indented;
                try
                {
                    yaz.WriteStartDocument();
                    yaz.WriteStartElement("Setting");
                    yaz.WriteStartElement("DB");
                    yaz.WriteElementString("Provider", "SQLOLEDB.1");
                    yaz.WriteElementString("ServerName", TxtSunucuAdi.Text);
                    yaz.WriteElementString("DatabaseName", TxtVeritabani.Text);
                    yaz.WriteElementString("UserID", TxtKullanici.Text);
                    yaz.WriteElementString("Password", Ayar.sifrele(TxtSifre.Text, TxtAnahtar.Text));
                    yaz.WriteElementString("Keys", TxtAnahtar.Text);
                    yaz.WriteEndElement();
                    yaz.WriteEndElement();
                    yaz.Close();
                    MessageBox.Show("Ayarlar dosyanız oluştu, Program yeniden başlatıldıktan sonra kullanıma hazır olacaktır.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata Mesajı : " + ex.Message.ToString(), "Hata Alındı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurmanız gerekir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
        }
    }
}

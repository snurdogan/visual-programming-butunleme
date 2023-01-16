using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace rozgift_stock_management_system
{
    public partial class jsonkur : Form
    {
        public jsonkur()
        {
            InitializeComponent();
        }

        private void jsonkur_Load(object sender, EventArgs e)
        {
            DovizGoster();
        }
        public void DovizGoster()
        {
            // hoca json ya da xml demişti xml daha kolaymış
            try
            {
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");

                decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
                decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));
                decimal sterlin = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "GBP")).InnerText.Replace('.', ','));
                decimal isvicreFrangi = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "CHF")).InnerText.Replace('.', ','));
                decimal isveckronu = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "SEK")).InnerText.Replace('.', ','));
                decimal japonyeni = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "JPY")).InnerText.Replace('.', ','));
                decimal kanadadolari = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "CAD")).InnerText.Replace('.', ','));
                decimal norveckronu = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "NOK")).InnerText.Replace('.', ','));
                decimal suudiArabistanRiyali = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "SAR")).InnerText.Replace('.', ','));
                decimal danimarkaKronu = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "DKK")).InnerText.Replace('.', ','));
                decimal BulgarLevasi = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "BGN")).InnerText.Replace('.', ','));
                decimal RumenLeyi = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "RON")).InnerText.Replace('.', ','));
                decimal RusRublesi = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "RUB")).InnerText.Replace('.', ','));
                decimal iranRiyali = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "IRR")).InnerText.Replace('.', ','));
                decimal cinYuani = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "CNY")).InnerText.Replace('.', ','));
                decimal GuneyKoreWonu = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "KRW")).InnerText.Replace('.', ','));
                decimal AzerbaycanYeniManati = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "AZN")).InnerText.Replace('.', ','));
                decimal KatarRiyali = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "QAR")).InnerText.Replace('.', ','));


                lblDolar.Text = dolar.ToString();
                lblEuro.Text = euro.ToString();
                lblSterlin.Text = sterlin.ToString();
                lblFrang.Text = isvicreFrangi.ToString();
                label29.Text = isveckronu.ToString();
                label30.Text = japonyeni.ToString();
                label31.Text = kanadadolari.ToString();
                label32.Text = norveckronu.ToString();
                label33.Text = suudiArabistanRiyali.ToString();
                label34.Text = danimarkaKronu.ToString();
                label35.Text = BulgarLevasi.ToString();
                label36.Text = RumenLeyi.ToString();
                label37.Text = RusRublesi.ToString();
                label38.Text = iranRiyali.ToString();
                label39.Text = cinYuani.ToString();
                label40.Text = GuneyKoreWonu.ToString();
                label41.Text = AzerbaycanYeniManati.ToString();
                label42.Text = KatarRiyali.ToString();

            }
            catch (XmlException xml)
            {
                //timer1.Stop();
                MessageBox.Show(xml.ToString());
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DovizGoster();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            stoklar obj = new stoklar();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Kategori obj = new Kategori();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            müsteri obj = new müsteri();
            obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Firmalar obj = new Firmalar();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            siparisler obj = new siparisler();
            obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace rozgift_stock_management_system
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            KategoriSay();
            MusteriSay();
            FirmaSay();
            EnYuksekSiparis();
            EnİyiMust();
            SonSiparis();
        }

        private void KategoriSay()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from kategori", Database.dbconnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label14.Text = dt.Rows[0][0].ToString()+"  Kategori";// kategori numara label14
        }
        private void EnYuksekSiparis()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select  max(Tutar) from siparis", Database.dbconnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label19.Text = dt.Rows[0][0].ToString();// 
        }
        private void EnİyiMust()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select  musteri.musAdi from musteri join siparis on musteri.musId= siparis.mus_ID where siparis.Tutar=(select max(Tutar) from siparis ) ", Database.dbconnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label17.Text = dt.Rows[0][0].ToString();// 
        }
        private void FirmaSay()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from firma", Database.dbconnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label15.Text = dt.Rows[0][0].ToString() + "  Firma";// kategori numara label15
        }

        private void MusteriSay()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from musteri", Database.dbconnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label16.Text = dt.Rows[0][0].ToString() + "  Müşteri";// kategori numara label16
        }
        private void SonSiparis()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select max(Tarih) from siparis", Database.dbconnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string TheFullDate = dt.Rows[0][0].ToString();
            string ShortDate = TheFullDate.Substring(0, 12);
            label21.Text = ShortDate;
        }
        private void label21_Click(object sender, EventArgs e)
        {

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
            Firmalar obj = new Firmalar();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}

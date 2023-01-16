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
    public partial class stoklar : Form
    {
        public stoklar()
        {
            InitializeComponent();
            ShowUrunler();
            KategoriGetir();
            tedarikciGetir();
        }
        private void ShowUrunler()
        {
            string sorgu = "select * from urunler";
            MySqlDataAdapter sda = new MySqlDataAdapter(sorgu, Database.dbconnection);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void KategoriGetir()
        {
            MySqlCommand cmd = new MySqlCommand("select * from kategori", Database.dbconnection);
            MySqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("katId", typeof(int));
            dt.Load(rdr);
            kategoriCb.ValueMember = "katId";
            kategoriCb.DisplayMember = "katAdi";
            kategoriCb.DataSource = dt;
        }
        private void tedarikciGetir()
        {
            MySqlCommand cmd = new MySqlCommand("select * from firma", Database.dbconnection);
            MySqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("firKodu", typeof(int));
            dt.Load(rdr);
            urSupCb.ValueMember = "firKodu";
            urSupCb.DisplayMember = "firAdi";
            urSupCb.DataSource = dt;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(urAdiTb.Text=="" || urMiktarTb.Text== ""|| ursPriceTb.Text=="" || urbPriceTb.Text=="" || urSupCb.SelectedIndex== -1 || kategoriCb.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Bilgiler Eksik!");
            }
            else
            {
                
                try
                {
                    int kazanc = Convert.ToInt32(ursPriceTb.Text) - Convert.ToInt32(urbPriceTb.Text);
                    MySqlCommand cmd = new MySqlCommand("insert into urunler(urAdi, urKategori, urMiktar , urAlfiyat, urSatFiyat, urTarih, urSup, urKazanc) values (@urAdi, @urKategori, @urMiktar , @urAlfiyat, @urSatFiyat, @urTarih, @urSup, @urKazanc) ", Database.dbconnection);
                    cmd.Parameters.AddWithValue("@urAdi", urAdiTb.Text);
                    cmd.Parameters.AddWithValue("@urKategori", kategoriCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@urMiktar", urMiktarTb.Text);
                    cmd.Parameters.AddWithValue("@urAlfiyat", urbPriceTb.Text);
                    cmd.Parameters.AddWithValue("@urSatFiyat", ursPriceTb.Text);
                    cmd.Parameters.AddWithValue("@urTarih", guna2DateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@urSup", urSupCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@urKazanc", kazanc);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this ," Ürün Kaydedildi!");

                    ShowUrunler();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            urAdiTb.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
             kategoriCb.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            urMiktarTb.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            urbPriceTb.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            ursPriceTb.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            guna2DateTimePicker1.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            urSupCb.Text = guna2DataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            if(urAdiTb.Text== "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (urAdiTb.Text == "" || urMiktarTb.Text == "" || ursPriceTb.Text == "" || urbPriceTb.Text == "" || urSupCb.SelectedIndex == -1 || kategoriCb.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Bilgiler Eksik!");
            }
            else
            {
                
                try
                {
                    int kazanc = Convert.ToInt32(ursPriceTb.Text) - Convert.ToInt32(urbPriceTb.Text);
 
                    string updateSorgu = "update rozgiftnew.urunler set urAdi=@urAdi,urKategori=@urKategori, urMiktar=@urMiktar, urAlfiyat=@urAlfiyat, urSatFiyat=@urSatFiyat, urTarih=@urTarih,urSup=@urSup , urKazanc=@urKazanc WHERE urKodu=@urKey  ";
                    MySqlCommand cmd = new MySqlCommand(updateSorgu, Database.dbconnection);
                    cmd.Parameters.AddWithValue("@urAdi", urAdiTb.Text);
                    cmd.Parameters.AddWithValue("@urKategori", kategoriCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@urMiktar", urMiktarTb.Text);
                    cmd.Parameters.AddWithValue("@urAlfiyat", urbPriceTb.Text);
                    cmd.Parameters.AddWithValue("@urSatFiyat", ursPriceTb.Text);
                    cmd.Parameters.AddWithValue("@urTarih", guna2DateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@urSup", urSupCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@urKazanc", kazanc);
                    cmd.Parameters.AddWithValue("@urKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, " Ürün Güncellendi!");

                    ShowUrunler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show(this, "Ürün Seçiniz!");
            }
            else
            {
                int kazanc = Convert.ToInt32(ursPriceTb.Text) - Convert.ToInt32(urbPriceTb.Text);
                try
                {
                    string updateSorgu = "DELETE FROM rozgiftnew.urunler  WHERE urKodu=@urKey ";
                    MySqlCommand cmd = new MySqlCommand(updateSorgu, Database.dbconnection);
                   
                    cmd.Parameters.AddWithValue("@urKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, " Ürün Silindi!");

                    ShowUrunler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

        private void label5_Click(object sender, EventArgs e)
        {
            Kategori obj = new Kategori();
            obj.Show();
            this.Hide();
        }

        private void stoklar_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            siparisler obj = new siparisler();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            jsonkur obj = new jsonkur();
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

        private void kategoriCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

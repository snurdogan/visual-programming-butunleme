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
    public partial class Kategori : Form
    {
        public Kategori()
        {
            InitializeComponent();
            ShowKategori();
            kategoriSay();
        }
        private void ShowKategori()
        {
            string sorgu = "select * from kategori";
            MySqlDataAdapter sda = new MySqlDataAdapter(sorgu, Database.dbconnection);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            kategoriDGV.DataSource = ds.Tables[0];
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (katAdiTb.Text == "")
            {
                MessageBox.Show(this, "Bilgiler Eksik!");
            }
            else
            {

                try
                {

                    MySqlCommand cmd = new MySqlCommand("insert into kategori(katAdi) values (@katAdi) ", Database.dbconnection);

                    cmd.Parameters.AddWithValue("@katAdi", katAdiTb.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, " Kaydedildi!");

                    ShowKategori();
                    kategoriSay();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void kategoriDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            katAdiTb.Text = kategoriDGV.SelectedRows[0].Cells[1].Value.ToString();


            if (katAdiTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(kategoriDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (katAdiTb.Text == "" )
            {
                MessageBox.Show(this, "Bilgiler Eksik!");
            }
            else
            {

                try
                {
                  
                    string sorgu = "UPDATE rozgiftnew.kategori SET katAdi=@katAdi  WHERE katId=@katId ";
                    MySqlCommand cmd = new MySqlCommand(sorgu, Database.dbconnection);
                    cmd.Parameters.AddWithValue("@katAdi", katAdiTb.Text);
                  
                    cmd.Parameters.AddWithValue("@katId", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, " Kaydedildi!");

                    ShowKategori();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void kategoriSay()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from kategori" , Database.dbconnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label12.Text = dt.Rows[0][0].ToString();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show(this, "Kategori Seçiniz!");
            }
            else
            {

                try
                {
                    string updateSorgu = "DELETE FROM rozgiftnew.kategori  WHERE katId=@katId ";
                    MySqlCommand cmd = new MySqlCommand(updateSorgu, Database.dbconnection);

                    cmd.Parameters.AddWithValue("@katId", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, " kategori Silindi!");
                    ShowKategori();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            stoklar obj = new stoklar();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
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

        private void Kategori_Load(object sender, EventArgs e)
        {

        }
    }
}

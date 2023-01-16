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
    public partial class Firmalar : Form
    {
        public Firmalar()
        {
            InitializeComponent();
            ShowFirma();
        }
        private void ShowFirma()
        {
            string sorgu = "select * from firma";
            MySqlDataAdapter sda = new MySqlDataAdapter(sorgu, Database.dbconnection);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            firmaDGV.DataSource = ds.Tables[0];
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (firAdiTb.Text == "" || telnoTb.Text == "" || adresTb.Text == "")
            {
                MessageBox.Show(this, "Bilgiler Eksik!");
            }
            else
            {

                try
                {

                    Database.dbconnection.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into firma(firAdi, firTel, firAdr) values (@firAdi, @firTel, @firAdr ) ", Database.dbconnection);

                    cmd.Parameters.AddWithValue("@firAdi", firAdiTb.Text);
                    cmd.Parameters.AddWithValue("@firTel", telnoTb.Text);
                    cmd.Parameters.AddWithValue("@firAdr", adresTb.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, " Kaydedildi!");

                    Database.dbconnection.Close();
                    ShowFirma();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void firmaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            firAdiTb.Text = firmaDGV.SelectedRows[0].Cells[1].Value.ToString();
            telnoTb.Text = firmaDGV.SelectedRows[0].Cells[2].Value.ToString();
            adresTb.Text = firmaDGV.SelectedRows[0].Cells[3].Value.ToString();


            if (firAdiTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(firmaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (firAdiTb.Text == "" || telnoTb.Text == "" || adresTb.Text == "")
            {
                MessageBox.Show(this, "Bilgiler Eksik!");
            }
            else
            {

                try
                {
                    string sorgu = "UPDATE rozgiftnew.firma SET firAdi=@firAdi, firTel=@firTel, firAdr=@firAdr WHERE firKodu=@firKodu ";
                    MySqlCommand cmd = new MySqlCommand(sorgu, Database.dbconnection);
                    cmd.Parameters.AddWithValue("@firAdi", firAdiTb.Text);
                    cmd.Parameters.AddWithValue("@firTel", telnoTb.Text);
                    cmd.Parameters.AddWithValue("@firAdr", adresTb.Text);
                    cmd.Parameters.AddWithValue("@firKodu", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, " Güncellendi!");

                    ShowFirma();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show(this, "Kişi Seçiniz!");
            }
            else
            {

                try
                {
                    string updateSorgu = "DELETE FROM rozgiftnew.firma  WHERE firKodu=@firKodu ";
                    MySqlCommand cmd = new MySqlCommand(updateSorgu, Database.dbconnection);

                    cmd.Parameters.AddWithValue("@firKodu", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, " kişi Silindi!");
                    ShowFirma();
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

        private void Firmalar_Load(object sender, EventArgs e)
        {

        }
    }
}

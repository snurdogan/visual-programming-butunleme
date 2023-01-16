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
    public partial class müsteri : Form
    {
        public müsteri()
        {
            InitializeComponent();
            ShowMusteri();
        }

        private void ShowMusteri()
        {
            string sorgu = "select * from musteri";
            MySqlDataAdapter sda = new MySqlDataAdapter(sorgu, Database.dbconnection);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            musteriDGV.DataSource = ds.Tables[0];
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (musAdiTb.Text == "" || CinsiyetCb.SelectedIndex == -1 || telnoTb.Text == "" || adresTb.Text == "")
            {
                MessageBox.Show(this, "Bilgiler Eksik!");
            }
            else
            {

                try
                {

                    MySqlCommand cmd = new MySqlCommand("insert into musteri(musAdi, musTel, musAdr,musCins) values (@musAdi, @musTel, @musAdr , @musCins) ", Database.dbconnection);

                    cmd.Parameters.AddWithValue("@musAdi", musAdiTb.Text);
                    cmd.Parameters.AddWithValue("@musTel", telnoTb.Text);
                    cmd.Parameters.AddWithValue("@musAdr", adresTb.Text);
                    cmd.Parameters.AddWithValue("@musCins", CinsiyetCb.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, " Kaydedildi!");

                    ShowMusteri();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void musteriDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            musAdiTb.Text = musteriDGV.SelectedRows[0].Cells[1].Value.ToString();
            telnoTb.Text = musteriDGV.SelectedRows[0].Cells[2].Value.ToString();
            adresTb.Text = musteriDGV.SelectedRows[0].Cells[3].Value.ToString();
            CinsiyetCb.Text = musteriDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (musAdiTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(musteriDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (musAdiTb.Text == "" || CinsiyetCb.SelectedIndex == -1 || telnoTb.Text == "" || adresTb.Text == "")
            {
                MessageBox.Show(this, "Bilgiler Eksik!");
            }
            else
            {

                try
                {

                    //MySqlCommand cmd = new MySqlCommand("insert into musteri(musAdi, musTel, musAdr,musCins) values (@musAdi, @musTel, @musAdr , @musCins) ", con);
                    string sorgu = "UPDATE rozgiftnew.musteri SET musAdi=@musAdi, musTel=@musTel, musAdr=@musAdr, musCins=@musCins WHERE musId=@musId ";
                    MySqlCommand cmd = new MySqlCommand(sorgu, Database.dbconnection);
                    cmd.Parameters.AddWithValue("@musAdi", musAdiTb.Text);
                    cmd.Parameters.AddWithValue("@musTel", telnoTb.Text);
                    cmd.Parameters.AddWithValue("@musAdr", adresTb.Text);
                    cmd.Parameters.AddWithValue("@musCins", CinsiyetCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@musId", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, " Kaydedildi!");

                    ShowMusteri();
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

                    string updateSorgu = "DELETE FROM rozgiftnew.musteri  WHERE musId=@musId ";
                    MySqlCommand cmd = new MySqlCommand(updateSorgu, Database.dbconnection);

                    cmd.Parameters.AddWithValue("@musId", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, " kişi Silindi!");

                    ShowMusteri();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

        private void label4_Click(object sender, EventArgs e)
        {
            stoklar obj = new stoklar();
            obj.Show();
            this.Hide();
        }

        private void müsteri_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            müsteri obj = new müsteri();
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

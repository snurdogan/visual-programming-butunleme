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
    public partial class siparisler : Form
    {
        public siparisler()
        {
            InitializeComponent();
            MusteriGetir();
            UrunGetir();
            ShowSiparis();
        }
        MySqlConnection con = new MySqlConnection("server=localhost; database=rozgiftnew; uid=root; pwd='';");

        private void ShowSiparis()
        {
            con.Open();
            string sorgu = "select * from siparis";
            MySqlDataAdapter sda = new MySqlDataAdapter(sorgu, con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            siparisDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void MusteriGetir()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from musteri", con);
            MySqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("musId", typeof(int));
            dt.Load(rdr);
            msCb.ValueMember = "musId";
            msCb.DisplayMember = "musAdi";
            msCb.DataSource = dt;
            con.Close();
        }
        private void UrunGetir()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from urunler", con);
            MySqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("urKodu", typeof(int));
            dt.Load(rdr);
            urnCb.ValueMember = "urKodu";
            urnCb.DisplayMember = "urAdi";
            urnCb.DataSource = dt;
            con.Close();
        }
        private void UrunAdiGetir()
        {
            con.Open();
            string mysql = " SELECT * FROM urunler where urKodu = '" + urnCb.SelectedValue.ToString() + "'  ";
            MySqlCommand cmd = new MySqlCommand(mysql, con);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                urnadiTb.Text = dr["urAdi"].ToString();
                FiyatTb.Text = dr["urSatFiyat"].ToString();
            }
            con.Close();
        }
        //int key = 0;
        private void GuncelStok()
        {

            try
            {

                con.Open();

                string updateSorgu = "update rozgiftnew.urunler set urMiktar=@urMiktar  WHERE urKodu=@urKey  ";
                MySqlCommand cmd = new MySqlCommand(updateSorgu, con);
                
                cmd.Parameters.AddWithValue("@urMiktar", MiktarTB.Text);

                cmd.Parameters.AddWithValue("@urKey", urnCb.SelectedValue.ToString());
               
                cmd.ExecuteNonQuery();

                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (urnCb.SelectedIndex == -1 || kullCb.SelectedIndex == -1 || tutarTb.Text == "")
            {
                MessageBox.Show(this, "Bilgiler Eksik!");
            }
            else
            {

                try
                {

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into siparis (mus_ID ,kull_ID,Tarih,Tutar) values (@mus_ID,@kull_ID,@Tarih,@Tutar) ", con);
                    cmd.Parameters.AddWithValue("@mus_ID", urnCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@kull_ID", kullCb.SelectedIndex.ToString());
                    cmd.Parameters.AddWithValue("@Tarih", guna2DateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@Tutar", tutarTb.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, " Sipariş Eklendi!");

                    con.Close();
                    ShowSiparis();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int n = 0;
        int GTotal = 0;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (urnadiTb.Text == "" || MiktarTB.Text == "")
            {
                MessageBox.Show("Bilgiler Eksik");
            }
            else
            {
                int total = Convert.ToInt32(MiktarTB.Text) * Convert.ToInt32(FiyatTb.Text);
                DataGridViewRow nr = new DataGridViewRow();
                nr.CreateCells(FaturaDGV);
                nr.Cells[0].Value = n + 1;
                nr.Cells[1].Value = urnadiTb.Text;
                nr.Cells[2].Value = FiyatTb.Text;
                nr.Cells[3].Value = MiktarTB.Text;
                nr.Cells[4].Value = total;
                FaturaDGV.Rows.Add(nr);
                GTotal = GTotal + total;
                label14.Text = "Total   " + GTotal + "TL";
                tutarTb.Text = "" + GTotal;
                n++;
                GuncelStok();
                MessageBox.Show(this, "ürünler eklendi.");

            }
        }

        private void urnCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UrunAdiGetir();
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

        private void msCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iptalBtn_Click(object sender, EventArgs e)
        {

        }
    }
}

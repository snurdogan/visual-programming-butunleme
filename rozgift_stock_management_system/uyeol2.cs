using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rozgift_stock_management_system
{
    public partial class uyeol2 : Form
    {
        public uyeol2()
        {
            InitializeComponent();
        }

       

        private void kytBtn_Click(object sender, EventArgs e)
        {
            if (kulladiTb.Text == "" || postaTb.Text == "" || sifreTb.Text == "" || tkrSifreTb.Text == "")
            {
                MessageBox.Show(this, "Bilgiler Eksik!");
            }
            else
            {

                try
                {
                    
                    MySqlCommand cmd = new MySqlCommand("insert into kulltb(kullAdi, kullSifre, kullMail ) values (@kullAdi, @kullSifre, @kullMail ) ", Database.dbconnection);
                    cmd.Parameters.AddWithValue("@kullAdi", kulladiTb.Text);
                    cmd.Parameters.AddWithValue("@kullSifre", sifreTb.Text);
                    cmd.Parameters.AddWithValue("@kullMail", postaTb.Text);
                   
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, " kişi Kaydedildi Kaydedildi!");

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

          
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

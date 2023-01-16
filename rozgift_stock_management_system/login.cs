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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private void login_Load(object sender, EventArgs e)
        {
            if (Database.dbconnection.State == ConnectionState.Closed)
            {
                Database.dbconnection.Open();
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {



            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT COUNT(*) FROM kullTb WHERE kullAdi='" + KullaniciTb.Text + "' AND kullSifre='" + passwordTb.Text + "'", Database.dbconnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                stoklar obj = new stoklar();
                obj.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("geçersiz kullanıcı adı ya da şifre", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1_Click(sender, e); // kullanıcı bilgileri yanlış girildiğinde gelen uyarı ekranı kapanınca girilen bilgilerde temizlenir.

            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (passwordTb.PasswordChar.ToString() == "*")
            {
                passwordTb.PasswordChar = char.Parse("\0");
                button1.Text = "Gizle";
            }
            else
            {
                passwordTb.PasswordChar = char.Parse("*");
                button1.Text = "Göster";
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uyeol2 obj = new uyeol2();
            obj.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifremiunuttum obj = new sifremiunuttum();
            obj.Show();
            this.Hide();
        }
    }
}

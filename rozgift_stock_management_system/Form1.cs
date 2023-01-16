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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int progress_value = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            guna2CircleProgressBar1.ShowPercentage = true;
            guna2CircleProgressBar1.Animated = false;
            guna2CircleProgressBar1.Value = 0;

            timer1.Enabled = true;
            timer1.Interval = 100;
            timer1.Tick += timer1_Tick;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progress_value < 101)
            {
                guna2CircleProgressBar1.Value = progress_value;
                progress_value += 2;
            }
            else
            {
                timer1.Enabled = false;
                this.Hide();
                login obj = new login();
                obj.Show();
            }
        }

       
    }
}

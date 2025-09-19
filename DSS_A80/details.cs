using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSS_A80
{
    public partial class details : Form
    {
        public details()
        {
            InitializeComponent();
        }//deleted

        private void btn_back_Click(object sender, EventArgs e)
        {
            maincs maincs = new maincs();
            maincs.Show();
            this.Hide();
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[0];
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[1];
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[2];
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[3];
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[4];
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[5];
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[6];
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[7];
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[8];
        }
        private void btn10_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[9];
        }
        private void btn11_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[10];
        }

        private void details_Load(object sender, EventArgs e)
        {

        }


    }
}

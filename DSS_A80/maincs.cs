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
    public partial class maincs : Form
    {
        public maincs()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btn_to_CVBT_Click(object sender, EventArgs e)
        {

        }

        private void btn_to_details_Click(object sender, EventArgs e)
        {
            details details = new details();
            details.Show();
            this.Hide();
        }
    }
}

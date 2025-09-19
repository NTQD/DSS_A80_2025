namespace DSS_A80
{
    public partial class Form1 : Form
    {
        private Size originalFormSize;

        public Form1()
        {
            InitializeComponent();
            originalFormSize = this.Size;
        }

        private void bnt_start_Click(object sender, EventArgs e)
        {
            maincs mainForm = new maincs();
            mainForm.Show();
            this.Hide();
        }

        private void ScaleAllControls(Control control, float scaleX, float scaleY)
        {
            foreach (Control c in control.Controls)
            {
                c.Left = (int)(c.Left * scaleX);
                c.Top = (int)(c.Top * scaleY);
                c.Width = (int)(c.Width * scaleX);
                c.Height = (int)(c.Height * scaleY);
                c.Font = new Font(c.Font.FontFamily, c.Font.Size * Math.Min(scaleX, scaleY), c.Font.Style);
                if (c.Controls.Count > 0)
                    ScaleAllControls(c, scaleX, scaleY);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            float scaleX = (float)this.Width / originalFormSize.Width;
            float scaleY = (float)this.Height / originalFormSize.Height;
            ScaleAllControls(this, scaleX, scaleY);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

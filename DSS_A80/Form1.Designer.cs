namespace DSS_A80
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            bnt_start = new Button();
            SuspendLayout();
            // 
            // bnt_start
            // 
            bnt_start.BackColor = Color.White;
            bnt_start.Location = new Point(407, 677);
            bnt_start.Name = "bnt_start";
            bnt_start.Size = new Size(134, 40);
            bnt_start.TabIndex = 0;
            bnt_start.Text = "Tìm hiểu thêm";
            bnt_start.UseVisualStyleBackColor = false;
            bnt_start.Click += bnt_start_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.a80__1_;
            ClientSize = new Size(950, 749);
            Controls.Add(bnt_start);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button bnt_start;
    }
}

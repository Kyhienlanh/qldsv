using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace quanlidiem
{
    public partial class giangvien : Form
    {
        public giangvien()
        {
            InitializeComponent();
        }
        public giangvien(string a)
        {
            InitializeComponent();
            label2.Text = a;
          
        }
        
      
        private Form currentFormchild;
        private void openformchild(Form childform)
        {

            if (currentFormchild != null)
            {
                currentFormchild.Close();
            }
            currentFormchild = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panel4.Controls.Add(childform);
            panel4.Tag = childform;
            childform.BringToFront();
            childform.Show();


        }


        private void button1_Click(object sender, EventArgs e)
        {
            openformchild(new themdiem(label2.Text));
        }

        private void giangvien_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openformchild(new inthongtin(label2.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (currentFormchild != null)
            {
                currentFormchild.Close();
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

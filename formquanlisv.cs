using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlidiem
{
    public partial class formquanlisv : Form
    {
        public formquanlisv()
        {
            InitializeComponent();
        }
        public formquanlisv(String a)
        {
            InitializeComponent();
            label2.Text = a;
        }
        private Form currentFormchild;

        private void formquanlisv_Load(object sender, EventArgs e)
        {

        }
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
            openformchild(new themsv());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (currentFormchild != null)
            {
                currentFormchild.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openformchild(new timkiemsv());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}

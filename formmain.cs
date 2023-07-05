using qld;
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
    public partial class formmain : Form
    {
        public formmain()
        {
            InitializeComponent();
        }
        public formmain(string user)
        {
            InitializeComponent();
            label2.Text = user;
        }
        private Form currentFormchild;
        private void label2_Click(object sender, EventArgs e)
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
       // private void pictureBox2_Click(object sender, EventArgs e)
       // {
          
       // }


        private void button2_Click(object sender, EventArgs e)
        {
            openformchild(new mh());

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (currentFormchild != null)
            {
                currentFormchild.Close();
            }
        }

        private void formmain_Load(object sender, EventArgs e)
        {
            openformchild(new mh());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

    }
}

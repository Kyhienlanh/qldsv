using quanlidiem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace giaodien
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        modify modify = new modify();
        private void button1_Click(object sender, EventArgs e)
        {
            String taikhoan = textBox1.Text;
            string matkhau = textBox2.Text;
            if (taikhoan.Trim() == "")
            {
                MessageBox.Show("Vui long nhap tai khoan");
            }
            else if (matkhau.Trim() == "")
            {
                MessageBox.Show("vui long nhap mat khau");
            }
            else
            {
                String query = "select username,password,quyenTruycap from Admin where username='" + taikhoan + "'and password='" + matkhau + "'";
                if (modify.taikhoans(query).Count != 0)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    if (modify.taikhoans(query)[0].Quyen == "user")
                    {
                        formmain fm = new formmain(taikhoan);
                        fm.Show();
                        this.Hide(); // Ẩn Form1
                    }
                    else if(modify.taikhoans(query)[0].Quyen == "admin")
                    {
                        formmain fm = new formmain(taikhoan);
                        fm.Show();
                        // this.Hide(); // Ẩn Form1

                    }

                }
                else MessageBox.Show("Đăng nhập thất bại");
            }
        }
    }
}

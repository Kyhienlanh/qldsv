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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
        modify modify=new modify();
            private void Login_Click(object sender, EventArgs e)
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
                        if (modify.taikhoans(query)[0].Quyen == "giangvien")
                        {
                        //  formmain fm = new formmain(taikhoan);
                        // fm.Show();
                        // this.Hide(); // Ẩn Form1
                            giangvien ina= new giangvien(taikhoan);
                            ina.Show();
                            this.Hide();

                        }
                        else if (modify.taikhoans(query)[0].Quyen == "phongdaotao")
                        {
                        formmain fm = new formmain(taikhoan);
                        fm.Show();
                        this.Hide(); // Ẩn Form1
                         }
                   
                        else 
                        {
                            formquanlisv fm = new formquanlisv(taikhoan);
                            fm.Show();
                             this.Hide(); // Ẩn Form1

                        }

                    }
                    else MessageBox.Show("Đăng nhập thất bại");
                }
            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)

        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn tắt chương trình?", "Xác nhận tắt chương trình", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Đóng Form hiện tại
                this.Close();

                // Hoặc đóng toàn bộ ứng dụng
                // Application.Exit();
            }
            else
            {
                // Người dùng chọn "No" - không làm gì cả
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
            }
            else textBox2.PasswordChar = '*';


        }

        private void button1_Click(object sender, EventArgs e)
        {
            timmatkhau timmatkhau = new timmatkhau();
            timmatkhau.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /*private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }*/
    }
}

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
    public partial class timmatkhau : Form
    {
        public timmatkhau()
        {
            InitializeComponent();
        }
        modify modify = new modify();
        private void button2_Click(object sender, EventArgs e)
        {
                String taikhoan = textBox1.Text;
                string email = textBox2.Text;
                if (taikhoan.Trim() == "")
                {
                    MessageBox.Show("Vui long nhap tai khoan");
                }
                else if (email.Trim() == "")
                {
                    MessageBox.Show("vui long nhap email");
                }
                else
                {
                    String query = "select username,password,email from Admin where username='" + taikhoan + "'and email='" + email + "'";
                    if (modify.taikhoans(query).Count != 0)
                    {
                    label5.Text = modify.taikhoans(query)[0].Matkhau;

                    }
                    else MessageBox.Show("Email hoặc tài khoản sai");
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}

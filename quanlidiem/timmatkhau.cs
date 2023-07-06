using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
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
        private Int32 userId = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            string token = textBox3.Text;

            bool isCorrect = ResetPassword.VerifyPasswordResetHmacCode(token, out userId);
            if (isCorrect && userId >= 0)
            {
                MessageBox.Show("correct");
                //TODO: create a new reset password form
                Form2 form = new Form2();
                form.Show();
                this.Hide();
            }
            else MessageBox.Show("incorrect");
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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
                //String query = "select username,password,email from Admin where username='" + taikhoan + "'and email='" + email + "'";
                //if (modify.taikhoans(query).Count != 0) //if has a user, send mail
                //{
                //modify.taikhoans(query)[0].Tentaikhoan;
                //TODO: query userId from database ->
                //userId = ?
                MailAddress from = new MailAddress("nguyengialac99@gmail.com", "Lac Nguyen");
                MailAddress to = new MailAddress("nggialac99@gmail.com", "Nguyen Lac"); //change receiver email
                List<MailAddress> cc = new List<MailAddress>();
                //cc.Add(new MailAddress("Someone@domain.topleveldomain", "Name and stuff"));
                ResetPassword.SendEmail(userId, "Reset password via mail service", from, to, cc);
                //}
                //else MessageBox.Show("Email hoặc tài khoản sai");
            }
        }
    }
}

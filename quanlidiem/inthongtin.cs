using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace quanlidiem
{
    public partial class inthongtin : Form
    {
        public inthongtin()
        {
            InitializeComponent();
        }
        public inthongtin(string user)
        {
            InitializeComponent();
            label8.Text = user;
            //thongtin(label8.Text);
        }

        private void inthongtin_Load(object sender, EventArgs e)
        {
            thongtin(label8.Text);
            label8.Hide();
            dateTimePicker1.Hide();
        }
        modify modify = new modify();
        public void thongtin(string a)
        {

            using (SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                sqlConnection.Open();

                // Viết câu truy vấn SQL để lấy thông tin từ cơ sở dữ liệu
                string query = "SELECT magv,tengv,khoa,diachi,sdt,email FROM GiangVien WHERE magv = @a";

                // Tạo đối tượng SqlCommand để thực hiện truy vấn
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    // Thực thi truy vấn và lấy dữ liệu vào đối tượng SqlDataReader
                    command.Parameters.Add("@a", SqlDbType.NVarChar).Value = a;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Lấy giá trị từ cột TenCot1 và gán vào textBox1
                            textBox1.Text = reader.GetString(0);

                            // Lấy giá trị từ cột TenCot2 và gán vào textBox2
                            textBox2.Text = reader.GetString(1);

                            // Lấy giá trị từ cột TenCot3 và gán vào dateTimePicker1
                          //  dateTimePicker1.Value = reader.GetDateTime(2);

                            // Lấy giá trị từ cột TenCot4 và chuyển đổi thành chuỗi

                            textBox4.Text = reader.GetString(2);

                            // Lấy giá trị từ cột TenCot5 và gán vào textBox5
                            textBox5.Text = reader.GetString(3);

                            // Lấy giá trị từ cột TenCot6 và gán vào textBox6
                            textBox6.Text = reader.GetString(4);

                            // Lấy giá trị từ cột TenCot7 và gán vào textBox7
                            textBox7.Text = reader.GetString(5);
                        }
                    }
                }

                sqlConnection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            dateTimePicker1.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            button2.Enabled= true;
            button1.Enabled = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public bool luu(String a)
        {
            using (SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                sqlConnection.Open();

                string sqlUpdateQuery = "UPDATE giangvien SET tengv = @Value1,khoa=@value3 ,diachi=@value4,sdt=@value5,email=@value6 WHERE magv = @a";

                using (SqlCommand command = new SqlCommand(sqlUpdateQuery, sqlConnection))
                {
                    // Truyền các giá trị từ TextBox vào tham số của truy vấn
                    command.Parameters.AddWithValue("@Value1", textBox2.Text);
                  
                    command.Parameters.AddWithValue("@Value3", textBox4.Text);
                    command.Parameters.AddWithValue("@Value4", textBox5.Text);
                    command.Parameters.AddWithValue("@Value5", textBox6.Text);
                    command.Parameters.AddWithValue("@Value6", textBox7.Text);
                    command.Parameters.AddWithValue("@a", a); // recordID là ID của bản ghi cần sửa

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (luu(label8.Text))
            {
                MessageBox.Show("sửa thành công");
            }
            else MessageBox.Show("Không sửa dược");
            textBox1.Enabled =false;
            textBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;


        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}

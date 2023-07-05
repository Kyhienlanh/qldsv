using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace quanlidiem
{
    public partial class themsv : Form
    {
        public themsv()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        modify modify1;
        private void themsv_Load(object sender, EventArgs e)
        {
             modify1 = new modify();
            dataGridView1.DataSource = modify1.getallsinhvien();
        }

        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            try
            {
                // Tạo một đối tượng Excel mới
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add();

                // Tạo một đối tượng Worksheet và lấy nó từ Workbook
                Excel.Worksheet worksheet = workbook.ActiveSheet;

                // Đặt tên các cột dựa trên Header Text của DataGridView
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
                }

                // Sao chép dữ liệu từ DataGridView vào tệp Excel
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // Lưu tệp Excel và đóng ứng dụng Excel
                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();

                MessageBox.Show("Dữ liệu đã được xuất thành công ra tệp Excel!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string mssv = textBox1.Text;
            string ten = textBox2.Text;
            DateTime tg = dateTimePicker1.Value;
            string nganh=textBox4.Text;
            string lop=textBox5.Text;
            int gioitinh=Convert.ToInt32(textBox7.Text);
            string sdt=textBox8.Text;
            string diachi=textBox9.Text;
            sinhvien sinhvien = new sinhvien(mssv,ten,nganh,lop,tg,gioitinh,diachi, sdt);

            if (modify1.IsMssvExists(mssv))
            {
                MessageBox.Show("Mã số sinh viên trùng ");
            }
            else if ( ten.Trim() == "" || nganh.Trim() == "" || lop.Trim() == "" ||  sdt.Trim() == "" || diachi.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
            }
            else
            {
               
                    if (modify1.insert(sinhvien))
                    {
                    MessageBox.Show("Thêm thành công");
                        dataGridView1.DataSource = modify1.getallsinhvien();
                    }
                    else
                    {
                        MessageBox.Show("Thêm vào không thành công");
                    }
               
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mssv = textBox1.Text;
            string ten = textBox2.Text;
            DateTime tg = dateTimePicker1.Value;
            string nganh = textBox4.Text;
            string lop = textBox5.Text;
            int gioitinh = Convert.ToInt32(textBox7.Text);
            string sdt = textBox8.Text;
            string diachi = textBox9.Text;
            sinhvien sinhvien = new sinhvien(mssv, ten, nganh, lop, tg, gioitinh, diachi, sdt);
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (modify1.Update(sinhvien))
                {
                    MessageBox.Show("Sửa thành công mssv: " + mssv);
                    dataGridView1.DataSource = modify1.getallsinhvien();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mssv = textBox1.Text;
            DialogResult result = MessageBox.Show("Bạn có muốn xóa sinh viên có mssv "+mssv+" ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (modify1.Delete(mssv))
                {
                    dataGridView1.DataSource = modify1.getallsinhvien();
                }
                else MessageBox.Show("không thể xóa");
            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo chỉ xử lý khi người dùng chọn vào một hàng hợp lệ
            {
                // Lấy dữ liệu từ hàng đã chọn
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string mssv = row.Cells["Mssv"].Value.ToString();
                string ten = row.Cells["Ten"].Value.ToString();
                string chuongtrinhdaotao = row.Cells["chuongtrinhdaotao"].Value.ToString();
                string lop = row.Cells["lop"].Value.ToString();
                string ngaysinh = row.Cells["ngaysinh"].Value.ToString();
                string gioitinh = row.Cells["gioitinh"].Value.ToString();
                string diachi = row.Cells["diachi"].Value.ToString();
                string sdt = row.Cells["sdt"].Value.ToString();
                // Lấy các giá trị khác tương tự

                // Hiển thị dữ liệu lên các TextBox
                textBox1.Text = mssv;
                textBox2.Text = ten;
                textBox4.Text= chuongtrinhdaotao;
                textBox5.Text = lop;
                dateTimePicker1.Text = ngaysinh;
                textBox7.Text = gioitinh;
                textBox8.Text=sdt;
                textBox9.Text = diachi;
                // Gán các giá trị khác cho các TextBox tương tự
            }

        }
    }
}

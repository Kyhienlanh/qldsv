using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;
namespace qld
{
    public partial class mh : Form
    {
        public mh()
        {
            InitializeComponent();
        }
        Monhoc Monhoc;
        modify11 modify11;
        

        private void Form1_Load(object sender, EventArgs e)
        {
            modify11 modify1 = new modify11();
            try
            {
                dataGridView1.DataSource = modify1.getallsinhvien();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        internal class connection
        {
            public static String stringconnection = @"server=DOTANLOC; database=quanlidiem;integrated security=true";
            public static SqlConnection GetSqlConnection()

            {
                return new SqlConnection(stringconnection);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maMh = textBox1.Text;
            string tenMh = textBox2.Text;
            string soTinChi =textBox4.Text;
            int tongTiet = int.Parse(textBox3.Text);
            string theLoai = textBox5.Text;
            string hinhThucDanhGia = textBox8.Text;
            //string maMh, string tenMh, string soTinChi, string theLoai, int tongTiet, string hinhThucDanhGia)
           Monhoc Monhoc = new Monhoc(maMh, tenMh, soTinChi, theLoai, tongTiet, hinhThucDanhGia);
           
            if (modify1.Insert(Monhoc) ) 
            {
                dataGridView1.DataSource = modify1.getallsinhvien();

            }
            else
            {
                MessageBox.Show("Lỗi: " + "Không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            
        }
        modify11 modify1 = new modify11();
        private void button2_Click(object sender, EventArgs e)
        {
            string maMh = textBox1.Text;
            if (modify1.Delete(maMh))
            {
                dataGridView1.DataSource = modify1.getallsinhvien();

            }
            else
            {
                MessageBox.Show("Lỗi: " + "Không xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string maMh = textBox1.Text;
            string tenMh = textBox2.Text;
            string soTinChi = textBox4.Text;
            int tongTiet = int.Parse(textBox3.Text);
            string theLoai = textBox5.Text;
            string hinhThucDanhGia = textBox8.Text;
            //string maMh, string tenMh, string soTinChi, string theLoai, int tongTiet, string hinhThucDanhGia)
            Monhoc Monhoc = new Monhoc(maMh, tenMh, soTinChi, theLoai, tongTiet, hinhThucDanhGia);
            if (modify1.Update(Monhoc))
            {
                dataGridView1.DataSource = modify1.getallsinhvien();

            }
            else
            {
                MessageBox.Show("Lỗi: " + "Không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ExportToExcel(DataGridView dataGridView)
        {
            try
            {
                string folderPath = @"C:\Users\USER\OneDrive\Máy tính";
                string userName = Environment.UserName;
                string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string fileName = $"DataExport_{userName}_{timeStamp}.xlsx";
                string filePath = Path.Combine(folderPath, fileName);

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
        private void button4_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

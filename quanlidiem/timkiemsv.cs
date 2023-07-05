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
using Excel = Microsoft.Office.Interop.Excel;
namespace quanlidiem
{
    public partial class timkiemsv : Form
    {
        public timkiemsv()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timkiemsv_Load(object sender, EventArgs e)
        {
            modify modify = new modify();
            dataGridView2.DataSource = modify.getallsinhvien();
            modify.themdulieu(comboBox2);



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    if (textBox1.Text == dataGridView2[0, i].Value.ToString())
                    {
                        dataGridView1.Rows.Add(dataGridView2[0, i].Value, dataGridView2[1, i].Value, dataGridView2[2, i].Value, dataGridView2[3, i].Value, dataGridView2[4, i].Value, dataGridView2[5, i].Value, dataGridView2[6, i].Value, dataGridView2[7, i].Value);
                    }
                }
            }
            if (radioButton2.Checked)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    if (comboBox1.Text == dataGridView2[2, i].Value.ToString())
                    {
                        dataGridView1.Rows.Add(dataGridView2[0, i].Value, dataGridView2[1, i].Value, dataGridView2[2, i].Value, dataGridView2[3, i].Value, dataGridView2[4, i].Value, dataGridView2[5, i].Value, dataGridView2[6, i].Value, dataGridView2[7, i].Value);
                    }
                }
            }
            if (radioButton3.Checked)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    if (comboBox2.Text == dataGridView2[3, i].Value.ToString())
                    {
                        dataGridView1.Rows.Add(dataGridView2[0, i].Value, dataGridView2[1, i].Value, dataGridView2[2, i].Value, dataGridView2[3, i].Value, dataGridView2[4, i].Value, dataGridView2[5, i].Value, dataGridView2[6, i].Value, dataGridView2[7, i].Value);
                    }
                }
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }
        /*   private void ExportToExcel(DataGridView dataGridView, string filePath)
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
           }*/
        private void ExportToExcel(DataGridView dataGridView)
        {
            try
            {
                string folderPath = @"E:\In file excel";
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
        private void button1_Click_2(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand();

                string query = "SELECT masv, tensv, khoa, lop, ngaysinh, gioitinh, sdt, diachi FROM sinhvien WHERE lop = @a";
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@a", comboBox2.SelectedValue.ToString());

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                CrystalReport1 report = new CrystalReport1();
                report.SetDataSource(table);
                XUATBAOCAO xUATBAOCAO = new XUATBAOCAO();
                xUATBAOCAO.crystalReportViewer1.ReportSource = report;
                xUATBAOCAO.ShowDialog();
            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

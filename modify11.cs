using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static qld.mh;
using System.Threading;
using System.Data.Common;
using System.Data.SqlTypes;

namespace qld
{
    internal class modify11
    {
        public modify11()
        {
        }
        SqlCommand command;//truy van cau lenh
        SqlDataReader reader;// doc du lieu
        SqlDataAdapter adapter;
        private object maMh;

        public DataTable getallsinhvien()
        {
            DataTable dt = new DataTable();
            String query = "select * from Monhoc";
            using (SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                sqlConnection.Open();
                adapter = new SqlDataAdapter(query, sqlConnection);
                adapter.Fill(dt);
                sqlConnection.Close();
            }
            return dt;
        }
        public bool Insert(Monhoc monhoc)
        {

            try
            {
                string query = "INSERT INTO Monhoc (maMH, tenmh, sotinchi, theloai, tongtiet, hinhthucdanhgia) " +
                               "VALUES (@maMh, @tenMh, @soTinChi, @theLoai, @tongTiet, @hinhThucDanhGia)";

                using (SqlConnection sqlConnection = connection.GetSqlConnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.Add("@maMh", SqlDbType.NVarChar).Value = monhoc.MaMh;
                        command.Parameters.Add("@tenMh", SqlDbType.NVarChar).Value = monhoc.TenMh;
                        command.Parameters.Add("@soTinChi", SqlDbType.NVarChar).Value = monhoc.SoTinChi;
                        command.Parameters.Add("@theLoai", SqlDbType.NVarChar).Value = monhoc.TheLoai;
                        command.Parameters.Add("@tongTiet", SqlDbType.Int).Value = monhoc.TongTiet;
                        command.Parameters.Add("@hinhThucDanhGia", SqlDbType.NVarChar).Value = monhoc.HinhThucDanhGia;
                        command.ExecuteNonQuery(); // Thực thi lệnh truy vấn
                    }
                    sqlConnection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ tại đây
                Console.WriteLine("Lỗi khi chèn dữ liệu môn học: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string mamh)
        {
            try
            {
                using (SqlConnection sqlConnection = connection.GetSqlConnection())
                {
                    string query = "DELETE FROM Monhoc WHERE maMh = @maMh";

                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.Add("@maMh", SqlDbType.NVarChar).Value = mamh;
                        command.ExecuteNonQuery(); // Thực thi lệnh truy vấn
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ tại đây (ví dụ: ghi log, hiển thị thông báo lỗi)
                return false;
            }
        }
        public bool Update(Monhoc monhoc)
        {
            try
            {
                string query = "UPDATE Monhoc SET maMh = @maMh, tenMh = @tenMh, soTinChi = @soTinChi, theLoai = @theLoai, " +
                               "tongTiet = @tongTiet, hinhThucDanhGia = @hinhThucDanhGia WHERE maMh = @maMh";

                using (SqlConnection sqlConnection = connection.GetSqlConnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.Add("@maMh", SqlDbType.NVarChar).Value = monhoc.MaMh;
                        command.Parameters.Add("@tenMh", SqlDbType.NVarChar).Value = monhoc.TenMh;
                        command.Parameters.Add("@soTinChi", SqlDbType.NVarChar).Value = monhoc.SoTinChi;
                        command.Parameters.Add("@theLoai", SqlDbType.NVarChar).Value = monhoc.TheLoai;
                        command.Parameters.Add("@tongTiet", SqlDbType.Int).Value = monhoc.TongTiet;
                        command.Parameters.Add("@hinhThucDanhGia", SqlDbType.NVarChar).Value = monhoc.HinhThucDanhGia;
                        command.ExecuteNonQuery(); // Thực thi lệnh truy vấn
                    }
                    sqlConnection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ tại đây
                Console.WriteLine("Lỗi khi cập nhật dữ liệu môn học: " + ex.Message);
                return false;
            }

        }
    }
    
    
}

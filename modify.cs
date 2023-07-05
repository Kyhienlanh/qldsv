using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace quanlidiem
{
    internal class modify
    {
        public modify()
        {
        }
        SqlCommand command;//truy van cau lenh
        SqlDataReader reader;// doc du lieu
        public List<taikhoan> taikhoans(String query)
        {
            List<taikhoan> taikhoans = new List<taikhoan>();
            using (SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    taikhoans.Add(new taikhoan(reader.GetString(0), reader.GetString(1), reader.GetString(2)));
                }
                sqlConnection.Close();
            }
            return taikhoans;
        }
        SqlDataAdapter adapter;
        public DataTable getallsinhvien()
        {
            DataTable dt = new DataTable();
            String query = "select * from Sinhvien";
            using (SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                sqlConnection.Open();
                adapter = new SqlDataAdapter(query,sqlConnection);
                adapter.Fill(dt);
                sqlConnection.Close() ;
            }
            return dt;
        }
        public bool IsMssvExists(string mssv)
        {
            string query = "SELECT COUNT(*) FROM Sinhvien WHERE mssv = @mssv";
            using (SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@mssv", SqlDbType.NVarChar).Value = mssv;
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public bool insert(sinhvien sinhvien)
        {
            try
            {
                string query = "INSERT INTO Sinhvien (mssv, ten, chuongtrinhdaotao, lop, ngaysinh, gioitinh, diachi, sdt) " +
                        "VALUES (@mssv, @ten, @chuongtrinhdaotao, @lop, @ngaysinh, @gioitinh, @diachi, @sdt)";

                using (SqlConnection sqlConnection1 = connection.GetSqlConnection())
                {
                    sqlConnection1.Open();
                    using (SqlCommand command = new SqlCommand(query, sqlConnection1))
                    {
                        command.Parameters.Add("@mssv", SqlDbType.NVarChar).Value = sinhvien.Mssv;
                        command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = sinhvien.Ten;
                        command.Parameters.Add("@chuongtrinhdaotao", SqlDbType.NVarChar).Value = sinhvien.Chuongtrinhdaotao;
                        command.Parameters.Add("@lop", SqlDbType.NVarChar).Value = sinhvien.Lop;
                        command.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = sinhvien.Ngaysinh;
                        command.Parameters.Add("@gioitinh", SqlDbType.TinyInt).Value = sinhvien.Gioitinh;
                        command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = sinhvien.Diachi;
                        command.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = sinhvien.Sdt;
                        command.ExecuteNonQuery();
                    }
                    sqlConnection1.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ tại đây
                Console.WriteLine("Lỗi khi chèn dữ liệu sinh viên: " + ex.Message);
                return false;
            }

        }

        public bool Update(sinhvien sinhvien)
        {
            string query = "UPDATE Sinhvien " +
                           "SET ten = @ten, chuongtrinhdaotao = @chuongtrinhdaotao, lop = @lop, " +
                           "ngaysinh = @ngaysinh, gioitinh = @gioitinh, diachi = @diachi, sdt = @sdt " +
                           "WHERE mssv = @mssv";

            using (SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@mssv", SqlDbType.NVarChar).Value = sinhvien.Mssv;
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = sinhvien.Ten;
                command.Parameters.Add("@chuongtrinhdaotao", SqlDbType.NVarChar).Value = sinhvien.Chuongtrinhdaotao;
                command.Parameters.Add("@lop", SqlDbType.NVarChar).Value = sinhvien.Lop;
                command.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = sinhvien.Ngaysinh;
                command.Parameters.Add("@gioitinh", SqlDbType.TinyInt).Value = sinhvien.Gioitinh;
                command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = sinhvien.Diachi;
                command.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = sinhvien.Sdt;
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        
        public bool Delete(string mssv)
        {
            try
            {
                string query = "DELETE FROM Sinhvien WHERE mssv = @mssv";

                using (SqlConnection sqlConnection = connection.GetSqlConnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.Add("@mssv", SqlDbType.NVarChar).Value = mssv;
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ tại đây
               
                return false;
            }
        }
        public void themdulieu(ComboBox comboBox)
        {
            using(SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                string query = "SELECT * FROM sinhvien";
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Loại bỏ các giá trị trùng lặp
                DataView view = new DataView(table);
                DataTable distinctValues = view.ToTable(true, "lop");

                comboBox.DataSource = distinctValues;
               // comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "lop";

            }
        }
        public void themdulieumh(ComboBox comboBox,string a)
        {
            using (SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                string query = "select LopHocPhan.maMh,LopHocPhan.maGiangVien from GiangVien,LopHocPhan where GiangVien.maGiangVien=LopHocPhan.maGiangVien and GiangVien.maGiangVien=@a";
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@a", SqlDbType.NVarChar).Value = a;
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Loại bỏ các giá trị trùng lặp
                DataView view = new DataView(table);
                DataTable distinctValues = view.ToTable(true, "maMh");

                comboBox.DataSource = distinctValues;
                // comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "maMh";

            }
        }
        public DataTable getallmahp()
        {
            DataTable dt = new DataTable();
            String query = "select * from diem";
            using (SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                sqlConnection.Open();
                adapter = new SqlDataAdapter(query, sqlConnection);
                adapter.Fill(dt);
                sqlConnection.Close();
            }
            return dt;
        }
        public bool UpdateDiem(string mssv,string Mamh, float DiemGiuaKy, float DiemCuoiKy)
        {
            string query = "UPDATE Diem " +
                           "SET diemGiuaKy = @diemGiuaKy, diemCuoiKy = @diemCuoiKy " +
                           "WHERE mamh = @mamh AND mssv = @mssv";

            using (SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@mamh", SqlDbType.NVarChar).Value = Mamh;
                command.Parameters.Add("@mssv", SqlDbType.NVarChar).Value = mssv;
                command.Parameters.Add("@diemGiuaKy", SqlDbType.Float).Value = DiemGiuaKy;
                command.Parameters.Add("@diemCuoiKy", SqlDbType.Float).Value = DiemCuoiKy;
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

    }

}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlidiem
{
    internal class taikhoan
    {
       
        private String tentaikhoan;
        private String matkhau;
        private string quyen;
        public taikhoan()
        {

        }
        public taikhoan(string tentaikhoan, string matkhau, string quyen)
        {
            this.tentaikhoan = tentaikhoan;
            this.matkhau = matkhau;
            this.quyen = quyen;
        }

        public string Tentaikhoan { get => tentaikhoan; set => tentaikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string Quyen { get => quyen; }
    
    }

}

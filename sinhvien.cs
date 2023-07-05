using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlidiem
{
    internal class sinhvien
    {

        private String mssv;
        private String ten;
        private String chuongtrinhdaotao;
        private String lop;
        private DateTime ngaysinh;
        private int gioitinh;
        private String diachi;
        private String sdt;

        public sinhvien()
        { 
        }

        public sinhvien(string mssv, string ten, string chuongtrinhdaotao, string lop, DateTime ngaysinh, int gioitinh, string diachi, string sdt)
        {
            this.mssv = mssv;
            this.ten = ten;
            this.chuongtrinhdaotao = chuongtrinhdaotao;
            this.lop = lop;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.sdt = sdt;
        }

        public string Mssv { get => mssv; set => mssv = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Chuongtrinhdaotao { get => chuongtrinhdaotao; set => chuongtrinhdaotao = value; }
        public string Lop { get => lop; set => lop = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public int Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}

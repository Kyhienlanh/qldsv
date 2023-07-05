using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qld
{
    internal class Monhoc
    {
        /*internal object maMh;
        internal object tenMh;
        internal object soTinChi;
        internal object theLoai;
        internal object tongTiet;
        internal object hinhThucDanhGia;*/
        private string maMh;
        private string tenMh;
        private string soTinChi;
        private string theLoai;
        private int tongTiet;
        private string hinhThucDanhGia;

        public Monhoc(string maMh, string tenMh, string soTinChi, string theLoai, int tongTiet, string hinhThucDanhGia)
        {
            this.maMh = maMh;
            this.tenMh = tenMh;
            this.soTinChi = soTinChi;
            this.theLoai = theLoai;
            this.tongTiet = tongTiet;
            this.hinhThucDanhGia = hinhThucDanhGia;
        }

        public string MaMh { get => maMh; set => maMh = value; }
        public string TenMh { get => tenMh; set => tenMh = value; }
        public string SoTinChi { get => soTinChi; set => soTinChi = value; }
        public string TheLoai { get => theLoai; set => theLoai = value; }
        public int TongTiet { get => tongTiet; set => tongTiet = value; }
        public string HinhThucDanhGia { get => hinhThucDanhGia; set => hinhThucDanhGia = value; }
    }
    

}

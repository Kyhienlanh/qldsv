using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qld
{
    internal class Monhoc
    {

        private string maMh;
        private string tenMh;
        private string soTinChi;
        private DateTime thoigianhoc;

        public Monhoc(string maMh, string tenMh, string soTinChi, DateTime thoigian)
        {
            this.MaMh = maMh;
            this.TenMh = tenMh;
            this.SoTinChi = soTinChi;
            this.thoigianhoc = thoigian;
        }

        public string MaMh { get => maMh; set => maMh = value; }
        public string TenMh { get => tenMh; set => tenMh = value; }
        public string SoTinChi { get => soTinChi; set => soTinChi = value; }
        public DateTime Thoigianhoc { get => thoigianhoc; set => thoigianhoc = value; }
    }
    

}

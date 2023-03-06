using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DangNhap_DangKi
{
    public class CongDan
    {
        public readonly string HoTen;
        public readonly DateTime NgaySinh;
        public readonly string DiaChiThuongTru;
        public readonly string DiaChiHienTai;
		public readonly string CCCD;
		public readonly string DanToc;
		public readonly string TonGiao;
		public readonly string GioiTinh;
		public readonly string NgheNghiep;
		public readonly string TrinhDoHocVan;
		public CongDan(string Hoten, DateTime NgaySinh, string DiaChiThuongTru, string DiaChiHienTai,
               string CCCD, string DanToc, string TonGiao, string GioiTinh, string NgheNghiep, string TrinhDoHocVan)
		{
			this.HoTen = Hoten;
			this.NgaySinh = NgaySinh;
			this.CCCD = CCCD;
			this.TrinhDoHocVan = TrinhDoHocVan;
			this.DiaChiThuongTru = DiaChiThuongTru;
			this.DiaChiHienTai = DiaChiHienTai;
			this.DanToc = DanToc;
			this.TonGiao = TonGiao;
			this.GioiTinh = GioiTinh;
			this.NgheNghiep = NgheNghiep;
		}
    }
}

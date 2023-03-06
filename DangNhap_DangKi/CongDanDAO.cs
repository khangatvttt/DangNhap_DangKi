using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap_DangKi
{
    public class CongDanDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        public DataTable LayDuLieu()
        {
            string sqlStr = "use QLCD select * from CongDan";
            return TraCuu(sqlStr);
        }
        public void ThemDuLieu(CongDan congdan)
        {
            string SQL = string.Format("use QLCD Insert into CongDan values " +
              "(N'{0}','{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}')",
              congdan.HoTen,congdan.NgaySinh.ToString("yyyy/MM/dd"),congdan.DiaChiThuongTru,congdan.DiaChiHienTai,
              congdan.CCCD,congdan.DanToc,congdan.TonGiao,congdan.GioiTinh,congdan.NgheNghiep,congdan.TrinhDoHocVan);
            this.ThucThi(SQL);
        }
        public void XoaDuLieu(string CCCD)
        {
            string SQL = string.Format("use QLCD delete from CongDan where CCCD='{0}'",CCCD);
            this.ThucThi(SQL);
        }
        public void ThucThi(string sql)
        {
            try
            {
                conn.Open();
                string sqlStr = sql;
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Lệnh đã thực hiện thành công!","Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lệnh thất bại! Lỗi: " + ex,"Thất bại");
            }
            finally
            {
                conn.Close();
            }
        }
        public CongDan LayDuLieuCongDan(string CCCD)
        {
            string SQL = string.Format("use QLCD select * from CongDan where CCCD='{0}'", CCCD);
            conn.Open();
            string sqlStr = SQL;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            DataSet dtCongDan = new DataSet();
            adapter.Fill(dtCongDan);
            string HoTen=dtCongDan.Tables[0].Rows[0][0].ToString();
            DateTime NgaySinh = (DateTime)dtCongDan.Tables[0].Rows[0][1];
            string DCTT = dtCongDan.Tables[0].Rows[0][2].ToString();
            string DCHT = dtCongDan.Tables[0].Rows[0][3].ToString();
            string So_CCCD = dtCongDan.Tables[0].Rows[0][4].ToString();
            string DanToc = dtCongDan.Tables[0].Rows[0][5].ToString();
            string TonGiao = dtCongDan.Tables[0].Rows[0][6].ToString();
            string GioiTinh = dtCongDan.Tables[0].Rows[0][7].ToString();
            string NgheNghiep = dtCongDan.Tables[0].Rows[0][8].ToString();
            string HocVan = dtCongDan.Tables[0].Rows[0][9].ToString();
            CongDan cd = new CongDan(HoTen, NgaySinh, DCTT, DCHT, So_CCCD, DanToc, TonGiao, GioiTinh, NgheNghiep, HocVan);
            conn.Close();
            return cd;
        }
        public void SuaDuLieu(string CCCD, CongDan congdan)
        {
            string SQL = string.Format("use QLCD update CongDan set HoTen=N'{0}',NgaySinh='{1}'," +
                                    "DiaChiThuongTru=N'{2}',DiaChiHienTai=N'{3}',CCCD='{4}',DanToc=N'{5}',TonGiao=N'{6}'," +
                                    "GioiTinh=N'{7}',NgheNghiep=N'{8}',TrinhDoHocVan=N'{9}' where CCCD='{10}'"
                                    ,congdan.HoTen,congdan.NgaySinh.ToString("yyyy/MM/dd"),congdan.DiaChiThuongTru,congdan.DiaChiHienTai
                                    , congdan.CCCD,congdan.DanToc,congdan.TonGiao,congdan.GioiTinh,congdan.NgheNghiep,congdan.TrinhDoHocVan,CCCD);
            this.ThucThi(SQL);
        }

        public DataTable TraCuuTheoHoTen(string HoTen)
        {
            string sqlStr = "use QLCD select * from CongDan where HoTen like N'" + HoTen + "%'";
            return TraCuu(sqlStr);
        }
        public DataTable TraCuuTheoCCCD(string CCCD)
        {
            string sqlStr = "use QLCD select * from CongDan where CCCD like N'" + CCCD + "%'";
            return TraCuu(sqlStr);
        }
        public DataTable TraCuu(string SQL)
        {
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, conn);
                DataTable dtCongDan = new DataTable();
                adapter.Fill(dtCongDan);
                return dtCongDan;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool CheckCCCD(string CCCD)
        {
            string sqlStr = "use QLCD select * from CongDan where CCCD='"+CCCD+"'";
            DataTable dtCongDan=TraCuu(sqlStr);
            try
            {
                dtCongDan.Rows[0]["HoTen"].ToString();
                //Trùng
                return false;
            }
            catch
            {
                //Không trùng
                return true;
            }
        }
    }
}

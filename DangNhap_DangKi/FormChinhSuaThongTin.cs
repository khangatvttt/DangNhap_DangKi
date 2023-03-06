using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DangNhap_DangKi
{
    public partial class FormChinhSuaThongTin : Form
    {
        bool[] HopLe = new bool[10];
        public bool Them = false;
        public string CCCD;
        public FormChinhSuaThongTin()
        {
            InitializeComponent();
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            txtCCCD_Leave(sender, e);
            txtDanToc_Leave(sender, e);
            txtDiaChiHT_Leave(sender, e);
            txtDiaChiTT_Leave(sender, e);
            txtHoten_Leave(sender, e);
            txtTonGiao_Leave(sender, e);
            txtHocVan_Leave(sender, e);
            txtNghe_Leave(sender, e);
            bool Flag = true;
            for (int i = 0; i <= 7; i++)
                if (HopLe[i] == false)
                {
                    Flag = false;
                    break;
                }
            if (rdbNam.Checked == false && rdbNu.Checked == false)
            {
                Flag = false;
                ErrorProvider.SetError(rdbNu, "Vui lòng chọn");
                lblErrorGioiTinh.Text = "Dữ liệu không được để trống!";
                lblErrorGioiTinh.ForeColor = Color.Red;
            }
            if (Flag)
            {
                //Thêm thông tin
                if (Them == true)
                {
                    var XacNhan = MessageBox.Show("Bạn có chắc muốn thêm dữ liệu mới?",
                                             "Xác nhận", MessageBoxButtons.YesNo);
                    if (XacNhan == DialogResult.Yes)
                    {
                        CongDan Data_CD = new CongDan(txtHoten.Text, dtpNgaySinh.Value.Date, txtDiaChiTT.Text, txtDiaChiHT.Text, txtCCCD.Text
                                                , txtDanToc.Text, txtTonGiao.Text, rdbNam.Checked ? "Nam" : "Nữ", txtNghe.Text, txtHocVan.Text);
                        CongDanDAO congDanDAO = new CongDanDAO();
                        congDanDAO.ThemDuLieu(Data_CD);
                    }
                    this.Close();
                }
                //Sửa thông tin
                else
                {
                    var XacNhan = MessageBox.Show("Bạn có chắc muốn thay đổi dữ liệu này?",
                                             "Xác nhận", MessageBoxButtons.YesNo);
                    if (XacNhan == DialogResult.Yes)
                    {
                        CongDan Data_CD = new CongDan(txtHoten.Text, dtpNgaySinh.Value.Date, txtDiaChiTT.Text, txtDiaChiHT.Text, txtCCCD.Text
                                                , txtDanToc.Text, txtTonGiao.Text, rdbNam.Checked ? "Nam" : "Nữ", txtNghe.Text, txtHocVan.Text);
                        CongDanDAO congDanDAO = new CongDanDAO();
                        congDanDAO.SuaDuLieu(CCCD,Data_CD);
                    }
                    this.Close();
                }
            }
            else MessageBox.Show("Dữ liệu chưa hợp lệ!");
            
        }

        private void txtHoten_Leave(object sender, EventArgs e)
        {
            HopLe[0] = CheckDuLieuTrong(txtHoten, lblErrorHoTen);
        }
        private void txtDiaChiTT_Leave(object sender, EventArgs e)
        {
            HopLe[1] = CheckDuLieuTrong(txtDiaChiTT, lblErrorDCTT);
        }

        private void txtDiaChiHT_Leave(object sender, EventArgs e)
        {
            HopLe[2] = CheckDuLieuTrong(txtDiaChiHT, lblErrorDCHT);
        }

        private void txtNghe_Leave(object sender, EventArgs e)
        {
            HopLe[3] = CheckDuLieuTrong(txtNghe, lblErrorNghe);
        }

        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            
            HopLe[4] = CheckDuLieuTrong(txtCCCD, lblErrorCCCD);
            if (HopLe[4] == true)
                try
                {
                    if (txtCCCD.Text.Length != 12)
                        throw new ApplicationException();
                    long.Parse(txtCCCD.Text);
                    ErrorProvider.SetError(txtCCCD, "");
                    lblErrorCCCD.Text = "";
                }
                catch(FormatException)
                {
                    HopLe[4] = false;
                    ErrorProvider.SetError(txtCCCD, "Số CCCD không hợp lệ");
                    lblErrorCCCD.Text = "Số CCCD chỉ chứa các số từ 0-9!";
                    lblErrorCCCD.ForeColor = Color.Red;

                }
                catch(ApplicationException)
                {
                    HopLe[4] = false;
                    ErrorProvider.SetError(txtCCCD, "Số CCCD không hợp lệ");
                    lblErrorCCCD.Text = "Số CCCD phải bao gồm 12 chữ số!";
                    lblErrorCCCD.ForeColor = Color.Red;
                }
            if (HopLe[4] == true)
            {
                CongDanDAO congDanDAO = new CongDanDAO();
                if (congDanDAO.CheckCCCD(txtCCCD.Text) == true)
                    HopLe[4] = true;
                else HopLe[4] = false;
                if (Them == false && txtCCCD.Text == CCCD)
                    HopLe[4] = true;
                if (HopLe[4] == true)
                {
                    ErrorProvider.SetError(txtCCCD, "");
                    lblErrorCCCD.Text = "";
                }
                else
                {
                    ErrorProvider.SetError(txtCCCD, "Số CCCD không hợp lệ");
                    lblErrorCCCD.Text = "CCCD đã tồn tại!";
                    lblErrorCCCD.ForeColor = Color.Red;
                }
            }
        }

        private void txtDanToc_Leave(object sender, EventArgs e)
        {
            HopLe[5] = CheckDuLieuTrong(txtDanToc, lblErrorDanToc);
        }
        private void txtTonGiao_Leave(object sender, EventArgs e)
        {
            HopLe[6] = CheckDuLieuTrong(txtTonGiao, lblErrorTonGiao);
        }
        private void txtHocVan_Leave(object sender, EventArgs e)
        {
            HopLe[7] = CheckDuLieuTrong(txtHocVan, lblErrorHocVan);
        }
        private bool CheckDuLieuTrong(Control controlTxt, Control controlLbl)
        {
            if (controlTxt.Text == "")
            {
                ErrorProvider.SetError(controlTxt, "Không được để trống!");
                controlLbl.Text = "Dữ liệu không được để trống!";
                controlLbl.ForeColor = Color.Red;
                return false;
            }
            else
            {
                ErrorProvider.SetError(controlTxt, "");
                controlLbl.Text = "";
                return true;
            }
        }

        private void FormChinhSuaThongTin_Load(object sender, EventArgs e)
        {
            if (Them == false)
                DuLieuCanSua();
        }

        private void rdbNam_CheckedChanged(object sender, EventArgs e)
        {
            ErrorProvider.SetError(rdbNu, "");
            lblErrorGioiTinh.Text = "";
        }

        private void rdbNu_CheckedChanged(object sender, EventArgs e)
        {
            ErrorProvider.SetError(rdbNu, "");
            lblErrorGioiTinh.Text = "";
        }
        private void DuLieuCanSua()
        {
            CongDanDAO congdanDao = new CongDanDAO();
            CongDan cd = congdanDao.LayDuLieuCongDan(CCCD);
            txtHoten.Text = cd.HoTen;
            dtpNgaySinh.Text = cd.NgaySinh.ToString();
            txtDiaChiTT.Text = cd.DiaChiHienTai;
            txtDiaChiHT.Text = cd.DiaChiThuongTru;
            txtNghe.Text = cd.NgheNghiep;
            txtHocVan.Text = cd.TrinhDoHocVan;
            if (cd.GioiTinh == "Nam")
                rdbNam.Checked = true;
            else rdbNu.Checked = true;
            txtCCCD.Text = cd.CCCD;
            txtDanToc.Text = cd.DanToc;
            txtTonGiao.Text = cd.TonGiao;
        }
        private void btnDataGoc_Click(object sender, EventArgs e)
        {
            DuLieuCanSua();
        }
    }
}

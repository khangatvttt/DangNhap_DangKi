using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap_DangKi
{
    public partial class F_Admin : Form
    {
        public F_Admin()
        {
            InitializeComponent();
        }
        private void F_Admin_Load(object sender, EventArgs e)
        {
            CongDanDAO congDanDAO = new CongDanDAO();
            dtgTTCongDan.DataSource = congDanDAO.LayDuLieu();
            SetDataGridView();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            FormChinhSuaThongTin FormThongTin = new FormChinhSuaThongTin();
            FormThongTin.Them = true;
            FormThongTin.ShowDialog();
            F_Admin_Load(sender, e);
        }
        private void SetDataGridView()
        {
            dtgTTCongDan.Columns[0].Width=110;
            dtgTTCongDan.Columns[0].HeaderText = "Họ tên";
            dtgTTCongDan.Columns[1].Width = 80;
            dtgTTCongDan.Columns[1].HeaderText = "Ngày sinh";
            dtgTTCongDan.Columns[2].Width = 70;
            dtgTTCongDan.Columns[2].HeaderText = "Địa chỉ\nthường trú";
            dtgTTCongDan.Columns[3].Width = 70;
            dtgTTCongDan.Columns[3].HeaderText = "Địa chỉ\nhiện tại";
            dtgTTCongDan.Columns[4].Width = 90;
            dtgTTCongDan.Columns[4].HeaderText = "Số CCCD";
            dtgTTCongDan.Columns[5].Width = 70;
            dtgTTCongDan.Columns[5].HeaderText = "Dân tộc";
            dtgTTCongDan.Columns[6].Width = 75;
            dtgTTCongDan.Columns[6].HeaderText = "Tôn giáo";
            dtgTTCongDan.Columns[7].Width = 70;
            dtgTTCongDan.Columns[7].HeaderText = "Giới tính";
            dtgTTCongDan.Columns[8].Width = 70;
            dtgTTCongDan.Columns[8].HeaderText = "Nghề\nnghiệp";
            dtgTTCongDan.Columns[9].Width = 70;
            dtgTTCongDan.Columns[9].HeaderText = "Trình độ\nhọc vấn";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int row = dtgTTCongDan.CurrentCell.RowIndex;
            string CCCD =dtgTTCongDan.Rows[row].Cells[4].Value.ToString();
            string Ten = dtgTTCongDan.Rows[row].Cells[0].Value.ToString();
            var XacNhan = MessageBox.Show("Bạn có chắc muốn xóa công dân "+Ten+" có mã CCCD là: "+CCCD+"?",
                                         "Xác nhận", MessageBoxButtons.YesNo);
            if (XacNhan == DialogResult.Yes)
            {
                CongDanDAO Cd = new CongDanDAO();
                Cd.XoaDuLieu(CCCD);
                F_Admin_Load(sender, e);
            }
            
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            FormChinhSuaThongTin FormThongTin = new FormChinhSuaThongTin();
            FormThongTin.Them = false;
            int row = dtgTTCongDan.CurrentCell.RowIndex;
            FormThongTin.CCCD = dtgTTCongDan.Rows[row].Cells[4].Value.ToString();
            FormThongTin.ShowDialog();
            F_Admin_Load(sender, e);
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            CongDanDAO congDanDAO = new CongDanDAO();
            dtgTTCongDan.DataSource = congDanDAO.TraCuuTheoHoTen(txtHoTen.Text);
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            CongDanDAO congDanDAO = new CongDanDAO();
            dtgTTCongDan.DataSource = congDanDAO.TraCuuTheoCCCD(txtCCCD.Text);
        }

        private void btnNhapLaiCCCD_Click(object sender, EventArgs e)
        {
            txtCCCD.Text = "";
        }

        private void btnNhapLaiHoTen_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
        }
    }
}

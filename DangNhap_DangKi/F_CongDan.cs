using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap_DangKi
{
    public partial class F_CongDan : Form
    {
        string CCCD = "022222222222";
        public F_CongDan()
        {
            InitializeComponent();
        }
        private void F_CongDan_Load(object sender, EventArgs e)
        {
            CongDanDAO congDanDAO = new CongDanDAO();
            CongDan cd = congDanDAO.LayDuLieuCongDan(CCCD);
            lblHoTen.Text = cd.HoTen;
            lblCCCD.Text = cd.CCCD;
            //
            congDanDAO.TinhThueQuaHan();
            DataTable data = congDanDAO.LayThue(CCCD);
            dtgThue.DataSource = data;
            SetDataGridView();
        }
        public Dictionary<string,int> LayTienThueChuaDong()
        {
            CongDanDAO congDanDAO = new CongDanDAO();
            DataTable data = congDanDAO.LayThueChuaDong(CCCD);
            Dictionary<string, int> TienThue = new Dictionary<string, int>(data.Rows.Count);
            foreach (DataRow row in data.Rows)
                TienThue.Add((string)row["LoaiThue"], (int)row["Tong"]);
            return TienThue;
        }
        private void SetDataGridView()
        {
            dtgThue.Columns[0].HeaderText = "Loại thuế";
            dtgThue.Columns[1].HeaderText = "Số tiền";
            dtgThue.Columns[2].HeaderText = "Ngày đến hạn";
            dtgThue.Columns[3].HeaderText = "Tình trạng";
            dtgThue.Columns[4].HeaderText = "Tiền phạt quá hạn";
            dtgThue.Columns[5].HeaderText = "Tổng tiền cần nộp";
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            CongDanDAO congDanDAO = new CongDanDAO();
            DataTable data = congDanDAO.LayThueChuaDong(CCCD);
            if (data.Rows.Count > 0)
            {
                DongThue dongThue = new DongThue();
                dongThue.ShowDialog();
                List<string> ThueChon = dongThue.LayDuLieuThueChon();
                string dataThueChon="";
                int TongTien = 0;
                Dictionary<string, int> ThueChuaDong = LayTienThueChuaDong();
                foreach (string i in ThueChon)
                {
                    if (i == "Tổng")
                        continue;
                    //
                    dataThueChon += i;
                    dataThueChon += '\n';
                    //
                    TongTien += ThueChuaDong[i];
                }
                richtxtDataChon.Text = dataThueChon;
                lblTienThue.Text = TongTien.ToString();
            }
            else
                MessageBox.Show("Bạn đã đóng đủ các loại thuế hiện tại", "Thông báo");
            
        }

        private void DongTien_Click(object sender, EventArgs e)
        {
            string[] ThueChon = richtxtDataChon.Text.Split('\n');
            CongDanDAO congDanDAO = new CongDanDAO();
            congDanDAO.DongThue(ThueChon);
            MessageBox.Show("Bạn đã đóng thuế thành công", "Thành công");
            F_CongDan_Load(sender,e);
        }
    }
}

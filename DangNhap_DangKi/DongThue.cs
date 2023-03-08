using System;
using System.Collections;
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
    public partial class DongThue : Form
    {
        public DongThue()
        {
            InitializeComponent();
        }

        private void DongThue_Load(object sender, EventArgs e)
        {
            F_CongDan f_CongDan = new F_CongDan();
            Dictionary<string,int> data = f_CongDan.LayTienThueChuaDong();
            foreach (KeyValuePair<string, int> entry in data)
                chlbDongThue.Items.Add(entry.Key);
        }

        private void chlbDongThue_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            F_CongDan f_CongDan = new F_CongDan();
            Dictionary<string, int> data = f_CongDan.LayTienThueChuaDong();
            List<string> checkedItems = new List<string>();
            foreach (var item in chlbDongThue.CheckedItems)
                checkedItems.Add(item.ToString());
            if (e.NewValue == CheckState.Checked)
                checkedItems.Add(chlbDongThue.Items[e.Index].ToString());
            else
                checkedItems.Remove(chlbDongThue.Items[e.Index].ToString());
            listviewThue.Items.Clear();
            int TongTien = 0;
            foreach (string item in checkedItems)
            {
                TongTien += data[item];
                ListViewItem Thue = new ListViewItem(item);
                ListViewItem.ListViewSubItem Tien = new ListViewItem.ListViewSubItem(Thue, data[item].ToString());
                Thue.SubItems.Add(Tien);
                listviewThue.Items.Add(Thue);
            }
            ListViewItem Tong = new ListViewItem("Tổng");
            ListViewItem.ListViewSubItem TienTong = new ListViewItem.ListViewSubItem(Tong, TongTien.ToString());
            Tong.SubItems.Add(TienTong);
            listviewThue.Items.Add(Tong);
            Tong.Font = new Font(listviewThue.Font, FontStyle.Bold);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public List<string> LayDuLieuThueChon()
        {
            List<string> TraDuLieuThue = new List<string>();
            foreach (ListViewItem i in listviewThue.Items)
                TraDuLieuThue.Add(i.Text);
            return TraDuLieuThue;
        }
    }
}

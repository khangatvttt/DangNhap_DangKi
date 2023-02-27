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
    public partial class F_DangKi : Form
    {
        public F_DangKi()
        {
            InitializeComponent();
        }

        private void CheckNull(object sender, EventArgs e)
        {
            bool flag = false;
            if (txtCCCD.Text == "" || txtXacNhanMK.Text == "" || txtTenTaiKhoan.Text == "" || txtHoTen.Text == " "
                || txtMatKhau.Text == "")
                flag = true;
            if (rdNam.Checked == false && rdNu.Checked == false)
                flag = true;
            if (flag)
            {
                btnDangKi.Enabled = false;
                btnDangKi.BackColor = Color.Gray;
                btnDangKi.ForeColor = Color.BlanchedAlmond;
            }
            else
            {
                btnDangKi.Enabled = true;
                btnDangKi.BackColor = Color.Blue;
                btnDangKi.ForeColor = Color.White;
            }
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            
            CheckNull(sender, e);
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            CheckNull(sender, e);
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            CheckNull(sender, e);
        }

        private void rdNam_CheckedChanged(object sender, EventArgs e)
        {
            CheckNull(sender, e);
        }

        private void rdNu_CheckedChanged(object sender, EventArgs e)
        {
            CheckNull(sender, e);
        }

        private void txtTenTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            CheckNull(sender, e);
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            CheckNull(sender, e);
        }

        private void txtXacNhanMK_TextChanged(object sender, EventArgs e)
        {
            CheckNull(sender, e);
        }
    }
}

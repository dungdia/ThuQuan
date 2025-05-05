using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClient.UI.Dialog.ChildDialog
{
    public partial class SelectTinhTrangVatDungTraDialog : Form
    {
        public ReturnDialog _parent;
        public int _idx;
        public SelectTinhTrangVatDungTraDialog(ReturnDialog parent, int idx)
        {
            InitializeComponent();
            _parent = parent;
            _idx = idx;

            tinhTrangDropDown.SelectedIndex = 0;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (_idx < 0)
            {
                MessageBox.Show("Chưa có vật dụng nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (tinhTrangDropDown.SelectedItem == null)
            {
                MessageBox.Show("Chưa có tình trạng nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _parent._ChiTietPhieuTraDTO[_idx].tinhtrang = tinhTrangDropDown.SelectedItem.ToString();
            _parent.refeshTable();
            Close();
        }

    }
}

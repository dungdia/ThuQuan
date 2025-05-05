using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClient.APIs;
using DesktopClient.DTO.ApiResponseDTO;

namespace DesktopClient.UI.Dialog.ChildDialog
{
    public partial class SelectThanhVienPhieuPhatDialog : Form
    {
        public PenaltyDialog _parent;
        public SelectThanhVienPhieuPhatDialog(PenaltyDialog parent)
        {
            InitializeComponent();
            _parent = parent;

            var response = APIContext.GetMethod<ThanhVienNotLockDTO>($"GetThanhVienNotLock");
            thanhVienDataTable.DataSource = response;
            thanhVienDataTable.Columns["id"].FillWeight = 30;
            thanhVienDataTable.Columns["id"].HeaderText = "ID";
            thanhVienDataTable.Columns["hoten"].HeaderText = "Họ Tên";
            thanhVienDataTable.Columns["soDienThoai"].HeaderText = "Số điện thoại";
            thanhVienDataTable.Columns["id_taikhoan"].Visible = false;
            thanhVienDataTable.Columns["tinhTrang"].HeaderText = "Tình trạng";
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if(thanhVienDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không có thành viên nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var idx = thanhVienDataTable.CurrentRow.Index;
            if (idx < 0)
            {
                MessageBox.Show("Vui lòng chọn một thành viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var id = thanhVienDataTable.Rows[idx].Cells["id"].Value.ToString();
            var hoten = thanhVienDataTable.Rows[idx].Cells["hoten"].Value.ToString();

            _parent._phieuPhatDTO.id_thanhvien = Int32.Parse(id);
            _parent._phieuPhatDTO.hoten = hoten;
            _parent.RefeshAtribute();
            //MessageBox.Show($"Đã chọn thành viên {hoten}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}

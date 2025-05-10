using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClient.APIs;
using DesktopClient.DTO.ApiRequestDTO;
using DesktopClient.DTO.ApiResponseDTO;
using DesktopClient.Models;

namespace DesktopClient.UI.Dialog
{
    public partial class DeleteMemeberDialog : Form
    {
        List<ThanhVienDTO> _listThanhVien;
        MemberPanel _parent;

        public DeleteMemeberDialog(List<ThanhVienDTO> list, MemberPanel parent)
        {
            InitializeComponent();
            _parent = parent;

            _listThanhVien = list;

            delete_member_table.DataSource = _listThanhVien;
            delete_member_table.Columns["password"].Visible = false;
        }

        private void Delete_Event(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show($"Bạn chắc chắn muốn xóa {_listThanhVien.Count} thành viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.No) return;
            List<DeleteBulkNhanVienRequestDTO> listIdTaiKhoan = new List<DeleteBulkNhanVienRequestDTO>();
            listIdTaiKhoan = _listThanhVien.Select(x => new DeleteBulkNhanVienRequestDTO { id_taikhoan = x.id_taikhoan, id_thanhvien = x.id_thanhvien }).ToList();
            var response = APIContext.PostMethod($"Admin/DeleteBulkThanhVien", listIdTaiKhoan.ToArray());
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(APIContext.getErrorMessage(response));
                return;
            }
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _parent.refeshTable();
            this.Close();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

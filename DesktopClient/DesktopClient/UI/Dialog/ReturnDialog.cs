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
using DesktopClient.DTO.ApiRequestDTO;
using DesktopClient.DTO.ApiResponseDTO;
using DesktopClient.Models;
using DesktopClient.UI.Dialog.ChildDialog;
using DesktopClient.UI.Panels;

namespace DesktopClient.UI.Dialog
{
    public partial class ReturnDialog : Form
    {
        public PhieuTraDTO _phieuTraDTO;
        public ReturnPanel _parent;
        public List<ChiTietPhieuTraDTO> _ChiTietPhieuTraDTO = new List<ChiTietPhieuTraDTO>();
        public int id_phieumuon = 0;

        public void refeshInputData()
        {
            ten_thanhvienTextBox.Text = _phieuTraDTO.ten_thanhvien;
            id_thanhvienTextBox.Text = _phieuTraDTO.id_thanhvien.ToString();
        }

        public void refeshTable()
        {
            chiTietPhieuTraTable.DataSource = null; //Để đây để nó add xong mới refresh lại
            chiTietPhieuTraTable.DataSource = _ChiTietPhieuTraDTO;
            chiTietPhieuTraTable.Columns["id_phieutra"].HeaderText = "ID Phiếu Trả";
            chiTietPhieuTraTable.Columns["id_vatdung"].HeaderText = "ID Vật Dụng";
            chiTietPhieuTraTable.Columns["tenvatdung"].HeaderText = "Tên Vật Dụng";
            chiTietPhieuTraTable.Columns["tinhtrang"].HeaderText = "Tình Trạng";
        }

        public void initialAtribute()
        {
            idTextBox.Text = _phieuTraDTO.id.ToString();
            id_nhanvienTextBox.Text = _phieuTraDTO.id_nhanvien.ToString();
            ten_nhanvienTextBox.Text = _phieuTraDTO.ten_nhanvien;
            id_thanhvienTextBox.Text = _phieuTraDTO.id_thanhvien.ToString();
            ten_thanhvienTextBox.Text = _phieuTraDTO.ten_thanhvien;
            thoigiantraTimePicker.Value = _phieuTraDTO.thoigiantra;
            thoigiantraTimePicker.Enabled = false;
            tinhtrangTextBox.Text = _phieuTraDTO.tinhtrang;
            _ChiTietPhieuTraDTO = APIContext.GetMethod<ChiTietPhieuTraDTO>($"getChiTietPhieuDat?id_phieutra={_phieuTraDTO.id}");

            refeshTable();
        }

        public ReturnDialog(ReturnPanel parent, string type, PhieuTraDTO phieuTraDTO)
        {
            InitializeComponent();
            this.Text = $"{type} Phiếu Trả";

            _phieuTraDTO = phieuTraDTO;
            _parent = parent;

            if (type == "Tạo")
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
                tinhtrangLabel.Visible = false;
                tinhtrangTextBox.Visible = false;
                tennhanvienLabel.Visible = false;
                ten_nhanvienTextBox.Visible = false;
                id_nhanvienTextBox.Visible = false;
                idnhanvienLabel.Visible = false;
                thoigiantraTimePicker.Visible = false;
                thoiGianTraLabel.Visible = false;
            }
            else
            {
                initialAtribute();
                changeItemPropertyBtn.Visible = false;
                selectBorrowBtn.Visible = false;
                createBtn.Visible = false;
            }



        }

        private void selectBorrowBtn_Click(object sender, EventArgs e)
        {
            var selectBorrowDialog = new SelectBorrowDialog(this);
            selectBorrowDialog.ShowDialog();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (id_phieumuon == 0)
            {
                MessageBox.Show("Chưa có phiếu mượn nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_ChiTietPhieuTraDTO.Count == 0)
            {
                MessageBox.Show("Chưa có phiếu mượn nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Bạn có muốn tạo phiếu trả?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.No)
                return;

            ChiTietPhieuTra[] listItem = _ChiTietPhieuTraDTO.Select(dto => new ChiTietPhieuTra()
            {
                id_phieutra = _phieuTraDTO.id,
                id_vatdung = dto.id_vatdung,
                tinhtrang = dto.tinhtrang
            }).ToArray();

            var addPhieuMuonRequestDTO = new AddPhieuTraRequestDTO()
            {
                id_phieumuon = id_phieumuon,
                id_thanhvien = _phieuTraDTO.id_thanhvien,
                listItem = listItem,
            };
          
            var response = APIContext.PostMethod("addPhieuTra", addPhieuMuonRequestDTO);
            
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(APIContext.getErrorMessage(response), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(response.Content, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _parent.refeshTable();
            Close();
        }

        private void changeItemPropertyBtn_Click(object sender, EventArgs e)
        {
            if (chiTietPhieuTraTable.CurrentRow == null)
            {
                MessageBox.Show("Không có vật dụng để chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var idx = chiTietPhieuTraTable.CurrentRow.Index;
            if (idx < 0)
            {
                MessageBox.Show("Chọn vật dụng để tiếp tục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectTinhTrangVatDungTraDialog = new SelectTinhTrangVatDungTraDialog(this, idx);
            selectTinhTrangVatDungTraDialog.ShowDialog();
        }

    }
}

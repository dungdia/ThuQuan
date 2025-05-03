using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClient.APIs;
using DesktopClient.DTO.ApiRequestDTO;
using DesktopClient.DTO.ApiResponseDTO;
using DesktopClient.UI.Dialog.ChildDialog;
using DesktopClient.UI.Panels;

namespace DesktopClient.UI.Dialog
{
    public partial class BorrowDialog : Form
    {
        public PhieuMuonDTO _phieuMuonDTO;
        public BorrowPanel _parent;
        public List<ChiTietPhieuMuonDTO> _ChiTietPhieuMuonDTO = new List<ChiTietPhieuMuonDTO>();

        public void refeshInputDate()
        {
            id_thanhvienTextBox.Text = _phieuMuonDTO.id_thanhvien.ToString();
            ten_thanhvienTextBox.Text = _phieuMuonDTO.ten_thanhvien;
        }

        public void refeshTable()
        {
            chiTietPhieuMuonTable.DataSource = null; //Để đây để nó add xong mới refresh lại
            chiTietPhieuMuonTable.DataSource = _ChiTietPhieuMuonDTO;
            chiTietPhieuMuonTable.Columns["id_phieumuon"].FillWeight = 30;
            chiTietPhieuMuonTable.Columns["id_vatdung"].FillWeight = 30;
            chiTietPhieuMuonTable.Columns["id_phieumuon"].HeaderText = "ID Phiếu Mượn";
            chiTietPhieuMuonTable.Columns["id_vatdung"].HeaderText = "ID Vật Dụng";
            chiTietPhieuMuonTable.Columns["tenvatdung"].HeaderText = "Tên Vật Dụng";
        }

        public void InitialAtribute()
        {
            idTextBox.Text = _phieuMuonDTO.id.ToString();
            id_nhanvienTextBox.Text = _phieuMuonDTO.id_nhanvien.ToString();
            ten_nhanvienTextBox.Text = _phieuMuonDTO.ten_nhanvien;
            id_thanhvienTextBox.Text = _phieuMuonDTO.id_thanhvien.ToString();
            ten_thanhvienTextBox.Text = _phieuMuonDTO.ten_thanhvien;
            thoigianMuonTimePicker.Value = _phieuMuonDTO.thoigianmuon;
            thoigiantraTimePicker.Value = _phieuMuonDTO.thoigiantra;
            thoigiantraTimePicker.Enabled = false;
            tinhtrangTextBox.Text = _phieuMuonDTO.tinhtrang;

            _ChiTietPhieuMuonDTO = APIContext.GetMethod<ChiTietPhieuMuonDTO>($"GetChiTietPhieuMuon?id_phieumuon={_phieuMuonDTO.id}");
            refeshTable();
        }

        public BorrowDialog(PhieuMuonDTO phieuMuonDTO, string type, BorrowPanel parent)
        {
            InitializeComponent();
            this.Text = $"{type} Phiếu Mượn";

            _phieuMuonDTO = phieuMuonDTO;
            _parent = parent;

            if (type == "Tạo")
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
                tinhtrangLabel.Visible = false;
                tinhtrangTextBox.Visible = false;
                thoigianMuonTimePicker.Visible = false;
                thoigianmuonLabel.Visible = false;
                tennhanvienLabel.Visible = false;
                ten_nhanvienTextBox.Visible = false;
                id_nhanvienTextBox.Visible = false;
                idnhanvienLabel.Visible = false;
            }
            else
            {
                InitialAtribute();
                addItemBtn.Visible = false;
                createBtn.Visible = false;
                removeItemBtn.Visible = false;
                selectUserBtn.Visible = false;
            }

        }

        private void createBtn_Click(object sender, EventArgs e)
        {

            if (_phieuMuonDTO.id_thanhvien == 0)
            {
                MessageBox.Show("Vui lòng chọn thành viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_ChiTietPhieuMuonDTO.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một vật dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (thoigiantraTimePicker.Value < DateTime.Today)
            {
                MessageBox.Show("Thời gian trả không được nhỏ hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn tạo phiếu mượn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }

            var listId = _ChiTietPhieuMuonDTO.Select(item => item.id_vatdung).ToArray();

            var requestObject = new AddPhieuMuonRequestDTO()
            {
                id_thanhvien = _phieuMuonDTO.id_thanhvien,
                listId = listId,
                thoigiantra = thoigiantraTimePicker.Value.ToString("yyyy-MM-dd'T'HH:mm:ssZ"),
            };
            var response = APIContext.PostMethod("InsertPhieuMuon", requestObject);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var error = APIContext.getErrorMessage(response);
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Tạo phiếu mượn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _parent.refeshTable();
            this.Close();
        }

        private void selectUserBtn_Click(object sender, EventArgs e)
        {
            var selectThanhVienDialog = new SelectThanhVienDialog(this);
            selectThanhVienDialog.ShowDialog();
        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            var selectedItem = _ChiTietPhieuMuonDTO.Select(item => item.id_vatdung).ToList();
            var selectItemDialog = new SelectItemDialog(this, selectedItem);
            selectItemDialog.ShowDialog();
        }

        private void removeItemBtn_Click(object sender, EventArgs e)
        {

            if (chiTietPhieuMuonTable.CurrentRow == null)
            {
                MessageBox.Show("Không có vật dụng nào để xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var idx = chiTietPhieuMuonTable.CurrentRow.Index;
            if (idx < 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa vật dụng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;
   
            _ChiTietPhieuMuonDTO.RemoveAt(idx);
            refeshTable();
        }
    }
}

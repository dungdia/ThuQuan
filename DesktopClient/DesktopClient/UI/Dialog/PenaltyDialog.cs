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
using DesktopClient.UI.Dialog.ChildDialog;
using DesktopClient.UI.Panels;

namespace DesktopClient.UI.Dialog
{
    public partial class PenaltyDialog : Form
    {
        public PenaltyPanel _parent;
        public PhieuPhatDTO _phieuPhatDTO;
        public string _type;
        public List<ChiTietPhieuPhatDTO> _chiTietPhieuPhatDTO = new List<ChiTietPhieuPhatDTO>();

        public void RefeshAtribute()
        {
            idTextBox.Text = _phieuPhatDTO.id.ToString();
            id_thanhvienTextBox.Text = _phieuPhatDTO.id_thanhvien.ToString();
            ten_thanhvienTextBox.Text = _phieuPhatDTO.hoten;
            mucPhatTextBox.Text = _phieuPhatDTO.mucphat;
        }

        public void InitializeAtribute()
        {
            idTextBox.Text = _phieuPhatDTO.id.ToString();
            id_thanhvienTextBox.Text = _phieuPhatDTO.id_thanhvien.ToString();
            ten_thanhvienTextBox.Text = _phieuPhatDTO.hoten;
            lyDoTextBox.Text = _phieuPhatDTO.lydo;
            mucPhatTextBox.Text = _phieuPhatDTO.mucphat;
            lyDoTextBox.ReadOnly = true;

            _chiTietPhieuPhatDTO = APIContext.GetMethod<ChiTietPhieuPhatDTO>($"GetChiTietPhieuPhat?id_phieuphat={_phieuPhatDTO.id}");
            chiTietPhieuPhatTable.DataSource = _chiTietPhieuPhatDTO;
            chiTietPhieuPhatTable.Columns["id_phieuphat"].HeaderText = "ID Phiếu Phạt";
            chiTietPhieuPhatTable.Columns["id_vatdung"].HeaderText = "ID Vật Dụng";
            chiTietPhieuPhatTable.Columns["tenvatdung"].HeaderText = "Tên Vật Dụng";
            chiTietPhieuPhatTable.Columns["ghichu"].HeaderText = "Ghi Chú";
        }

        public PenaltyDialog(PenaltyPanel parent, string type, PhieuPhatDTO phieuPhatDTO)
        {
            InitializeComponent();
            _parent = parent;
            _phieuPhatDTO = phieuPhatDTO;
            _type = type;

            this.Text = $"{type} Phiếu Phạt";


            if (type != "Tạo")
            {
                InitializeAtribute();
                selectUserBtn.Visible = false;
            }
            if(type == "Sửa")
            {
                selectUserBtn.Visible = true;
                lyDoTextBox.ReadOnly = false;
            }



        }

        private void selectPenaltyType_Click(object sender, EventArgs e)
        {
            var selectFineType = new SelectFineType(this);
            selectFineType.ShowDialog();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (mucPhatTextBox.Text == "")
            {
                MessageBox.Show("Mức phạt không được để trống");
                return;
            }
            if (_phieuPhatDTO.id_thanhvien == 0)
            {
                MessageBox.Show("Chưa chọn thành viên nào để thực hiện hành động này");
                return;
            }

            if (lyDoTextBox.Text == "")
            {
                MessageBox.Show("Lý do không được để trống");
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn thực hiện hành động này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            if (_type == "Xử lý")
            {
                var phieuPhatRequestDTO = new PhieuPhatRequestDTO()
                {
                    id = _phieuPhatDTO.id,
                    Id_ThanhVien = _phieuPhatDTO.id_thanhvien,
                    LyDo = _phieuPhatDTO.lydo,
                    MucPhat = _phieuPhatDTO.mucphat,
                };

                var response = APIContext.PostMethod("XuLyPhieuPhat", phieuPhatRequestDTO);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var errorResponse = APIContext.getErrorMessage(response);
                    MessageBox.Show(errorResponse, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(response.Content, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _parent.refeshTable();
                Close();
                return;
            }
            if(_type == "Tạo")
            {
                var phieuPhatRequestDTO = new PhieuPhatRequestDTO()
                {
                    id = 0,
                    Id_ThanhVien = _phieuPhatDTO.id_thanhvien,
                    LyDo = lyDoTextBox.Text,
                    MucPhat = _phieuPhatDTO.mucphat,
                };

                var response = APIContext.PostMethod("addPhieuPhat", phieuPhatRequestDTO);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var errorResponse = APIContext.getErrorMessage(response);
                    MessageBox.Show(errorResponse, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(response.Content, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _parent.refeshTable();
                Close();
                return;
            }
            if (_type == "Sửa")
            {
                var phieuPhatRequestDTO = new PhieuPhatRequestDTO()
                {
                    id = _phieuPhatDTO.id,
                    Id_ThanhVien = _phieuPhatDTO.id_thanhvien,
                    LyDo = lyDoTextBox.Text,
                    MucPhat = _phieuPhatDTO.mucphat,
                };
                var response = APIContext.PostMethod("updatePhieuPhat", phieuPhatRequestDTO);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var errorResponse = APIContext.getErrorMessage(response);
                    MessageBox.Show(errorResponse, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(response.Content, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _parent.refeshTable();
                Close();
                return;
            }


        }

        private void selectUserBtn_Click(object sender, EventArgs e)
        {
            var selectThanhVienPhieuPhatDialog = new SelectThanhVienPhieuPhatDialog(this);
            selectThanhVienPhieuPhatDialog.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClient.APIs;
using DesktopClient.DTO.ApiResponseDTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesktopClient.UI.Dialog
{
    public partial class MemberDialog : Form
    {
        private ThanhVienDTO _editThanhVienDTO;
        private string _type;
        public MemberPanel _parent;

        public MemberDialog(ThanhVienDTO thanhvienDTO, string type, MemberPanel parent)
        {
            InitializeComponent();
            _editThanhVienDTO = thanhvienDTO;
            _type = type;
            _parent = parent;
            Text = $"{type} thành viên";

            idThanhVien_Input.Text = thanhvienDTO.id_thanhvien.ToString();
            idTaiKhoan_Input.Text = thanhvienDTO.id_taikhoan.ToString();
            username_Input.Text = thanhvienDTO.username;
            email_Input.Text = thanhvienDTO.email;
            hoten_Input.Text = thanhvienDTO.hoten;
            sodienthoai_Input.Text = thanhvienDTO.sodienthoai;
            tinhTrang_Txt.Text = thanhvienDTO.tinhtrang;

            if(type == "Xem")
            {
                // Label
                xn_mk_lb.Visible = false;
                mk_lb.Visible = false;
                // 
                xn_matkhau_Input.Visible = false;
                matkhau_Input.Visible = false;
                // 
                confirmBtn.Visible = false;
                // Lock all input
                username_Input.ReadOnly = true;
                email_Input.ReadOnly = true;
                hoten_Input.ReadOnly = true;
                sodienthoai_Input.ReadOnly = true;
            }
        }

        private void ConfirmEvent(object sender, EventArgs e)
        {
            _editThanhVienDTO.username = username_Input.Text;
            _editThanhVienDTO.email = email_Input.Text;
            _editThanhVienDTO.hoten = hoten_Input.Text;
            _editThanhVienDTO.sodienthoai = sodienthoai_Input.Text;
            _editThanhVienDTO.tinhtrang = tinhTrang_Txt.Text;

            Debug.WriteLine("Confirm event");
            if (matkhau_Input.Text != "" && matkhau_Input.Text.Length < 6)
            { 
                MessageBox.Show("Mật khẩu phải ít nhất 6 kí tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (xn_matkhau_Input.Text != matkhau_Input.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(xn_matkhau_Input.Text == matkhau_Input.Text)
            {
                var password = matkhau_Input.Text == "" ? "" : matkhau_Input.Text;
                _editThanhVienDTO.password = password;
                Debug.WriteLine(_editThanhVienDTO.ToString());

                var response = APIContext.PostMethod($"Admin/UpdateThanhVienAdmin?idTaiKhoan={_editThanhVienDTO.id_taikhoan}", _editThanhVienDTO);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var error = APIContext.getErrorMessage(response);
                    MessageBox.Show(error);
                }
                MessageBox.Show(response.Content);
                _parent.refeshTable("all", "");
            }
        }
    }
}

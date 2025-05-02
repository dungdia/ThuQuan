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
using DesktopClient.Models;
using DesktopClient.UI.Dialog.ChildDialog;
using DesktopClient.UI.Panels;

namespace DesktopClient.UI.Dialog
{
    public partial class BookingDialog : Form
    {
        private PhieuDatDTO _adminPhieuDatDTO;
        private string _type;
        public BookingPanel _parent;
        public BookingDialog(PhieuDatDTO adminPhieuDatDTO, string type, BookingPanel parent)
        {
            InitializeComponent();
            _adminPhieuDatDTO = adminPhieuDatDTO;
            _type = type;
            _parent = parent;
            Text = $"{type} phiếu đặt";

            if (type == "Xem")
            {
                processBtn.Visible = false;
            }


            idTextBox.Text = adminPhieuDatDTO.id.ToString();
            id_thanhvienTextBox.Text = adminPhieuDatDTO.id_thanhvien.ToString();
            nameTextBox.Text = adminPhieuDatDTO.hoten;
            dateTextBox.Text = adminPhieuDatDTO.ngaydat.ToString("dd/MM/yyyy");
            tinhTrangTextBox.Text = adminPhieuDatDTO.tinhtrang;


            var response = APIContext.GetMethod<ChiTietPhieuDatDTO>($"getChiTietPhieuDatAdmin?id_phieudat={adminPhieuDatDTO.id}");
            ChiTietPhieuDatDataTable.DataSource = response;
            ChiTietPhieuDatDataTable.Columns["id_phieudat"].HeaderText = "ID Phiếu Đặt";
            ChiTietPhieuDatDataTable.Columns["id_vatdung"].HeaderText = "ID Vật Dụng";
            ChiTietPhieuDatDataTable.Columns["tenvatdung"].HeaderText = "Tên Vật Dụng";
        }

        private void processBtn_Click(object sender, EventArgs e)
        {
            var bookingDateInputDialog = new BookingDateInputDialog(_adminPhieuDatDTO,this);
            bookingDateInputDialog.ShowDialog();
        }
    }
}

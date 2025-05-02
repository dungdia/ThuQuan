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

namespace DesktopClient.UI.Dialog.ChildDialog
{
    public partial class BookingDateInputDialog : Form
    {

        private PhieuDatDTO _adminPhieuDatDTO;
        private BookingDialog _parent;

        public BookingDateInputDialog(PhieuDatDTO adminPhieuDatDTO,BookingDialog parent)
        {
            InitializeComponent();
            _adminPhieuDatDTO = adminPhieuDatDTO;
            _parent = parent;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            var bookingDate = dateTimePicker1.Value;
            if (bookingDate < DateTime.Today)
            {
                MessageBox.Show("Ngày dự kiến trả không hợp lệ","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            var requestObj = new PhieuDatToPhieuMuonRequestDTO()
            {
                id_PhieuDat = _adminPhieuDatDTO.id,
                ngayTra = bookingDate.ToString("yyyy-MM-dd'T'HH:mm:ssZ"),
            };
            //var json = System.Text.Json.JsonSerializer.Serialize(requestObj);
            var response = APIContext.PostMethod("AddPhieuMuonFromPhieuDat", requestObj);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //var error = APIContext.getErrorMessage(response);
                MessageBox.Show(response.Content, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Đã chuyển thành phiếu mượn thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _parent._parent.refeshTable();
            _parent.Close();
            Close();
        }
    }
}

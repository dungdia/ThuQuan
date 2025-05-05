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
    public partial class SelectBorrowDialog : Form
    {
        ReturnDialog _parent;
        public List<PhieuMuonDTO> _PhieuMuonDTO = new List<PhieuMuonDTO>();

        public SelectBorrowDialog(ReturnDialog parent)
        {
            InitializeComponent();
            _parent = parent;

            _PhieuMuonDTO = APIContext.GetMethod<PhieuMuonDTO>("GetPhieuMuon?type=Chưa trả");
            phieuMuonTable.DataSource = _PhieuMuonDTO;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            var searchItem = _PhieuMuonDTO.Where(pm => pm.ten_thanhvien.ToLower()
                                                    .Contains(searchInput.Text.ToLower())).ToList();
            phieuMuonTable.DataSource = searchItem;
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (phieuMuonTable.CurrentRow == null)
            {
                MessageBox.Show("Không có phiếu mượn để chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var idx = phieuMuonTable.CurrentRow.Index;
            if (idx < 0)
            {
                MessageBox.Show("Chọn một phiếu mượn để tiếp tục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var chiTietPhieuMuon = APIContext.GetMethod<ChiTietPhieuMuonDTO>($"GetChiTietPhieuMuon?id_phieumuon={phieuMuonTable.Rows[idx].Cells["id"].Value.ToString()}");
            var chiTietPhieuTra = new List<ChiTietPhieuTraDTO>();
            chiTietPhieuTra = chiTietPhieuMuon.Select(ctpm => new ChiTietPhieuTraDTO()
            {
                id_phieutra = _parent._phieuTraDTO.id,
                id_vatdung = ctpm.id_vatdung,
                tenvatdung = ctpm.tenvatdung,
                tinhtrang = "Nguyên vẹn",
            }).ToList();

            _parent.id_phieumuon = Int32.Parse(phieuMuonTable.Rows[idx].Cells["id"].Value.ToString());
            _parent._phieuTraDTO.ten_thanhvien = phieuMuonTable.Rows[idx].Cells["ten_thanhvien"].Value.ToString();
            _parent._phieuTraDTO.id_thanhvien = Int32.Parse(phieuMuonTable.Rows[idx].Cells["id_thanhvien"].Value.ToString());
            _parent._ChiTietPhieuTraDTO = chiTietPhieuTra;

            _parent.refeshTable();
            _parent.refeshInputData();
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

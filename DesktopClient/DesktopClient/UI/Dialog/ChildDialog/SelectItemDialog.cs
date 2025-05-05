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

namespace DesktopClient.UI.Dialog.ChildDialog
{
    public partial class SelectItemDialog : Form
    {
        List<VatDung> _vatDungList = new List<VatDung>();
        List<int> _selectedItems = new List<int>();
        BorrowDialog _parent;

        public SelectItemDialog(BorrowDialog parent, List<int> selectedItems)
        {
            InitializeComponent();
            _parent = parent;
            _selectedItems = selectedItems;

            _vatDungList = APIContext.GetMethod<VatDung>("GetVatDungChuaMuon").Where(vd => !_selectedItems.Contains(vd.id)).ToList();
            VatDungTable.DataSource = _vatDungList;
            VatDungTable.Columns["id"].FillWeight = 30;
            VatDungTable.Columns["tenVatDung"].HeaderText = "Tên Vật Dụng";
            VatDungTable.Columns["hinhAnh"].Visible = false;
            VatDungTable.Columns["moTa"].Visible = false;
            VatDungTable.Columns["id_LoaiVatDung"].Visible = false;
            VatDungTable.Columns["tinhTrang"].Visible = false;
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            var chiTietPhieuMuon = new ChiTietPhieuMuonDTO()
            {
                id_phieumuon = _parent._phieuMuonDTO.id,
                id_vatdung = (int)VatDungTable.SelectedRows[0].Cells["id"].Value,
                tenvatdung = VatDungTable.SelectedRows[0].Cells["tenVatDung"].Value.ToString()
            };

            _parent._ChiTietPhieuMuonDTO.Add(chiTietPhieuMuon);
            _parent.refeshTable();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            var tempList = _vatDungList
                .Where(vd => vd.tenVatDung.ToLower().Contains(searchInput.Text.ToLower())).ToList();

            VatDungTable.DataSource = tempList;

        }
    }
}

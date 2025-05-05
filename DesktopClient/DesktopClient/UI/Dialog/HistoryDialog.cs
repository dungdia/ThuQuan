using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClient.APIs;
using DesktopClient.DTO.ApiResponseDTO;
using DesktopClient.UI.Panels;

namespace DesktopClient.UI.Dialog
{
    public partial class HistoryDialog : Form
    {

        public List<LichSuDTO> LichSuList { get; set; }
        public string _type;
        public int? _idtv;
        HistoryPanel _parent;


        public HistoryDialog(int? idThanhVien, string type, HistoryPanel parent)
        {
            InitializeComponent();
            _parent = parent;
            _type = type;
            _idtv = idThanhVien ?? null;

            month_cBox.SelectedIndex = 0;
            year_cBox.SelectedIndex = 0;


            Text = "Danh sách lịch sử";

            // id có khả năng null
            refeshTable(_idtv, "", "");
        }

        public void refeshTable(int? idThanhVien, string type, params object?[] value)
        {
            LichSuList = APIContext.GetMethod<LichSuDTO>($"LichSu/GetLichSu?id_thanhvien={idThanhVien}");
            Debug.WriteLine(value[0]);
            //Debug.WriteLine(LichSuList[0].thoigianvao.ToString("MM"));
            if (idThanhVien != null)
            {
                LichSuList = LichSuList.Where(x => x.id_thanhvien == Convert.ToInt32(idThanhVien)).ToList();
            }
            if (type == "time" && value[0] != null)
            {
                LichSuList = LichSuList.Where(x => x.thoigianvao.ToString("MM").Contains(value[0].ToString())).ToList();
            }
            if (type == "time" && value[1] != null)
            {
                LichSuList = LichSuList.Where(x => x.thoigianvao.ToString("yyyy").Contains(value[1].ToString())).ToList();
            }

            XemLichSu_Table.DataSource = LichSuList;

            XemLichSu_Table.Columns["id_thanhvien"].HeaderText = "ID";
            XemLichSu_Table.Columns["id_thanhvien"].FillWeight = 30;
            XemLichSu_Table.Columns["thoigianvao"].HeaderText = "Thời gian vào";


            XemLichSu_Table.Columns["id_lichsu"].Visible = false;
            XemLichSu_Table.Columns["sodienthoai"].Visible = false;
            XemLichSu_Table.Columns["tinhtrang"].Visible = false;
        }

        private void SearchEvent(object sender, EventArgs e)
        {
            if (month_cBox.SelectedIndex == -1 && year_cBox.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tháng hoac nam", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refeshTable(_idtv, "time", [month_cBox.SelectedItem, year_cBox.SelectedItem]);
        }

        private void ResetEvent(object sender, EventArgs e)
        {
            refeshTable(_idtv, "reset", "");
            month_cBox.SelectedIndex = -1;
            year_cBox.SelectedIndex = -1;
        }
    }
}

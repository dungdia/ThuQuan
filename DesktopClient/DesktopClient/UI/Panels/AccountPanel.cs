using DesktopClient.APIs;
using DesktopClient.Models;

namespace DesktopClient.UI;

public partial class AccountPanel : UserControl
{
    List<TaiKhoan> taiKhoans = new();
    
    public AccountPanel()
    {
        InitializeComponent();
        taiKhoans = APIContext.GetMethod<TaiKhoan>("GetTaiKhoan");
        dataGridView1.DataSource = taiKhoans;
        dataGridView1.CellFormatting += cellFormatting;
        dataGridView1.Columns["id"].HeaderText = "ID";
        dataGridView1.Columns["id"].FillWeight = 30;
        dataGridView1.Columns["userName"].HeaderText = "Tên đăng nhập";
        dataGridView1.Columns["password"].Visible = false;
        dataGridView1.Columns["email"].HeaderText = "Email";
        dataGridView1.Columns["ngayThamGia"].HeaderText = "Ngày tham gia";
        dataGridView1.Columns["vaiTro"].HeaderText = "Vai trò";
        dataGridView1.Columns["tinhTrang"].HeaderText = "Tình trạng";
    }

    private void cellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // Check xem cột hiện tại có phải là cột "vaiTro" không
        if (dataGridView1.Columns[e.ColumnIndex].Name == "vaiTro" && e.Value != null )
        {
            // Đổi từ string sang int và check
            int vaiTroValue = Convert.ToInt32(e.Value);
            e.Value = vaiTroValue == 1 ? "Nhân viên" : "Thành viên";
            //if (vaiTroValue == 1)
            //{
            //    e.Value = "Nhân viên";
            //} else
            //{
            //    e.Value = "Thành viên";
            //}
            e.FormattingApplied = true;
        }
    }
}
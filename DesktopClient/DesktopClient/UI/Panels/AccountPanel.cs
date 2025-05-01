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
        dataGridView1.Columns["id"].HeaderText = "ID";
        dataGridView1.Columns["userName"].HeaderText = "Tên đăng nhập";
        dataGridView1.Columns["password"].HeaderText = "Mật khẩu";
        dataGridView1.Columns["email"].HeaderText = "Email";
        dataGridView1.Columns["ngayThamGia"].HeaderText = "Ngày tham gia";
        dataGridView1.Columns["vaiTro"].HeaderText = "Vai trò";
        dataGridView1.Columns["tinhTrang"].HeaderText = "Tình trạng";
    }
}
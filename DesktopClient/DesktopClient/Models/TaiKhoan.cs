namespace DesktopClient.Models;

public class TaiKhoan
{
    public int       id { get; set; }
    public string    userName { get; set; }
    public string    password { get; set; }
    public string    email { get; set; }
    public DateTime  ngayThamGia { get; set; }
    public int    vaiTro { get; set; }
    
    public string tinhTrang { get; set; }
    
    public string toString()
    {
        return $"id: {id} \n ngayThamGia: {ngayThamGia}";
    }
}
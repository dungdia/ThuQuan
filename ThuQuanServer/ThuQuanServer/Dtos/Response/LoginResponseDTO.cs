namespace ThuQuanServer.Dtos.Response;

public class LoginResponseDTO
{
    public string accessToken {get; set;}
    
    public string UserName {get; set;}
    
    public string Email { get; set; }

    public int vaitro { get; set; }
    
    public string hoten { get; set; }
    
    public string sdt {get; set;}
}
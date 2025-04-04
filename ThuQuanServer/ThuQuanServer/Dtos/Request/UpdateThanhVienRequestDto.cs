using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class UpdateThanhVienRequestDto
{ 
    public int Id { get; set; }
    

    public string UserName {get;set;}
    
    public string Hoten {get;set;}
    
    public string Email {get;set;}
    
    public string sdt {get;set;}
}
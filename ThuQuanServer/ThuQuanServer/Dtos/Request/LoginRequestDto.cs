using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [Length(6,100,ErrorMessage = "Password must be between 6 and 100 characters.")]
    public string Password { get; set; }
}
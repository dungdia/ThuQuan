using System.Security.Claims;
using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IAuthService
{
    string GenerateJwtAccessToken(TaiKhoan user);

    public int DecodeJwtAccessToken(string token);
}
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Dtos.Response;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;
using ThuQuanServer.Repository;

namespace ThuQuanServer.Endpoints;

public static class SecurityEndpoint
{
    public static void MapSecurityEndpoints(this IEndpointRouteBuilder app)
    {
        var _dbcontext = app.ServiceProvider.GetRequiredService<DbContext>();
        var authService = app.ServiceProvider.GetRequiredService<IAuthService>();
        var taikhoanRepository = app.ServiceProvider.GetRequiredService<ITaiKhoanRepository>();
        var nhanvienRepository = app.ServiceProvider.GetRequiredService<INhanVienRepository>();
        var passwordHashService = app.ServiceProvider.GetRequiredService<IPasswordHashService>();
        var groupName = "Xac thuc";

        app.MapPost("/adminlogin", ([FromBody] LoginRequestDto LoginRequestDto) =>
        {
            var taikhoan = taikhoanRepository.GetAccountByProps(new { Email = LoginRequestDto.Email });
            if (taikhoan.Count == 0)
            {
                return Results.NotFound("Không tìm thấy tài khoản");
            }

            var tk = taikhoan.First();

            if (tk.VaiTro != 1)
            {
                return Results.NotFound("Không tìm tấy tài khoản");
            }
            
            if (tk.TinhTrang == "Đã bị khoá")
            {
                return Results.BadRequest("Tài khoản đã bị khoá");
            }

            if (!passwordHashService.VerifyPassword(LoginRequestDto.Password, tk.Password))
            {
                return Results.BadRequest("Mật khẩu không chính xác");
            }

            var nhanvien = nhanvienRepository.GetNhanVienByProps(new { Id_TaiKhoan= tk.Id }).FirstOrDefault();

            if (nhanvien == null)
            {
                return Results.NotFound("Không tìm thấy nhân viên"); 
            }

            var accesstoken = authService.GenerateJwtAccessToken(tk);
            
            return Results.Ok(new
            {
                accesstoken=accesstoken,
                tenNhanVien=nhanvien.HoTen
            });
        }).WithMetadata(typeof(LoginRequestDto)).WithTags(groupName);
        
        app.MapPost("/userlogin", ([FromBody] LoginRequestDto loginRequestDto) =>
        {

            var taikhoan = taikhoanRepository.GetAccountByProps(new { Email = loginRequestDto.Email });
            if (taikhoan.Count == 0)
            {
                return Results.NotFound("Không tìm thấy người dùng");
            }

            var tk = taikhoan.First();
            
            if (tk.TinhTrang == "Đã bị khoá")
            {
                return Results.BadRequest("Tài khoản đã bị khoá");
            }
            
            if (!passwordHashService.VerifyPassword(loginRequestDto.Password, tk.Password))
                return Results.BadRequest("Mật khẩu không chính xác");

            var accessToken = authService.GenerateJwtAccessToken(tk);
            if (tk.VaiTro == 1)
            {
                return Results.BadRequest("Không tìm thấy người dùng");
            }
            
        var query = @"SELECT tk.*,tv.HoTen, tv.SoDienThoai
            FROM TaiKhoan tk
            JOIN ThanhVien tv ON tk.Id = tv.Id_TaiKhoan
            WHERE tk.Email = ?";
            var result = _dbcontext.ExcuteQuerry(query, tk.Email).First();
            if (result == null)
            {
                return Results.BadRequest("Thành viên không tồn tại");
            }
            return Results.Ok(new LoginResponseDTO
            {
                accessToken = accessToken,
                Email = tk.Email,
                UserName = tk.UserName,
                vaitro = tk.VaiTro,
                hoten = (string) result["HoTen"],
                sdt = (string) result["SoDienThoai"],
            });
        }).WithMetadata(typeof(LoginRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        }).WithTags(groupName);

        app.MapGet("JwtSecure", (HttpContext context) =>
        {
          var Authoriation = context.Request.Headers.Authorization.ToString();
          var token = Authoriation.Substring(7,Authoriation.Length-7);
          
          Console.WriteLine(token);
          return Results.Ok($"tai khoan id: {authService.DecodeJwtAccessToken(token)}");
        })
        .WithTags(groupName).RequireAuthorization();
    }
}
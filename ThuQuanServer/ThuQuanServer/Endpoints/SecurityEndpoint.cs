using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;
using ThuQuanServer.Repository;

namespace ThuQuanServer.Endpoints;

public static class SecurityEndpoint
{
    public static void MapSecurityEndpoints(this IEndpointRouteBuilder app)
    {
        var authService = app.ServiceProvider.GetRequiredService<IAuthService>();
        var taikhoanRepository = app.ServiceProvider.GetRequiredService<ITaiKhoanRepository>();
        var passwordHashService = app.ServiceProvider.GetRequiredService<IPasswordHashService>();
        var groupName = "Xac thuc";

        app.MapGet("/login", ( [FromQuery] string username, [FromQuery] string password) =>
        {
            
            var taikhoan = taikhoanRepository.GetAccountByProps(new {username=username});
            if (taikhoan.Count == 0)
            {
                return Results.BadRequest("Không đúng tài khoản hoặc mật khẩu");
            }

            var tk = taikhoan.First();
            Console.WriteLine(tk.UserName);
            Console.WriteLine(tk.Password);
            if(!passwordHashService.VerifyPassword(password, tk.Password))
                return Results.BadRequest("Không đúng tài khoản hoặc mật khẩu");
            
            var accessToken = authService.GenerateJwtAccessToken(tk);
            
            return Results.Ok(accessToken);
        }).WithTags(groupName);

        app.MapGet("/JwtSecure", () =>
        {
            return "hello world";
        }).WithTags(groupName).RequireAuthorization();
    }
}
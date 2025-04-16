using System.Text;
using Microsoft.AspNetCore.Mvc;
using ThuQuanServer.Interfaces;

namespace ThuQuanServer.Endpoints;

public static class SendOTPEndpoint
{
    public static void MapSendOTPEndpoints(this IEndpointRouteBuilder app)
    {
        var sendOtpRepository = app.ServiceProvider.GetRequiredService<ISendOTPRepository>();
        var taikhoanRepository = app.ServiceProvider.GetRequiredService<ITaiKhoanRepository>();

        app.MapPost("/OTP", async ([FromQuery]string Email) =>
        {
            try
            {   
                // Kiểm tra tài khoản có tồn tại không
                var account =  taikhoanRepository.CheckTaiKhoanExist(Email);
                if (!account)
                {
                    return Results.BadRequest("Tài khoản không tồn tại");
                }
                
                // Tạo mã OTP ngẫu nhiên
                string otp = GenerateOTP();
                
                // Nội dung HTML
                string html = $"<h1>Xin chào!<h1/>" +
                              $"<p>Mã OTP của bạn là: <strong>{otp}<strong/><p/>";
                // Gửi Email
                sendOtpRepository.sendHTMLMessage(Email,"Send OTP",html);
                
                // Gửi phản hồi
                var response = new
                {
                    message = "Gửi mã OTP thành công!",
                    otp = otp
                };
                
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Đã xảy ra lỗi khi gửi email: {ex.Message}");
            }
        }).WithTags("Mã OTP").WithName("OTP");
        
        static string GenerateOTP()
        {
            var random = new Random();
            var otp = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                otp.Append(random.Next(10));
            }
            return otp.ToString();
        }

    }
}
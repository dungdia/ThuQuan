using Microsoft.AspNetCore.Mvc;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Endpoints;

public static class ThanhVienEndpoints
{
    public static void MapThanhVienEndpoint(this IEndpointRouteBuilder app)
    {
        var dbContext = app.ServiceProvider.GetRequiredService<DbContext>();
        var taiKhoanRepository = app.ServiceProvider.GetRequiredService<ITaiKhoanRepository>();
        var passwordHashService = app.ServiceProvider.GetRequiredService<IPasswordHashService>();
        
        // GET
        // Admin 
        // Speed run version, xử lý search bằng linq trên winform
        // Admin
        app.MapGet("/Admin/GetThanhVien", ([FromQuery] int idThanhVien) =>
        {
            var queryFindAccount = @"SELECT tk.id AS id_taikhoan, tk.username, tk.email, tk.ngaythamgia, tv.id as id_thanhvien, tv.hoten, tv.sodienthoai, tv.tinhtrang 
                                     FROM taikhoan tk JOIN thanhvien tv 
                                     ON tk.id = tv.id_taikhoan WHERE tv.id = ?";
            var idTaiKhoan = dbContext.ExcuteQuerry(queryFindAccount, idThanhVien).FirstOrDefault();
            
            return Results.Ok(idTaiKhoan);
        }).WithTags("admin");
        // Đăng kí nhan viên
        app.MapPost("/Admin/AddThanhVienAdmin", (TaiKhoanRequestDto req) =>
        {
            Console.WriteLine(req);
    
            var existedUsername = taiKhoanRepository.GetAccount().Where(x => x.UserName == req.UserName).ToList();
            if (existedUsername.Any())
            {
                return Results.BadRequest("Tên tài khoản đã tồn tại");
            }
            var existedEmail = taiKhoanRepository.GetAccount().Where(x => x.Email == req.Email).ToList();
            if (existedEmail.Any())
            {
                return Results.BadRequest("Tên email đã tồn tại");
            }
            
            req.Password = passwordHashService.HashPassword(req.Password);
            
            var insertAccountDTO = new
            {
                username = req.UserName,
                email = req.Email,
                ngaythamgia = DateTime.Now,
                password = req.Password,
                vaiTro = req.VaiTro
            };
            
            dbContext.Add<TaiKhoan>(insertAccountDTO);
            var lastId = dbContext.GetLastInsertId();

            var insertThanhVienDTO = new
            {
                id_taikhoan = lastId,
                hoten = "",
                sodienthoai = "",
                tinhtrang = 1
            };
            
            dbContext.Add<ThanhVien>(insertThanhVienDTO);
            
            dbContext.SaveChange();
            
            return Results.Ok("Đăng ký thành công");
        }).WithTags("admin").WithMetadata(typeof(TaiKhoanRequestDto));
        
        // Cập nhât thông tin nhân viên
        app.MapPost("/Admin/UpdateThanhVienAdmin", ([FromQuery] int idTaiKhoan, [FromBody] AdminUpdateThanhVienRequestDTO request) =>
        {
            var queryFindStaff = "SELECT id FROM thanhvien WHERE id_taikhoan = ?";
            var idThanhVien = dbContext.ExcuteQuerry(queryFindStaff, idTaiKhoan).Select(x => x["id"]).FirstOrDefault();
            
            var existedUsername = dbContext.ExcuteQuerry("SELECT * FROM taikhoan WHERE username = ? AND id != ?", request.username, idTaiKhoan).ToList();
            if (existedUsername.Any())
            {
                return Results.BadRequest("Tên tài khoản đã tồn tại");
            }
            var existedEmail = dbContext.ExcuteQuerry("SELECT * FROM taikhoan WHERE email = ? AND id != ?", request.email, idTaiKhoan).ToList();
            if (existedEmail.Any())
            {
                return Results.BadRequest("email đã tồn tại");
            }
            
            var queryUpdateStaff = "UPDATE taikhoan SET username = ?, email = ? WHERE id = ?";
            if (request.password != null || request.password != "")
            {
                request.password = passwordHashService.HashPassword(request.password);
                queryUpdateStaff = "UPDATE taikhoan SET username = ?, email = ?, password = ? WHERE id = ?";
            }
            
            var result = dbContext.ExecuteNonQuery(queryUpdateStaff, request.username, request.email, request.password != "" ? request.password : null, idTaiKhoan);
            if (result != 1)
            {
                return Results.BadRequest("Cập nhật thông tin thành viên không thành công");
            }
            
            var queryUpdateThanhVien = "UPDATE thanhvien SET hoten = ?, sodienthoai = ? WHERE id = ?";
            dbContext.ExecuteNonQuery(queryUpdateThanhVien, request.hoten, request.sodienthoai, idThanhVien);
            if (result != 1)
            {
                return Results.BadRequest("Cập nhật thông tin tài khoản không thành công");
            }

            return Results.Ok("Cập nhât thông tin tài khoản thành viên thành công");
        }).WithTags("admin");

        // app.MapPost("/Admin/KhoaThanhVien", ([FromQuery] int idThanhVien) =>
        // {
        //     var queryFindAccount = "SELECT id FROM thanhvien WHERE id_taikhoan = ?";
        // });
    }
}
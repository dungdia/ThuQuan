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
        app.MapGet("/Admin/GetThanhVien", ([FromQuery] int? idThanhVien) =>
        {
            if (idThanhVien == null)
            {
                var queryFindAccount = @"SELECT tk.id AS id_taikhoan, tk.username, tk.email, tk.ngaythamgia, tv.id as id_thanhvien, tv.hoten, tv.sodienthoai, tv.tinhtrang 
                                     FROM taikhoan tk JOIN thanhvien tv ON tk.id = tv.id_taikhoan ";
                var tks = dbContext.ExcuteQuerry(queryFindAccount, idThanhVien);
                return Results.Ok(tks);
            }
            else
            {
                var queryFindAccount = @"SELECT tk.id AS id_taikhoan, tk.username, tk.email, tk.ngaythamgia, tv.id as id_thanhvien, tv.hoten, tv.sodienthoai, tv.tinhtrang 
                                 FROM taikhoan tk JOIN thanhvien tv 
                                 ON tk.id = tv.id_taikhoan WHERE tv.id = ?";      
                var tks = dbContext.ExcuteQuerry(queryFindAccount, idThanhVien);
                return Results.Ok(tks);
            }
        }).WithTags("admin");
        // Đăng kí nhan viên
        app.MapPost("/Admin/AddThanhVien", (RegisterAccountRequestDTO requestDTO) =>
        {
            Console.WriteLine(requestDTO);
    
            var existedUsername = taiKhoanRepository.GetAccount().Where(x => x.UserName == requestDTO.username).ToList();
            if (existedUsername.Any())
            {
                return Results.BadRequest("Tên tài khoản đã tồn tại");
            }
            var existedEmail = taiKhoanRepository.GetAccount().Where(x => x.Email == requestDTO.email).ToList();
            if (existedEmail.Any())
            {
                return Results.BadRequest("Tên email đã tồn tại");
            }
            
            requestDTO.password = passwordHashService.HashPassword(requestDTO.password);
            
            var AddAccountDTO = new
            {
                username = requestDTO.username,
                email = requestDTO.email,
                ngaythamgia = DateTime.Now,
                password = requestDTO.password,
                vaiTro = 0
            };
            
            dbContext.Add<TaiKhoan>(AddAccountDTO);
            var lastId = dbContext.GetLastInsertId();

            var AddThanhVienDTO = new
            {
                id_taikhoan = lastId,
                hoten = "",
                sodienthoai = "",
                tinhtrang = 1
            };
            
            dbContext.Add<ThanhVien>(AddThanhVienDTO);
            
            dbContext.SaveChange();
            
            return Results.Ok("Đăng ký thành công");
        }).WithTags("admin").WithMetadata(typeof(RegisterAccountRequestDTO));
        
        // Cập nhât thông tin nhân viên
        app.MapPost("/Admin/UpdateThanhVienAdmin", ([FromQuery] int idTaiKhoan, [FromBody] AdminUpdateThanhVienRequestDTO request) =>
        {
            var queryFindStaff = "SELECT id FROM thanhvien WHERE id_taikhoan = ?";
            var idThanhVien = dbContext.ExcuteQuerry(queryFindStaff, idTaiKhoan).Select(x => x["id"]).FirstOrDefault();
            Console.WriteLine(idTaiKhoan);
            
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
            
            var result_1 = dbContext.ExecuteNonQuery(queryUpdateStaff, request.username, request.email, request.password != "" || request.password != null ? request.password : null, idTaiKhoan);
            if (result_1  != 1)
            {
                return Results.BadRequest("Cập nhật thông tin thành viên không thành công");
            }
            
            var queryUpdateThanhVien = "UPDATE thanhvien SET hoten = ?, sodienthoai = ? WHERE id = ?";
            var result_2 = dbContext.ExecuteNonQuery(queryUpdateThanhVien, request.hoten, request.sodienthoai, idThanhVien);
            if (result_2 != 1)
            {
                return Results.BadRequest("Cập nhật thông tin tài khoản không thành công");
            }

            return Results.Ok("Cập nhât thông tin tài khoản thành viên thành công");
        }).WithTags("admin").WithMetadata(typeof(AdminUpdateThanhVienRequestDTO));
        
        app.MapPost("/Admin/KhoaThanhVien", ([FromQuery] int idThanhVien, [FromQuery] string type) =>
        {
            var status = type == "Khóa" ? "Đã bị khoá" : "Hoạt động";
            Console.WriteLine("/Admin/KhoaThanhVien");
            var queryFindAccount = @"SELECT tk.id FROM taikhoan tk 
                                     JOIN thanhvien tv ON tk.id = tv.id_taikhoan 
                                     WHERE tv.id = ?";      
            var idTaiKhoan = dbContext.ExcuteQuerry(queryFindAccount, idThanhVien).FirstOrDefault()["id"];
            Console.WriteLine("IdTaiKhoan: " + idTaiKhoan);
            Console.WriteLine("IdThanhVien: " + idThanhVien);
            Console.WriteLine("Status: " + status);
            
            var queryLockAccount = "UPDATE taikhoan SET tinhtrang = ? WHERE id = ?";
            var result_1 = dbContext.ExecuteNonQuery(queryLockAccount, status, idTaiKhoan);
            if (result_1  != 1)
            {
                return Results.BadRequest("Cập nhật tai khoan không thành công");
            }
            
            var queryLockThanhVien = "UPDATE thanhvien SET tinhtrang = ? WHERE id = ?";
            var result_2 = dbContext.ExecuteNonQuery(queryLockThanhVien, status, idThanhVien);
            if (result_2  != 1)
            {
                return Results.BadRequest("Cập nhật thanhvien không thành công");
            }
            
            return Results.Ok("Cap nhap thanh cong");
        }).WithTags("admin");
    }
}
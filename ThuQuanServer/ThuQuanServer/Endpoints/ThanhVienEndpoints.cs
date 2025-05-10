using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Dtos.Request.ThanhVien;
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
                                     FROM taikhoan tk JOIN thanhvien tv ON tk.id = tv.id_taikhoan WHERE tk.tinhtrang != 'Ẩn' OR tv.tinhtrang != 'Ẩn'";
                var tks = dbContext.ExcuteQuerry(queryFindAccount, idThanhVien);
                return Results.Ok(tks);
            }
            else
            {
                var queryFindAccount = @"SELECT tk.id AS id_taikhoan, tk.username, tk.email, tk.ngaythamgia, tv.id as id_thanhvien, tv.hoten, tv.sodienthoai, tv.tinhtrang 
                                 FROM taikhoan tk JOIN thanhvien tv 
                                 ON tk.id = tv.id_taikhoan WHERE tv.id = ? WHERE tk.tinhtrang != 'Ẩn' OR tv.tinhtrang != 'Ẩn'";      
                var tks = dbContext.ExcuteQuerry(queryFindAccount, idThanhVien);
                return Results.Ok(tks);
            }
        }).WithTags("admin");
        
        // Đăng kí nhan viên
        app.MapPost("/Admin/AddThanhVien", (AdminThanhVienRequestDTO request) =>
        {
            var existedUsername = dbContext.ExcuteQuerry("SELECT * FROM taikhoan WHERE username = ?", request.username).ToList().Any();
            if (existedUsername) return Results.BadRequest($"tên tài khoản: {request.username} đã tồn tại");
            
            var existedEmail = dbContext.ExcuteQuerry("SELECT * FROM taikhoan WHERE email = ?", request.email).ToList().Any();
            if (existedEmail) return Results.BadRequest($"email: {request.email} đã tồn tại");
            
            var existedPhone = dbContext.ExcuteQuerry("SELECT * FROM thanhvien WHERE sodienthoai = ?", request.sodienthoai).ToList().Any();
            if (existedPhone) return Results.BadRequest($"số điện thoại: {request.sodienthoai} đã tồn tại");
            
            request.password = passwordHashService.HashPassword(request.password);
            
            var AddAccountDTO = new
            {
                username = request.username,
                email = request.email,
                ngaythamgia = DateTime.Now,
                password = request.password,
                vaiTro = 0
            };
            
            dbContext.Add<TaiKhoan>(AddAccountDTO);
            var lastId = dbContext.GetLastInsertId();

            var AddThanhVienDTO = new
            {
                id_taikhoan = lastId,
                hoten = request.hoten,
                sodienthoai = request.sodienthoai,
                tinhtrang = 1
            };
            
            dbContext.Add<ThanhVien>(AddThanhVienDTO);
            dbContext.SaveChange();
            
            return Results.Ok("Đăng ký thành viên mới thành công");
        }).WithTags("admin").WithMetadata(typeof(AdminThanhVienRequestDTO));
        
        // Cập nhât thông tin nhân viên
        app.MapPost("/Admin/UpdateThanhVienAdmin", ([FromQuery] int idTaiKhoan, [FromBody] AdminUpdateThanhVienRequestDTO request) =>
        {
            var queryFindStaff = "SELECT id FROM thanhvien WHERE id_taikhoan = ?";
            var idThanhVien = dbContext.ExcuteQuerry(queryFindStaff, idTaiKhoan).Select(x => x["id"]).FirstOrDefault();
            Console.WriteLine(idTaiKhoan);
            
            var existedUsername = dbContext.ExcuteQuerry("SELECT * FROM taikhoan WHERE username = ? AND id != ?", request.username, idTaiKhoan).ToList().Any();
            if (existedUsername) return Results.BadRequest($"Tên tài khoản: {request.username} đã tồn tại");
            
            var existedEmail = dbContext.ExcuteQuerry("SELECT * FROM taikhoan WHERE email = ? AND id != ?", request.email, idTaiKhoan).ToList().Any();
            if (existedEmail) return Results.BadRequest($"email: {request.email} đã tồn tại");
            
            var existedPhone = dbContext.ExcuteQuerry("SELECT * FROM thanhvien WHERE sodienthoai = ? AND id != ?", request.sodienthoai, idThanhVien).ToList().Any();
            if (existedPhone) return Results.BadRequest($"số điện thoại: {request.sodienthoai} đã tồn tại");
            
            var queryUpdateStaff = "UPDATE taikhoan SET username = ?, email = ? WHERE id = ?";
            if (request.password != "")
            {
                request.password = passwordHashService.HashPassword(request.password);
                queryUpdateStaff = "UPDATE taikhoan SET username = ?, email = ?, password = ? WHERE id = ?";
            }
            
            var result_1 = dbContext.ExecuteNonQuery(queryUpdateStaff, request.username, request.email, request.password != "" || request.password != null ? request.password : null, idTaiKhoan);
            if (result_1  != 1)
            {
                return Results.BadRequest($"Cập nhật thành viên {idThanhVien} thành công");
            }
            
            var queryUpdateThanhVien = "UPDATE thanhvien SET hoten = ?, sodienthoai = ? WHERE id = ?";
            var result_2 = dbContext.ExecuteNonQuery(queryUpdateThanhVien, request.hoten, request.sodienthoai, idThanhVien);
            if (result_2 != 1)
            {
                return Results.BadRequest($"Cập nhật thành viên {idThanhVien} thành công");
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
                return Results.BadRequest($"Cập nhật thành viên {idThanhVien}  không thành công");
            }
            
            var queryLockThanhVien = "UPDATE thanhvien SET tinhtrang = ? WHERE id = ?";
            var result_2 = dbContext.ExecuteNonQuery(queryLockThanhVien, status, idThanhVien);
            if (result_2  != 1)
            {
                return Results.BadRequest($"Cập nhật thành viên {idThanhVien}  không thành công");
            }
            
            return Results.Ok($"Cập nhật thành viên {idThanhVien} thành công");
        }).WithTags("admin");

        app.MapPost("/Admin/DeleteBulkThanhVien", ([FromBody] List<DeleteBulkThanhVienRequestDTO> request) =>
        {
            foreach (var r in request)
            {
                var sucessTK = dbContext.ExecuteNonQuery("UPDATE thanhvien SET tinhtrang = ? WHERE id = ?", "Ẩn", r.id_thanhvien);
                if (sucessTK != 1)
                {
                    return Results.BadRequest($"Xóa thành viên {r.id_thanhvien} không thành công");
                }
                var succesTV = dbContext.ExecuteNonQuery("UPDATE taikhoan SET tinhtrang = ? WHERE id = ?", "Ẩn", r.id_taikhoan);
                if (succesTV != 1)
                {
                    return Results.BadRequest($"Xóa tài khoản {r.id_thanhvien} không thành công");
                }
            }
            return Results.Ok("Xóa thành công");
        }).WithTags("admin");
    }
}
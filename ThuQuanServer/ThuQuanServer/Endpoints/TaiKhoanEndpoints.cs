using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;
using ThuQuanServer.Services;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Dtos.Response;

namespace ThuQuanServer.Endpoints;

public static class TaiKhoanEndpoints
{
    public static void MapTaiKhoanEndpoints(this IEndpointRouteBuilder app)
    {   
        var dbContext = app.ServiceProvider.GetRequiredService<DbContext>();
        var taiKhoanRepository = app.ServiceProvider.GetRequiredService<ITaiKhoanRepository>();
        var passwordHashService = app.ServiceProvider.GetRequiredService<IPasswordHashService>();
        
        var groupName = "Thanh Vien";
        
        // GET API
        app.MapGet("/GetTaiKhoan", (DbContext dbContext) =>
        {
            var taikhoan = taiKhoanRepository.GetAccount();
            return Results.Ok(taikhoan);
        }).WithTags(groupName);

        app.MapGet("/GetTaiKhoanById/{id}", ([FromRoute , Required] int? id) =>
        {
            var taikhoan = taiKhoanRepository.GetAccountByProps(new {
                Id = id,
            });
            return Results.Ok(taikhoan);
        }).WithTags(groupName);;
        
        app.MapGet("/GetTaiKhoanByVaiTro/{vaitro}", ([FromRoute , Required] string? vaitro) =>
        {
            // if (string.IsNullOrEmpty(request)) return RequireMessage(vaiTro);
            var taikhoan = taiKhoanRepository.GetAccountByProps(new {
                VaiTro = vaitro,
            });
            return Results.Ok(taikhoan);
        }).WithTags(groupName);
        
        app.MapGet("/GetThanhVien", () =>
        {
            var thanhvien = taiKhoanRepository.GetThanhVien();
            return Results.Ok(thanhvien);
        }).WithTags(groupName);

        // POST API
        app.MapPost("/InsertTaiKhoan", (
            [FromBody] TaiKhoanRequestDto taikhoanRequest) =>
        {
            // Check existed username
            var existedUserName = taiKhoanRepository.GetAccount()
                .Where(p => p.UserName == taikhoanRequest.UserName);
            
            if (existedUserName.Any())
            {
                return Results.BadRequest("Ten tai khoan da ton tai");
            }
            
            // Check existed email
            var existedEmail = taiKhoanRepository.GetAccount()
                .Where(p => p.Email == taikhoanRequest.Email);
            
            if (existedEmail.Any())
            {
                return Results.BadRequest("Email is already exist");
            }

            TaikhoanInsertDTO taikhoanInsertDto = new TaikhoanInsertDTO();
            
            taikhoanInsertDto.UserName = taikhoanRequest.UserName;
            taikhoanInsertDto.Email = taikhoanRequest.Email;
            taikhoanInsertDto.VaiTro = taikhoanRequest.VaiTro;
            
            // Hash password
            taikhoanInsertDto.Password = passwordHashService.HashPassword(taikhoanRequest.Password);
            
            // Time
            taikhoanInsertDto.NgayThamGia = (DateTime.Now);
            
            if (!taiKhoanRepository.AddThanhVien(taikhoanInsertDto))
            {
                return Results.BadRequest("Insert TaiKhoan failed");
            }
            
            return Results.Ok(new ApiResponse
            {
                Success = true,
                Message = $"Insert thanh vien successully",
                Data = taikhoanRequest
            });
        }).WithMetadata(typeof(TaiKhoanRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        }).WithTags(groupName);
        
        // PUT API
        app.MapPut("/UpdateThanhVien", (
            [FromQuery] int id,
            [FromBody] ThanhVienRequestDto thanhVienRequest) =>
        {
            if (!taiKhoanRepository.UpdateThanhVien(thanhVienRequest, id))
            {
                return Results.BadRequest("update ThanhVien failed");
            }
            
            return Results.Ok(new ApiResponse
            {
                Success = true,
                Message = $"update thanh vien {id} successully",
                Data = thanhVienRequest
            });
        }).WithMetadata(typeof(ThanhVienRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        }).WithTags(groupName);

        //API đổi mật khẩu
        app.MapPut("/change-password", ([FromBody] ChangePasswordRequestDto changePasswordRequestDto) =>
        {
            var tk = taiKhoanRepository.GetAccountByProps(new {Email=changePasswordRequestDto.Email}).FirstOrDefault();
            if (tk ==null)
            {
                return Results.BadRequest("Tài khoản không tồn tại");
            }

            if (!passwordHashService.VerifyPassword(changePasswordRequestDto.Password, tk.Password))
            {
                return Results.BadRequest("Mật khẩu cũ không đúng");
            }

            if (changePasswordRequestDto.Password == changePasswordRequestDto.newPassword)
            {
                return Results.BadRequest("Hãy nhập mật khẩu mới");
            }

            var taiKhoanInsertDTO = new TaikhoanInsertDTO
            {
                UserName = tk.UserName,
                Email = tk.Email,
                Password = passwordHashService.HashPassword(changePasswordRequestDto.newPassword),
                VaiTro = tk.VaiTro,
                NgayThamGia = tk.NgayThamGia
            };

            var result = taiKhoanRepository.UpdateTaiKhoan(taiKhoanInsertDTO, tk.Id);
            if (!result)
            {
                return Results.BadRequest("Đổi mật khẩu không thành công");
            }
            return Results.Ok(new ApiResponse
            {
                Success = true,
                Message = $"update Tai Khoan {tk.Id} successully",
                Data = taiKhoanInsertDTO
            });
        }).WithMetadata(typeof(ChangePasswordRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        }).WithTags(groupName);
        
        // API kiểm tra password
        app.MapPost("/check-password", ([FromBody] LoginRequestDto LoginRequestDto) =>
        {
            var tk = taiKhoanRepository.GetAccountByProps(new { Email = LoginRequestDto.Email }).FirstOrDefault();
            if (tk == null)
                return Results.BadRequest("Tài khoản không tồn tại");
            if (!passwordHashService.VerifyPassword(LoginRequestDto.Password, tk.Password))
            {
                return Results.BadRequest("Mật khẩu không chính xác");
            }

            return Results.Ok("Mật khẩu chính xác");
        }).WithMetadata(typeof(LoginRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        }).WithTags(groupName);
        
  
        
       // API cập nhật thông tin người dùng
        app.MapPut("/update-info-user", ([FromBody] UpdateThanhVienRequestDto updateThanhVienRequestDto) =>
        {
            var tk = taiKhoanRepository.GetAccountByProps(new { Id = updateThanhVienRequestDto.Id }).FirstOrDefault();
            if (tk == null)
            {
                return Results.BadRequest("Tài khoản không tồn tại");
            }

            // Kiểm tra Email đã tồn tại chưa
            var existingEmail = taiKhoanRepository.GetAccountByProps(new { Email = updateThanhVienRequestDto.Email }).FirstOrDefault();
            if (existingEmail != null && existingEmail.Id != tk.Id)
            {
                return Results.BadRequest("Email đã tồn tại");
            }

            // Kiểm tra số điện thoại đã tồn tại chưa
            var existingPhoneNumber = taiKhoanRepository.GetThanhVien().FirstOrDefault(tv => tv.SoDienThoai == updateThanhVienRequestDto.sdt);
            if (existingPhoneNumber != null && existingPhoneNumber.Id != tk.Id)
            {
                return Results.BadRequest("Số điện thoại đã tồn tại");
            }

            // Update TaiKhoan
            var taiKhoanUpdate = new TaiKhoanUpdateResponseDTO()
            {
                Id = tk.Id,
                UserName = updateThanhVienRequestDto.UserName,
                Email = updateThanhVienRequestDto.Email,
                Password = tk.Password, // Keep the existing password
                VaiTro = tk.VaiTro,
                NgayThamGia = tk.NgayThamGia
            };

            if (!taiKhoanRepository.UpdateTaiKhoan(taiKhoanUpdate, tk.Id))
            {
                return Results.BadRequest("Cập nhật thông tin tài khoản không thành công");
            }

            // Update ThanhVien
            var thanhVienUpdate = new ThanhVienUpdateResponseDTO()
            {
                Id = tk.Id,
                HoTen = updateThanhVienRequestDto.Hoten,
                SoDienThoai = updateThanhVienRequestDto.sdt,
                TinhTrang = 1 // Assuming TinhTrang is always set to 1
            };

            if (!taiKhoanRepository.UpdateThanhVien(thanhVienUpdate, tk.Id))
            {
                return Results.BadRequest("Cập nhật thông tin người dùng không thành công");
            }

            return Results.Ok(new ApiResponse
            {
                Success = true,
                Message = $"Cập nhật thông tin người dùng {tk.Id} thành công",
                Data = updateThanhVienRequestDto
            });
        }).WithMetadata(typeof(UpdateThanhVienRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        }).WithTags(groupName);
        
        // API lấy tài khoản qua Email
        app.MapGet("/GetTaiKhoanByEmail/{email}", ([FromRoute, Required] string email) =>
        {
            var taikhoan = taiKhoanRepository.GetAccountByProps(new { Email = email }).FirstOrDefault();
            if (taikhoan == null)
            {
                return Results.BadRequest("Không tìm thấy tài khoản với email này");
            }
            return Results.Ok(taikhoan);
        }).WithTags(groupName);
        
    }
}
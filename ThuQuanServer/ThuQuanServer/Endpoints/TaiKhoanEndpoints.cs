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
using System.Text.RegularExpressions;
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
        
        // API lấy thành viên bằng email
        app.MapGet("/GetThanhVienByEmail", ([FromQuery] string email) =>
        {
            if (string.IsNullOrEmpty(email))
            {
                return Results.BadRequest("Email không được để trống");
            }

            var thanhVien = taiKhoanRepository.GetAccountThanhVienByEmailTaiKhoan(new { Email = email });

            if (thanhVien == null)
            {
                return Results.NotFound("Không tìm thấy thành viên với email này");
            }

            return Results.Ok(thanhVien);
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

            // POST API đăng kí tài khoản thành viên
            app.MapPost("/userRegister", (
                [FromBody] TaiKhoanRequestDto taikhoanRequest) =>
            {
                // Regular expressions for validation
                string usernamePattern = @"^.{3,100}$";
                string emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
                string passwordPattern = @"^.{6,100}$";

                
                // Không được để trống các trường
                if (string.IsNullOrEmpty(taikhoanRequest.UserName) ||
                    string.IsNullOrEmpty(taikhoanRequest.Email) ||
                    string.IsNullOrEmpty(taikhoanRequest.Password))
                {
                    return Results.BadRequest("Điền thông tin đầy đủ");
                }
                
                // Validate UserName
                if (!Regex.IsMatch(taikhoanRequest.UserName, usernamePattern))
                {
                    return Results.BadRequest("Tên đăng nhập phải từ 3 đến 100 ký tự");
                }

                // Validate Email
                if (!Regex.IsMatch(taikhoanRequest.Email, emailPattern))
                {
                    return Results.BadRequest("Email không đúng định dạng");
                }

                // Validate Password
                if (!Regex.IsMatch(taikhoanRequest.Password, passwordPattern))
                {
                    return Results.BadRequest("Mật khẩu phải từ 6 đến 100 ký tự");
                }

                // Kiểm tra người dùng đã tồn tại hay chưa
                var existedUserName = taiKhoanRepository.GetAccount()
                    .Where(p => p.UserName == taikhoanRequest.UserName);
                
                if (existedUserName.Any())
                {
                    return Results.BadRequest("Tên tài khoản đã tồn tại");
                }
                
                // Check existed email
                var existedEmail = taiKhoanRepository.GetAccount()
                    .Where(p => p.Email == taikhoanRequest.Email);
                
                if (existedEmail.Any())
                {
                    return Results.BadRequest("Email đã tồn tại");
                }

                TaikhoanInsertDTO taikhoanInsertDto = new TaikhoanInsertDTO();
                
                taikhoanInsertDto.UserName = taikhoanRequest.UserName;
                taikhoanInsertDto.Email = taikhoanRequest.Email;
                taikhoanInsertDto.VaiTro = taikhoanRequest.VaiTro;
                
                // Hash password
                taikhoanInsertDto.Password = passwordHashService.HashPassword(taikhoanRequest.Password);
                
                // Time
                taikhoanInsertDto.NgayThamGia = DateTime.Now;
                
                if (!taiKhoanRepository.AddThanhVien(taikhoanInsertDto))
                {
                    return Results.BadRequest("Đăng kí thất bại. Vui lòng thử lại");
                }
                
                return Results.Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Đăng kí thành công",
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
        app.MapPut("/change-password", [Authorize] ([FromBody] ChangePasswordRequestDto changePasswordRequestDto) =>
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
        app.MapPost("/check-password", [Authorize] ([FromBody] LoginRequestDto LoginRequestDto) =>
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
                // Regex cho các trường
                string usernameHotenPattern = @"^.{3,100}$";
                string sdtPattern = @"^\d{10,11}$";
                string emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";

                // Không được để trống các trường
                if (string.IsNullOrEmpty(updateThanhVienRequestDto.UserName) ||
                    string.IsNullOrEmpty(updateThanhVienRequestDto.Hoten) ||
                    string.IsNullOrEmpty(updateThanhVienRequestDto.Email) ||
                    string.IsNullOrEmpty(updateThanhVienRequestDto.sdt))
                {
                    return Results.BadRequest("Điền thông tin đầy đủ");
                }

                // Validate username và họ tên
                if (!Regex.IsMatch(updateThanhVienRequestDto.UserName, usernameHotenPattern) ||
                    !Regex.IsMatch(updateThanhVienRequestDto.Hoten, usernameHotenPattern))
                {
                    return Results.BadRequest("Tên đăng nhập và họ tên phải từ 3 đến 100 ký tự");
                }

                // Validate sdt
                if (!Regex.IsMatch(updateThanhVienRequestDto.sdt, sdtPattern))
                {
                    return Results.BadRequest("Số điện thoại phải từ 10 đến 11 số");
                }

                // Validate Email
                if (!Regex.IsMatch(updateThanhVienRequestDto.Email, emailPattern))
                {
                    return Results.BadRequest("Email không đúng định dạng");
                }

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
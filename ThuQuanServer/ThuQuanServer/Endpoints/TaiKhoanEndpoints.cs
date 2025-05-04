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
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
<<<<<<< HEAD
using MySqlX.XDevAPI.Common;
=======
using Mysqlx.Datatypes;
>>>>>>> 431206f7c963665bc3ee18ed571523b311eb3c40
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
        var nhanVienRepository = app.ServiceProvider.GetRequiredService<INhanVienRepository>();
        var _dbcontext = app.ServiceProvider.GetRequiredService<DbContext>();
        
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
        
        app.MapGet("/GetNhanVienAndTheirAccount", ([FromQuery] string type) =>
        {
            string[] typeList = ["Tất cả", "Đang làm việc", "Đã nghỉ"];
            if (!typeList.Contains(type))
            {
                return Results.NotFound("Không tìm thấy nhân viên có tình trạng trên");
            }

            string query = @"SELECT nhanvien.id, hoten, sodienthoai, gioitinh, diachi, nhanvien.id_taikhoan, nhanvien.tinhtrang, username, email, ngaythamgia
                            FROM nhanvien
                            JOIN taikhoan ON nhanvien.id_taikhoan = taikhoan.id
                            WHERE";
            IEnumerable<Dictionary<string, object>> result;
            if (type == "Tất cả")
            {
                query += " 1=1 ";
                result = _dbcontext.ExcuteQuerry(query);
            }
            else
            {
                query += " nhanvien.tinhtrang = ?";
                result = _dbcontext.ExcuteQuerry(query, type);
            }
            
            return Results.Ok(result);
        }).WithTags(groupName);

        app.MapPost("/UpdateNhanVienById", ([FromQuery] int idNhanVien, [FromBody] UpdateNhanVienRequestDto request) =>
        {
            var query = "SELECT nhanvien.id_taikhoan FROM nhanvien, taikhoan WHERE nhanvien.id_taikhoan = taikhoan.id AND nhanvien.id = ?";
            var idTaiKhoan = _dbcontext.ExcuteQuerry(query, idNhanVien);
            Console.WriteLine(idTaiKhoan);
            
            var currentEmailQuery = "SELECT taikhoan.email FROM nhanvien JOIN taikhoan ON nhanvien.id_taikhoan = taikhoan.id WHERE nhanvien.id = ?";
            var currentEmailResult = _dbcontext.ExcuteQuerry(currentEmailQuery, idNhanVien);
            string currentEmail = currentEmailResult.FirstOrDefault()?["email"]?.ToString();

            if (!string.Equals(currentEmail, request.email, StringComparison.OrdinalIgnoreCase))
            {
                var existedEmail = _dbcontext.ExcuteQuerry("SELECT * FROM taikhoan WHERE email = ? AND id != ?", request.email, idTaiKhoan);
                if (existedEmail.Any())
                {
                    return Results.BadRequest("Email đã tồn tại!");
                }
            }
            var updateQuery = 
                "UPDATE nhanvien JOIN taikhoan ON nhanvien.id_taikhoan = taikhoan.id SET nhanvien.hoten = ?, nhanvien.sodienthoai = ?, nhanvien.gioitinh = ?, nhanvien.diachi = ?, taikhoan.email = ? WHERE nhanvien.id = ?";
            var result = _dbcontext.ExecuteNonQuery(updateQuery, request.hoten, request.sodienthoai, request.gioitinh, request.diachi, request.email, idNhanVien);
            Console.WriteLine(result);
            if (result != 0)
            {
                return Results.Ok("Cập nhật thông tin nhân viên thành công!");
            }
            else
            {
                return Results.BadRequest("Cập nhật thông tin nhân viên không thành công!");
            }
        }).WithMetadata(typeof(UpdateNhanVienRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        }).WithTags(groupName);
        
        app.MapPost("/LockAccountNhanVien",
            ([FromQuery] int idNhanVien) =>
            {
                var query = "UPDATE nhanvien JOIN taikhoan ON nhanvien.id_taikhoan = taikhoan.id SET nhanvien.tinhtrang = 2, taikhoan.tinhtrang = 2 WHERE nhanvien.id = ?";
                var result = _dbcontext.ExecuteNonQuery(query, idNhanVien);
                Console.WriteLine(result);
                if (result != 0)
                {
                    return Results.Ok("Cập nhật tình trạng nhân viên thành công!");
                }
                else
                {
                    return Results.BadRequest("Cập nhật tình trạng nhân viên thất bại!");
                }
            }).WithTags(groupName);
        
        app.MapPost("/UnlockAccountNhanVien",
            ([FromQuery] int idNhanVien) =>
            {
                var query = "UPDATE nhanvien JOIN taikhoan ON nhanvien.id_taikhoan = taikhoan.id SET nhanvien.tinhtrang = 1, taikhoan.tinhtrang = 1 WHERE nhanvien.id = ?";
                var result = _dbcontext.ExecuteNonQuery(query, idNhanVien);
                Console.WriteLine(result);
                if (result != 0)
                {
                    return Results.Ok("Cập nhật tình trạng nhân viên thành công!");
                }
                else
                {
                    return Results.BadRequest("Cập nhật tình trạng nhân viên thất bại!");
                }
            }).WithTags(groupName);
        
        app.MapPost("/InsertNhanVienAndTheirAccount",
            ([FromBody] AddNhanVienAndAccountRequestDto request) =>
            {
                var existedEmail = _dbcontext.ExcuteQuerry("SELECT * FROM taikhoan WHERE email = ?", request.email);
                if (existedEmail.Any())
                {
                    return Results.BadRequest("Email đã tồn tại!");
                }

                var existedPhoneNumber = _dbcontext.ExcuteQuerry("SELECT * FROM nhanvien WHERE sodienthoai = ?", request.sodienthoai);
                if (existedPhoneNumber.Any())
                {
                    return Results.BadRequest("Số điện thoại đã được sử dụng!");
                }
                
                var existedUsername = _dbcontext.ExcuteQuerry("SELECT * FROM taikhoan WHERE username = ?", request.username);
                if (existedUsername.Any())
                {
                    return Results.BadRequest("Username đã tồn tại!");
                }

                request.password = "123456";
                request.password = passwordHashService.HashPassword(request.password);
                Console.WriteLine(request.ngaythamgia);
                var addAccountQuery = "INSERT INTO taikhoan (username, password, email, ngaythamgia, vaitro) VALUES (?, ?, ?, ?, 1)";
                _dbcontext.ExecuteNonQuery(addAccountQuery, request.username, request.password, request.email, request.ngaythamgia);
                var lastInsertAccountId = _dbcontext.GetLastInsertId();
                var addNhanVienQuery = "INSERT INTO nhanvien (hoten, sodienthoai, gioitinh, diachi, tinhtrang, id_taikhoan) VALUES (?, ?, ?, ?, ?, ?)";
                var result = _dbcontext.ExecuteNonQuery(
                    addNhanVienQuery,
                    request.hoten,
                    request.sodienthoai,
                    request.gioitinh,
                    request.diachi,
                    request.tinhtrang,
                    lastInsertAccountId);
                if (result != 0)
                {
                    return Results.Ok("Tạo nhân viên mới thành công!");
                }
                else
                {
                    return Results.BadRequest("Tạo nhân viên thất bại!");
                }
            }).WithMetadata(typeof(AddNhanVienAndAccountRequestDto)).WithOpenApi(o =>
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
        
        
        // API Kiểm tra tải khoản có tồn tại không
        app.MapGet("/CheckTaiKhoan", ([FromQuery] string email) =>
        {
            var taikhoan = taiKhoanRepository.CheckTaiKhoanExist(email);
            if (!taikhoan )
            {
                return Results.BadRequest("Tài khoản không tồn tại");
            }
            return Results.Ok("Tài khoản tồn tại");
        }).WithTags(groupName);
  
        // API lấy thành viên qua id-tai khoan
        app.MapGet("/get-thanh-vien-by-id", ([FromQuery] int id) =>
            {
                var thanhVien = taiKhoanRepository.GetThanhVienById(id);

                return Results.Ok(thanhVien);
            })
            .WithOpenApi(o =>
            {
                o.Security = new List<OpenApiSecurityRequirement>();
                return o;
            })
            .WithTags(groupName);

        
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

            var thanhVien = taiKhoanRepository.GetThanhVienById(tk.Id);
            if (thanhVien == null)
            {
                return Results.BadRequest("Người dùng không tồn tại");
            }

            // Kiểm tra Email đã tồn tại chưa
            var existingEmail = taiKhoanRepository.GetAccountByProps(new { Email = updateThanhVienRequestDto.Email }).FirstOrDefault();
            if (existingEmail != null && existingEmail.Id != tk.Id)
            {
                return Results.BadRequest("Email đã tồn tại");
            }

            // Kiểm tra số điện thoại đã tồn tại chưa
            var existingPhoneNumber = taiKhoanRepository.GetThanhVien()
                .FirstOrDefault(tv => tv.SoDienThoai == updateThanhVienRequestDto.sdt);
            if (existingPhoneNumber != null && existingPhoneNumber.Id != thanhVien.Id)
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
                Id = thanhVien.Id,
                HoTen = updateThanhVienRequestDto.Hoten,
                SoDienThoai = updateThanhVienRequestDto.sdt,
                TinhTrang = 1 // Assuming TinhTrang is always set to 1
            };

            if (!taiKhoanRepository.UpdateThanhVien(thanhVienUpdate, thanhVien.Id))
            {
                return Results.BadRequest("Cập nhật thông tin người dùng không thành công");
            }

            return Results.Ok(new ApiResponse
            {
                Success = true,
                Message = $"Cập nhật thông tin người dùng {tk.Id} thành công",
                Data = updateThanhVienRequestDto
            });
        })
        .WithMetadata(typeof(UpdateThanhVienRequestDto))
        .WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        })
        .WithTags(groupName);

        
        // API lấy tài khoản qua Email
        app.MapGet("/GetTaiKhoanByEmail", ([FromQuery, Required] string email) =>
        {
            var taikhoan = taiKhoanRepository.GetTaiKhoanByEmail(email).FirstOrDefault();
            if (taikhoan == null)
            {
                return Results.BadRequest("Không tìm thấy tài khoản với email này");
            }
            return Results.Ok(taikhoan);
        }).WithTags(groupName);
        
        // API đổi mật khẩu
        app.MapPost("/forgot-password", ([FromQuery] string email, [FromQuery] string newPassword) =>
        {
            var result = taiKhoanRepository.ChangePassword(email, newPassword);
            return Results.Ok(result);
        }).WithTags(groupName);
    }
}
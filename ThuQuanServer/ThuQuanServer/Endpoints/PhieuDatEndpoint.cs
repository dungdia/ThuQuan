using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using ThuQuanServer.Contains;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Endpoints;

public static class PhieuDatEndpoint
{
    public static void MapPhieuDatEndpoints(this IEndpointRouteBuilder app)
    {
        var tagName = "Phieu Dat";

        var phieuDatRepository = app.ServiceProvider.GetRequiredService<IPhieuDatRepository>();
        var taiKhoanRepository = app.ServiceProvider.GetRequiredService<ITaiKhoanRepository>();        
        var authService = app.ServiceProvider.GetRequiredService<IAuthService>();
        var vatDungRepository = app.ServiceProvider.GetRequiredService<IVatDungRepository>();
        // Lấy tất cả phiếu đặt
        app.MapGet("/PhieuDat", () =>
        {
            var result = phieuDatRepository.GetPhieuDat();
                return Results.Ok(result);
        }).WithTags(tagName);
        
        // Lấy phiếu đặt từ id thành viên
        app.MapGet("/GetPhieuDatByToken", (HttpContext context) =>
            {
                var Authorization = context.Request.Headers.Authorization.ToString();
                var token = Authorization.Substring(7, Authorization.Length - 7);
                var idThanhVien = authService.DecodeJwtAccessToken(token);

                Console.WriteLine($"id {idThanhVien}");

                // Lấy danh sách phiếu đặt
                var danhSachPhieuDat = phieuDatRepository.GetPhieuDatByIdThanhVien(idThanhVien);

                foreach (var phieuDat in danhSachPhieuDat)
                {
                    // Lấy danh sách chi tiết phiếu đặt
                    var danhSachChiTietPhieuDat = phieuDatRepository.GetChiTietPhieuDatByIdPhieuDat(phieuDat.Id);

                    foreach (var chiTiet in danhSachChiTietPhieuDat)
                    {
                        // Lấy VatDung từ IdVatDung
                        var vatDung = vatDungRepository.VatDungById(chiTiet.Id_VatDung);

                        // Gán VatDung vào ChiTietPhieuDat
                        chiTiet.VatDung = vatDung;
                    }

                    // Gán lại danh sách chi tiết phiếu đặt vào đối tượng phiếu đặt
                    phieuDat.ChiTietPhieuDatList = danhSachChiTietPhieuDat;
                }

                // Trả về kết quả
                return Results.Ok(danhSachPhieuDat);
            }).RequireAuthorization()
            .WithTags(tagName);

        
        // Lấy ChiTietPhieuDat từ id phieu dat 
        app.MapGet("ChiTietPhieuDat", ([FromQuery]int id) =>
        {
            var result = phieuDatRepository.GetChiTietPhieuDatByIdPhieuDat(id);
            return Results.Ok(result);
        }).WithTags(tagName);
        
        // API tạo phiếu đặt
        app.MapPost("/AddPhieuDat", ([FromQuery] string email, [FromQuery] int id_vatDung) =>
        {
            //  Lấy thành viên từ email
            var thanhvien = taiKhoanRepository.GetAccountThanhVienByEmailTaiKhoan(new { Email = email });
            if (thanhvien == null)
            {
                return Results.BadRequest("Lỗi không đặt hàng bởi thành viên này");
            }

            //  Kiểm tra trạng thái vật dụng
            var vatDung = vatDungRepository.VatDungById(id_vatDung);
            if (vatDung == null || vatDung.TinhTrang == "Ẩn")
            {
                return Results.BadRequest("Vật dụng không tồn tại");
            }

            var trangThaiKhongChoDat = new[] { "Đang mượn", "Bị hỏng", "Đã đặt","Đã mượn" };
            if (trangThaiKhongChoDat.Contains(vatDung.TinhTrang))
            {
                return Results.BadRequest($"Vật dụng không thể đặt vì đang ở trạng thái: {vatDung.TinhTrang}");
            }

            var updateTrangThaiVatDung = vatDungRepository.updateTinhTranDaDatgById(id_vatDung);
            if (updateTrangThaiVatDung <=0)
                return Results.BadRequest("Lỗi cập nhật trạng thái vật dụng");
            
          

            //  Tạo phiếu đặt
            var phieuDat = new PhieuDat
            {
                Id_ThanhVien = thanhvien.Id,
                NgayDat = DateTime.Now,
                TinhTrang = "Đã xuất phiếu"
            };

            var newPhieuDatId = phieuDatRepository.AddPhieuDatReturnId(phieuDat);
            if (newPhieuDatId <= 0)
            {
                return Results.Problem("Tạo phiếu đặt thất bại.");
            }

            //  Gán lại ID mới tạo vào đối tượng để trả kết quả
            phieuDat.Id = newPhieuDatId;

            //  Thêm chi tiết phiếu đặt
            var chiTietPhieuDat = new ChiTietPhieuDat
            {
                Id_PhieuDat = newPhieuDatId,
                Id_VatDung = id_vatDung
            };

            var addChiTietPhieuDat = phieuDatRepository.AddChiTietPhieuDat(chiTietPhieuDat);
            if (!addChiTietPhieuDat)
            {
                return Results.Problem("Tạo chi tiết phiếu đặt thất bại.");
            }

            //  Thành công
            return Results.Ok(new
            {
                PhieuDat = phieuDat,
                ChiTietPhieuDat = chiTietPhieuDat
            });
        }).WithTags(tagName);

        
        app.MapPut("/UpdatePhieuDat", () =>
        {
            return Results.Ok();
        }).WithTags(tagName);
        
        
    }
}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using ThuQuanServer.Contains;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Endpoints;

public static class PhieuDatEndpoint
{
    public static void MapPhieuDatEndpoints(this IEndpointRouteBuilder app)
    {
        var tagName = "Phieu Dat";

        var phieuDatRepository = app.ServiceProvider.GetRequiredService<IPhieuDatRepository>();
        var vatDungRepository = app.ServiceProvider.GetRequiredService<IVatDungRepository>();
        // Lấy tất cả phiếu đặt
        app.MapGet("/PhieuDat", () =>
        {
            var result = phieuDatRepository.GetPhieuDat();
            return Results.Ok(result);
        }).WithTags(tagName);
        
        // API tạo phiếu đặt
        app.MapPost("/AddPhieuDat", ([FromQuery] string email, [FromQuery] int id_vatDung, ITaiKhoanRepository taiKhoanRepository, IVatDungRepository vatDungRepository, IPhieuDatRepository phieuDatRepository) =>
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
                IdPhieuDat = newPhieuDatId,
                IdVatDung = id_vatDung
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
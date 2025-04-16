using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using ThuQuanServer.ApplicationContext;
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
        var authService = app.ServiceProvider.GetRequiredService<IAuthService>();
        var _dbcontext = app.ServiceProvider.GetRequiredService<DbContext>();
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


        app.MapPost("/AddPhieuDat", [Authorize] (HttpContext httpContext,AddPhieuDatRequestDto addPhieuDatRequestDto) =>

        {
            //Lấy access token từ request header
            var authorization = httpContext.Request.Headers.Authorization.ToString();
            var token = authorization.Substring(7);
            
            //Sử dụng service để decode accesss token lấy id rồi tìm thành viến với id dó
            var taiKhaiId = authService.DecodeJwtAccessToken(token);
            var thanhvien = taiKhoanRepository.GetAccountByProps(new {Id = taiKhaiId}).FirstOrDefault();
            
            if (thanhvien == null)
                return Results.NotFound("Không tìm thấy thành viên");
            
            var vatDung = vatDungRepository.GetVatDung().Where(p => addPhieuDatRequestDto.listId.Contains(p.Id)).ToList();
            
            if (vatDung.Count() != addPhieuDatRequestDto.listId.Length)
                return Results.BadRequest("Vật dụng không tồn tại");
            
            var vatDungDaDat = vatDung.Where(p => p.TinhTrang != "Chưa mượn").ToList();  
            
            if (vatDungDaDat.Count > 0)
            {
                var firstVatDung = vatDungDaDat.First();
                if (firstVatDung.TinhTrang == "Ẩn")
                    return Results.BadRequest($"Vật dụng không tồn tại");
                return Results.BadRequest($"Vật dụng { firstVatDung.TenVatDung }, Id={ firstVatDung.Id } { firstVatDung.TinhTrang }");
            }

            var newPhieuDat = new PhieuDat()
            {
                Id_ThanhVien = thanhvien.Id,
                NgayDat = DateTime.Now,
                TinhTrang = "Đã xuất phiếu"
            };
            
            var resultPhieuDat = phieuDatRepository.AddPhieuDat(newPhieuDat, addPhieuDatRequestDto.listId);
            if(!resultPhieuDat)
                return Results.UnprocessableEntity("Thêm phiếu đặt không thành công");
            var resultVatDung = vatDungRepository.updateListTinhTranDaDa(addPhieuDatRequestDto.listId);
            if (!resultVatDung)
                return Results.UnprocessableEntity("Đã xảy ra lỗi lúc thêm phiếu đặt");
            
            return Results.Ok("Đặt thành công");
        }).WithMetadata(typeof(AddPhieuDatRequestDto)).WithTags(tagName);


        app.MapPut("/HuyPhieuDat", [Authorize](int idPhieuDat) =>

          return Result.Ok("test");
        }).WithTags(tagName);

        
        app.MapPut("/UpdatePhieuDat", () =>

        {
            var phieuDat = phieuDatRepository.GetPhieuDatByProps(new { Id = idPhieuDat }).FirstOrDefault();
            if (phieuDat == null)
                return Results.BadRequest("Không tìm thấy phiếu đặt");
            return Results.Ok("HI");
        }).WithTags(tagName);
    }
}
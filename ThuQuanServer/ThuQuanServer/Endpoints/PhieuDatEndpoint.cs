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
        var vatDungRepository = app.ServiceProvider.GetRequiredService<IVatDungRepository>();
        var authService = app.ServiceProvider.GetRequiredService<IAuthService>();
        var _dbcontext = app.ServiceProvider.GetRequiredService<DbContext>();
        // Lấy tất cả phiếu đặt
        app.MapGet("/PhieuDat", () =>
        {
            var result = phieuDatRepository.GetPhieuDat();
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
        {
            var phieuDat = phieuDatRepository.GetPhieuDatByProps(new { Id = idPhieuDat }).FirstOrDefault();
            if (phieuDat == null)
                return Results.BadRequest("Không tìm thấy phiếu đặt");
            return Results.Ok("HI");
        }).WithTags(tagName);
    }
}
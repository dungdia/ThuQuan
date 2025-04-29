using Microsoft.AspNetCore.Http.HttpResults;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.Response;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Services;
using Microsoft.AspNetCore.Mvc;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Models;

namespace ThuQuanServer.Endpoints;

public static class PhieuTraEndpoint
{
    public static void MapPhieuTraEndpoints(this IEndpointRouteBuilder app)
    {
        var tagName = "Phieu Tra";
        var phieuTraRepository = app.ServiceProvider.GetRequiredService<IPhieuTraRepository>();
        var _dbContext = app.ServiceProvider.GetRequiredService<DbContext>();
        var authService = app.ServiceProvider.GetRequiredService<IAuthService>();
        var vatDungRepository = app.ServiceProvider.GetRequiredService<IVatDungRepository>();
        var taiKhoanRepository = app.ServiceProvider.GetRequiredService<ITaiKhoanRepository>();
        
        // Lấy tất cả phiếu trả
        app.MapGet("/GetPhieuTra", () =>
        {
            var results = phieuTraRepository.GetPhieuTra();
            return Results.Ok(results);
        }).WithTags(tagName);
        // Lấy phiếu trả theo id nhân viên
        app.MapPost("/GetPhieuByNhanVienIdFromToken", (HttpContext context) =>
        {
            var Authorization = context.Request.Headers.Authorization.ToString();
            var token = Authorization.Substring(7, Authorization.Length - 7);
            var idTaiKhoan = authService.DecodeJwtAccessToken(token);
            var nhanVien = taiKhoanRepository.GetAccountByProps(new { Id = idTaiKhoan }).FirstOrDefault();
            
            Console.WriteLine($"id: {idTaiKhoan}");
            
            // Lấy danh sách phiếu trả
            var PhieuTraList = phieuTraRepository.GetPhieuTraByIdNhanVien(nhanVien.Id);
            var phieuTraResponse = new List<PhieuTraResponseDto>();

            foreach (var phieuTra in PhieuTraList)
            {
                var currentPhieuTra = new PhieuTraResponseDto()
                {
                    Id = phieuTra.Id,
                    Id_ThanhVien = phieuTra.Id_ThanhVien,
                    Id_NhanVien = phieuTra.Id_NhanVien,
                    TinhTrang = phieuTra.TinhTrang,
                };
                // Lấy danh sách chi tiết phiếu trả
                var getChiTietPhieuTraList = phieuTraRepository.GetChiTietPhieuTraByIdPhieuTra(phieuTra.Id);
                var ChiTietPhieuTraList = new List<ChiTietPhieuTraResponseDto>();
                foreach (var chiTietPhieuTra in getChiTietPhieuTraList)
                {
                    // Lấy vật dụng từ IdVatDung
                    var vatDung = vatDungRepository.VatDungById(chiTietPhieuTra.Id_VatDung);
                    
                    // Truyền vật dụng vào chi tiết phiếu trả
                    var currentChiTietPhieuTra = new ChiTietPhieuTraResponseDto()
                    {
                        Id_PhieuTra = chiTietPhieuTra.Id_PhieuTra,
                        Id_VatDung = chiTietPhieuTra.Id_VatDung,
                        VatDung = vatDung,
                        TinhTrang = chiTietPhieuTra.TinhTrang,
                    };
                    ChiTietPhieuTraList.Add(currentChiTietPhieuTra);
                }
                
                // Gán lại danh sách chi tiết phiếu trả vào phiếu trả
                currentPhieuTra.ChiTietPhieuTra = ChiTietPhieuTraList;
                phieuTraResponse.Add(currentPhieuTra);
            }
            
            return Results.Ok(phieuTraResponse);
        }).WithTags(tagName);
        
        //Lấy phiếu trả theo id thành viên
        app.MapGet("/getPhieuTraByThanhVienIdFromToken", (HttpContext context) =>
        {
            var Authorization = context.Request.Headers.Authorization.ToString();
            var token = Authorization.Substring(7, Authorization.Length - 7);
            var idTaiKhoan = authService.DecodeJwtAccessToken(token);
            var thanhVien = taiKhoanRepository.GetAccountByProps(new { Id = idTaiKhoan }).FirstOrDefault();
            
            Console.WriteLine($"id: {idTaiKhoan}");
            
            var phieuTraList = phieuTraRepository.GetPhieuTraByIdThanhVien(thanhVien.Id);
            var phieuTraResponse = new List<PhieuTraResponseDto>();

            foreach (var phieuTra in phieuTraList)
            {
                var currentPhieuTra = new PhieuTraResponseDto()
                {
                    Id = phieuTra.Id,
                    Id_ThanhVien = phieuTra.Id_ThanhVien,
                    Id_NhanVien = phieuTra.Id_NhanVien,
                    TinhTrang = phieuTra.TinhTrang,
                };
                
                var getChiTietPhieuTraList = phieuTraRepository.GetChiTietPhieuTraByIdPhieuTra(phieuTra.Id);
                var ChiTietPhieuTraList = new List<ChiTietPhieuTraResponseDto>();

                foreach (var chiTietPhieuTra in getChiTietPhieuTraList)
                {
                    var vatDung = vatDungRepository.VatDungById(chiTietPhieuTra.Id_VatDung);
                    
                    var currentChiTietPhieuTra = new ChiTietPhieuTraResponseDto()
                    {
                        Id_PhieuTra = chiTietPhieuTra.Id_PhieuTra,
                        Id_VatDung = chiTietPhieuTra.Id_VatDung,
                        VatDung = vatDung,
                        TinhTrang = chiTietPhieuTra.TinhTrang,
                    };
                    
                    ChiTietPhieuTraList.Add(currentChiTietPhieuTra);
                }
                
                currentPhieuTra.ChiTietPhieuTra = ChiTietPhieuTraList;
                phieuTraResponse.Add(currentPhieuTra);
            }
            
            return Results.Ok(phieuTraResponse);
        }).WithTags(tagName);
        
        app.MapGet("/getChiTietPhieuDat", ([FromQuery] int id) =>
        {
            var result = phieuTraRepository.GetChiTietPhieuTraByIdPhieuTra(id);
            return Results.Ok(result);
        }).WithTags(tagName);
        
        // app.MapPut("/addPhieuTra", (HttpContext context,AddPhieuTraRequestDto addPhieuTraRequestDto, ThanhVien thanhVien) =>
        // {
        //     var Authorization = context.Request.Headers.Authorization.ToString();
        //     var token = Authorization.Substring(7, Authorization.Length - 7);
        //     var idTaiKhoan = authService.DecodeJwtAccessToken(token);
        //     var nhanVien = taiKhoanRepository.GetNhanVienById(idTaiKhoan);
        //
        //     if (thanhVien == null)
        //         return Results.NotFound("Không tìm thấy thành viên!");
        //
        //     var vatDung = vatDungRepository.GetVatDung().Where(p => addPhieuTraRequestDto.listIds.Contains(p.Id))
        //         .ToList();
        //
        //     if (vatDung.Count != addPhieuTraRequestDto.listIds.Length)
        //         return Results.BadRequest("Vật dụng không tồn tại");
        //     
        //     // var vatDungDangMuon = vatDung.Where(p => p.TinhTrang == "Đang mượn").ToList();
        //     //
        //     // if (vatDungDangMuon.Count != addPhieuTraRequestDto.listIds.Length)
        //     // {
        //     //     return Results.BadRequest("Vật dụng không thuộc phiếu đặt hoặc chưa được mượn");
        //     // }
        //
        //     var newPhieuTra = new PhieuTra()
        //     {
        //         Id_NhanVien = nhanVien.Id,
        //         Id_ThanhVien = thanhVien.Id,
        //         NgayTra = DateTime.Now,
        //         TinhTrang = "Đã xuất phiếu"
        //     };
        //
        //     var resultPhieuDat = phieuTraRepository.AddPhieuTra(newPhieuTra, addPhieuTraRequestDto.listIds);
        //     if (!resultPhieuDat)
        //         return Results.UnprocessableEntity("Tạo phiếu trả không thành công!");
        //     // var resultVatDung = vatDungRepository.updateListTinhTrangDaDat(addPhieuTraRequestDto.listIds);
        //     // if (!resultVatDung)
        //     //     return Results.UnprocessableEntity("Đã xảy ra lỗi lúc tạo phiếu trả");
        //     return Results.Ok("Tạo phiếu trả thành công");
        // }).WithMetadata(typeof(AddPhieuTraRequestDto)).WithTags(tagName);
    }
}
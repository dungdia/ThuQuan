using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Contains;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Dtos.Response;
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
        var _dbcontext = app.ServiceProvider.GetRequiredService<DbContext>();
        // Lấy tất cả phiếu đặt
        app.MapGet("/PhieuDat", () =>
        {
            var result = phieuDatRepository.GetPhieuDat();
                return Results.Ok(result);
        }).WithTags(tagName);

        app.MapGet("/getPhieuDatAdmin",([FromQuery] string type) =>
        {
            string[] typeList =  ["Tất cả", "Đã xử lý","Chưa xử lý", "Đã huỷ"];
            if (!typeList.Contains(type))
            {
                return Results.NotFound("Không có phiếu đặt loại đó");
            }

            if (type == "Chưa xử lý")
                type = "Đã xuất phiếu";
            
            string query = @"SELECT pd.id,pd.id_thanhvien,tv.hoten,pd.ngaydat,pd.tinhtrang 
                             FROM PhieuDat pd 
                             JOIN Thanhvien tv ON pd.id_thanhvien = tv.id 
                             WHERE";
            IEnumerable<Dictionary<string, object>> result;

            if (type == "Tất cả")
            {
                query += " pd.tinhtrang != ?";
                result = _dbcontext.ExcuteQuerry(query,"Ẩn");
            }
            else
            {
                query += " pd.tinhtrang = ?";
                result = _dbcontext.ExcuteQuerry(query,type);
            }
            
            return Results.Ok(result);
        }).WithTags(tagName);

        app.MapGet("/getChiTietPhieuDatAdmin", [Authorize]([FromQuery] int id_phieudat) =>
        {
            var query = @"SELECT CTPD.*,vd.tenvatdung FROM ChiTietPhieuDat CTPD 
                          JOIN VatDung vd ON vd.id = CTPD.id_vatdung
                          WHERE CTPD.id_phieudat = ?";

            var result = _dbcontext.ExcuteQuerry(query, id_phieudat);
            
            return Results.Ok(result);
        }).WithTags(tagName);


        app.MapPost("/HuyPhieuDat", [Authorize](int id_phieudat) =>
        {
            var phieudat = phieuDatRepository.GetPhieuDatByProps(new { Id = id_phieudat }).FirstOrDefault();
            if (phieudat == null)
                return Results.NotFound("Không tìm thấy phiếu đặt");
            

            if (phieudat.TinhTrang != "Đã xuất phiếu")
                return Results.BadRequest("Chỉ có thể huỷ phiếu có tình trạng đã xuất phiếu");
            
            var chiTietPhieuDat = phieuDatRepository.GetChiTietPhieuDatByIdPhieuDat(id_phieudat);

            phieudat.TinhTrang = "Đã huỷ";
            if (!phieuDatRepository.UpdatePhieuDat(phieudat, id_phieudat))
                return Results.UnprocessableEntity("Không thể huỷ phiếu đặt");
            foreach (var ct in chiTietPhieuDat)
            {
                var result = vatDungRepository.updateTinhTrangChuaMuon(ct.Id_VatDung);
                if (!result)
                    return Results.UnprocessableEntity("Đã xả ra lỗi lúc huỷ");
            }
            
            return Results.Ok("Huỷ thành công");
        });
        
        // Lấy phiếu đặt từ id thành viên
        app.MapGet("/GetPhieuDatByToken", (HttpContext context) =>
            {
                var Authorization = context.Request.Headers.Authorization.ToString();
                var token = Authorization.Substring(7, Authorization.Length - 7);
                var idTaiKhoan = authService.DecodeJwtAccessToken(token);

                var idThanhVien = taiKhoanRepository.GetThanhVienById(idTaiKhoan);
                Console.WriteLine($"id {idTaiKhoan}");

                // Lấy danh sách phiếu đặt
                var danhSachPhieuDat = phieuDatRepository.GetPhieuDatByIdThanhVien(idThanhVien.Id);
                var phieuDatResponse = new List<PhieuDatResponseDto>();
                
                foreach (var phieuDat in danhSachPhieuDat)
                {

                    var current_phieudat = new PhieuDatResponseDto()
                    {
                        Id = phieuDat.Id,
                        NgayDat = phieuDat.NgayDat,
                        Id_ThanhVien = phieuDat.Id_ThanhVien,
                        TinhTrang = phieuDat.TinhTrang,
                    };
                    // Lấy danh sách chi tiết phiếu đặt
                    var danhSachChiTietPhieuDat = phieuDatRepository.GetChiTietPhieuDatByIdPhieuDat(phieuDat.Id);
                    var listChiTietPhieuDat = new List<ChiTietPhieuDatResponseDto>();
                    foreach (var chiTiet in danhSachChiTietPhieuDat)
                    {
                        
                        // Lấy VatDung từ IdVatDung
                        var vatDung = vatDungRepository.VatDungById(chiTiet.Id_VatDung);

                        // // Gán VatDung vào ChiTietPhieuDat
                        // chiTiet.VatDung = vatDung;
                        var current_chiTiet = new ChiTietPhieuDatResponseDto()
                        {
                            Id_PhieuDat = chiTiet.Id_PhieuDat,
                            Id_VatDung = chiTiet.Id_VatDung,
                            VatDung = vatDung,
                        };
                        listChiTietPhieuDat.Add(current_chiTiet);
                    }

                    // Gán lại danh sách chi tiết phiếu đặt vào đối tượng phiếu đặt
                    current_phieudat.ChiTietPhieuDatList = listChiTietPhieuDat;
                    phieuDatResponse.Add(current_phieudat);
                }

                // Trả về kết quả
                return Results.Ok(phieuDatResponse);
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
            var taiKhoanId = authService.DecodeJwtAccessToken(token);
            var thanhvien = taiKhoanRepository.GetAccountByProps(new {Id = taiKhoanId}).FirstOrDefault();
            
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
                NgayDat = addPhieuDatRequestDto.NgayDat,
                TinhTrang = "Đã xuất phiếu"
            };
            
            var resultPhieuDat = phieuDatRepository.AddPhieuDat(newPhieuDat, addPhieuDatRequestDto.listId);
            if(!resultPhieuDat)
                return Results.UnprocessableEntity("Thêm phiếu đặt không thành công");
            var resultVatDung = vatDungRepository.updateListTinhTrangDaDat(addPhieuDatRequestDto.listId);
            if (!resultVatDung)
                return Results.UnprocessableEntity("Đã xảy ra lỗi lúc thêm phiếu đặt");
            
            return Results.Ok("Đặt thành công");
        }).WithMetadata(typeof(AddPhieuDatRequestDto)).WithTags(tagName);
    }
}
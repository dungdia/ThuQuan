using Microsoft.AspNetCore.Authorization;
using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Endpoints;

public static class PhieuMuonEndpoint
{
    public static void MapPhieuMuonEndpoints(this IEndpointRouteBuilder app)
    {
        var phieuMuonRepository = app.ServiceProvider.GetService<IPhieuMuonRepository>();
        var phieuDatRepository = app.ServiceProvider.GetService<IPhieuDatRepository>();
        var vatDungRepositoru = app.ServiceProvider.GetService<IVatDungRepository>();
        var nhanVienRepository = app.ServiceProvider.GetService<INhanVienRepository>();
        var authService = app.ServiceProvider.GetService<IAuthService>();
        var groupName = "Phieu Muon";

        app.MapGet("/GetPhieuMuon", () => { return Results.Ok(); }).WithTags(groupName);
        
        app.MapPost("/InsertPhieuMuon", () => { return Results.Ok(); }).WithTags(groupName);
        
        app.MapPut("/UpdatePhieuMuon", () => { return Results.Ok(); }).WithTags(groupName);
        
        app.MapPost("/AddPhieuMuonFromPhieuDat", [Authorize] (HttpContext context,PhieuMuonFromPhieuDatDTO phieudatDTO) =>
        {
            var Authorization = context.Request.Headers.Authorization.ToString();
            var token = Authorization.Substring(7, Authorization.Length - 7);
            var idTaiKhoan = authService.DecodeJwtAccessToken(token);
            
            var phieudat = phieuDatRepository.GetPhieuDatByProps(new {Id = phieudatDTO.id_PhieuDat}).FirstOrDefault();
            if(phieudat == null) 
                return Results.NotFound("Không tìm thấy phiếu đặt");
            if (phieudatDTO.ngayTra < DateTime.Today)
                return Results.BadRequest("Ngày trả dự kiến không hợp lệ");
            
            var chitietPhieuDat = phieuDatRepository.GetChiTietPhieuDatByIdPhieuDat(phieudatDTO.id_PhieuDat);
            var nhanvien = nhanVienRepository.GetNhanVienByProps(new { Id_TaiKhoan = idTaiKhoan}).FirstOrDefault();

            if (nhanvien == null)
                return Results.NotFound("Không tìm thấy nhân viên");
            
            
            var newPhieuMuon = new PhieuMuonInsertDTO()
            {
                thoiGianTra = phieudatDTO.ngayTra,
                Id_ThanhVien = phieudat.Id_ThanhVien,
                Id_NhanVien = nhanvien.Id,
                TinhTrang = "Đã xuất phiếu",
                ThoiGianMuon = DateTime.Now,
            };
            
            var listId = chitietPhieuDat.Select(p => p.Id_VatDung).ToArray();
            if (!phieuMuonRepository.AddPhieuMuon(newPhieuMuon,listId))
                return Results.BadRequest("Tạo phiếu mượn không thành công");

            foreach (var id in listId)
                vatDungRepositoru.updateTinhTrangDaMuon(id);

            phieudat.TinhTrang = "Đã xử lý";
            if (!phieuDatRepository.UpdatePhieuDat(phieudat, phieudat.Id))
                return Results.UnprocessableEntity("Không thể thay đổi tình trạng của phiếu đặt");
            
            
            return Results.Ok("Thêm phiếu mượn thành công");
        }).WithTags(groupName);
}
}
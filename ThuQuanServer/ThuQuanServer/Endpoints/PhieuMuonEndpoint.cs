using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThuQuanServer.ApplicationContext;
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
        var vatDungRepository = app.ServiceProvider.GetService<IVatDungRepository>();
        var nhanVienRepository = app.ServiceProvider.GetService<INhanVienRepository>();
        var taiKhoanRepository = app.ServiceProvider.GetService<ITaiKhoanRepository>();
        var authService = app.ServiceProvider.GetService<IAuthService>();
        var _dbcontext = app.ServiceProvider.GetService<DbContext>();
        var groupName = "Phieu Muon";

        app.MapGet("/GetPhieuMuon", ([FromQuery] string type) =>
        {
            string[] typeList = ["Tất cả","Chưa trả","Đã trả","Đã huỷ","Ẩn"];
            if(!typeList.Contains(type))
                return Results.BadRequest("Kiểu không hợp lệ");
            if (type == "Chưa trả")
                type = "Đã xuất phiếu";
            
            string query = @"SELECT pm.id,pm.id_thanhvien,tv.hoten as ten_thanhvien,pm.id_nhanvien,nv.hoten as ten_nhanvien,pm.thoigianmuon,pm.thoigiantra,pm.tinhtrang
                             FROM Phieumuon pm
                             JOIN Thanhvien tv ON tv.id = pm.id_thanhvien
                             JOIN nhanvien nv ON nv.id = pm.id_nhanvien
                             WHERE ";
            IEnumerable<Dictionary<string, object>> result;

            if (type == "Tất cả")
            {
                query += " pm.tinhtrang != ?";
                result = _dbcontext.ExcuteQuerry(query,"Ẩn");
            }
            else
            {
                query += " pm.tinhtrang = ?";
                result = _dbcontext.ExcuteQuerry(query,type);
            }
            
            return Results.Ok(result);
        }).WithTags(groupName);

        app.MapGet("/GetChiTietPhieuMuon", (int id_phieumuon) =>
        {
            var query = @"SELECT ctpm.*,vd.tenvatdung FROM chitietphieumuon ctpm
                          JOIN Vatdung vd on vd.id = ctpm.id_vatdung
                          WHERE id_phieuMuon = ?";

            var result = _dbcontext.ExcuteQuerry(query,id_phieumuon);
            return Results.Ok(result); 
        }).WithTags(groupName);
        
        app.MapPost("/InsertPhieuMuon", [Authorize] (HttpContext context, AddPhieuMuonDTO addPhieuMuonDTO) =>
        {
            //Lấy access token từ request header
            var authorization = context.Request.Headers.Authorization.ToString();
            var token = authorization.Substring(7);
            var idTaiKhoan = authService.DecodeJwtAccessToken(token);
            var nhanvien = nhanVienRepository.GetNhanVienByProps(new { Id_TaiKhoan = idTaiKhoan}).FirstOrDefault();

            if (nhanvien == null)
                return Results.BadRequest("Không tìm thấy nhân viên");

            var thanhvien = taiKhoanRepository.GetThanhVienByIdThanhVien(addPhieuMuonDTO.id_thanhvien);

            if (thanhvien == null)
                return Results.BadRequest("Không tìm thấy thành viên");

            var vatDung = vatDungRepository.GetVatDung().Where(p => addPhieuMuonDTO.listId.Contains(p.Id)).ToList();
            
            if (vatDung.Count() != addPhieuMuonDTO.listId.Length)
                return Results.BadRequest("Vật dụng không tồn tại");
            var vatDungDaDat = vatDung.Where(p => p.TinhTrang != "Chưa mượn").ToList(); 
            
            if (vatDungDaDat.Count > 0)
            {
                var firstVatDung = vatDungDaDat.First();
                if (firstVatDung.TinhTrang == "Ẩn")
                    return Results.BadRequest($"Vật dụng không tồn tại");
                return Results.BadRequest($"Vật dụng { firstVatDung.TenVatDung }, Id={ firstVatDung.Id } { firstVatDung.TinhTrang }");
            }

            var newPhieuMuon = new PhieuMuonInsertDTO()
            {
                thoiGianTra = addPhieuMuonDTO.thoigiantra,
                TinhTrang = "Đã xuất phiếu",
                ThoiGianMuon = DateTime.Now,
                Id_ThanhVien = addPhieuMuonDTO.id_thanhvien,
                Id_NhanVien = nhanvien.Id
            };
            
            if (!phieuMuonRepository.AddPhieuMuon(newPhieuMuon,addPhieuMuonDTO.listId))
                return Results.BadRequest("Tạo phiếu mượn không thành công");

            foreach (var id in addPhieuMuonDTO.listId)
                vatDungRepository.updateTinhTrangDaMuon(id);
            
            return Results.Ok();
        }).WithMetadata(typeof(AddPhieuMuonDTO)).WithTags(groupName);
        
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
                vatDungRepository.updateTinhTrangDaMuon(id);

            phieudat.TinhTrang = "Đã xử lý";
            if (!phieuDatRepository.UpdatePhieuDat(phieudat, phieudat.Id))
                return Results.UnprocessableEntity("Không thể thay đổi tình trạng của phiếu đặt");
            
            
            return Results.Ok("Thêm phiếu mượn thành công");
        }).WithTags(groupName);
}
}
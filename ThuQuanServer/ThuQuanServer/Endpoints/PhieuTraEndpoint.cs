using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.Response;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Services;
using Microsoft.AspNetCore.Mvc;
using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Models;
using ThuQuanServer.Repository;

namespace ThuQuanServer.Endpoints;

public static class PhieuTraEndpoint
{
    public static void MapPhieuTraEndpoints(this IEndpointRouteBuilder app)
    {
        var tagName = "Phieu Tra";
        var phieuTraRepository = app.ServiceProvider.GetRequiredService<IPhieuTraRepository>();
        var authService = app.ServiceProvider.GetRequiredService<IAuthService>();
        var vatDungRepository = app.ServiceProvider.GetRequiredService<IVatDungRepository>();
        var taiKhoanRepository = app.ServiceProvider.GetRequiredService<ITaiKhoanRepository>();
        var nhanVienRepository = app.ServiceProvider.GetRequiredService<INhanVienRepository>();
        var phieuMuonRepository = app.ServiceProvider.GetRequiredService<IPhieuMuonRepository>();
        var phieuPhatRepository = app.ServiceProvider.GetRequiredService<IPhieuPhatRepository>();
        var _dbcontext = app.ServiceProvider.GetRequiredService<DbContext>();
        
        // Lấy tất cả phiếu trả
        app.MapGet("/GetPhieuTra", ([FromQuery] string type) =>
        {
            string[] typeList = ["Tất cả","Đã trả","Trễ","Ẩn"];
            if(!typeList.Contains(type))
                return Results.BadRequest("Kiểu không hợp lệ");
            if (type == "Đã trả")
                type = "Đã xuất phiếu";
            
            var query = @"SELECT pt.id,pt.id_thanhvien,tv.hoten as ten_thanhvien,pt.id_nhanvien,nv.hoten as ten_nhanvien,pt.thoigiantra,pt.tinhtrang
                             FROM Phieutra pt
                             JOIN Thanhvien tv ON tv.id = pt.id_thanhvien
                             JOIN nhanvien nv ON nv.id = pt.id_nhanvien
                             WHERE ";
            IEnumerable<Dictionary<string, object>> result;

            if (type == "Tất cả")
            {
                query += " pt.tinhtrang != ?";
                result = _dbcontext.ExcuteQuerry(query,"Ẩn");
            }
            else
            {
                query += " pt.tinhtrang = ?";
                result = _dbcontext.ExcuteQuerry(query,type);
            }
            
            return Results.Ok(result);
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
        
        app.MapGet("/getChiTietPhieuDat", [Authorize] ([FromQuery] int id_phieutra) =>
        {
            var query = @"SELECT CTPT.*,vd.tenvatdung FROM ChiTietPhieuTra CTPT 
                          JOIN VatDung vd ON vd.id = CTPT.id_vatdung
                          WHERE CTPT.id_phieutra = ?";

            var result = _dbcontext.ExcuteQuerry(query, id_phieutra);
            
            return Results.Ok(result);
        }).WithTags(tagName);

        app.MapPost("/addPhieuTra", [Authorize] (HttpContext context,AddPhieuTraRequestDto addPhieutraRequestDto) =>
        {
            //Lấy access token từ request header
            var authorization = context.Request.Headers.Authorization.ToString();
            var token = authorization.Substring(7);
            var idTaiKhoan = authService.DecodeJwtAccessToken(token);
            var nhanvien = nhanVienRepository.GetNhanVienByProps(new { Id_TaiKhoan = idTaiKhoan}).FirstOrDefault();
            
            if(nhanvien == null)
                return Results.NotFound("Không tìm thấy nhân viên");

            var thanhvien = taiKhoanRepository.GetThanhVienByIdThanhVien(addPhieutraRequestDto.id_thanhvien);

            if (thanhvien == null)
                return Results.NotFound("Không tìm thấy thành viên");

            var phieuMuon = phieuMuonRepository.GetPhieuMuonByProps(new { Id = addPhieutraRequestDto.id_phieumuon}).FirstOrDefault();

            if (phieuMuon == null)
                return Results.NotFound("Không tìm thấy phiếu mượn");

            var listIdVd = addPhieutraRequestDto.listItem.Select(item => item.Id_VatDung);
            
            var vatDung = vatDungRepository.GetVatDung().Where(p => listIdVd.Contains(p.Id)).ToList();
            
            if (vatDung.Count() != listIdVd.Count())
                return Results.BadRequest("Vật dụng không tồn tại");
            
            var vatDungDaMuon = vatDung.Where(p => p.TinhTrang != "Đang mượn").ToList();  
            
            if (vatDungDaMuon.Count > 0)
            {
                var firstVatDung = vatDungDaMuon.First();
                if (firstVatDung.TinhTrang == "Ẩn")
                    return Results.BadRequest($"Vật dụng không tồn tại");
                return Results.BadRequest($"Vật dụng { firstVatDung.TenVatDung }, Id={ firstVatDung.Id } { firstVatDung.TinhTrang } đã trả");
            }
            
            
            //Kiểm tra để tự tạo phiếu phạt
            var vatDungBiHu = addPhieutraRequestDto.listItem.Where(vd => vd.TinhTrang == "Hư hỏng").Select(vd => vd.Id_VatDung).ToList();
            var vatDungBiMat = addPhieutraRequestDto.listItem.Where(vd => vd.TinhTrang == "Bị mất").Select(vd => vd.Id_VatDung).ToList();
            var tratre = phieuMuon.thoiGianTra < DateTime.Today;
            PhieuPhatInsertDTO phieuPhat = null;
            List<ChiTietPhieuPhat> chiTietPhieuPhatList = new List<ChiTietPhieuPhat>();
            var lydo = "";
            if (tratre || vatDungBiHu.Any() || vatDungBiMat.Any())
            {
                if (tratre)
                    lydo += "Trã trễ; ";
                if (vatDungBiHu.Any())
                    lydo += "Làm hỏng vật dụng; ";
                if (vatDungBiMat.Any())
                    lydo += "Làm mất vật dụng; ";
                phieuPhat = new PhieuPhatInsertDTO()
                {
                    Id_ThanhVien = thanhvien.Id,
                    LyDo = lydo,
                    MucPhat = "",
                    tinhtrang = "Đã xuất phiếu"
                };

                foreach (var vd in vatDungBiHu)
                {
                    var newChiTietPhieuPhat = new ChiTietPhieuPhat()
                    {
                        Id_VatDung = vd,
                        Id_PhieuPhat = 0,
                        GhiChu = "",
                    };
                    chiTietPhieuPhatList.Add(newChiTietPhieuPhat);
                }

                foreach (var vatdung in vatDungBiMat)
                {
                    var newChiTietPhieuPhat = new ChiTietPhieuPhat()
                    {
                        Id_VatDung = vatdung,
                        Id_PhieuPhat = 0,
                        GhiChu = "",
                    };
                    chiTietPhieuPhatList.Add(newChiTietPhieuPhat);
                }
            }

            foreach (var vd in vatDung)
            {
                vd.TinhTrang = "Chưa mượn";
                if (vatDungBiHu.Contains(vd.Id))
                    vd.TinhTrang = "Bị hỏng";
                if (vatDungBiMat.Contains(vd.Id))
                    vd.TinhTrang = "Ẩn";
            }
                
            
            
            var phieutra = new PhieuTraInsertDTO()
            {
                Id_NhanVien = nhanvien.Id,
                Id_ThanhVien = thanhvien.Id,
                ThoiGianTra = DateTime.Now,
                TinhTrang = "Đã xuất phiếu"
            };
            
            if (!phieuTraRepository.AddPhieuTra(phieutra, addPhieutraRequestDto.listItem))
                return Results.UnprocessableEntity("Không thể thêm phiếu trả");

            var phieuMuonInsertDto = new PhieuMuonInsertDTO()
            {
                Id_NhanVien = phieuMuon.Id_NhanVien,
                Id_ThanhVien = phieuMuon.Id_ThanhVien,
                TinhTrang = "Đã trả",
                thoiGianTra = phieuMuon.thoiGianTra,
                ThoiGianMuon = phieuMuon.ThoiGianMuon
            };

            if (!phieuMuonRepository.UpdatePhieuMuon(phieuMuonInsertDto, phieuMuon.Id))
                return Results.UnprocessableEntity("Không thể xử lý phiếu mượn");

            foreach (var vd in vatDung)
            {
                var vatDungInsert = new VatDungRequestDto()
                {
                    TenVatDung = vd.TenVatDung,
                    id_loaiVatDung = vd.Id_LoaiVatDung,
                    HinhAnh = vd.HinhAnh,
                    MoTa = vd.MoTa,
                    TinhTrang = vd.TinhTrang
                };
                _dbcontext.Update<VatDung>(vatDungInsert,vd.Id);
                _dbcontext.SaveChange();
            }

            if (phieuPhat != null)
            {
                if (!phieuPhatRepository.AddPhieuPhat(phieuPhat, chiTietPhieuPhatList.ToArray()))
                    return Results.UnprocessableEntity("Không thể thêm phiếu phạt");
                return Results.Ok($"Tạo phiếu trả thành công với vi phạm: {lydo}");
            }
            
            return Results.Ok("Tạo Phiếu Trả Thành Công");
        }).WithMetadata(typeof(AddPhieuTraRequestDto)).WithTags(tagName);

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
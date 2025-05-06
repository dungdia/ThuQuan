using ThuQuanServer.ApplicationContext;

using ThuQuanServer.Dtos.Response;
using ThuQuanServer.Interfaces;

using ThuQuanServer.Dtos.InsertObject;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;


namespace ThuQuanServer.Endpoints;

public static class PhieuPhatEndpoint
{


    public static void MapPhieuPhatEndpoint(this IEndpointRouteBuilder app)
    {
        var phieuPhatRepository = app.ServiceProvider.GetService<IPhieuPhatRepository>();
        var taiKhoanRepository = app.ServiceProvider.GetService<ITaiKhoanRepository>();
        var _dbcontext = app.ServiceProvider.GetService<DbContext>();
        var authService = app.ServiceProvider.GetService<IAuthService>();
        var vatDungRepository = app.ServiceProvider.GetService<IVatDungRepository>();
        var tagName = "Phieu Phat";

        app.MapGet("/GetPhieuPhat", (string type) =>
        {
            string[] typeList = ["Tất cả","Chưa xử lý","Đã xử lý","Đã huỷ"];
            
            if (!typeList.Contains(type))
                return Results.BadRequest("Kiêu tìm không hợp lệ");

            if (type == "Chưa xử lý")
                type = "Đã xuất phiếu";

            var query = @"SELECT pp.*,tv.hoten FROM Phieuphat pp
                          JOIN Thanhvien tv ON tv.id = pp.id_thanhvien
                          WHERE ";
            IEnumerable<Dictionary<string, object>> result;
            
            if (type == "Tất cả")
            {
                query += " pp.tinhtrang != ?";
                result = _dbcontext.ExcuteQuerry(query,"Ẩn");
            }
            else
            {
                query += " pp.tinhtrang = ?";
                result = _dbcontext.ExcuteQuerry(query, type);
            }
            
            return Results.Ok(result);
        }).WithTags(tagName);

        app.MapGet("/GetChiTietPhieuPhat", (int id_phieuphat) =>
        {
            var query = @"SELECT pp.*,vd.tenvatdung FROM ChiTietPhieuPhat pp
                          JOIN vatdung vd ON vd.id = pp.id_vatdung
                          WHERE pp.id_phieuphat = ?";
            var result = _dbcontext.ExcuteQuerry(query,id_phieuphat);
            return Results.Ok(result);
        }).WithTags(tagName);

        app.MapPost("/HuyPhieuPhat", (int id_phieuphat) =>
        {
            var phieuphat = phieuPhatRepository.GetPhieuPhatByProps(new { Id = id_phieuphat }).FirstOrDefault();

            if (phieuphat == null)
                return Results.NotFound("Không tìm thấy phiếu phạt");

            if (phieuphat.TinhTrang != "Đã xuất phiếu")
                return Results.BadRequest("Không thể huỷ phiếu này");
                
            var phieuPhatInsertDTO = new PhieuPhatInsertDTO()
            {
                tinhtrang = "Đã huỷ",
                LyDo = phieuphat.LyDo,
                MucPhat = phieuphat.MucPhat,
                Id_ThanhVien = phieuphat.Id_ThanhVien,
            };

            if (!phieuPhatRepository.UpdatePhieuPhat(phieuPhatInsertDTO,phieuphat.Id))
                return Results.UnprocessableEntity("Không thể xử lý phiếu phạt");

            return Results.Ok("Huỷ phiếu phạt thành công");
        });
        
        app.MapPost("/XoaPhieuPhat", (int id_phieuphat) =>
        {
            var phieuphat = phieuPhatRepository.GetPhieuPhatByProps(new { Id = id_phieuphat }).FirstOrDefault();

            if (phieuphat == null)
                return Results.NotFound("Không tìm thấy phiếu phạt");

            if (phieuphat.TinhTrang != "Đã xuất phiếu" && phieuphat.TinhTrang != "Đã huỷ")
                return Results.BadRequest("Không thể xoá phiếu này");
                
            var phieuPhatInsertDTO = new PhieuPhatInsertDTO()
            {
                tinhtrang = "Ẩn",
                LyDo = phieuphat.LyDo,
                MucPhat = phieuphat.MucPhat,
                Id_ThanhVien = phieuphat.Id_ThanhVien,
            };

            if (!phieuPhatRepository.UpdatePhieuPhat(phieuPhatInsertDTO,phieuphat.Id))
                return Results.UnprocessableEntity("Không thể xử lý phiếu phạt");

            return Results.Ok("Xoá phiếu phạt thành công");
        });

        app.MapPost("/updatePhieuPhat", (PhieuPhatRequestDTO phieuPhatRequestDTO) =>
        {
            var phieuPhat = phieuPhatRepository.GetPhieuPhatByProps(new {Id = phieuPhatRequestDTO.id}).FirstOrDefault();
            if(phieuPhat == null)
                return Results.NotFound("Không tìm thấy phiếu phạt");
            
            var phieuPhatInsertDTO = new PhieuPhatInsertDTO()
            {
                MucPhat = phieuPhatRequestDTO.MucPhat,
                Id_ThanhVien = phieuPhatRequestDTO.Id_ThanhVien,
                LyDo = phieuPhatRequestDTO.LyDo,
                tinhtrang = phieuPhat.TinhTrang
            };
            
            if (!phieuPhatRepository.UpdatePhieuPhat(phieuPhatInsertDTO, phieuPhatRequestDTO.id))
                return Results.UnprocessableEntity("Xử lý phiếu thất bại");
            
            var thanhvien = taiKhoanRepository.GetThanhVienByIdThanhVien(phieuPhatRequestDTO.Id_ThanhVien);
            if (thanhvien== null)
                return Results.NotFound("Không tìm thấy tài khoản");

            var taikhoan = taiKhoanRepository.GetAccountByProps(new { Id = thanhvien.Id_TaiKhoan }).FirstOrDefault();

            if (taikhoan == null)
                return Results.NotFound("Không tìm thấy tài khoản");

            if (phieuPhatInsertDTO.MucPhat != "Khoá tài khoản")
            {
                taikhoan.TinhTrang = "Hoạt động";
                _dbcontext.Update<TaiKhoan>(taikhoan,taikhoan.Id);
                _dbcontext.SaveChange();
                thanhvien.TinhTrang = "Hoạt động";
                _dbcontext.Update<ThanhVien>(thanhvien, thanhvien.Id);
                _dbcontext.SaveChange();
                return Results.Ok("Xử lý thành công");
            }

            if (phieuPhatInsertDTO.MucPhat == "Khoá tài khoản")
            {
                taikhoan.TinhTrang = "Đã bị khoá";
                _dbcontext.Update<TaiKhoan>(taikhoan,taikhoan.Id);
                _dbcontext.SaveChange();
                thanhvien.TinhTrang = "Đã bị khoá";
                _dbcontext.Update<ThanhVien>(thanhvien, thanhvien.Id);
                _dbcontext.SaveChange();
                return Results.Ok("Xử lý phiếu thành công");
            }
            
            return Results.Ok("");
        }).WithMetadata(typeof(PhieuPhatRequestDTO)).WithTags(tagName);

        app.MapPost("/XuLyPhieuPhat", (PhieuPhatRequestDTO phieuPhatRequestDTO) =>
        {
            var phieuPhat = phieuPhatRepository.GetPhieuPhatByProps(new {Id = phieuPhatRequestDTO.id}).FirstOrDefault();
            if(phieuPhat == null)
                return Results.NotFound("Không tìm thấy phiếu phạt");
            
            var phieuPhatInsertDTO = new PhieuPhatInsertDTO()
            {
                MucPhat = phieuPhatRequestDTO.MucPhat,
                Id_ThanhVien = phieuPhatRequestDTO.Id_ThanhVien,
                LyDo = phieuPhatRequestDTO.LyDo,
                tinhtrang = "Đã xử lý"
            };

            if (!phieuPhatRepository.UpdatePhieuPhat(phieuPhatInsertDTO, phieuPhatRequestDTO.id))
                return Results.UnprocessableEntity("Xử lý phiếu thất bại");
            
            if (phieuPhatInsertDTO.MucPhat != "Khoá tài khoản")
                return Results.Ok("Xử lý thành công");
            
            var thanhvien = taiKhoanRepository.GetThanhVienByIdThanhVien(phieuPhatRequestDTO.Id_ThanhVien);
            if (thanhvien== null)
                return Results.NotFound("Không tìm thấy tài khoản");

            var taikhoan = taiKhoanRepository.GetAccountByProps(new { Id = thanhvien.Id_TaiKhoan }).FirstOrDefault();

            if (taikhoan == null)
                return Results.NotFound("Không tìm thấy tài khoản");

            taikhoan.TinhTrang = "Đã bị khoá";
            _dbcontext.Update<TaiKhoan>(taikhoan,taikhoan.Id);
            _dbcontext.SaveChange();
            thanhvien.TinhTrang = "Đã bị khoá";
            _dbcontext.Update<ThanhVien>(thanhvien, thanhvien.Id);
            _dbcontext.SaveChange();
            
            return Results.Ok("Xử lý phiếu thành công");
        }).WithMetadata(typeof(PhieuPhatRequestDTO)).WithTags(tagName);

        app.MapPost("/addPhieuPhat", (PhieuPhatRequestDTO PhieuPhatRequestDTO) =>
        {
            var phieuPhatInsertDTO = new PhieuPhatInsertDTO()
            {
                Id_ThanhVien = PhieuPhatRequestDTO.Id_ThanhVien,
                MucPhat = PhieuPhatRequestDTO.MucPhat,
                tinhtrang = "Đã xử lý",
                LyDo = PhieuPhatRequestDTO.LyDo,
            };
            if (!phieuPhatRepository.AddPhieuPhat(phieuPhatInsertDTO, []))
                return Results.UnprocessableEntity("Thêm phiếu phạt không thành công");

            
            if (phieuPhatInsertDTO.MucPhat != "Khoá tài khoản")
                return Results.Ok("Tạo phiếu thành công");
            
            var thanhvien = taiKhoanRepository.GetThanhVienByIdThanhVien(phieuPhatInsertDTO.Id_ThanhVien);
            if (thanhvien== null)
                return Results.NotFound("Không tìm thấy tài khoản");

            var taikhoan = taiKhoanRepository.GetAccountByProps(new { Id = thanhvien.Id_TaiKhoan }).FirstOrDefault();

            if (taikhoan == null)
                return Results.NotFound("Không tìm thấy tài khoản");

            taikhoan.TinhTrang = "Đã bị khoá";
            _dbcontext.Update<TaiKhoan>(taikhoan,taikhoan.Id);
            _dbcontext.SaveChange();
            thanhvien.TinhTrang = "Đã bị khoá";
            _dbcontext.Update<ThanhVien>(thanhvien, thanhvien.Id);
            _dbcontext.SaveChange();
            
            return Results.Ok("Tạo phiếu thành công");
        }).WithMetadata(typeof(PhieuPhatRequestDTO)).WithTags(tagName);
  
     app.MapGet("/GetPhieuPhatByToken", (HttpContext context) =>
        {
            var Authorization = context.Request.Headers.Authorization.ToString();
            var token = Authorization.Substring(7,Authorization.Length - 7);
            var idTaiKhoan = authService.DecodeJwtAccessToken(token);

            var idThanhVien = taiKhoanRepository.GetThanhVienById(idTaiKhoan);
            Console.WriteLine($"id {idTaiKhoan}");
            
            // Lấy danh sách phiếu phạt
            var danhSachPhieuPhat = phieuPhatRepository.GetPhieuPhatByIdThanhVien(idThanhVien.Id);
            var phieuPhatResponse = new List<PhieuPhatResponseDto>();

            foreach (var phieuPhat in danhSachPhieuPhat)
            {
                var current_phieuphat = new PhieuPhatResponseDto()
                {
                    Id = phieuPhat.Id,
                    Id_ThanhVien = phieuPhat.Id_ThanhVien,
                    lydo = phieuPhat.LyDo,
                    mucphat = phieuPhat.MucPhat,
                    TinhTrang = phieuPhat.TinhTrang
                };
                // Lấy danh sách chi tiết phiếu phạt
                var danhSachChiTietPhieuPhat = phieuPhatRepository.GetChiTietPhieuPhatByIdPhieuPhat(phieuPhat.Id);
                var listChiTietPhieuPhat = new List<ChiTietPhieuPhatResponseDto>();
                foreach (var chiTiet in danhSachChiTietPhieuPhat)
                {
                    // Lấy VatDung từ IdVatDung
                    var vatDung = vatDungRepository.VatDungById(chiTiet.Id_VatDung);
                    // // // Gán VatDung vào ChiTietPhieuDat
                    // chiTiet.VatDung = vatDung;
                    var current_chiTiet = new ChiTietPhieuPhatResponseDto()
                    {
                        Id_PhieuPhat = chiTiet.Id_PhieuPhat,
                        Id_VatDung = chiTiet.Id_VatDung,
                        GhiChu = chiTiet.GhiChu,
                        VatDung = vatDung,
                    };
                    listChiTietPhieuPhat.Add(current_chiTiet);
                }
                // Gán lại danh sách chi tiết phiếu phạt vào đối tượng phiếu phạt
                current_phieuphat.ChiTietPhieuPhatList = listChiTietPhieuPhat;
                phieuPhatResponse.Add(current_phieuphat);
            }
            
            // Trả về kết quả
            return Results.Ok(phieuPhatResponse);
        }).RequireAuthorization()
            .WithTags(tagName);

    }
}
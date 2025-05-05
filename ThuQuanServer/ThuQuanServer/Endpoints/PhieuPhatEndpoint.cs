using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.Response;
using ThuQuanServer.Interfaces;

namespace ThuQuanServer.Endpoints;

public static class PhieuPhatEndpoint
{
    public static void MapPhieuPhatEndpoints(this IEndpointRouteBuilder app)
    {
        var tagName= "Phieu Phat";
        var phieuPhatRepository = app.ServiceProvider.GetRequiredService<IPhieuPhatRepository>();
        
        var authService = app.ServiceProvider.GetRequiredService<IAuthService>();
        var _dbcontext = app.ServiceProvider.GetRequiredService<DbContext>();
        var taiKhoanRepository = app.ServiceProvider.GetRequiredService<ITaiKhoanRepository>();
        var vatDungRepository = app.ServiceProvider.GetRequiredService<IVatDungRepository>();
        
        
        // Lấy tất cả phiếu phạt theo token(id thanh vien)
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
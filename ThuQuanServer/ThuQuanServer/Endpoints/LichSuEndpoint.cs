using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Endpoints;

public static class  LichSuEndpoint
{
    public static void MapLichSuEndpoints(this IEndpointRouteBuilder app)
    {
        var dbContext = app.ServiceProvider.GetRequiredService<DbContext>();
        
        var groupName = "Lich Su";

        app.MapGet("LichSu/GetThanhVien", () =>
        {
            var query = @"SELECT tv.id as id_thanhvien, tv.hoten, tv.sodienthoai, tv.tinhtrang, ls.id as id_lichsu, ls.thoigianvao
                          FROM thanhvien tv 
                          JOIN lichsu ls
                          ON tv.id = ls.id_thanhvien;";   
            var result = dbContext.ExcuteQuerry(query).ToList();
            
            return Results.Ok(result);
        }).WithTags(groupName);

        app.MapPost("LichSu/CheckLichSuVao", (
            [FromQuery] int idThanhVien) =>
        {
            // Kiểm tra xem thành viên này tồn tại hay không -> thong bao
            var queryFindMember = @"SELECT * FROM thanhvien WHERE id = ?";
            var memberExisted = dbContext.ExcuteQuerry(queryFindMember, idThanhVien);
            if (!memberExisted.Any())
            {
                return Results.BadRequest("Không tìm thấy thành viên");
            }
            
            // Kiểm tra xem phiếu phạt có đang bị xủ lý ko -> thong bao
            var queryFindPenalty = @"SELECT * 
                                    FROM thanhvien tv
                                    JOIN phieuphat ppe on ppe.id_thanhvien = ?
                                    WHERE ppe.tinhtrang = 'Đã xuất phiếu'";
            var penaltyExisted = dbContext.ExcuteQuerry(queryFindPenalty, idThanhVien);
            if (penaltyExisted.Any())
            {
                return Results.BadRequest("Thành viên đang bị xử lý vi phạm");
            }
            
            // Insert vao lichsu
            var requestDTO = new LichSuRequestDTO
            {
                id_thanhvien = idThanhVien,
                thoigianvao = DateTime.Now
            };
            var queryInsertLichSu = dbContext.Add<LichSu>(requestDTO);
            if (queryInsertLichSu != 1)
            {
                return Results.BadRequest("Không thể thực hiện check in");
            }

            dbContext.SaveChange();
            
            
            return Results.Ok("Check in thành công");
        }).WithTags(groupName);
    }
}
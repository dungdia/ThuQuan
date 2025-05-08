using Microsoft.AspNetCore.Mvc;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Repository;

namespace ThuQuanServer.Endpoints;

public static class ThongKeEndpoint
{
    public static void MapThongKeEndpoints(this IEndpointRouteBuilder app)
    {
        var dbContext = app.ServiceProvider.GetRequiredService<DbContext>();
        var ThongKeRepository = app.ServiceProvider.GetRequiredService<IThongKeRepository>();
        
        var groupName = "Thong Ke";
        
        // GET
        app.MapPost("/thongKeLichSuNgay", (
            [FromBody] ThongKeLichSuNgayRequestDTO thongKeLichSuNgayRequest) =>
        {
            var thongKeLichSuNgay = ThongKeRepository.ThongKeLichSuNgay(thongKeLichSuNgayRequest.ngay);
            return Results.Ok(thongKeLichSuNgay);
        }).WithTags("ThongKe");
        
        app.MapPost("/ThongKeLichSuKhoangTG", (
            [FromBody] ThongKeKhoangTGRequestDTO tklsktgRequestDTO) =>
        {
            var thongKeLichSu = ThongKeRepository.ThongKeLichSuKhoangNgay(tklsktgRequestDTO.ngayBatDau, tklsktgRequestDTO.ngayKetThuc);
            return Results.Ok(thongKeLichSu);
        }).WithTags("ThongKe");
        
        app.MapPost("/ThongKeVatDungMuon", (
            [FromBody] ThongKeKhoangTGRequestDTO tkktgRequestDTO) => 
        {
            var thongKeVatDung = ThongKeRepository.ThongKeVatDungMuon(tkktgRequestDTO.ngayBatDau, tkktgRequestDTO.ngayKetThuc);
            return Results.Ok(thongKeVatDung);
        }).WithTags("ThongKe");
    }
}
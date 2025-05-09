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
        
        app.MapGet("/ThongKeLichSuKhoangTG", ([FromQuery] string startDate, string endDate) =>
        {
            var thongKeLichSu = ThongKeRepository.ThongKeLichSuKhoangNgay(startDate, endDate);
            return Results.Ok(thongKeLichSu);
        }).WithTags("ThongKe");
        
        app.MapGet("/ThongKeVatDungMuon", ([FromQuery] string startDate, string endDate) => 
        {
            var thongKeVatDung = ThongKeRepository.ThongKeVatDungMuon(startDate, endDate);
            return Results.Ok(thongKeVatDung);
        }).WithTags("ThongKe");
        
    }
}
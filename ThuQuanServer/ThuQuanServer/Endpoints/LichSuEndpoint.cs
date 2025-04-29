using MySqlX.XDevAPI.Common;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos;
using ThuQuanServer.Interfaces;

namespace ThuQuanServer.Endpoints;

public static class  LichSuEndpoint
{
    public static void MapLichSuEndpoints(this IEndpointRouteBuilder app)
    {
        var lichSuRepository = app.ServiceProvider.GetRequiredService<ILichSuRepository>();
        var groupName = "Lich Su";
        
        app.MapGet("/GetAllLichSu", () =>
        {
            var result = lichSuRepository.GetLichSu();
            
            if (!result.Any())
            {
                return Results.BadRequest("Không thể lấy danh sách lịch sử");
            }

            return Results.Ok(result);
        }).WithTags(groupName);
        
        app.MapPost("/CheckLichSuVao", (int? IdThanhVien) =>
        {
            if(!lichSuRepository.CheckLichSuVao(IdThanhVien)){
                return Results.BadRequest("Không thể lấy danh sách lịch sử");
            }
            
            return Results.Ok(new 
            {
                Success = true,
                Message = "Mời vào!",
            });
        }).WithTags(groupName);
    }
}
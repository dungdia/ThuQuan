using Microsoft.AspNetCore.Mvc;
using ThuQuanServer.ApplicationContext;
using System.ComponentModel.DataAnnotations;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using ThuQuanServer.Dtos;

namespace ThuQuanServer.Endpoints;

public static class LoaiVatDungEndpoint
{
    public static void MapLoaiVatDungEndpoint(this IEndpointRouteBuilder app)
    {
        var dbContext = app.ServiceProvider.GetRequiredService<DbContext>();
        var loaiVatDungRepository = app.ServiceProvider.GetRequiredService<ILoaiVatDungRepository>();
        
        var groupName = "Loai vat dung";
        
        // GET
        app.MapGet("/getLoaiVatDung", (DbContext dbContext) =>
        {
            var loaiVatDung = loaiVatDungRepository.GetLoaiVatDung();
            return Results.Ok(loaiVatDung);
        }).WithTags(groupName);

        app.MapGet("/getLoaiVatDungById/{id}", ([FromRoute, Required] int? id) =>
        {
            var loaiVatDung = loaiVatDungRepository.GetLoaiVatDungByProps(new
            {
                Id = id,
            });
            return Results.Ok(loaiVatDung);
        }).WithTags(groupName);
        
        // POST
        app.MapPost("/insertLoaiVatDung", (

            [FromBody] LoaiVatDungRequestDto loaiVatDungRequest) =>
        {
            // Check if ten loai existed
            var existedTenLoaiVatDung = loaiVatDungRepository.GetLoaiVatDung()
                .Where(p => p.tenLoai == loaiVatDungRequest.tenLoai);

            if (existedTenLoaiVatDung.Any())
            {
                return Results.BadRequest("Ten loai vat dung da ton tai");
            }

            LoaiVatDungRequestDto newLoaiVatDung = new LoaiVatDungRequestDto();
            newLoaiVatDung.tenLoai = loaiVatDungRequest.tenLoai;

            if (!loaiVatDungRepository.AddLoaiVatDung(newLoaiVatDung))
            {
                return Results.BadRequest("Insert loai vat dung failed!!!");
            }
            
            return Results.Ok(new ApiResponse
            {
                Success = true,
                Message = "Insert loai vat dung success!",
                Data = newLoaiVatDung
            });
        }).WithMetadata(typeof(LoaiVatDungRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        }).WithTags(groupName);
        
        // PUT
        app.MapPut("/updateLoaiVatDung", (
                [FromQuery] int id,
                [FromBody] LoaiVatDungRequestDto loaiVatDung) =>
            {
                if (!loaiVatDungRepository.UpdateLoaiVatDung(loaiVatDung, id))
                {
                    return Results.BadRequest("Update loai vat dung failed!!!");
                }

                return Results.Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Update loai vat dung success!",
                    Data = loaiVatDung
                });
            }).WithMetadata(typeof(LoaiVatDungRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        }).WithTags(groupName);
    }
}
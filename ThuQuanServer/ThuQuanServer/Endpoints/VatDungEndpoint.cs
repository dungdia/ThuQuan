using Microsoft.AspNetCore.Mvc;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Endpoints;

public static class VatDungEndpoint
{
    public static void MapVatDungEndpoints(this IEndpointRouteBuilder app)
    {
        var tagName = "Vat Dung";
        var vatDungRepository = app.ServiceProvider.GetRequiredService<IVatDungRepository>();

        // Lấy tất cả vật dụng
        app.MapGet("/VatDung", () =>
        {
            var result = vatDungRepository.GetVatDung();
            return Results.Ok(result);
        }).WithTags(tagName);

        // Lấy vật dụng theo điều kiện (props)
        app.MapPost("/VatDung/search", ([FromBody] object props) =>
        {
            var result = vatDungRepository.GetVatDungByProps(props);
            return Results.Ok(result);
        }).WithTags(tagName);

        // Thêm mới vật dụng
        app.MapPost("/VatDung", ([FromBody] VatDungRequestDto dto) =>
        {
            var success = vatDungRepository.AddVatDung(dto);
            return success ? Results.Ok("Thêm thành công") : Results.BadRequest("Thêm thất bại");
        }).WithTags(tagName);

        // Cập nhật vật dụng theo ID
        app.MapPut("/VatDung/{id:int}", ([FromBody] VatDungRequestDto dto, [FromRoute] int id) =>
        {
            var success = vatDungRepository.UpdateVatDung(dto, id);
            return success ? Results.Ok("Cập nhật thành công") : Results.BadRequest("Cập nhật thất bại");
        }).WithTags(tagName);

        // Lấy danh sách vật dụng loại sách (BOOK)
        app.MapGet("/VatDung/books", () =>
        {
            var books = vatDungRepository.GetBook();
            return Results.Ok(books);
        }).WithTags(tagName);

        // Lấy danh sách sách có phân trang và tìm kiếm
        app.MapGet("/VatDung/books-paging", (
            [FromQuery] string? search,
            [FromQuery] int page,
            [FromQuery] int pageSize) =>
        {
            var pagedResult = vatDungRepository.GetVatDungBooks(search ?? "", page, pageSize);
            return Results.Ok(pagedResult);
        }).WithTags(tagName);
    }
}

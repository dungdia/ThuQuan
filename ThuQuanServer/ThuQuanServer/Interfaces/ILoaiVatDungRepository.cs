using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface ILoaiVatDungRepository
{
    public ICollection<LoaiVatDung> GetLoaiVatDung();
    public ICollection<LoaiVatDung> GetLoaiVatDungByProps(object? values);
    public bool AddLoaiVatDung(LoaiVatDungRequestDto loaiVatDung);
    public bool UpdateLoaiVatDung(LoaiVatDungRequestDto loaiVatDung, int id);
}
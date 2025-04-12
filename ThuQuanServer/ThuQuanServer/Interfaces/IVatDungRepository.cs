using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IVatDungRepository
{
    public ICollection<VatDung> GetVatDung();
    public ICollection<VatDung> GetVatDungByProps(object? values);
    public bool AddVatDung(VatDungRequestDto vatDungRequestDto);
    public bool UpdateVatDung(VatDungRequestDto vatDungRequestDto, int id);
    
    public ICollection<VatDung> GetBook();

    public PageResultVatDungBooks<VatDung> GetVatDungBooks(string search, int page, int pageSize);

    public ICollection<VatDung> GetThreeBook(int loaiVatDung);

    public ICollection<VatDung> GetDevice();
    
    public PageResultVatDungBooks<VatDung> GetVatDungDevices(string search, int page, int pageSize);
}
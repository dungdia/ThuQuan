using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IVatDungRepository
{
    public ICollection<VatDung> GetVatDung();
    public VatDung VatDungById(int id);

    public ICollection<VatDung> GetVatDungByProps(object? values);
    public bool AddVatDung(VatDungRequestDto vatDungRequestDto);
    public bool UpdateVatDung(VatDungRequestDto vatDungRequestDto, int id);
    public bool updateListTinhTrangDaDat(int[] listId);
    public bool updateTinhTrangChuaMuon(int id);
    public bool updateTinhTrangBiHong(int id);
    public bool updateTinhTrangDaMuon(int id);
    public ICollection<VatDung> GetVaTDungBooked();
    public ICollection<VatDung> GetBook();

    public PageResultVatDungBooks<VatDung> GetVatDungBooks(string search, int page, int pageSize);

    public ICollection<VatDung> GetThreeBook(int loaiVatDung);

    public ICollection<VatDung> GetDevice();
    
    public PageResultVatDungBooks<VatDung> GetVatDungDevices(string search, int page, int pageSize);
}
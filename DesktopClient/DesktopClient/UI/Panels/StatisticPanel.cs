using System.Security.Policy;
using System.Windows.Forms.DataVisualization.Charting;
using DesktopClient.APIs;
using DesktopClient.DTO.ApiRequestDTO;
using DesktopClient.Interface;
using DesktopClient.Models;
using RestSharp;

namespace DesktopClient.UI;

public partial class StatisticPanel : UserControl
{

    public StatisticPanel()
    {
        InitializeComponent();
        string startDate = DateTime.Today.AddDays(-15).ToString("yyyy-MM-dd");
        string endDate = DateTime.Today.AddDays(15).ToString("yyyy-MM-dd");
        List<ThongKeKhoangTG> results1 = APIContext.GetMethod<ThongKeKhoangTG>($"ThongKeLichSuKhoangTG?startDate={startDate}&endDate={endDate}");
        List<ThongKeKhoangTG> results2 = APIContext.GetMethod<ThongKeKhoangTG>($"ThongKeVatDungMuon?startDate={startDate}&endDate={endDate}");

        chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        chart1.ChartAreas[0].AxisX.Interval = 1;
        chart1.Series["SoLuong"].IsValueShownAsLabel = true;
        chart1.Series["SoLuong"].XValueMember = "Ngay";
        chart1.Series["SoLuong"].YValueMembers = "SoLuong";
        chart1.DataSource = results1;
        //chart1.DataBind();

        chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        chart2.ChartAreas[0].AxisX.Interval = 1;
        chart2.Series["SoLuong"].IsValueShownAsLabel = true;
        chart2.Series["SoLuong"].XValueMember = "Ngay";
        chart2.Series["SoLuong"].YValueMembers = "SoLuong";
        chart2.DataSource = results2;
        //chart2.DataBind();

    }

    public void thongKeVao()
    {
        DateTime startDate = ngayBD1.Value;
        DateTime endDate = ngayKT1.Value;

        if (startDate > endDate)
        {
            MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc");
            return;
        }

        TimeSpan diff = endDate - startDate;
        int days = Math.Abs(diff.Days);
        if (days > 30)
        {
            MessageBox.Show("Khoảng cách tối đa 30 ngày");
            return;
        }

        string startDateString = startDate.ToString("yyyy-MM-dd");
        string endDateString = endDate.ToString("yyyy-MM-dd");
        List<ThongKeKhoangTG> results = APIContext.GetMethod<ThongKeKhoangTG>($"ThongKeLichSuKhoangTG?startDate={startDateString}&endDate={endDateString}");

        chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        chart1.ChartAreas[0].AxisX.Interval = 1;
        chart1.Series["SoLuong"].IsValueShownAsLabel = true;
        chart1.Series["SoLuong"].XValueMember = "Ngay";
        chart1.Series["SoLuong"].YValueMembers = "SoLuong";
        chart1.DataSource = results;
        //chart1.DataBind();
    }

    public void thongKeMuon()
    {
        DateTime startDate = ngayBD1.Value.Date;
        DateTime endDate = ngayKT1.Value.Date;

        if (startDate > endDate)
        {
            MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc");
            return;
        }

        TimeSpan diff = endDate - startDate;
        int days = Math.Abs(diff.Days);
        if (days > 30)
        {
            MessageBox.Show("Khoảng cách tối đa 30 ngày");
            return;
        }

        string startDateString = startDate.ToString("yyyy-MM-dd");
        string endDateString = endDate.ToString("yyyy-MM-dd");
        List<ThongKeKhoangTG> results = APIContext.GetMethod<ThongKeKhoangTG>($"ThongKeVatDungMuon?startDate={startDateString}&endDate={endDateString}");

        chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        chart2.ChartAreas[0].AxisX.Interval = 1;
        chart2.Series["SoLuong"].IsValueShownAsLabel = true;
        chart2.Series["SoLuong"].XValueMember = "Ngay";
        chart2.Series["SoLuong"].YValueMembers = "SoLuong";
        chart2.DataSource = results;
        //chart2.DataBind();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        thongKeVao();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        thongKeMuon();
    }
}
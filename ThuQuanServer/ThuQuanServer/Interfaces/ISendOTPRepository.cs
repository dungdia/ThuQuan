namespace ThuQuanServer.Interfaces;

public interface ISendOTPRepository
{
    public void sendHTMLMessage(string to, string subject, string html);
}
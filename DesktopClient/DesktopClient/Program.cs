using DesktopClient.DTO.ApiResponseDTO;
using RestSharp;

namespace DesktopClient
{
    internal static class Program
    {

        public static string ServerUrl = "http://localhost:3000/";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var loginFrame = new LoginFrame();
            Application.Run(loginFrame);
        }
    }
}
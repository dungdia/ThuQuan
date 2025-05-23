using ThuQuanServer.Interfaces;

namespace ThuQuanServer.Services;

public class PasswordHashService : IPasswordHashService
{
    private const int WorkFactor = 12;
    
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
    }

    public bool VerifyPassword(string providedPassword ,string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
    }
} 
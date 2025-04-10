using System.Text;
using Scalar.AspNetCore;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Endpoints;
using ThuQuanServer.Extension;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;
using ThuQuanServer.Repository;
using ThuQuanServer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ZstdSharp.Unsafe;
Console.OutputEncoding = System.Text.Encoding.UTF8;
var builder = WebApplication.CreateBuilder(args);

// Add db access
builder.Services.AddSingleton<DbContext>();
builder.Services.AddSingleton<ITaiKhoanRepository , TaiKhoanRepository>();
builder.Services.AddSingleton<IPasswordHashService , PasswordHashService>();
builder.Services.AddSingleton<ILoaiVatDungRepository , LoaiVatDungRepository>();
builder.Services.AddSingleton<IVatDungRepository , VatDungRepository>();
builder.Services.AddSingleton<IAuthService, AuthService>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine($"Token validated successfully");
                return Task.CompletedTask;
            }
        };
    });

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",policy => 
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Cho phép frontend truy cập
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // Cho phép gửi cookie
    });
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    var config = builder.Configuration.GetSection("OpenApi");
    options.AddDocumentTransformer((document, _, _) =>
    {
        document.Components = new OpenApiComponents();
        document.Components.SecuritySchemes = config.GetSection("SecuritySchemes").Get<Dictionary<string, OpenApiSecurityScheme>>();
        document.SecurityRequirements = config.GetSection("Security").Get<List<OpenApiSecurityRequirement>>(); 
        return Task.CompletedTask;
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    IdentityModelEventSource.ShowPII = true;
    IdentityModelEventSource.LogCompleteSecurityArtifact = true;
    app.MapOpenApi();
    
    // Add Scalar API Reference
    app.MapScalarApiReference(); 
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Use CORS middleware
app.UseCors("AllowSpecificOrigin");

// Check validation
app.UseValidationMiddleware();

// Endpoints
app.MapTaiKhoanEndpoints();
app.MapPhieuDatEndpoints();
app.MapPhieuMuonEndpoints();
app.MapPhieuTraEndpoints();
app.MapVatDungEndpoints();
app.MapLoaiVatDungEndpoint();
app.MapSecurityEndpoints();

app.Run();


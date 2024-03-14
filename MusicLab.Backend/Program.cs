using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MusicLab.Backend.Automapper;
using MusicLab.Backend.Middleware;
using MusicLab.Backend.Services;
using MusicLab.Backend.Services.Interfaces;
using MusicLab.Repository;
using MusicLab.Repository.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddDbContext<MusicLabContext>();
builder.Services.AddTransient<IAWSS3Service, AWSS3Service>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


IConfiguration configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    configuration["JWTToken:SecretKey"]
                )),

            ClockSkew = TimeSpan.Zero,
        };
    });


var app = builder.Build();

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
//app.UseMiddleware<CustomMiddleware>();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.Run();

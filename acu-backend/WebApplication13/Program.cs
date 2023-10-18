
using Castle.Core.Smtp;
using DI.Service;
using FluentAssertions.Common;
using Jose;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using WebApplication13.Security;
using WebApplication13.Service;

var builder = WebApplication.CreateBuilder(args);

// Ū���]�w��
var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var configuration = configurationBuilder.Build();




//    builder.Services.AddAuthentication(options => {
//        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    })
//    .AddJwtBearer(options =>
//    {
//        options.RequireHttpsMetadata = false;
//        options.SaveToken = true;
//        options.IncludeErrorDetails = true;
//        options.TokenValidationParameters = new TokenValidationParameters
//        {

//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Jwt:SecretKey"))),
//            ValidateIssuer = false,
//            //ValidIssuer = builder.Configuration.GetValue<string>("Jwt:Issuer"),
//            ValidateAudience = false,
//            ValidateLifetime = true,
//            ClockSkew = TimeSpan.Zero
//        };
//    });
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("User", policy => policy.RequireClaim("role", "user", "admin"));
//    options.AddPolicy("Admin", policy => policy.RequireClaim("role", "admin"));
//});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.IncludeErrorDetails = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {

        // �z�L�o���ŧi�A�N�i�H�q "roles" ���ȡA�åi�� [Authorize] �P�_����

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Jwt:SecretKey"))),
        ValidateIssuer = false,
        //ValidIssuer = builder.Configuration.GetValue<string>("Jwt:Issuer"),
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

});





builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//�s��appsrttings��local�s�u�r��
var connectionString = configuration.GetConnectionString("local");
//�إߪA�Ȯɦp�ݨ�L�̪ۨA��
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));
builder.Services.AddSingleton<UserDBService>();
builder.Services.AddSingleton<MailDBService>();
builder.Services.AddSingleton<JwtService>();
builder.Services.AddSingleton<ForgetPwdDBService>();
builder.Services.AddSingleton<Eye_questionDBService>();
builder.Services.AddSingleton<D_recordDBService>();
builder.Services.AddSingleton<Acupuncture_PointsDBService>();
builder.Services.AddSingleton<Chinese_MedicineDBService>();
builder.Services.AddSingleton<R_RecordDBService>();
builder.Services.AddSingleton<CM_outputDBService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.MapControllers();

app.Run();

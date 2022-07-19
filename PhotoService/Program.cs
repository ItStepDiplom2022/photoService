using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PhotoService.BLL;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Services;
using PhotoService.DAL.Interfaces;
using PhotoService.DAL.Repositories;
using PhotoService.Renderes;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperSettings());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IJwtService,JwtService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddSingleton<IHtmlRenderer, HtmlRenderer>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).
            AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtKey").ToString())),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(builder => builder.WithOrigins("https://localhost:44414")
            .AllowAnyHeader()
            .AllowAnyMethod()
        )
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

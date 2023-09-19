using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiServiceRepositorySecurityDatabase.Models;
using WebApiServiceRepositorySecurityDatabase.Repositories;
using WebApiServiceRepositorySecurityDatabase.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SDbContext")));

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IServices, Services>();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = "myUsers",
        ValidIssuer = "mySystem",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"))
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapControllers();

app.Run();

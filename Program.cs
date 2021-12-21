using Files.Models;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = builder.Configuration;
// builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(configuration.GetConnectionString("FilesConnection")));
// builder.Services.AddScoped<DatabaseContext,DatabaseContext>();



builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("FilesConnection")));
builder.Services.AddScoped<ApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
builder.Services.AddScoped<ApplicationDbContext, ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
     app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using VandecoStore.API.Configurations;
using VandecoStore.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureWebApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ECommerceContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Configuration
     .SetBasePath(builder.Environment.ContentRootPath)
     .AddJsonFile("appsettings.json", true, true)
     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
     .AddEnvironmentVariables();

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

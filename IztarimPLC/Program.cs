using ModbusPlcProject.Models;
using ModbusPlcProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Modbus servisi için ekledim D.K. 15.04.2025
builder.Services.AddSingleton<ModbusService>();

builder.Services.Configure<ModbusConfig>(
    builder.Configuration.GetSection("ModbusSettings"));

builder.Services.AddSingleton<ModbusService>();
builder.Services.AddRazorPages();

//**---------------**//////

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

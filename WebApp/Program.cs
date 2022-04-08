using BL.GlobalParameters;
using BL.SMB;
using DAL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WebApp.Data;
using WebApp.State;

var builder = WebApplication.CreateBuilder(args);
IUnitOfWork unitOfWork = new UnitOfWork("192.168.2.115:6379");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<ISmbServices,SmbServices>();
builder.Services.AddSingleton<IGlobalParameters>(new GlobalParameters(unitOfWork));
builder.Services.AddSingleton<FileManagerState>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

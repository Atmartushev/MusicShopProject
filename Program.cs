﻿using Microsoft.EntityFrameworkCore;
using MusicShopProject.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MusicShopProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MusicShopProjectContext") ?? throw new InvalidOperationException("Connection string 'MusicShopProjectContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "adminPage",
    pattern: "AdminPage",
    defaults: new { controller = "Songs", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

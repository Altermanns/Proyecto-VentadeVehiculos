﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_VentadeVehiculos.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Proyecto_VentadeVehiculosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proyecto_VentadeVehiculosContext") ?? throw new InvalidOperationException("Connection string 'Proyecto_VentadeVehiculosContext' not found.")));

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

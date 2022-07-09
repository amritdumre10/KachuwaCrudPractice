using DapperPractice.Services;
using Kachuwa.Core.Extensions;
using Kachuwa.Data;
using Kachuwa.Data.Crud;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IDbConnection>((sp) =>
//            new SqlConnection(Configuration)
//        );

#region Kachuwa Setup

    builder.Services.AddSingleton(Configuration);
    var serviceProvider = builder.Services.BuildServiceProvider();
    IDatabaseFactory dbFactory = DatabaseFactories.SetFactory(Dialect.SQLServer, serviceProvider);
    builder.Services.AddSingleton(dbFactory);

#endregion

#region Service Registrar

    builder.Services.AddSingleton<IStudentService, StudentService>();

#endregion

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
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();

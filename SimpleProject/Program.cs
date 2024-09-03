using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleProject.Controllers;
using SimpleProject.Data;
using SimpleProject.Models.Services.Implementations;
using SimpleProject.Models.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var greeting = builder.Configuration["key"];
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();


//create one instance for the project lifecycle
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IFileService, FileService>();

builder.Services.AddDbContext<AppDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<ICategoryService, CategoryService>();



// create new instance for the same request 
//builder.Services.AddScoped<IProductService, ProductService>();


// create new isntance for each request even the same request with Threads

//builder.Services.AddTransient<IProductService, ProductService>();



var app = builder.Build();


//app.MapGet("/", () => greeting + "hi");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

}

else
{
    app.UseExceptionHandler("/home/error");//production
    app.UseHsts();//security for production



}




app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
// always home/index
//app.MapDefaultControllerRoute();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "product/{*index}",
//    defaults: new { Controller = "Product", action = "Index" }

//    );


app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{Id?}");// = defaultRoute


app.Run();

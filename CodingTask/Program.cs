using CodingTask;
using CodingTask.DataCon;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<NumberTextUtility>();  //register service with the name NumberTextUtility

builder.Services.AddDbContext<LogNumberDbContext>(options =>   
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));  //register service with the name LogNumberDbContext

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
    pattern: "{controller=LogNumberModels}/{action=Index}/{id?}");

app.Run();

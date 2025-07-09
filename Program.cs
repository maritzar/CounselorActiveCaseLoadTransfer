// Add the necessary using directive for the SQL Server provider  
using Microsoft.EntityFrameworkCore.SqlServer;

// File: Program.cs
using Microsoft.EntityFrameworkCore;
using Counselor_Active_CaseLoad_Transfer.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ✅ Register DbContext with connection string
builder.Services.AddDbContext<AdvocateDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdvocateConnection")));

builder.Services.AddDbContext<AdvocateUsersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdvocateUserConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CaseProgram}/{action=UpdateForm}/{id?}");

app.Run();

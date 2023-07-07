using Microsoft.EntityFrameworkCore;
using StudentDeptMemoCRUD.Models;
using StudentDeptMemoCRUD.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IStudentRepo, StudentRepo>();
builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<Context>(a =>
{
    a.UseSqlServer(builder.Configuration.GetConnectionString("DeptStuDbConnection"));
    a.UseLazyLoadingProxies();
},ServiceLifetime.Transient);

//builder.Services.AddAuthentication(auth)

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
    pattern: "{controller=Home}/{action=CIndex}/{id?}");

app.Run();

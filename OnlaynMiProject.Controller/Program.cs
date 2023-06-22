using OnlaynMiProject.BusinessLayer.Abstract;
using OnlaynMiProject.BusinessLayer.Concrete;
using OnlaynMiProject.DataAccessLayer.Abstract;
using OnlaynMiProject.DataAccessLayer.Concrete;
using OnlaynMiProject.DataAccessLayer.EntityFramework;
using OnlaynMiProject.EntityLayer.Concrete;
using OnlaynMiProject.Controller.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddScoped<IGroupService, GroupManager>();
builder.Services.AddScoped<IGroupDal, EfGroupDal>();

builder.Services.AddScoped<IEventService, EventManager>();
builder.Services.AddScoped<IEventDal, EfEventDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Login");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

using TourBreeze;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TourBreeze.Data;
using TourBreeze.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TourBreezeContextConnection") ?? throw new InvalidOperationException("Connection string 'TourBreezeContextConnection' not found.");

builder.Services.AddDbContext<TourBreezeContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<TourBreezeUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TourBreezeContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

ConfigurationService.RagistrationDependancies(builder.Services, builder.Configuration);

//builder.Services.AddDbContext<ApplicationDbContext>(option =>
//{
//    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
//});
//builder.Services.AddScoped<IProductRepo,ProductRepo>();

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
name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();

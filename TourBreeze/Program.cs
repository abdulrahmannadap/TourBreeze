using Microsoft.EntityFrameworkCore;
using TourBreeze;
using TourBreeze.Server.Data;
using TourBreeze.Server.Service.Implimentation;
using TourBreeze.Server.Service.Interface;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});
builder.Services.AddScoped<IProductRepo,ProductRepo>();
builder.Services.AddScoped<ICountriesRepo,CountriesRepo>();
//ConfigurationService.RagistrationDependancies(builder.Services, builder.Configuration);

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
//app.MapControllerRoute(
//name: "areas",
//            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "areas",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();


using Library;
using LibraryData;
using LibraryServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//If you are having problems, look into more detail of services.AddSingleton(Configuration)
builder.Services.AddScoped<ILibraryAsset, LibraryAssetService>();
builder.Services.AddScoped<ICheckout, CheckoutService>();

builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("LibraryConnection")
));


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

using MicrosWPSShopping.Web.Services;
using MicrosWPSShopping.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<IProductService, ProductServices>(c=>
c.BaseAddress = new Uri(
    builder.Configuration["ServiceUrls:ProductApi"]
    )
);
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

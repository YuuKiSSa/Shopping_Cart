using Microsoft.EntityFrameworkCore;
using Shopping_Cart.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDbContext>(options => {
    var conn_str = builder.Configuration.GetConnectionString("conn_string");
    options.UseLazyLoadingProxies().UseSqlServer(conn_str);
});

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

InitDB(app.Services);

app.Run();

void InitDB(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    MyDbContext db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}
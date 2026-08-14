using Microsoft.EntityFrameworkCore;
using Myinventory.Models;
using Microsoft.Extensions.DependencyInjection;
using Myinventory.Data;
using Myinventory.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CategoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CategoryDbContext") ?? throw new InvalidOperationException("Connection string 'CategoryDbContext' not found.")));
builder.Services.AddDbContext<InventoryLogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryLogDbContext") ?? throw new InvalidOperationException("Connection string 'InventoryLogDbContext' not found.")));
builder.Services.AddDbContext<LocationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocationDbContext") ?? throw new InvalidOperationException("Connection string 'LocationDbContext' not found.")));
builder.Services.AddDbContext<OrderItemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderItemDbContext") ?? throw new InvalidOperationException("Connection string 'OrderItemDbContext' not found.")));
builder.Services.AddDbContext<OedersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OedersDbContext") ?? throw new InvalidOperationException("Connection string 'OedersDbContext' not found.")));
builder.Services.AddDbContext<ProductsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsDbContext") ?? throw new InvalidOperationException("Connection string 'ProductsDbContext' not found.")));
builder.Services.AddDbContext<StockDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StockDbContext") ?? throw new InvalidOperationException("Connection string 'StockDbContext' not found.")));
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbContext") ?? throw new InvalidOperationException("Connection string 'UserDbContext' not found.")));
builder.Services.AddDbContext<MyinventoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyinventoryContext") ?? throw new InvalidOperationException("Connection string 'MyinventoryContext' not found.")));

// Add services to the container.
builder.Services.AddDbContext<MyinventoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

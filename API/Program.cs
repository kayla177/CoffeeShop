using API.Services;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 3. let the application recognize the api controller
builder.Services.AddControllers();

// 1. register the context
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 4. Register the coffee shop service, so the app at run time can know to access the service
builder.Services.AddScoped<ICoffeeShopService, CoffeeShopService>();

var app = builder.Build();

// 3.
app.MapControllers();

app.Run();

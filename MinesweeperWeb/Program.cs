using Microsoft.EntityFrameworkCore;
using Minesweeper.BLL.Services;
using Minesweeper.BLL.Services.Interface;
using Minesweeper.DAL.Context;
using Minesweeper.DAL.UnitOfWork;
using Minesweeper.DAL.UnitOfWork.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Додаємо MVC з Views (підтримка UI)
builder.Services.AddControllersWithViews();

// Реєструємо DbContext з PostgreSQL
builder.Services.AddDbContext<MinesweeperDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI для UnitOfWork та сервісів бізнес-логіки
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGameResultService, GameResultService>();
builder.Services.AddScoped<IGameService, GameService>();


// Swagger для API документації (опційно)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Маршрут для MVC контролерів + Views
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Маршрут для API контролерів
app.MapControllers();



app.MapGet("/", context =>
{
    context.Response.Redirect("/Home/Index");
    return Task.CompletedTask;
});



app.Run();
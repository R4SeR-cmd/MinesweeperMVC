using Microsoft.EntityFrameworkCore;
using Minesweeper.BLL.Services;
using Minesweeper.BLL.Services.Interface;
using Minesweeper.DAL.Context;
using Minesweeper.DAL.UnitOfWork;
using Minesweeper.DAL.UnitOfWork.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// ������ MVC � Views (�������� UI)
builder.Services.AddControllersWithViews();

// �������� DbContext � PostgreSQL
builder.Services.AddDbContext<MinesweeperDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI ��� UnitOfWork �� ������ �����-�����
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGameResultService, GameResultService>();
builder.Services.AddScoped<IGameService, GameService>();


// Swagger ��� API ������������ (�������)
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

// ������� ��� MVC ���������� + Views
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ������� ��� API ����������
app.MapControllers();



app.MapGet("/", context =>
{
    context.Response.Redirect("/Home/Index");
    return Task.CompletedTask;
});



app.Run();
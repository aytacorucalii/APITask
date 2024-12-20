using Microsoft.EntityFrameworkCore;
using WorksShop.BL.Services.Abstractions;
using WorksShop.BL.Services.Implementations;
using WorksShop.DAL.DAL;
using WorksShop.DAL.Repositories.Abstractions;
using WorksShop.DAL.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<IWorkShopRepository, WorkShopRepository>();
builder.Services.AddScoped<IWorkShopService, WorkService>();
builder.Services.AddScoped<IParticipantRepository,ParticipantRepository>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"))
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

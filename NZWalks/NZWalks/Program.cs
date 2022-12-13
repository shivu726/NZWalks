using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WalkDbContext>(options => 
{ 
    options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnection")); 
});

builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IWalksRepository, WalksRepository>();
builder.Services.AddScoped<IWalkDifficultyRepository, WalkDifficultyRepository>();

// Add automapper..

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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

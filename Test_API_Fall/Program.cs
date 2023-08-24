using Microsoft.EntityFrameworkCore;
using Test_API.Data;
using Test_API_Fall.Respository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnect")));
builder.Services.AddScoped<IGenreRes, GenreRes>();
builder.Services.AddScoped<IMovieRes, MovieRes>();
builder.Services.AddScoped<IActorRes, ActorRes>();
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

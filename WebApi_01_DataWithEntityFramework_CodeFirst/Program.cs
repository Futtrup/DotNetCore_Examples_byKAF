using Microsoft.EntityFrameworkCore;
using WebApi_01_DataWithEntityFramework_CodeFirst.Data;
using WebApi_01_DataWithEntityFramework_CodeFirst.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine("Add a db context as a service to be used with dependency injection");
builder.Services.AddDbContext<PersonDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("conString")), ServiceLifetime.Singleton);

Console.WriteLine("Use a hosted service to ensure that data exists");
builder.Services.AddHostedService<DataService>();

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

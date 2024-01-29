using interfacesLib;
using servicesLib;
using FileService;
using Extensions;
using LogServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPizzaShopServices,PizzaShopServices>();
builder.Services.AddTransient<IOrderPizza,OrderPizzaService>();
builder.Services.AddScoped<IWorkers,WorkersService>();
builder.Services.AddSingleton<Ifile,myFile>();
builder.Services.AddSingleton<Ilog,myLog>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseActionLog();

app.Run();

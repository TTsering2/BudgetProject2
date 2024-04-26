using Microsoft.EntityFrameworkCore;
using Budgets.Data;
using Budgets.Services;

using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

using Budgets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;//////
using BudgetProject2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddDbContext<BudgetsDbContext>(options => 
options.UseSqlServer(builder.Configuration["dbconnectionstr"]));

// Adding Repo class for Income
builder.Services.AddScoped<IIncomeRepository, IncomeRepo>();
builder.Services.AddScoped<IBudgetService, IncomeService>();

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockServices, StockServices>();
builder.Services.AddControllers();


// Add budget repository and service
builder.Services.AddScoped<IRepository<Expense>, ExpenseRepo>();//////From Budgets.Data

builder.Services.AddScoped<ExpensesService>();



// Adding Repo class for Income
builder.Services.AddScoped<IIncomeRepository, IncomeRepo>();
builder.Services.AddScoped<IBudgetService, IncomeService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//TODO: REMOVE ALL OF THIS
// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.MapControllers();
app.Run();





// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// //TODO: REMOVE ALL OF THIS
// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

// app.Run();

// //TODO : REMOVE ALL OF THIS
// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
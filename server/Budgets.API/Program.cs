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



builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserValidator, ValidatorUsers>();
builder.Services.AddControllers();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();
app.Run();


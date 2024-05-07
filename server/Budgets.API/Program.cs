using Microsoft.EntityFrameworkCore;
using Budgets.Data;
using Budgets.Services;
using Budgets.Validators;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Budgets.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BudgetsDbContext>(options => options.UseSqlServer(builder.Configuration["dbconnectionstr"]));

// Add income repo and service
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();

// Add stock repository and service
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockServices, StockServices>();

//Add expense repository and service
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();

// Add user repository and service
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserValidator, ValidatorUsers>();

<<<<<<< HEAD
//Add Budget Report service
builder.Services.AddScoped<IBudgetReportService, BudgetReportService>();


=======
>>>>>>> f97f61f7a762e0693a36525266f1e90529a7db1f
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
   
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.MapControllers();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


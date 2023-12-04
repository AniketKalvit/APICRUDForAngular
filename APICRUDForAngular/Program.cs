using APICRUDForAngular.Data;
using APICRUDForAngular.Repositories;
using APICRUDForAngular.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddDefaultPolicy(
                builder => builder.WithOrigins("http://localhost:4200", "*").AllowAnyMethod().
                AllowAnyHeader().AllowAnyOrigin()));


var constr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(op =>op.UseSqlServer(constr));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();
app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();

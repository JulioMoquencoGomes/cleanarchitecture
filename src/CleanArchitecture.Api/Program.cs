using Npgsql;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.UseCases;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.Infrastructure.Data;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("CleanArchitecture.Api")
    )
);

// Dependency Injection
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<BookService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("Front", policy =>
    {
        policy.WithOrigins("https://localhost:8080", "http://localhost:8080") // Origens permitidas
              .AllowAnyHeader()                                                // Headers como Authorization
              .AllowAnyMethod();                                               // Métodos como GET, POST, PUT
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();


app.UseSwagger();
app.UseSwaggerUI();
app.MapScalarApiReference();

app.UseCors("Front");
//app.UseAuthorization();
app.MapControllers();

app.Run();
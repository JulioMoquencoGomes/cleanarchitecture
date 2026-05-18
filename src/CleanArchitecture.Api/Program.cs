using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.UseCases;
using CleanArchitecture.Infrastructure.Repositories;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Dependency Injection
builder.Services.AddScoped<IBookRepository, InMemoryBookRepository>();
builder.Services.AddScoped<BookService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();


app.UseSwagger();
app.UseSwaggerUI();
app.MapScalarApiReference();

app.MapControllers();

app.Run();
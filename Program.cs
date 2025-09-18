using Microsoft.EntityFrameworkCore;
using System;
using Task_Tracker_V4.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// 1. DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HomeLocalDbConnection")));


// 2. Repositories


// 3. Services


// 4. Controllers
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();

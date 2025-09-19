using Microsoft.EntityFrameworkCore;
using System;
using Task_Tracker_V4.Data;
using Task_Tracker_V4.Repositories;
using Task_Tracker_V4.Repositories.Interfaces;
using Task_Tracker_V4.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// 1. DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HomeLocalDbConnection")));


// 2. Repositories
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
//builder.Services.AddScoped<IStatusRepository, StatusRepository>();
//builder.Services.AddScoped<ILoginRepository, LoginRepository>();
//builder.Services.AddScoped<IRoleRepository, RoleRepository>();


// 3. Services
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<NotificationService>();
//builder.Services.AddScoped<StatusService>();

builder.Services.AddScoped<AccountRepository>();



// 4. Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 5. React App Using CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

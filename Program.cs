using Microsoft.EntityFrameworkCore;
using Task_Tracker_V4.Data;
using Task_Tracker_V4.Repositories;
using Task_Tracker_V4.Repositories.Interfaces;
using Task_Tracker_V4.Services;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------
// 1. DbContext
// ---------------------------
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NewDatabaseHomeLocal")));

// ---------------------------
// 2. Repositories
// ---------------------------
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
// builder.Services.AddScoped<IStatusRepository, StatusRepository>();
// builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// ---------------------------
// 3. Services
// ---------------------------
builder.Services.AddScoped<RoleMapper>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<NotificationService>();
// builder.Services.AddScoped<StatusService>();

// ---------------------------
// 4. Controllers
// ---------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------------------------
// 5. CORS
// ---------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5173",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // React dev server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// ---------------------------
// 6. Middleware
// ---------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ Apply correct CORS policy BEFORE Authorization
app.UseCors("AllowLocalhost5173");

app.UseAuthorization();

app.MapControllers();

app.Run();

/**using Microsoft.EntityFrameworkCore;
using System;
using Task_Tracker_V4.Data;
using Task_Tracker_V4.Repositories;
using Task_Tracker_V4.Repositories.Interfaces;
using Task_Tracker_V4.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// 1. DbContext
// HomeLocalDbConnection - AspMonsterConnection
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NewDatabaseHomeLocal")));


// 2. Repositories
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
//builder.Services.AddScoped<IStatusRepository, StatusRepository>();
//builder.Services.AddScoped<ILoginRepository, LoginRepository>();
//builder.Services.AddScoped<IRoleRepository, RoleRepository>();



// 3. Services
builder.Services.AddScoped<RoleMapper>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<NotificationService>();
//builder.Services.AddScoped<StatusService>();




// 4. Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 5. React App Using CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        policy => policy
//            .AllowAnyOrigin()
//            .AllowAnyHeader()
//            .AllowAnyMethod());
//});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5173",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
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

app.Run();**/

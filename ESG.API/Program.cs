using ESG.API;
using ESG.API.Middleware;
using ESG.Infrastructure;
using Serilog.Formatting.Json;
using Serilog;
using Serilog.Exceptions;
using ESG.Application;
using ESG.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
});

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddAPIDependancies();
builder.Services.AddApplication();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .WriteTo.Console()
    .WriteTo.File("D:\\EsgLog\\log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();
//services cors
builder.Services.AddCors(p => p.AddPolicy("esgapp", builder =>
{
    builder.WithOrigins("*")
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
var app = builder.Build();
 using(var scope = app.Services.CreateScope())
{
    var dbContext= scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    //await dbContext.Database.MigrateAsync();
}
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();



//app.UseAuthorization();
app.UseCors("esgapp");
app.MapControllers();
app.UseExceptionHandler(opt => { });
app.Run();

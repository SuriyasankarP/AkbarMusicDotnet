global using FinalProject.Models.Playlist;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;

var builder = WebApplication.CreateBuilder(args);
var policyName = "_myAllowSpecificOrigins";
var connectionString = "Server=localhost;database=finalproject;user=root;password=12345678;";
builder.Services.AddDbContext<FinalProjectContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 31))));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder

                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                            
                            
                      });
});
// Add services to the container.

builder.Services.AddControllers();
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
app.UseCors(policyName);

app.UseAuthorization();

app.MapControllers();

app.Run();

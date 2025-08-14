using Microsoft.EntityFrameworkCore;
using API_codefirst.Models;
using API_codefirst.Service;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
.AddNewtonsoftJson(opt => { opt.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore; });
builder.Services.AddDbContext<CodeContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<AuthorService>();
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

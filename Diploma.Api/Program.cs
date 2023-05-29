using Diploma.BusinessLogic;
using Diploma.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Database
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DiplomaConnection"));
});

//Dependency resolver
builder.Services.AddApiDependencies();

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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

app.UseCors(policy =>
policy.WithOrigins("https://localhost:7233", "http://localhost:5224", "https://localhost:7200", "http://localhost:5087") 
.AllowAnyMethod()
.WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Holidays.API.Configurations;
using Holidays.Application.Mapper;
using Holidays.Infrastructure.Data.Options;
using Holidays.Infrastructure.ExternalService.Options;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencyInjectionConfiguration();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));

builder.Services.AddCors(
    options => options.AddPolicy(
        name: "Development",
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
        }));

// ConnectionString
builder.Services.Configure<ConnectionStringOptions>(
    builder.Configuration.GetSection(ConnectionStringOptions.ConnectionString));

// External API Url
builder.Services.Configure<ExternalServiceOptions>(
    builder.Configuration.GetSection(ExternalServiceOptions.ExternalService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

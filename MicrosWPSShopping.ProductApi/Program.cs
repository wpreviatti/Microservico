using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MicrosWPSShopping.ProductApi.Config;
using MicrosWPSShopping.ProductApi.Model.Context;
using MicrosWPSShopping.ProductApi.Repository;
using MicrosWPSShopping.ProductApi.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = builder.Configuration["SqlConnection:ConnectionString"];

builder.Services.AddDbContext<SQLContext>(options => options.UseSqlServer(connection));
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductRepository, ProductRepository>();
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

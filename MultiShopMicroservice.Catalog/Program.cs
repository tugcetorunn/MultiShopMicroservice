using Microsoft.Extensions.Options;
using MultiShopMicroservice.Catalog.Services.CategoryServices;
using MultiShopMicroservice.Catalog.Services.ProductDetailServices;
using MultiShopMicroservice.Catalog.Services.ProductImageServices;
using MultiShopMicroservice.Catalog.Services.ProductServices;
using MultiShopMicroservice.Catalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// uygulama �al��t�r�ld���nda constructor larda �a��rd���m�z interface lerin nesne �rneklerini olu�turmas� i�in;
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

// automapper entegrasyonu i�in;
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// appsettings teki db ba�lant�s� bilgilerinin oldu�u objeyi configure etmek i�in;
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

// databaseSettings teki value lara ula�mak i�in connStr vb.;
builder.Services.AddScoped<IDatabaseSettings>(sp => // serviceProvider
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value; 
});

// addscoped, addtransient ve addsingleton farklar� ne?

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

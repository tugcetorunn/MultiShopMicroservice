using MultiShopMicroservice.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShopMicroservice.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShopMicroservice.Order.Application.Interfaces;
using MultiShopMicroservice.Order.Application.Services;
using MultiShopMicroservice.Order.Persistence.Context;
using MultiShopMicroservice.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// mediator registiration ý direk burada yapmayacaðýz (single responsibility).
// app registiration iþlemleri için extension metod;
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderContext>();

#region CQRSRegistiration
builder.Services.AddScoped<GetAddressesQueryHandler>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<DeleteAddressCommandHandler>();

builder.Services.AddScoped<GetOrderDetailsQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<DeleteOrderDetailCommandHandler>();
#endregion

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



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

using Microsoft.EntityFrameworkCore;
using Orders_management;
using Orders_management.Repository;
using Orders_management.Services;
using Orders_management.Services.Implementation;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddJsonOptions(option =>
 {
     option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
 });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrdersManagementContext>(options => options.UseCosmos(
        connectionString: builder.Configuration.GetConnectionString("CosmosDB"),
        databaseName: "Order"
    ));

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IServiceBusMessageHandler, ServiceBusMessageHandler>();
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
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

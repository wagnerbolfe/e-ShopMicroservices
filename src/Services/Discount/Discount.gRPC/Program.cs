using Discount.gRPC.Extensions;
using Discount.gRPC.Repositories;
using Discount.gRPC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<DiscountService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.MigrateDatabase<Program>();

app.Run();

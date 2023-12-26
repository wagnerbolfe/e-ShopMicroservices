using Discount.gRPC.Extensions;
using Discount.gRPC.Repositories;
using Discount.gRPC.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddGrpc();

builder.WebHost.ConfigureKestrel(opt =>
{
    opt.ListenAnyIP(80, o => o.Protocols = HttpProtocols.Http2);
    opt.ListenAnyIP(5003, o => o.Protocols = HttpProtocols.Http2);
    opt.ListenAnyIP(8003, o => o.Protocols = HttpProtocols.Http2);
});

var app = builder.Build();

app.MapGrpcService<DiscountService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.MigrateDatabase<Program>();

app.Run();

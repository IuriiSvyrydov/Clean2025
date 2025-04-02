using Clean2025.Application;
using Clean2025.Infrastrucrure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastrucrure(builder.Configuration);
builder.Services.RegisterApplicationServices();
builder.Services.AddCors();
builder.AddServiceDefaults();
var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference();

app.UseCors(x=>x.AllowAnyHeader()
.AllowCredentials()
.AllowAnyMethod()
.SetIsOriginAllowed(t=>true)
.AllowAnyOrigin());
app.MapDefaultEndpoints();
app.Run();




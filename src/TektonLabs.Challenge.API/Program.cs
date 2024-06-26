using TektonLabs.Challenge.API.Extensions;
using TektonLabs.Challenge.Application;
using TektonLabs.Challenge.Infraestructure;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseLogging(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigration();
app.SeedData();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();


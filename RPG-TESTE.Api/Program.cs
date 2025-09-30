using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using RPG_TESTE.Domain.Entity;
using RPG_TESTE.Infrastructure.Database;
using RPG_TESTE.Infrastructure.Migrations;
using System;
using RPG_TESTE.Application;
using RPG_TESTE.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();    
builder.Services.AddInfrastructureServices(builder.Configuration);


builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddPostgres() 
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("DefaultConnection"))
        .ScanIn(typeof(RPG_Migration).Assembly).For.Migrations() 
    )
    .AddLogging(lb => lb.AddFluentMigratorConsole());





var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

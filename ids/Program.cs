using IdentityServer4.Models;
using IdentityServer4.Test;
using ids;
using ids.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString,
                    sqlOptions => sqlOptions.MigrationsAssembly("ids")));

builder.Services.AddIdentityServer()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = builder =>
            builder.UseSqlite(connectionString, opt => opt.MigrationsAssembly("ids"));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = builder =>
            builder.UseSqlite(connectionString, opt => opt.MigrationsAssembly("ids"));
    })
    .AddTestUsers(Config.Users)
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseIdentityServer();

app.Run();

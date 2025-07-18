﻿using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SteamDatabase;

[assembly: FunctionsStartup(typeof(SteamNews.FunctionApp.Startup))]
namespace SteamNews.FunctionApp;
public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddLogging();
        builder.Services.AddDbContext<SteamNewsDatabaseContext>(options => 
            options.UseSqlServer(Environment.GetEnvironmentVariable("SteamNewsDbConnectionString")!));
        
        builder.Services.AddSingleton<GetAndSendSteamNews>();
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces;
using MyApp.Domain.Repositories;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Repositories;
using MyApp.Infrastructure.Services;

namespace MyApp.Infrastructure;

public static class DependencyInjections
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<MyAppDbContext>(options =>
            options.UseSqlServer("name=ConnectionStrings:MyAppDatabase",
            x => x.MigrationsAssembly("MyApp.Infrastructure")));

        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ILoggerService, LoggerService>();
    }

    public static void MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<MyAppDbContext>>();
        
        using (var dbContext = new MyAppDbContext(dbContextOptions))
        {
            dbContext.Database.Migrate();
        }
    }
}
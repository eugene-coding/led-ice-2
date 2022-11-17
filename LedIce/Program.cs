using LedIce.Data;
using LedIce.Settings.Mail;

using Microsoft.EntityFrameworkCore;

namespace LedIce;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        builder.Services.AddLocalization();

        ConfigureDbContext(builder);

        builder.Services.AddScoped<MailService>();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            SeedData.Initialize(services);
        }

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }

    private static void ConfigureDbContext(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<Context>(options =>
        {
            var connectionString = builder.Configuration["ConnectionString"];
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            options.UseMySql(connectionString, serverVersion, options =>
            {
                options.EnableRetryOnFailure();
            });

            if (builder.Environment.IsDevelopment())
            {
                options.EnableDetailedErrors()
                .EnableSensitiveDataLogging();
            }
        });
    }
}

using Asp.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TranslationManagement.Api;

using System.IO;
using Data;
using Data.Management;
using External.ThirdParty.Services;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Notifications;
using TranslationManagement.Payments;

public class Startup
{
    const string ProductionSpecificOrigins = nameof(ProductionSpecificOrigins);
    const string DevelopmentSpecificOrigins = nameof(DevelopmentSpecificOrigins);

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {   
            options.AddPolicy(ProductionSpecificOrigins, policy  =>
            {
                policy.WithOrigins("<domain>");
            });
            options.AddPolicy(DevelopmentSpecificOrigins, policy  =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();         
            });
        });
        services.AddControllers();
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TranslationManagement.Api", Version = "v1" });
        });
        services.AddAutoMapper(GetType().Assembly);
        services.AddDb("Data Source=TranslationAppDatabase.db");
        services.AddDbIdentity("Data Source=TranslationIdentityDatabase.db");
        services.AddTransient<IPriceCalculator, PriceCalculator>();
        services.AddTransient<INotificationService, UnreliableNotificationService>();
        services.AddTransient<INotification<JobRecrod>, JobNotification>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors(env.IsProduction() ? ProductionSpecificOrigins : DevelopmentSpecificOrigins);
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TranslationManagement.Api v1"));
        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
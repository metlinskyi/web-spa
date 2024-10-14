namespace TranslationManagement.Api;

using Files;
using Asp.Versioning;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Middleware;
using Payments;
using TranslationManagement.Notifications;

public class Startup(IConfiguration configuration)
{
    const string ProductionSpecificOrigins = nameof(ProductionSpecificOrigins);
    const string DevelopmentSpecificOrigins = nameof(DevelopmentSpecificOrigins);

    public IConfiguration Configuration => configuration;

    public void ConfigureServices(IServiceCollection services)
    {        
        services
                .AddLogging(config => config.AddConsole())
                .AddDb("Data Source=TranslationAppDatabase.db")
                .AddDbIdentity("Data Source=TranslationIdentityDatabase.db")
                .AddAutoMapper(GetType().Assembly)
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Startup>())
                .AddPayments()
                .AddMiddleware()
                .AddFileServices()
                .AddNotifications()
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TranslationManagement.Api", Version = "v1" });
                })
                .AddCors(options =>
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
                })
                ;

        services.AddControllers();
        services.AddApiVersioning(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1);
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ApiVersionReader = ApiVersionReader.Combine(
                        new UrlSegmentApiVersionReader(),
                        new HeaderApiVersionReader("X-Api-Version"));
                })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'V";
                    options.SubstituteApiVersionInUrl = true;
                });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {       
        app
            .UseCors(env.IsProduction() ? ProductionSpecificOrigins : DevelopmentSpecificOrigins)
            .UseDefaultFiles()
            .UseStaticFiles()
            .UseRouting()
            .UseAuthorization()
            .UseEndpoints(endpoints => endpoints.MapControllers())
            .UseHealthChecks("/HealthCheck")
            .UseSwagger()
            .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TranslationManagement.Api v1"))
            ;

        app.ApplicationServices.GetRequiredService<IWarmUp>();
    }
}
using TranslationManagement.Middleware;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

internal class HealthCheck(
    ILogger<HealthCheck> logger
    ) : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, 
        CancellationToken cancellationToken = default)
    {
        var result = true;
        if (result)
        {
            logger.LogInformation("We are healthy!");
            return Task.FromResult(HealthCheckResult.Healthy("We are healthy!"));
        }
        
        logger.LogWarning("We are sick!");
        return Task.FromResult(HealthCheckResult.Unhealthy("We are sick!"));
    }
}
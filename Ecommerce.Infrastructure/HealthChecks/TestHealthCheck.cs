using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Interface.HealthChecks;

public class TestHealthCheck(ILogger<TestHealthCheck> logger) : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        logger.LogError(
            "Test Health Check failed!"
        );

        return Task.FromResult(
            HealthCheckResult.Unhealthy("Test health check failed")
        );
    }
}
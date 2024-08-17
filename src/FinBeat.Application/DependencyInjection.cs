using FinBeat.Application.Services.Logging;
using FinBeat.Application.Services.SortedData;
using Microsoft.Extensions.DependencyInjection;

namespace FinBeat.Application;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IRequestResponseLogService, RequestResponseLogService>();
        services.AddScoped<ISortedDataService, SortedDataService>();

        return services;
    }
}

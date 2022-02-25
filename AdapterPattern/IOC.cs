using LegacyService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewDomain;

namespace AdapterPattern;
public static class IOC
{
    public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IFlightRequestProcessor, FlightRequestProcessor>();
                    services.AddTransient<IFlightService, FlightServiceAdapter>();
                    services.AddTransient<IFlightLegacyService, FlightLegacyService>();
                });

}


using AdapterPattern;
using Microsoft.Extensions.DependencyInjection;
using NewDomain;

var host = IOC.CreateHostBuilder(args).Build();
var flightRequestProcessor = host.Services.GetService<IFlightRequestProcessor>();

flightRequestProcessor.BookFlight(Guid.NewGuid());
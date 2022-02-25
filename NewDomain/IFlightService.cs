using NewDomain.Model;
namespace NewDomain;

public interface IFlightService
{
    FlightDetails GetFlightDetails(Guid flightNumber);
}


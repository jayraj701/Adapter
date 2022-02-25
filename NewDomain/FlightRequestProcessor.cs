namespace NewDomain;
public interface IFlightRequestProcessor
{
    public void BookFlight(Guid flightId);
}

public class FlightRequestProcessor : IFlightRequestProcessor
{
    private readonly IFlightService _flightService;
    public FlightRequestProcessor(IFlightService flightService)
    {
        _flightService = flightService;
    }
    public void BookFlight(Guid flightId)
    {
        var flightDetails = _flightService.GetFlightDetails(flightId);
        Console.WriteLine($"yoo ...Fight Details received.. Flight Number: {flightDetails.FlightNumber} ," +
            $" From: {flightDetails.FromAirportCode}, To: {flightDetails.ToAirportCode}");
        // Process details
        //Book Flight
        //return to caller service for next steps in flow

    }
}

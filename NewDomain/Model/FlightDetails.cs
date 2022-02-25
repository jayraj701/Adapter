namespace NewDomain.Model;
public class FlightDetails
{
    public Guid FlightId { get; set; }
    public string FromAirportCode { get; set; }
    public string ToAirportCode { get; set; }
    public string FlightNumber { get; set; }
}

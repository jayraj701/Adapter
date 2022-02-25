using LegacyService;
using NewDomain.Model;
using System.Xml;

namespace NewDomain;

public class FlightServiceAdapter : IFlightService
{
    private readonly IFlightLegacyService _flightLegacyService;
    public FlightServiceAdapter(IFlightLegacyService flightLegacyService)
    {
        _flightLegacyService = flightLegacyService;

    }
    public FlightDetails GetFlightDetails(Guid flightNumber)
    {
        var flightDetailsXml = _flightLegacyService.GetFlightDetailsXml(flightNumber);
        return GetFlightDetailsFromXml(flightDetailsXml);
    }

    private FlightDetails GetFlightDetailsFromXml(XmlDocument flightDetailsXml)
    {
        var flightDetails = flightDetailsXml.GetElementsByTagName("FlightDetails")[0];
        Guid flightId = Guid.Empty;
        var fromAirportCode = string.Empty;
        var toAirportCode = string.Empty;
        var flightNumber = string.Empty;
        foreach (XmlElement element in flightDetails.ChildNodes)
        {
            if (element.Name == "FlightId")
            {
                flightId = Guid.Parse(element.InnerText);
            }
            if (element.Name == "FromAirportCode")
            {
                fromAirportCode = element.InnerText;
            }
            if (element.Name == "ToAirportCode")
            {
                toAirportCode = element.InnerText;
            }
            if (element.Name == "FlightNumber")
            {
                flightNumber = element.InnerText;
            }
        }

        return new FlightDetails()
        {
            FlightId = flightId,
            FlightNumber = flightNumber,
            FromAirportCode = fromAirportCode,
            ToAirportCode = toAirportCode
        };
    }
}


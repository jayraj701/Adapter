using System.Xml;
namespace LegacyService;
public interface IFlightLegacyService
{
    XmlDocument GetFlightDetailsXml(Guid inboundFlightId);
}

public class FlightLegacyService : IFlightLegacyService
{
    public XmlDocument GetFlightDetailsXml(Guid inboundFlightId)
    {
        // Legacy service communication with flight service provider based on XML Communication 
        // for demo purpose we will hide the infrastructure complexity and will return dumy document
        return CreateDumyXmlDocument();
    }

    private XmlDocument CreateDumyXmlDocument()
    {
        var xmlDocument = new XmlDocument();

        xmlDocument.LoadXml("<FlightDetails></FlightDetails>");
        var root = xmlDocument.DocumentElement;
        XmlElement flightId = xmlDocument.CreateElement("FlightId");
        flightId.InnerText = "6C76906E-4172-4A9A-BB79-DFEEEA38DDF6";
        XmlElement fromAirportCode = xmlDocument.CreateElement("FromAirportCode");
        fromAirportCode.InnerText = "LHR";
        XmlElement toAirportCode = xmlDocument.CreateElement("ToAirportCode");
        toAirportCode.InnerText = "BOM";
        XmlElement flightNumber = xmlDocument.CreateElement("FlightNumber");
        flightNumber.InnerText = "BA4536";

        root.AppendChild(flightId);
        root.AppendChild(fromAirportCode);
        root.AppendChild(toAirportCode);
        root.AppendChild(flightNumber);

        return xmlDocument;
    }
}

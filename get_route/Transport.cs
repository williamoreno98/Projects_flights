  
using Newtonsoft.Json;
public class Transport
{
    [JsonProperty(PropertyName = "flightCarrier")]
    public string? FlightCarrier1 { get; set; }

    [JsonProperty(PropertyName = "flightNumber")]
    public string? FlightNumber1 { get; set; }
}
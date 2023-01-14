using Newtonsoft.Json;

public class Flight
{
    [JsonProperty(PropertyName = "departureStation")]
    public string? Origin { get; set; }

    [JsonProperty(PropertyName = "arrivalStation")]
    public string? Destination { get; set; }

    public Transport? Transport { get; set; }

    [JsonProperty(PropertyName = "price")]
    public double Price { get; set; }

    [JsonProperty(PropertyName = "flightCarrier")]
    public string? FlightCarrier { get; set; }

    [JsonProperty(PropertyName = "flightNumber")]
    public string? FlightNumber { get; set; }

}
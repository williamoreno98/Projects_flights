
using Newtonsoft.Json;
public class Journey
{
    [JsonProperty(PropertyName = "flights")]
    public List<Flight>? Flights { get; set; }

    [JsonProperty(PropertyName = "origin")]
    public string? Origin { get; set; }

    [JsonProperty(PropertyName = "destination")]
    public string? Destination { get; set; }

    [JsonProperty(PropertyName = "price")]
    public double Price { get; set; }
}
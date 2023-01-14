// See https://aka.ms/new-console-template for more information


using System;
using System.Net;
using Newtonsoft.Json;

string API_info= "https://recruiting-api.newshore.es/api/flights/2";
var client= new HttpClient();
string data= client.GetStringAsync(API_info).Result;
Console.WriteLine(data);

try
{   
    List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(data);
        
    List<Journey> journeys = new List<Journey>();
    List<output_problem2> outputs = new List<output_problem2>();

    foreach (Flight flight in flights)
    {
        
        // Crear un nuevo objeto Journey y Transport
        Journey journey = new Journey();
        output_problem2 output= new output_problem2();

        // Asignar valores a los campos del objeto Journey
        journey.Origin = flight.Origin;
        journey.Destination = flight.Destination;
        journey.Price = flight.Price;
        journey.Flights = new List<Flight>();
        flight.Transport = new Transport
        {
            FlightCarrier1 = flight.FlightCarrier,
            FlightNumber1 = flight.FlightNumber
        };
        journey.Flights.Add(flight);
        // Agregar el objeto Journey a la lista de journeys
        journeys.Add(journey);

        output.departureStation_output=flight.Origin;
        output.arrivalStation_output= flight.Destination;
        output.flightCarrier_output= flight.FlightCarrier;
        output.flightNumber_output= flight.FlightNumber;
        output.price_output= flight.Price;

        outputs.Add(output);

    }

    foreach (Journey journey in journeys) {
    Console.WriteLine("Journey Origin: " + journey.Origin);
    Console.WriteLine("Journey Destination: " + journey.Destination);
    Console.WriteLine("Journey Price: " + journey.Price);
    foreach (Flight flight in journey.Flights){
        Console.WriteLine("Transport Flight Carrier: " + flight.Transport?.FlightCarrier1);
        Console.WriteLine("Transport Flight Number: " + flight.Transport?.FlightNumber1);
    }

    string json = JsonConvert.SerializeObject(journeys);
    Console.WriteLine(json);



    string final_output = JsonConvert.SerializeObject(outputs);
    Console.WriteLine(final_output);

}
}
catch (HttpRequestException ex)
{
    Console.WriteLine("Error: La variable data es nula. " + ex.Message);
}



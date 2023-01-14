// See https://aka.ms/new-console-template for more information

using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


string API_info= "https://recruiting-api.newshore.es/api/flights/2";
var client= new HttpClient();
string data= client.GetStringAsync(API_info).Result;
//Console.WriteLine(data);

try
{   
    List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(data);
        
    List<Journey> journeys = new List<Journey>();

    foreach (Flight flight in flights)
    {
        
        // Crear un nuevo objeto Journey y Transport
        Journey journey = new Journey();

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

    }

/*  
    foreach (Journey journey in journeys) {
    Console.WriteLine("Journey Origin: " + journey.Origin);
    Console.WriteLine("Journey Destination: " + journey.Destination);
    Console.WriteLine("Journey Price: " + journey.Price);
    foreach (Flight flight in journey.Flights){
        Console.WriteLine("Transport Flight Carrier: " + flight.Transport?.FlightCarrier1);
        Console.WriteLine("Transport Flight Number: " + flight.Transport?.FlightNumber1);
        }
    }
*/
    string json = JsonConvert.SerializeObject(journeys);
    //Console.WriteLine(json);

    var flightSearch = new FlightSearch(journeys);
    string user_origin="MAD";
    string user_destination="BCN";
    double precio_total= 0;
    var result=flightSearch.FindRoute(user_origin,user_destination);
    int tramo=1;
    Console.WriteLine(result);

    List<output_problem3> outputs = new List<output_problem3>();
    output_problem3 output= new output_problem3();

    foreach (Flight flight in result){
        foreach (Journey journey in journeys) {
            if(flight.Origin==journey.Origin && flight.Destination==journey.Destination){
                output.numero_tramo_output=tramo;
                output.origen_inicial_output=user_origin;
                output.destino_final_output=user_destination;
                output.origen_tramo_output=journey.Origin;
                output.destino_tramo_output=journey.Destination;
                output.precio_tramo_output=journey.Price;
                Console.WriteLine("Tramo: " + tramo);
                Console.WriteLine("Journey Origin: " + user_origin);
                Console.WriteLine("Journey Destination: " + user_destination);
                Console.WriteLine("Flight Origin: " + journey.Origin);
                Console.WriteLine("Flight Destination: " + journey.Destination);
                Console.WriteLine("Flight Price: " + journey.Price);
                precio_total=precio_total+journey.Price;
                output.precio_total_output=precio_total;
            foreach (Flight flight2 in journey.Flights){
                Console.WriteLine("Transport Flight Carrier: " + flight2.Transport?.FlightCarrier1);
                Console.WriteLine("Transport Flight Number: " + flight2.Transport?.FlightNumber1);
                output.flightCarrier_tramo_output=flight2.Transport?.FlightCarrier1;
                output.flightNumber_tramo_output=flight2.Transport?.FlightNumber1;
                outputs.Add(output);
            }
            tramo=tramo+1;
            }
        }
    }
    Console.WriteLine(precio_total);
    string final_output = JsonConvert.SerializeObject(outputs);
    Console.WriteLine(final_output);
}
catch (HttpRequestException ex)
{
    Console.WriteLine("Error: La variable data es nula. " + ex.Message);
}

public class FlightSearch
{
    private readonly Dictionary<string, Dictionary<string, double>> _flights;

    public FlightSearch(List<Journey> journeys)
    {
        _flights = new Dictionary<string, Dictionary<string, double>>();
        foreach (Journey journey in journeys)
        {
            foreach (Flight flight in journey.Flights)
            {
                if (!_flights.ContainsKey(flight.Origin))
                {
                    _flights[flight.Origin] = new Dictionary<string, double>();
                }
                _flights[flight.Origin][flight.Destination] = flight.Price;
            }
        }
    }

    public List<Flight> FindRoute(string origin, string destination)
    {
        var previous = new Dictionary<string, string>();
        var distances = new Dictionary<string, double>();
        var nodes = new List<string>();
        previous[origin] = "";
        List<string> path = null;

        //Inicializar las distancias de todos los nodos, incluyendo el nodo de origen
        foreach (var vertex in _flights){
            if (vertex.Key == origin){
                distances[vertex.Key] = 0;
            }
            else{
                distances[vertex.Key] = double.MaxValue;
            }
            nodes.Add(vertex.Key);
        }
        
        while (nodes.Count != 0){   
            
            nodes.Sort((x, y) => (int)distances[x]- (int)distances[y]);

            
            var smallest = nodes[0];

            nodes.Remove(smallest);

            if (smallest == destination)
            {
                path = new List<string>();
                while(previous.ContainsKey(smallest)){
                    path.Add(smallest);
                    smallest = previous[smallest];
                }
             break;
            }
            
        if (distances[smallest] == double.MaxValue)
        {
            break;
        }

        foreach (var neighbor in _flights[smallest]){
            
            var alt = distances[smallest] + neighbor.Value;
            if (alt < distances[neighbor.Key])
            {
                distances[neighbor.Key] = alt;
                previous[neighbor.Key] = smallest;
            }
        }
    }

    if(path == null){
        throw new Exception("No se encontró una ruta válida entre el origen y destino especificado.");
    }
    else
    {
        Console.WriteLine(path.Count);
        path.Reverse();
        var flights = new List<Flight>();
        for(int i = 0; i < path.Count-1; i++)
        {
            flights.Add(new Flight()
            {
                Origin = path[i],
                Destination = path[i+1],
                Price = _flights[path[i]][path[i+1]]
            });
        }
        return flights;
        }
    }
    
}





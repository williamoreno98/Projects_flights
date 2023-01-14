/*  
Código para probar que la creación de la clase fue correcta para varios casos genéricos diferentes a los 
datos proporcionados en la API
*/  

/*  
Inicialización de la clase transport de ejemplo que tiene los atributos FlightCarrier (Definido como la aerolinea) 
y FlightNumber(Definido como el número de vuelo)
*/  
Transport transport = new Transport();
transport.FlightCarrier = "Delta";
transport.FlightNumber = "DL2344";

/*  
Inicialización de la clase flight de ejemplo que tiene los atributos de la clase transport, origin, destination
and price
*/  
Flight flight = new Flight();
flight.Transport = transport;
flight.Origin = "New York City";
flight.Destination = "Vancouver";
flight.Price = 450;

/*  
Inicialización de la clase journey de ejemplo que tiene los atributos de la clase transport, la clase flight como lista y
origin, destination and price
*/  

Journey journey = new Journey();
journey.Flights = new List<Flight> { flight };
journey.Origin = "New York City";
journey.Destination = "Vancouver";
journey.Price = 500;

/*  
Creación de segundo objeto de la clase para imprimir correctamente 2 clases
*/  

Transport transport2 = new Transport();
transport2.FlightCarrier = "American Airlines";
transport2.FlightNumber = "AA5678";

Flight flight2 = new Flight();
flight2.Transport = transport2;
flight2.Origin = "Los Angeles";
flight2.Destination = "Paris";
flight2.Price = 600;

Journey journey2 = new Journey();
journey2.Flights = new List<Flight> { flight2 };
journey2.Origin = "Los Angeles";
journey2.Destination = "Paris";
journey2.Price = 650;

/*  
Impresión de clase transport y flight objeto 1
*/  

foreach (Flight flights in journey.Flights)
{
    Console.WriteLine("Transport Flight Carrier: " + flight.Transport.FlightCarrier);
    Console.WriteLine("Transport Flight Number: " + flight.Transport.FlightNumber);
    Console.WriteLine("Flight Origin: " + flight.Origin);
    Console.WriteLine("Flight Destination: " + flight.Destination);
    Console.WriteLine("Flight Price: " + flight.Price);
}

/*  
Impresión de clase transport y flight objeto 2
*/  

foreach (Flight flights in journey2.Flights)
{   
    Console.WriteLine("Transport Flight Carrier: " + flight2.Transport.FlightCarrier);
    Console.WriteLine("Transport Flight Number: " + flight2.Transport.FlightNumber);
    Console.WriteLine("Flight Origin: " + flights.Origin);
    Console.WriteLine("Flight Destination: " + flights.Destination);
    Console.WriteLine("Flight Price: " + flights.Price);
}

/*  
Impresión de clase journey objeto 1
*/  
Type type = journey.GetType();
var properties = type.GetProperties();
foreach (var property in properties)
{
    Console.WriteLine("{0}:{1}", property.Name, property.GetValue(journey, null));
}


/*  
Impresión de clase journey objeto 2
*/  
Type type2 = journey2.GetType();
var properties2 = type.GetProperties();
foreach (var property in properties2)
{
    Console.WriteLine("{0}:{1}", property.Name, property.GetValue(journey2, null));
}

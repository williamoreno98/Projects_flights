# Projects_flights

El siguiente repositorio cumple con el análisis, diseño e implementación de la solución Backend para el framework propuesto.
Se genera una solución con programación orientada a objetos realizado en C# con el framework .NET core 7.0.

# Arquitectura de la solución

La solución se divide en 4 carpetas principalmente.

Ingresar a cada una de las 4 carpetas y en cada una ingresar el comando dotnet restore y dotnet run para poder revisar el correcto funcionamiento de cada código.
Instalar el paquete Newtonsoft.JSON para deserealizar la información que viene del endpoint y MongoDB.Driver para que funcione la librería de MongoDB.

La primera carpeta se llama "myfirstapp". Aquí se soluciona el problema 1. Se compone de 4 códigos. 3 códigos que son para definir las clases de Journey, 
Flight y Transport y el código "Program_problem1.cs" para probar que la creación de la clase fue correcta para varios casos genéricos diferentes a los 
datos proporcionados en la API.

La segunda carpeta se llama "getrequest". Aquí se soluciona el problema 2. El código "Program_problem2.cs" para probar la conexión a la API proporcionada y guardar
los datos como objetos en las diferentes clases con sus respectivos atributos.

Se escoge la API con endpoint "https://recruiting-api.newshore.es/api/flights/2" y se deja como respuesta un JSON que tiene variable por nombre "final_outputs"


La tercera carpeta se llama "get_route". Aquí se soluciona el problema 3. El código "Program.cs" para probar la conexión a la API proporcionada y guardar
los datos como objetos en las diferentes clases con sus respectivos atributos. Aqui se utiliza el Algoritmo de Dijkstra para la determinación del camino más
corto, dado un vértice origen, hacia el resto de los vértices en un grafo que tiene pesos en cada arista. En este caso en particular se tienen 9 nodos que son
las ciudades únicas en los vuelos, además al final se devuelve un resultado para la ruta más optima encontrada y funciona con éxito. En total son 72 casos que se pueden probar con este endpoint proporcionado, los casos en los cuales la ciudad de origen empieza con "MZL" tienen errores ya que es el primer nodo, supe que este era el error pero por ahora no lo he podido solucionar, para el resto de 64 casos funciona muy bien el algoritmo. Las rutas donde hay mas tramos son las siguientes: 
BCN-->MEX, BCN-->MAD, MAD-->BCN y MEX-->BCN. 

En la linea 97 y 98 se muestra la salida final del algoritmo y en las lineas 58 y 59 se muestra la entrada digitada por el usuario. Intente exponer esto en una API
pero no tengo mucha familziarizacion para crear un endpoint HTTP, tengo mas experiencia consumiendolas pero no creando una.

La cuarta carpeta se llama "Mongo_Conexion". Aquí se soluciona el problema 4. El código "Program.cs" y todos los controladores y servicios hacen posible que se dé
una conexion a la BD creada en MongoDB, se que ustedes solicitaban ORM y una base de datos relacional, pero en términos de conexión estaba más familiarizado con MongoDB.
Este es un código de ejemplo para probar la conexión con MongoDB desde un endpoint. Al enpoint de salida del código se le debe agregar la ruta /swagger para que 
funcione correctamente. Para solucionar el problema 4 se puede acceder a la BD guardar los datos, y si no se han buscado calcular o la ruta, si ya se calculo
simplemente se manda al front la información que se necesita.

Aparte de la solución propuesta se podría revisar a futura esta posible solución utilizando una arquitectura de 3 capas podría ser la siguiente:

# API:

Crear una API web utilizando un framework de desarrollo de API como ASP.NET Core o Express.js
Crear un controlador que reciba como parámetros el origen y el destino del viaje, y que utilice el servicio de negocio para obtener la ruta de viaje.
Crear un end-point HTTP que recibe estos parámetros y retorna una respuesta en formato JSON.
Almacenar la ruta de viaje en un sistema de persistencia para su uso futuro.
# Business:

Crear una clase de servicio de negocio que se comunique con el servicio de datos para obtener la ruta de viaje.
Utilizar un algoritmo de búsqueda de grafos para encontrar la ruta de viaje entre el origen y el destino.
Retornar la ruta de viaje o un mensaje indicando que la ruta no puede ser calculada.

# DataAccess:

Crear una clase de acceso a datos que se comunique con una base de datos o un servicio externo para obtener la información de los vuelos.
Crear una clase de entidad que represente un vuelo.
Crear una clase de entidad que represente una ruta de viaje.
Crear una interfaz de repositorio para la manipulación de las rutas de viaje.
Esta es solo una posible solución y seguramente habrán muchas otras maneras de implementar esto. Considerar también en cuanto a seguridad, escalabilidad y rendimiento.
Además, el acceso a la información de los vuelos (origen, destino, horarios, etc) se puede lograr mediante un servicio web o una conexión directa a una base de datos, todo dependera de la arquitectura de su sistema.




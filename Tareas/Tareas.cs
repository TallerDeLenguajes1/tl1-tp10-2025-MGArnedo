/*● Defina una clase en C# llamada Tarea que represente la estructura de los objetos 
devueltos por la API.  
● Utilizando la clase HttpClient, realiza una petición GET asíncrona al siguiente 
endpoint: https://jsonplaceholder.typicode.com/todos/ 
● A la respuesta JSON de la API, deserialízala en una lista de objetos de tu clase 
Tarea (List<Tarea>). 
● Recorra la lista de tareas y muestra en la consola el título y el estado 
(completada/pendiente) de cada una de forma clara y legible, Al mostrar los 
resultados en consola, filtra la lista para mostrar primero todas las tareas 
pendientes y luego las completadas. 
● A la lista completa de tareas y serialízala nuevamente a formato JSON y guarda el 
resultado en un archivo llamado tareas.json en el directorio de ejecución de la 
aplicación.*/
namespace Tareas
{
    public class Tarea
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

    }
}
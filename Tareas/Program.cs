using Tareas;
using System;
using System.Text.Json;
using System.Net.WebSockets;

var listTareas = await GetTareasAsync();

Console.WriteLine("-----------------------------");
Console.WriteLine("Tareas");
foreach (var T in listTareas)
{
    Console.WriteLine("ID de usuario: " + T.userId + " - ID: " + T.id + " - Titulo: " + T.title + " - Completado: " + T.completed);
}


static async Task<List<Tarea>> GetTareasAsync()
{
    var url = "https://jsonplaceholder.typicode.com/todos";

    try
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        List<Tarea> listtarea = JsonSerializer.Deserialize<List<Tarea>>(responseBody);
        return listtarea;
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("Problemas de acceso a la API");
        Console.WriteLine("Message :{0} ", e.Message);
        return null;
    }
}

using Tareas;
using System;
using System.Text.Json;
using System.Net.WebSockets;

string estadoDeLaTarea;
var listTareas = await GetTareasAsync();
Console.WriteLine("===Tareas===");
Console.WriteLine("---Tareas Pendientes---");
foreach (var T in listTareas)
{
    if (T.completed == false)
    {
        estadoDeLaTarea = "pendiente";
        Console.WriteLine("Titulo: " + T.title + " - Estado: " + estadoDeLaTarea);

    }
}
Console.WriteLine("---Tareas Completadas---");
foreach (var T in listTareas)
{
    if (T.completed == true)
    {
        estadoDeLaTarea = "completada";
        Console.WriteLine("Titulo: " + T.title + " - Estado: " + estadoDeLaTarea);
    }
}

 string jsonString = JsonSerializer.Serialize(listTareas);
 File.WriteAllText("tareas.json", jsonString);
 
            

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

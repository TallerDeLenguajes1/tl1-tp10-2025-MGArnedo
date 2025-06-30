/*Ejercicio 2:  
Dentro de su repositorio cree una carpeta  que se llame “Usuarios” y en ella crear una aplicación 
de consola en C# que interactúe con una API REST para obtener datos, los muestre en pantalla 
y los guarde en el sistema de archivos local. 
● Implemente una aplicación que consuma el siguiente webservice 
https://jsonplaceholder.typicode.com/users/ 
● Muestre en pantalla el nombre y correo electrónico y Domicilio de los primeros 
cinco usuarios. */
using Usuarios;
using System;
using System.Text.Json;
using System.Net.WebSockets;
using System.Net.Http;

var listUsuarios = await ObtenerUsuariosAsync();
Console.WriteLine("===Usuarios===");
foreach (var U in listUsuarios.Take(5))
{
    Console.WriteLine("Nombre: " + U.name + " - Email: " + U.email + " - Domicilio: " + U.address.street + " " + U.address.suite);
}

 string jsonString = JsonSerializer.Serialize(listUsuarios);
 File.WriteAllText("usuarios.json", jsonString);

static async Task<List<Usuario>> ObtenerUsuariosAsync()
{
    var url = "https://jsonplaceholder.typicode.com/users";

    try
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        List<Usuario> listusuarios = JsonSerializer.Deserialize<List<Usuario>>(responseBody);
        return listusuarios;
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("Problemas de acceso a la API");
        Console.WriteLine("Message :{0} ", e.Message);
        return null;
    }
}

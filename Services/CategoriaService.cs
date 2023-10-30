using FakeStoreMaui.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;


namespace FakeStoreMaui.Services
{
    /// <summary>
    /// Implementacion de los metodos  GET, POST, PUT Y DELETE
    /// </summary>
    internal class CategoriaService : ICategoriaService
    {
        // URL base para las solicitudes a la API de categorías
        private string URLL = "https://api.escuelajs.co/api/v1/categories";
        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            try
            {
                // URL para obtener categorías
                const string URL = "https://api.escuelajs.co/api/v1/categories";
                // Cliente HTTP para hacer solicitudes
                var httpClient = new HttpClient();
                // Realiza una solicitud GET a la URL
                var respuesta = await httpClient.GetAsync(URL);

                if (respuesta.IsSuccessStatusCode)
                {
                    // Lee el contenido de la respuesta
                    var content = await respuesta.Content.ReadAsStringAsync();
                    // Desserializa el contenido JSON a una lista de categorías
                    var response = JsonSerializer.Deserialize<List<Categoria>>(content);
                    // Devuelve la lista de categorías
                    return response;
                }
                else
                {
                    // Manejo de errores si la respuesta no es exitosa
                    Console.WriteLine($"Error en la respuesta: {respuesta.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                Console.WriteLine($"Error al obtener las categorías: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> Post(Categoria category)
        {
            // URL para realizar una solicitud POST
            string url = "https://api.escuelajs.co/api/v1/categories/";
            try
            {
                // Cliente HTTP para hacer solicitudes
                var httpClient = new HttpClient();
                // Convierte la categoría en formato JSON y crea un contenido para la solicitud
                var content = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");
                // Realiza una solicitud POST a la URL
                var response = await httpClient.PostAsync(url, content);
                return response.IsSuccessStatusCode;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Solicitud POST exitosa");                  
                    return true; // Devuelve true si la solicitud es exitosa
                }
                else
                {
                    Console.WriteLine($"Solicitud POST fallida. Estado de respuesta: {response.StatusCode}");
                    return false; // Devuelve false si la solicitud falla
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al realizar la solicitud POST: {ex.Message}");
                return false;
            }
        }
    

        
        public async Task<bool> Put(Categoria category)
        {
            try
            {
                // Cliente HTTP para hacer solicitudes
                var httpClient = new HttpClient();
                // Convierte la categoría en formato JSON y crea un contenido para la solicitud
                var content = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");
                // Realiza una solicitud PUT a la URL de la categoría específica
                var response = await httpClient.PutAsync(URLL + "/" + category.id, content);
                // Devuelve true si la solicitud es exitosa
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false; // Devuelve false en caso de error
            }
        }

               
        public async Task DeleteCategoriaAsync(int id)
        {
            // URL para eliminar una categoría específica
            string URL = $"https://api.escuelajs.co/api/v1/categories/{id}";
            // Cliente HTTP para hacer solicitudes
            var htttpClient = new HttpClient();
            // Realiza una solicitud DELETE a la URL
            var respuesta = await htttpClient.DeleteAsync(URL);
        }
        // Lista de productos eliminados
        private List<int> productosEliminados = new List<int>();
    }
}

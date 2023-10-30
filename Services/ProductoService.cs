using FakeStoreMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;

namespace FakeStoreMaui.Services
{
    internal class ProductoService : IProductoService
    {
        public async Task<List<Producto>> GetProductosAsync()
        {
            const string URL = "https://fakestoreapi.com/products";

            var htttpClient = new HttpClient();
            var respuesta = await htttpClient.GetAsync(URL);
            var content = await respuesta.Content.ReadAsStringAsync();
            var producList = JsonSerializer.Deserialize<List<Producto>>(content);
            return producList;
        }
        public async Task PutProductAsync(Producto product)
        {
            string URL = "https://fakestoreapi.com/products/7";
            //ejecuta url
            var htttpClient = new HttpClient();

            Producto productos = new Producto()
            {
                title = "test product",     
                description = "lorem ipsum set",
                  
                   
            };

            var data = JsonSerializer.Serialize<Producto>(productos);
            HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "aplication/json");
            var respuesta = await htttpClient.PutAsync(URL, content);
            var result = await respuesta.Content.ReadAsStringAsync();
            var productoResult = JsonSerializer.Deserialize<Producto>(result);
        }
   
        public async Task PostProductAsync(Producto product)
        {
            string URL = "https://fakestoreapi.com/products";

            var htttpClient = new HttpClient();

            var data = JsonSerializer.Serialize(product);
            HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var respuesta = await htttpClient.PostAsync(URL, content);
            var result = await respuesta.Content.ReadAsStringAsync();
            var productoResult = JsonSerializer.Deserialize<Producto>(result);
        }
        
        
        public async Task DeleteProductAsync(int id)
        {
            string URL = "https://fakestoreapi.com/products/6";

            var htttpClient = new HttpClient();
            var respuesta = await htttpClient.DeleteAsync(URL);
        }
        private List<int> productosEliminados = new List<int>();

        public async Task<List<int>> GetProductosEliminadosAsync()
        {
            return productosEliminados;
        }
    }
}

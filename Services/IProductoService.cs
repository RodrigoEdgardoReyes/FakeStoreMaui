using System.Collections.Generic;
using System.Threading.Tasks;
using FakeStoreMaui.Models;

namespace FakeStoreMaui.Services
{
    internal interface IProductoService
    {
        Task<List<Producto>> GetProductosAsync();
        Task PutProductAsync(Producto product);
        Task PostProductAsync(Producto product);
        Task DeleteProductAsync(int id);
        public Task<List<int>> GetProductosEliminadosAsync();

    }
}

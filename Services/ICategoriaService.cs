using FakeStoreMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStoreMaui.Services
{
    internal interface ICategoriaService
    {

        Task<List<Categoria>> GetCategoriasAsync();
        //public Task<bool> PostCategoriaAsync(Categoria categoria);
        //Task PutCategoriaAsync(int id, string name);
        public Task<bool> Post(Categoria category);
        public Task<bool> Put(Categoria category);
        Task DeleteCategoriaAsync(int id);
    }
        
        
}

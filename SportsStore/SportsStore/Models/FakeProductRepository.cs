using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    // classe baseada em IProductRepository
    // FakeProductRepository - serviço: só preciso de mexer aqui para passar para BD
    public class FakeProductRepository : IProductRepository
    {
        // => lambda expression ; é um repositorio falso para testar sem BD
        // public IEnumerable<Product> Products => new List<Product>: é criado por "imposição" de IProductRepository
        public IEnumerable<Product> Products => new List<Product>
        {
            new Product { Name ="Football",Price = 25},

            new Product { Name ="Surf board", Price = 179},

            new Product { Name = "Running shoes", Price = 95, Description="You will run faster"},
        };
    }
}

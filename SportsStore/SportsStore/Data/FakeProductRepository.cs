using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    // classe baseada em IProductRepository
    // instancio aqui os products para os passar com um serviço (ver startup.cs)
    public class FakeProductRepository : IProductRepository
    {
        // => lambda expression ; 
        // é um repositorio falso para testar sem BD
        // implement de IProductRepository:
        //   .public IEnumerable<Product> Products => throw new NotImplementedException(); // orig.
        // este é o metodo definido em IProductRepository
        public IEnumerable<Product> Products => new List<Product>
        {
            new Product { Name ="Football",Price = 25},
            new Product { Name ="Surf board", Price = 179},
            new Product { Name = "Running shoes", Price = 95, Description="You will run faster"},
            // adicionados Aula Paginação
            new Product {Name = "Turf Tennis", Price = 65},
            new Product {Name = "Gloves", Price = 17, Description= "You will be a champion!"},
        };

    }
}

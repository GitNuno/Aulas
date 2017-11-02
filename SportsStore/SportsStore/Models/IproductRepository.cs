using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    // tem que devolver os produtos
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; } // posso implementar com uma lista

    }
}

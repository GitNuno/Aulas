using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    // permite-me criar qualquer tipo de "repositorio" (neste caso de produtos) a partir desta interface
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; } // posso implementar com uma lista
       // +++ aqui aparecem os IEnumerable<MyModels> ???

    }
}

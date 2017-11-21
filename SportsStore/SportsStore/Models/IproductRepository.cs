using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    // +++ crio apenas 1 class interface para todos modelos(tabelas) e com varios IEnumerable<MyModel> ???
    // +++ por sua vez EF()Repository implementa esta classe e cada destes IEnumerable<MyModel> é preenchido
    //     com BD usando ApplicationDbContext ??????
    // permite-me criar qualquer tipo de "repositorio" (neste caso de produtos) a partir desta interface
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; } // posso implementar com uma lista
       // +++ aqui aparecem os IEnumerable<MyModels> ???

    }
}

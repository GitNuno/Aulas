using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    // preciso de ir ao 
    public class EFProductRepository: IProductRepository
    {
        // para aceder ás tabelas
        private ApplicationDbContext dbContext;

        // preciso do construtor com contexto da BD e guarda paradps utiliizar
        // ver startup.cs
        public EFProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // throw new NotImplementedException(); // mudado
        // vai buscar os produtos á tabela de produtos, posso agora alterar no start up tenho um serviço 
        //
        // uso isto para todas as tbs
        public IEnumerable<Product> Products => dbContext.Products;
    }
}

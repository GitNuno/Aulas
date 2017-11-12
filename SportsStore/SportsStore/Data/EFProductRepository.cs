using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    // classe baseada em IProductRepository
    // +++ vai haver um EF(Mymodel)Repository:I(Mymodel)Repository por cada modelo(tabela) ??? ou
    // +++ ou vai haver apenas EFRepository:IRepository onde IRepository tem def. as IEnumerable<MyModels>??
    public class EFProductRepository: IProductRepository
    {
        // (classe baseada em DbContext) - crio um ctx para aceder ás tabelas da BD
        private ApplicationDbContext dbContext;

        // preciso do construtor com contexto da BD e guarda para dps passar nos serviços (ver startup.cs)
        public EFProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // implement de IProductRepository ...
        // vai buscar os produtos á tabela de produtos, posso agora criar um serviço no startup.cs
        public IEnumerable<Product> Products => dbContext.Products;
        // +++ aqui aparecem os implement de IRepository (se criei IEnumerable<Mymodels> em IRepository)???
    }
}

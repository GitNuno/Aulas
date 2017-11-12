using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    // class DbContext mapea BD
    // instancio esta classe nas minhas [EF(Mymodels)Repository:I(Mymodels)Repository] 
    public class ApplicationDbContext : DbContext
    {
        // base(options) mm que super: cria BD com as options
        // permite-me ter acessso ao que está no modelo
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // config. base dados com os modelos: digo onde vou passar a BD
        // tenho de fazer para cada tabela | Products representa a minha tabela produtos
        public DbSet<Product> Products { get; set; }
        // +++ aqui aparecem os DbSet<MyModels>  ???
    }
}

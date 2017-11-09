using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    // DbContext mapea BD
    public class ApplicationDbContext : DbContext
    {
        // base(options) mm que super: cria BD com as options
        // tenho de dizer onde vou passar a BD
        // permite-me ter acessso ao que está no modelo
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // a seguir preciso config. base dados
        // tenho de fazer para cada tabela | Products é a mina tabela produtos
        public DbSet<Product> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository repository;

        // Controlador vai ver se existe um serviço para IProductRepository
        // dependency injection
        public ProductsController(IProductRepository repository) // construtor
        {
            this.repository = repository;
        }

        // CAMINHO DADOS:
        //   .[serviços]: IProductRepository recebeu dados de EFProductRepository>() (ver startup.cs)
        //   .[EFProductRepository:IProductRepository]: recebeu dados da BD usando ApplicationDbContext (:DbContext)
        //   .[ApplicationDbContext:DbContext]: config. BD com os modelos (DbSet<Product> Products { get; set; })
        //      .Nota: A BD foi populada usando SeedData.cs (ver startup.cs) que usa ApplicationDbContext 
        //   .[view List]: é do tipo IEnumerable<Product> e exibe campos de Product com: foreach (Product p in Model)
        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}
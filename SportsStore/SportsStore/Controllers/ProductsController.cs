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

        // Controlador precisa de ir ao repositorio - vai aos serviços ver se existe um serviço para IProductRepository
        // nao conhece IProductRepository repository
        // dependency injection
        public ProductsController(IProductRepository repository)
        {
            this.repository = repository;

        }
        // 
        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}
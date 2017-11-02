using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PartyInvites.Controllers
{
    public class HelloWorldController : Controller
    {
        public string Index()
        {
            return "Hello World";
        }
        /*
      // GET: /helloWorld/welcome (controlador/acção)
      public string Welcome() { // se chamar no browser HelloWorld/welcome - recebo string
          return "stringWelcome" ;
      }
      */
        // GET: /helloWorld/welcome
        // Return View: Welcome.cshtml
        public ViewResult Welcome()
        {
            return View();
        }
    }
}
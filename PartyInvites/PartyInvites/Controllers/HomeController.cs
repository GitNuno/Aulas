using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers {
    public class HomeController : Controller {
        // IActionResult: é uma class Interface
        /*
        public IActionResult Index() // acções: EX: inserir produto numa class InsertController
        {                            // acções: podem ser chamados por http (se metodo for publico)
            return View();
        }
        */

        // Index - v02
        public IActionResult Index() {
            int hour = DateTime.Now.Hour;

            string message, expression_2;
            expression_2 = "How are you?";

            if (hour >= 7 && hour < 12) {
                message = "Good Morning";
            } else if (hour >= 12 && hour < 20) {
                message = "Good Afternoon";
            } else {
                message = "Good Evening";
            }

            ViewBag.Message = message;
            ViewBag.Expression_2 = expression_2;

            return View();
        }

        // GET
        // MVC faz o render da view Home/Rsvp (faço o get da pagina) !! - Faz Render da View com o nome da acção: RsvpForm()
        // [HttpGet] são anotações(metadados): faço o get da pagina
        // GET: /Home/Rsvp
        [HttpGet]
        public ViewResult Rsvp() {
            return View();
        }

        /*
       // Quando faço Submit => POST:
       // recebe o modelo, preenche o objecto GuestResponse.cs através do mecanismo model_binding
       // [HttpPost] são anotações(metadados): estou na pagina e faço POST dos dados
       [HttpPost] 
       public ViewResult RsvpForm(GuestResponse response) // obriga fazer import: using PartyInvites.Models;
       {
           // Process response
           Repository.AddResponse(response);
           return View();
       }
       */


        // Quando faço Submit => POST:
        // recebe o modelo, preenche o objecto GuestResponse.cs através do mecanismo model_binding
        // nota: Rsvp(GuestResponse response) - o modelo é do tipo GuestResponse (ver Rsvp.cshtml)
        // [HttpPost] são anotações(metadados): estou na pagina e faço POST dos dados
        // POST: /Home/Rsvp
        [HttpPost]
        public ViewResult Rsvp(GuestResponse response) {
            // validação
            if (ModelState.IsValid) {
                // guardo resposta do Convidado (Guest)
                Repository.AddResponse(response); // insere formulario numa lista
                return View("Thanks", response); // passa objecto GuestResponse para a view Thanks.cshtml
                                                 // qd POST: render da view Home/Thanks - MAS URL: /Home/Rsvp !!!
            }
            else {
                // There are Validation Errors > devolve a view em que estava 
                return View();
            }
        }


        /* 06-10 */
        // GET:
        // acção chamada na View Thanks.cshtml: <a asp-action="GuestList">here</a>
        public ViewResult GuestList() {

            // assim passa todas as respostas
            // return View(Repository.Responses); 

            // linq linguagem para Querys: BD ou IEnumerables ou arrays ...
            // funciona como na BD, os elementos estão na Lista mas o que é devolvido é apenas Query
            // r(var generica, guarda quem vem á festa)
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }


        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error() {
            return View();
        }
    }
}

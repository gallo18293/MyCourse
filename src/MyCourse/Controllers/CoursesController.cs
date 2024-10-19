using Microsoft.AspNetCore.Mvc;

namespace MyCourse.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return Content("Sono l'action Index del CoursesController!");
        }


        //L'action Detail deve restituire il dettaglio di un corso pertanto gli passo un'argomento
        //chiamato id di tipo stringa
        public IActionResult Detail (string id)
        {
            return Content($"Sono l'action Detail del CoursesController, ho ricevuto l'id {id}!");
        }
    }
}
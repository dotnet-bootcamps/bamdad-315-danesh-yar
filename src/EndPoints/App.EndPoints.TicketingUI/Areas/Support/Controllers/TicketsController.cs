using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.TicketingUI.Areas.Support.Controllers
{
    [Area("Support")]
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }
    }
}

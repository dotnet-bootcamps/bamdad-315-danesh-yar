using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.TicketingUI.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using App.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.TicketingUI.Areas.Support.Controllers
{
    [Area("Support")]
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<Ticket>();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = new Ticket();
            return View(model);
        }
    }
}

using App.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.TicketingUI.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<Ticket>();
            return View(model);
        }
    }
}

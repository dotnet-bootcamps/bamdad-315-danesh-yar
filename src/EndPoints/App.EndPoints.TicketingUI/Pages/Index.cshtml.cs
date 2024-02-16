using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace App.EndPoints.TicketingUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;

        public IndexModel(ILogger<IndexModel> _logger)
        {
            logger = _logger;
        }
        public void OnGet()
        {
            //throw new Exception("he he he khata rokh dad.");
            try
            {
                throw new Exception("be inja residim");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex?.Message);
                throw ex;
            }
            
        }
    }
}

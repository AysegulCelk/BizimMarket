using Microsoft.AspNetCore.Mvc;

namespace BizimMarket.Areas.Admin.Controllers
{
    public class DashBoardController : Controller
    {
        [Area("Admin")] //admini areası oldugunu belirttik
        public IActionResult Index()
        {
            return View();
        }
    }
}

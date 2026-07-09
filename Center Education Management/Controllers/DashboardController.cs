using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Login()
        {
            return Redirect("~/ecmp/index.html");
        }
    }
}

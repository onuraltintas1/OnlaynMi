using Microsoft.AspNetCore.Mvc;

namespace OnlaynMiProject.Controller.Controllers
{
    public class CustomerLayoutController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

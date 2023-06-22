using Microsoft.AspNetCore.Mvc;

namespace OnlaynMiProject.Controller.ViewComponents.Customer
{
    public class _CustomerLayoutNavbarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

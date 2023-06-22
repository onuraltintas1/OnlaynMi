using Microsoft.AspNetCore.Mvc;

namespace OnlaynMiProject.Controller.ViewComponents.Customer
{
    public class _CustomerLayoutFooterPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

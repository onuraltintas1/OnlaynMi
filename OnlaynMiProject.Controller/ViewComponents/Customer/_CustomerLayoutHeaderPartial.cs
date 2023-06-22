using Microsoft.AspNetCore.Mvc;

namespace OnlaynMiProject.Controller.ViewComponents.Customer
{
    public class _CustomerLayoutHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

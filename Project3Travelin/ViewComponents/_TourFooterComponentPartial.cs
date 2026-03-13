using Microsoft.AspNetCore.Mvc;

namespace Project3Travelin.ViewComponents
{
    public class _TourFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

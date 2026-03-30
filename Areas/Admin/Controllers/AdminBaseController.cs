using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OdakMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session.GetString("AdminGiris") != "true")
            {
                context.Result = RedirectToAction("Giris", "Auth", new { area = "Admin" });
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}

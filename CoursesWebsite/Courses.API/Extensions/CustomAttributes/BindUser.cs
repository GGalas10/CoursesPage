using Courses.API.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Courses.API.Extensions.CustomAttributes
{
    public class BindUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var ctrl = context.Controller as ApiBaseController;
            if (ctrl.User.Identity.IsAuthenticated)
            {
                ctrl.InitUser();
            }
        }
    }
}

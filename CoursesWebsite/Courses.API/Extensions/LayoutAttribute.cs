using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Courses.API.Extension
{
    public class LayoutAttribute :ResultFilterAttribute
    {
        private string _layoutAttribut;
        public LayoutAttribute(string layout)
        {
            this._layoutAttribut = layout;
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var viewResult = context.Result as ViewResult;
            if(viewResult != null)
            {
                viewResult.ViewData["Layout"] = this._layoutAttribut;
            }
        }
    }
}

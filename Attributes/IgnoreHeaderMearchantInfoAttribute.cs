using Microsoft.AspNetCore.Mvc.Filters;

namespace Meta.IntroApp.Attributes
{
    public class IgnoreHeaderMearchantInfoAttribute : ActionFilterAttribute
    {
        public IgnoreHeaderMearchantInfoAttribute(bool defaultCurrencyIfNotExist = false)
        {
            
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            base.OnActionExecuting(actionContext);
        }
    }
}

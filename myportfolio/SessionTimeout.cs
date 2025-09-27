using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;


namespace myportfolio
{
  
        public class SessionTimeout : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (context.HttpContext.Session == null ||
                                 !context.HttpContext.Session.TryGetValue("username", out byte[] val))
                {
                    context.Result =
                        new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Login",
                            action = "SignOut"
                        }));
                }
                base.OnActionExecuting(context);
            }
    }
}

using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;

namespace WebApiPracticeApp.Utils
{
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(actionContext); //Return status code 401 unauthorized for unauthenticated users
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, "Access Forbidden"); //Return status code 403 forbidden for authenticated but unauthorized users
            }
        }
    }
}
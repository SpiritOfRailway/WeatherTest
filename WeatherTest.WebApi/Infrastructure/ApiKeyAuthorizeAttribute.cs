using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WeatherTest.WebApi.Infrastructure
{
    public class ApiKeyAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            IEnumerable<String> keys;

            if (!actionContext.Request.Headers.TryGetValues("Api-Key", out keys))
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                var allowedKeysSetting = ConfigurationManager.AppSettings["Api-Keys"];

                IEnumerable<String> allowedKeys = null;
                if (allowedKeysSetting != null)
                {
                    allowedKeys = allowedKeysSetting.Split(';');
                }

                if (allowedKeys.Intersect(keys).Count() < 1)
                {
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
            }

            //base.OnAuthorization(actionContext);
        }
    }
}
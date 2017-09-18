using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using TokenService;

namespace ProductWebAPI.Filters
{
    public class CustomAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            IEnumerable<string> values = new List<string>();
            actionContext.Request.Headers.TryGetValues("token", out values);

            if(values == null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                base.OnAuthorization(actionContext);
                return;
            }

            string token = values.FirstOrDefault();


            WebRequest request = WebRequest.Create("http://localhost:49963/TokenService.svc/ValidateToken");

            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            using (StreamWriter requestWriter = new StreamWriter(request.GetRequestStream()))
            {
                requestWriter.Write("\""+token+"\"");
            }

            var response = request.GetResponse();
            using (StreamReader responseReader = new StreamReader(response.GetResponseStream()))
            {
                string responseData = responseReader.ReadToEnd();

                if(responseData == "false")
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    base.OnAuthorization(actionContext);
                    return;
                }
            }

            base.OnAuthorization(actionContext);
        }
    }
}
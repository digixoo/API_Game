using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Back.Filters
{
    public class BasicAutenticationFilter : AuthorizationFilterAttribute
    {
        private const string Realm = "localhost";
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
               
                if (actionContext.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    actionContext.Response.Headers.Add("WWW-Authenticate",
                        string.Format($"Basic realm={Realm}"));
                }
            }
            else
            {
                //Get the authentication token from the request header
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;

                //Decode the string
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));

                //Convert the string into an string array
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                //First element of the array is the username
                string username = usernamePasswordArray[0];
                //Second element of the array is the password
                string password = usernamePasswordArray[1];

                //call the login method to check the username and password
                if (UserValidate(username, password))
                {
                    var identity = new GenericIdentity(username);
                    IPrincipal principal = new GenericPrincipal(identity, null);

                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }

        private bool UserValidate(string username, string password)
        {
            bool isValid = false;

            if(username.Equals("user") && password.Equals("pass"))
            {
                isValid = true;    
            }

            return isValid;
        }
    }
}
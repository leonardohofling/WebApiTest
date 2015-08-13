using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApiTest.Controllers
{
    public class MeController : ApiController
    {
        private IAuthenticationManager Authentication
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }

        // GET api/values
        [Authorize]
        public string Get()
        {
            return this.Authentication.User.Identity.Name;
        }
    }


}

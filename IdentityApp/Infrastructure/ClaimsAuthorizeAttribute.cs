using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace IdentityApp.Infrastructure
{
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        public int Age { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }

            ClaimsIdentity claimsIdentity = httpContext.User.Identity as ClaimsIdentity;
            var yearClaims = claimsIdentity.FindFirst("Year");
            if (ReferenceEquals(yearClaims, null))
            {
                return false;
            }

            int year;
            if (!int.TryParse(yearClaims.Value, out year))
            {
                return false;
            }

            if ((DateTime.Now.Year - year) < this.Age)
            {
                return false;
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}
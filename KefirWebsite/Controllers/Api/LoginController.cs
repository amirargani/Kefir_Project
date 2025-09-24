using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace KefirWebsite.Controllers.Api
{
    public class LoginController : ApiController
    {
        DBContext db = new DBContext();
        [HttpPost]
        public IHttpActionResult SignIn(User user)
        {

            if (db.Users.Any(p => p.UserName == user.UserName && p.Password == user.Password&&p.IsActive==true))
            {
                
                FormsAuthentication.SetAuthCookie(user.UserName, user.remember);
                
                return Ok();
            }
            return BadRequest();
        }

       




    }
}

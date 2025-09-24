using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace KefirWebsite.Controllers.Api
{
    public class ContactUsController : ApiController
    {
        DBContext db = new DBContext();
        [HttpPost]
        public IHttpActionResult RegisterContacuUs(ContactUs c)
        {
            if (!Url.Request.IsLocal()) return BadRequest();
            c.HasRead = false;
                db.ContactUs.Add(c);
                db.SaveChanges();
                return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public List<ContactUs> GetMessages(bool id)
        {
            return db.ContactUs.Where(p=>p.HasRead==id).ToList();
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult DeleteMessage(int id)
        {
            var m = db.ContactUs.Find(id);
          
            db.ContactUs.Remove(m);
            db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult ChangeStatus(int id)
        {
            var m = db.ContactUs.Find(id);
            if (m == null)
                return BadRequest();
            m.HasRead = true;
            db.SaveChanges();
            return Ok();
        }
        
    }
}

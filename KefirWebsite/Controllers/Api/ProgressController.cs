using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KefirWebsite.Controllers.Api
{
    public class ProgressController : ApiController
    {
        DBContext db = new DBContext();
        [HttpGet]
        public List<Progress> GetProgresses()
        {
            
            return db.Progresses.ToList();
        }
      

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult Register(Progress p)
        {
            if (p.ProgressId != 0)
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            else db.Progresses.Add(p);
            db.SaveChanges();
            return Ok();
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IHttpActionResult DeleteProgress([FromUri]int id)
        {
            var x = db.Progresses.Find(id);
            db.Progresses.Remove(x);
            db.SaveChanges();
            return Ok();
        }
    }
}

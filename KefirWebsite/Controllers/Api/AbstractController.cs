using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace KefirWebsite.Controllers.Api
{
    public class AbstractController : ApiController
    {
        DBContext db = new DBContext();
        
        [HttpGet]
        public List<Abstract> GetAbstracts()
        {
            return db.Abstracts.ToList();
        }


      
        [HttpGet]
        public IHttpActionResult DeleteAbstract(int id)
        {
            
            db.Abstracts.Remove(db.Abstracts.Find(id));
            db.SaveChanges();
            return Ok();
        }

        [Authorize(Roles ="Administrator")]
        [HttpGet]
        public Abstract GetAbstract(int id)
        {

            return db.Abstracts.Find(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IHttpActionResult RegisterAbstract(Abstract abstrac)
        {
            if (!ModelState.IsValid)
            {

                string messages = string.Join("، ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return BadRequest(messages);
            }
            if (abstrac.AbstractId != 0)
            {
                db.Entry(abstrac).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                db.Abstracts.Add(abstrac);
            }
            db.SaveChanges();

            return Ok();
        }

    }
}

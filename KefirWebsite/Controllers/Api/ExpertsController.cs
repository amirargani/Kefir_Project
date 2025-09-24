using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KefirWebsite.Controllers.Api
{
    public class ExpertsController : ApiController
    {
        DBContext db = new DBContext();
        [HttpGet]
        public List<Expert> GetExperts()
        {
            return db.Experts.ToList();
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult DeleteExpert(int id)
        {
           
            db.Experts.Remove(db.Experts.Find(id));
            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public Expert GetExpert(int id)
        {

            return db.Experts.Find(id);
        }

        
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult RegisterExpert()
        {
            var req = System.Web.HttpContext.Current.Request;
            if (req.Files.Count != 1)
            {
                return BadRequest("تصویر را بطور صحیح وارد نمایید");

            }
            if (req.Files[0].ContentType != "image/jpeg")
            {
                return BadRequest("تصویر را بطور صحیح وارد نمایید");

            }
            var file = req.Files[0];

            
            JObject obj = JObject.Parse(System.Web.HttpContext.Current.Request["Expert"]);
            
          
            Expert expert = new Expert();
            
            expert.ExpertId = Convert.ToInt32(obj.GetValue("ExpertId"));
            expert.ExpertSkill = obj.GetValue("ExpertSkill").ToString();
            expert.ExpertFullName = obj.GetValue("ExpertFullName").ToString();
            string path = "~/Upload/Experts" + file.FileName;
            string PhisicalPath = System.Web.HttpContext.Current.Server.MapPath(path);
            file.SaveAs(PhisicalPath);
            expert.ExpertImage = path.Substring(1);


            if (expert.ExpertId!= 0)
            {
                db.Entry(expert).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                db.Experts.Add(expert);
            }
            
                db.SaveChanges();
           
            return Ok();
        }

    }
    
}

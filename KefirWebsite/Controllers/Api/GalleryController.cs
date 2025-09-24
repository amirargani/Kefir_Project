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
    public class GalleryController : ApiController
    {
        DBContext db = new DBContext();
        [HttpGet]
        public List<Gallery> GetGallery()
        {
            DBContext db = new DBContext();
            return db.Gallery.ToList();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult RegisterPicture()
        {
            var req = System.Web.HttpContext.Current.Request;
            JObject obj = JObject.Parse(req["Gallery"]);
            Gallery g = new Gallery();
            
            if (req.Files.Count != 1)
            {
                return BadRequest("تصویر را بطور صحیح وارد نمایید");

            }
            if (req.Files[0].ContentType != "image/jpeg")
            {
                return BadRequest("تصویر را بطور صحیح وارد نمایید");

            }
            var file = req.Files[0];
            var path = "~/Upload/Gallery/" + file.FileName;
            
            string PhisicalPath = System.Web.HttpContext.Current.Server.MapPath(path);
            file.SaveAs(PhisicalPath);
            g.GalleryPicAddress = path.Substring(1);
            g.GalleryPicId = Convert.ToInt32(obj.GetValue("GalleryPicId"));
            g.GalleryRegisterDate = DateTime.Now;
            if (g.GalleryPicId == 0)
                db.Gallery.Add(g);
            else
                db.Entry(g).State = System.Data.Entity.EntityState.Modified;


           
                db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult DeletePic(int id)
        {
            DBContext db = new DBContext();
            var q = db.Gallery.Find(id);
            db.Gallery.Remove(q);
            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public Gallery GetPicture(int id)
        {
            return db.Gallery.Find(id);
        }

    }
}

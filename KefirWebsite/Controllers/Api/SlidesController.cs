using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace KefirWebsite.Controllers
{
    public class SlidesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Slides
        [HttpGet]
        public List<Slide> GetSlides()
        {
            return db.Slides.ToList();
        }

        // GET: api/Slides/5
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public Slide GetSlide(int id)
        {
            Slide slide = db.Slides.Find(id);
            return slide;
        }

        // PUT: api/Slides/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IHttpActionResult RegisterSlide()
        { var req = System.Web.HttpContext.Current.Request;
            if(req.Files.Count!=1)
            {
                return BadRequest("تصویر را بطور صحیح وارد نمایید");

            }
            if (req.Files[0].ContentType != "image/jpeg")
            {
                return BadRequest("تصویر را بطور صحیح وارد نمایید");

            }
            var file = req.Files[0];
            JObject obj = JObject.Parse(System.Web.HttpContext.Current.Request["slide"]);
          
            Slide Slide = new Slide();
            Slide.SlideId = Convert.ToInt32(obj.GetValue("SlideId"));
            Slide.SlidePicDesc = obj.GetValue("SlidePicDesc").ToString();
            Slide.SlideSimpleTitle = obj.GetValue("SlideSimpleTitle").ToString();
            Slide.SlideCssTitle = obj.GetValue("SlideCssTitle").ToString();
            Slide.SlideText = obj.GetValue("SlideText").ToString();
            string url = "~/Upload/Slides/" + file.FileName;
            string path =System.Web.HttpContext.Current.Server.MapPath(url);
            file.SaveAs(path);
            Slide.SlidePicAddress = url.Substring(1);
            if (Slide.SlideId != 0)
            {
                db.Entry(Slide).State = EntityState.Modified;
            }
            else
            {
                db.Slides.Add(Slide);
            }
                db.SaveChanges();
            return Ok();
        }

      

        // DELETE: api/Slides/5
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult DeleteSlide(int id)
        {
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return NotFound();
            }

            db.Slides.Remove(slide);
            db.SaveChanges();

            return Ok();
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}
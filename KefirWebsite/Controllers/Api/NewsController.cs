using Jil;
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
    public class NewsController : ApiController
    {
        DBContext db = new DBContext();
        [HttpGet]
        public List<News> GetNews()
        {
         
            return db.News.Include("NewsPirctures").ToList();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult DeleteNews(int id)
        {
            db.News.Remove(db.News.Find(id));
            db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public News GetCurrentNews(int id)
        {
            return db.News.Include("NewsPirctures").SingleOrDefault(p=>p.NewsId==id);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult RegisterNews()
        {

            var req = System.Web.HttpContext.Current.Request;
            if (req.Files.Count <1|| req.Files.Count > 3)
            {
                return BadRequest("تصویر را بطور صحیح وارد نمایید");

            }
            
            var getnews = req["News"];
            JObject obj = JObject.Parse(getnews);
            News news;
           
            if (Convert.ToInt32(obj.GetValue("NewsId")) != 0)
            {
                int newsid = Convert.ToInt32(obj.GetValue("NewsId"));
                news = db.News.Include("NewsPirctures").SingleOrDefault(p=>p.NewsId==newsid);
                news.NewsDate = DateTime.Now;
                news.NewsText = obj.GetValue("NewsText").ToString();
                news.NewsTitle = obj.GetValue("NewsTitle").ToString();

                db.NewsPictures.RemoveRange(news.NewsPirctures);

                foreach (var item in news.NewsPirctures)
                {
                    db.NewsPictures.Remove(item);
                }

            }
            else
            {
                news = new News();
                
                news.NewsDate = DateTime.Now;
                news.NewsText = obj.GetValue("NewsText").ToString();
                news.NewsTitle = obj.GetValue("NewsTitle").ToString();
            }

            
            
            int ct = req.Files.Count;

            for (int i = 0; i < ct; i++)
            {
                var file=req.Files[i];
                if (file.ContentType != "image/jpeg")
                {
                    return BadRequest("تصویر را بطور صحیح وارد نمایید");

                }
                var path = "~/Upload/NewsPictures/"+file.FileName;
                var PhisicalPath = System.Web.HttpContext.Current.Server.MapPath(path);
                file.SaveAs(PhisicalPath);
                NewsPicture p = new NewsPicture() { NewsPicAddress = path.Substring(1) };
                news.NewsPirctures.Add(p);
            }
            if (news.NewsId == 0)
                db.News.Add(news);

           
                db.SaveChanges();
            return Ok();
        }

    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace KefirWebsite.Controllers.Api
{
    public class SettingController : ApiController
    {
        DBContext db = new DBContext();
        public object GetProgress()
        {
            var a = db.Setting.First();
            return new { AbstractTitle = a.AbstractTitle, AbstractText = a.AbstractText };
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IHttpActionResult SendProgress(string AbstractTitle, string AbstractText)
        {
            db.Setting.First().AbstractText = AbstractText;
            db.Setting.First().AbstractTitle = AbstractTitle;
            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public object GetGallery()
        {
            var a = db.Setting.First();
            return new { GalleryTitle = a.GalleryTitle, GalleryText = a.GalleryText };
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult SendGallery(string GalleryTitle, string GalleryText)
        {
            var a = db.Setting.First();
            a.GalleryText = GalleryText;
            a.GalleryTitle = GalleryTitle;
            db.SaveChanges();
            return Ok();

        }



        [HttpGet]
        public object GetExpert()
        {
            var a = db.Setting.First();
            return new { ExpertTitle = a.ExpertTitle, ExpertText = a.ExpertText };
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult SendExpert(string ExpertTitle, string ExpertText)
        {
            var a = db.Setting.First();
            a.ExpertText = ExpertText;
            a.ExpertTitle = ExpertTitle;
            db.SaveChanges();
            return Ok();

        }


        [HttpGet]
        public object GetNews()
        {
            var a = db.Setting.First();
            return new { NewsText = a.NewsText, NewsTitle = a.NewsTitle };
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult SendNews(string NewsTitle, string NewsText)
        {
            var a = db.Setting.First();
            a.NewsTitle = NewsTitle;
            a.NewsText = NewsText;
            db.SaveChanges();
            return Ok();

        }

        [HttpGet]
        public int GetAwardCount()
        {
            return db.Setting.First().AwardCount;
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult SetAwardCount(int id)
        {
            db.Setting.First().AwardCount = id;
            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public object GetAboutKefir()
        {
            var a = db.Setting.First();

            return new { AboutKefirTitle = a.AboutKefirTitle, AboutKefirText = a.AboutKefirText };
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult SetAboutKefir(JObject Obj)
        {
            var a = db.Setting.First();
            string text = Obj["AboutKefirText"].ToString().Replace("\n", "<br />");
            a.AboutKefirTitle = Obj["AboutKefirTitle"].ToString();
            a.AboutKefirText = text;
            db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public object GetCup()
        {

            var first = db.Setting.First();
            return new
            {

                CupTitle = first.CupTitle,

                CupFirstTitle = first.CupFirstTitle,
                CupFirstPercent = first.CupFirstPercent,

                CupSecoundTitle = first.CupSecoundTitle,
                CupSecoundPercent = first.CupSecoundPercent,

                CupThirdTitle = first.CupThirdTitle,
                CupThirdPercent = first.CupThirdPercent,

                CupFourthTitle = first.CupFourthTitle,
                CupFourthPercent = first.CupFourthPercent
            };


        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IHttpActionResult SetCup(JObject Cup)
        {
            var first = db.Setting.First();
            first.CupTitle = Cup["CupTitle"].ToString();
            first.CupFirstTitle = Cup["CupFirstTitle"].ToString();
            first.CupFirstPercent = float.Parse(Cup["CupFirstPercent"].ToString());
            first.CupSecoundTitle = Cup["CupSecoundTitle"].ToString();
            first.CupSecoundPercent = float.Parse(Cup["CupSecoundPercent"].ToString());
            first.CupThirdTitle = Cup["CupThirdTitle"].ToString();
            first.CupThirdPercent = float.Parse(Cup["CupThirdPercent"].ToString());
            first.CupFourthTitle = Cup["CupFourthTitle"].ToString();
            
            first.CupFourthPercent = float.Parse(Cup["CupFourthPercent"].ToString());
            db.SaveChanges();
            return Ok();
        }
    }
}

using KefirWebsite.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KefirWebsite.Controllers
{
    public class HomeController : Controller
    {
        DBContext db = new DBContext();
        void setData()
        {
            DBContext db = new DBContext();
            var first = db.Setting.FirstOrDefault();
            int UserCt = db.Users.Count();
            ViewBag.UserCount = UserCt;

            int Contact = db.ContactUs.Where(p => p.HasRead == true).Count();
            ViewBag.MessageCount = Contact;
            ViewBag.AwardCount = first.AwardCount;
            ViewBag.AboutKefirTitle = first.AboutKefirTitle;
            ViewBag.AboutKefirText = first.AboutKefirText;


            ViewBag.CupTitle = first.CupTitle;

            ViewBag.CupFirstTitle = first.CupFirstTitle;
            ViewBag.CupFirstPercent = first.CupFirstPercent.ToString().Replace('/','.');

            ViewBag.CupSecoundTitle = first.CupSecoundTitle;
            ViewBag.CupSecoundPercent = first.CupSecoundPercent.ToString().Replace('/', '.');

            ViewBag.CupThirdTitle = first.CupThirdTitle;
            ViewBag.CupThirdPercent = first.CupThirdPercent.ToString().Replace('/', '.');

            ViewBag.CupFourthTitle = first.CupFourthTitle;
            ViewBag.CupFourthPercent = first.CupFourthPercent.ToString().Replace('/', '.');
        }
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            setData();
            return View();
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Faq()
        {
            
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Question()
        {

            return View();
        }
        
        public ActionResult ActiveUser(string UserName,string Token)
        {
            string Message = "";
            var user = db.Users.SingleOrDefault(p=>p.UserName==UserName);
            if(user.guid.ToString()!=Token)
            {
                Message = "لینک وارد شده معتبر نیست";
            }
            else if(user.IsActive==true)
            {
                Message = "نام کاربری فعال است";
            }
            else
            {
                user.IsActive = true;
                db.SaveChanges();
                Message = "با موفقیت فعال شد";

            }
            ViewBag.Message = Message;
            return View();
        }


    }
}
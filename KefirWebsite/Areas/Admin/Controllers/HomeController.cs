using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KefirWebsite.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        void setData()
        {
            DBContext db = new DBContext();
            int UserCt = db.Users.Count();
            TempData["UserCount"] = UserCt;

            int Contact = db.ContactUs.Where(p => p.HasRead == false).Count();
            TempData["MessageCount"] = Contact;

            



        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            DBContext db = new DBContext();
            var a = db.Users.SingleOrDefault(p => p.UserName == User.Identity.Name);

            Session["UserName"] = a.UserFirstName + " " + a.UserLastName;
            setData();
            return View();
        }
        public ActionResult ManageProgress()
        {
            setData();
            return View();
        }
        public ActionResult ManageSlide()
        {
            return View();
        }
        public ActionResult ManageGallery()
        {
            setData();
            return View();
        }
        public ActionResult ManageExperts()
        {
            setData();
            return View();
        }
        public ActionResult ManageAbstracts()
        {
            setData();
            return View();
        }

        public ActionResult ManageNews()
        {
            setData();
            return View();
        }
        public ActionResult ManageUsers()
        {
            setData();
            return View();
        }
        public ActionResult ManageContactUs()
        {
            setData();
            return View();
        }
        public ActionResult ManageFaq()
        {
            setData();
            return View();
        }
        public ActionResult ManageAboutKefir()
        {
            setData();
            return View();
        }

        public ActionResult ManageCup()
        {
            setData();
            return View();
        }


    }
}
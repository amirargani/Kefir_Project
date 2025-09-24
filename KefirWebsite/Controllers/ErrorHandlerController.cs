using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KefirWebsite.Controllers
{
    public class ErrorHandlerController : Controller
    {
        // GET: CustomError
        public ActionResult Error(int? id)
        {

            if (id == 404)
            {
                ViewBag.ErrorText = "صفحه مورد نظر پیدا نشد";
                ViewBag.ErrorCode = 404;
            }
            else
            {
                ViewBag.ErrorCode = "خطا !";
            }
            return View();
        }
    }
}
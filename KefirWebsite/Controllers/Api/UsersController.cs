using KefirWebsite.Filter;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace KefirWebsite.Controllers.Api
{
    public class UsersController : ApiController
    {
        DBContext db = new DBContext();

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public Object GetUsers()
        {
            return db.Users.Include("role").Select(p => new { p.UserFirstName, p.UserEmail, p.UserId, p.UserLastName, p.UserName, p.role }).ToList();

        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult DeleteUser(int id)
        {
            if (id == 1) return BadRequest();
            var user = db.Users.Find(id);
            if (user == null)
            {
                return BadRequest();
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return Ok();
        }

        
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult RegisterAdmin(User usr)
        {
            User user;
            if (usr.UserId != 0)
            {
                user = db.Users.Find(usr.UserId);
               
            }
            else
            {
                user = new User();
                
            }
            user.Password = usr.Password;
            user.UserEmail = usr.UserEmail;
            user.UserFirstName = usr.UserFirstName;
            user.UserLastName = usr.UserLastName;
            user.UserName = usr.UserName;
            user.role = db.Roles.Find(1);
            if(usr.UserId==0)
                db.Users.Add(user);
            db.SaveChanges();
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IHttpActionResult RegisterMember(User usr)
        {
            

            User user;
            if (usr.UserId != 0)
            {
                user = db.Users.Find(usr.UserId);

            }
            else
            {
                user = new User();
            }
            user.Password = usr.Password;
            user.UserEmail = usr.UserEmail;
            user.UserFirstName = usr.UserFirstName;
            user.UserLastName = usr.UserLastName;
            user.UserName = usr.UserName;
            user.role = db.Roles.Find(2);
            if (usr.UserId == 0) db.Users.Add(user);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Register(User user)
        {

            if (db.Users.Any(p => p.UserName == user.UserName || p.UserEmail == user.UserEmail))
            {
                return BadRequest("اطلاعات شما در سیستم وجود دارد");
            }
            user.IsActive = false;
            user.role = db.Roles.Find(2);
            user.guid = Guid.NewGuid();
            db.Users.Add(user);
            db.SaveChanges();
            string href = "http://localhost:1760/Home/ActiveUser?UserName=" + user.UserName + "&Token=" + user.guid;
            Email email = new Email();
            List<string> list = new List<string>();
            list.Add(user.UserEmail);
            string body = "لینک فعالسازی برای شما ارسال گردیده است. چنانچه شما درخواست ثبتنام نکرده اید، به این ایمیل توجه نکنید<br />" + "<a target='_blank' href='" + href + "'>لینک فعالسازی</a>";
            try
            {
                email.Send(body, "لینک فعالسازی", list);
            }
            catch
            {
                db.Users.Remove(db.Users.Find(user.UserId));
                db.SaveChanges();
                ModelState.AddModelError("MyError", "عملیات مقدور نیست");
                throw new DbEntityValidationException();

              
            }
            return Ok();
        }
        
        [Authorize(Roles = "Administrator")]
        public Object GetUser(int id)
        {
            return db.Users.Include("role").Select(p => new { p.UserFirstName, p.UserEmail, p.UserId, p.UserLastName, p.UserName, p.role }).SingleOrDefault(p => p.UserId == id);
        }

        [HttpGet]
        public IHttpActionResult ForgetPass(string username)
        {
            var user = db.Users.SingleOrDefault(p => p.UserName == username);
            if(user==null || user.IsActive==false)
            {
                return BadRequest("اطلاعات شما موجود نیست");
            }
            Email email = new Email();
            List<string> list = new List<string>();
            list.Add(user.UserEmail);
            try
            {
                email.Send("رمز عبور شما : <br />" + user.Password, "بازیابی رمز عبور", list);
            }
            catch
            {

                ModelState.AddModelError("MyError", "عملیات مقدور نیست");
                throw new DbEntityValidationException();
            }
            return Ok();
        }


    }
}

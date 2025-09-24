using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KefirWebsite.Controllers.Api
{
    [Authorize]
    public class FAQController : ApiController
    {
        DBContext db = new DBContext();
        [HttpGet]
        public List<Faq> GetFAQs(bool HasAnswer=true)
        {
            if (HasAnswer)
                return db.Faqs.Where(p => p.Answer != null).ToList(); 
            return db.Faqs.Where(p => p.Answer == null).ToList(); ;
        }

        [HttpGet]
        public IHttpActionResult SendQuestion(string Question)
        {
            if (Question == null) return Ok("مقادیر ورودی صحیح نیست");
            string[] NewWords = Question.Split(' ');
            var list = db.Faqs.Where(p=>p.Answer!=null).ToList();

            //first is index and secound is ct%
            int[] Key = {-1,-1 };
            
            for (int i = 0; i < list.Count; i++)
            {
                int ct = 0;
                string[] oldWords = list[i].QuestionText.Split(' ');
                for (int j = 0; j < NewWords.Length; j++)
                {
                    for (int k = 0; k < oldWords.Length; k++)
                    {
                        if (NewWords[j].Equals(oldWords[k]))
                        {
                            ct++;
                        }
                    }
                }
                int persent = ct*100 / oldWords.Length;
                if(Key[1]<persent)
                {
                    Key[0] = i;
                    Key[1] = persent;
                }
            }

            if(Key[0]==-1||Key[1]<50)
            {
                db.Faqs.Add(new Faq() {QuestionText=Question,Answer=null });
                db.SaveChanges();
                return Ok("سوال شما در سیستم ثبت شد");
            }
            else
            {
                string answer = list[Key[0]].Answer;
                return Ok(answer);
            }

        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IHttpActionResult ChangeQuestion(int id , string answer)
        {
                db.Faqs.Find(id).Answer = answer;
                db.SaveChanges();
                return Ok();
        }

        [HttpGet]
        public Faq GetFaq(int id)
        {
            return db.Faqs.Find(id);
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IHttpActionResult DeleteData(int id)
        {
            db.Faqs.Remove(db.Faqs.Find(id));
            db.SaveChanges();
            return Ok();
        }
    }
}

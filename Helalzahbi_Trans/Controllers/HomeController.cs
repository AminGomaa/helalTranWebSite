using Helalzahbi_Trans.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Helalzahbi_Trans.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Details(int jobid)
        {
            var job = db.Jobs.Find(jobid);
            if (job == null)
            {
                HttpNotFound();

            }
            Session["jobid"] = jobid;
            return View(job);
            
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModel contact)
        {
            var mail = new MailMessage();
            var logInfo = new NetworkCredential("amingomaatube@gmail.com", "0106933724");
            mail.From = new MailAddress(contact.Email);
            mail.To.Add(new MailAddress("egyking2006@gmail.com"));
            mail.Subject = contact.Object;
            mail.IsBodyHtml = true;
            string body = "اسم الرسل: " + contact.Name + "<br>" +
                "بريد الرسل: " + contact.Email + "<br>" +
                "عنوان الرسالة: " + contact.Object + "<br>" +
                "نص الرسالة: <b>" + contact.Message+"</b>";
            mail.Body = body;
            var smtpclient = new SmtpClient("smtp.gmail.com", 587);
            smtpclient.EnableSsl = true;
            smtpclient.Credentials = logInfo;
            smtpclient.Send(mail);
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(string message)
        {
            var userId = User.Identity.GetUserId();
            var jobid = (int)Session["jobid"];
            var job = new ApplyForJob();
            job.JobId = jobid;
            job.UserId = userId;
            job.Message = message;
            job.ApplyDate = DateTime.Now;
            db.ApplyForJobs.Add(job);
            db.SaveChanges();
            ViewBag.Result = "تم ارسال طلبكم وسوف نرسل لكم الرد في اقرب وقت ممكن";
            return View();
            
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string searchName)
        {
            var result = db.Jobs.Where(a => a.jobcontent.Contains(searchName) || a.jobtitl.Contains(searchName) || a.category.categName.Contains(searchName)).ToList();
            return View(result);
        }

    }
}
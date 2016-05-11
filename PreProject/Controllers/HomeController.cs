using System.Web.Mvc;
using System.Net.Mail;
using PreProject.Models;
using System.Text;
using System;

namespace IdentitySample.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModels c)
        {
            //ViewBag.Message = "Your contact page.";
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    SmtpClient client = new SmtpClient();
                    //Use Gmail as smtp client
                    client.Host = "Smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new System.Net.NetworkCredential("chenyu.zhao1993@gmail.com","3202530zcy");
                    MailAddress from = new MailAddress(c.Email.ToString());
                    StringBuilder sb = new StringBuilder();
                    msg.To.Add("chenyu.zhao1993@gmail.com");
                    msg.Subject = "Contact Us";
                    msg.IsBodyHtml = false;
                    //smtp.Host = "mail.yourdomain.com";
                    //smtp.Port = 25;
                    sb.Append("First name: " + c.Name);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + c.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append("Message: " + c.Message);
                    msg.Body = sb.ToString();
                    client.Send(msg);
                    msg.Dispose();
                    return View("Success");
                }
                catch (Exception)
                {
                    return View("Error");
                }

            }

            return View();
        }
    }
}

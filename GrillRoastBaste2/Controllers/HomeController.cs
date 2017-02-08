using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrillRoastBaste2.Models;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc.Html;

namespace GrillRoastBaste2.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        //TO-DO: add functionality for admins to upload/delete menus from the menus section
        public ActionResult Menus()
        {
            return View();
        }

        public ActionResult OurStory()
        {
            return View();
        }


        [HttpGet]
        public ViewResult Book()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Book(CustomerSubmition customerSubmition)
        {
            if (ModelState.IsValid)
            { 
                customerSubmition.DateOfBooking = DateTime.Now; //Set the date and time when the booking is made

                var body = "<p>Hello! <strong>" + customerSubmition.Name + " " + customerSubmition.SurName + 
                    "</strong>, " + "Thank you for choosing GrillRoastBaste for your event.<br> One of our dedicated team members will be in touch</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(customerSubmition.Email));
                message.From = new MailAddress("mattsykesbbg@gmail.com"); //Change to grillroastbaste email
                message.Subject = "Booking Enquiry Confirmation GrillRoastBaste";
                message.Body = body; //need to add footer to email for contact links
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient()) //Smtp set up and send
                {
                    var credential = new NetworkCredential()
                    {
                        UserName = "mattsykesbbg@gmail.com", //change for grillroastbaste user + pass
                        Password = "stunl0ck123" //need to store credentials more securely in a Database
                    };

                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                }

                using (var context = new CustomerDbContext()) //uses the db context to add the customer sub to the db
                {
                    context.Customers.Add(customerSubmition);
                    context.SaveChanges();
                }

                return View("ThankYou", customerSubmition);
            }
            else
            {
                return View();
            }
        }



    }
}
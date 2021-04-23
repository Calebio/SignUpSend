using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net;
using System.Net.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignUpSend.Models;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace SignUpSend.Pages
{
    public class SignUpModel : PageModel
    {
        public void OnGet()
        {

        }
        [BindProperty]
        public ContactInfo sendmail { get; set; }
        public void OnPost()
        {
            string FirstName = sendmail.FirstName;
            string LastName = sendmail.LastName;
            string To = sendmail.Email;
            //string Subject = sendmail.Subject;
            //string Body = sendmail.Body;
            string UserEmail = sendmail.Email;
            string Phone = sendmail.Phone;

            MailMessage mm = new MailMessage();
            mm.To.Add(UserEmail);
            mm.Subject = ("Registration");
            mm.Body = ("Dear"+" "+ FirstName + ", "+"Welcome to Our Platform, we look forward to doing good business with you! Cheers!!");
            mm.IsBodyHtml = true;
            mm.From = new MailAddress("fellakuti7@gmail.com");  // passed the useremail as parameter to be the from 

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("fellakuti7@gmail.com", "@Caleb55446");
            smtp.SendMailAsync(mm);
            ViewData["Message"] = "Sign Up successful!";

        }
    }
}
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Diagnostics;
using TaxiMalinWebApp.Data;
using TaxiMalinWebApp.Models;

namespace TaxiMalinWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDataContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDataContext context)
        {
            _logger = logger;
            _context = context; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation([Bind("Id,Name,Email,NumeroTelephone,NbrePassager,AdresseDepart,AdresseDestination,DateReservation,SelectTime")] Reservation formulaireModel)
        {

            //if (ModelState.IsValid)
            //{
            //    formulaireModel.Id = Guid.NewGuid();
            //    _context.Add(formulaireModel);
            //    //
            //    //var apiKey = Environment.GetEnvironmentVariable("aU880WpsROyxRk9IK4Zidg.WqjmpjdkW_9KowXiFOyDPZS0AAYiCb2rTotPvBZa8KM");
            //    //var client = new SendGridClient("aU880WpsROyxRk9IK4Zidg.WqjmpjdkW_9KowXiFOyDPZS0AAYiCb2rTotPvBZa8KM");
            //    //var from = new EmailAddress(formulaireModel.AdresseCourriel, formulaireModel.Nom);
            //    //var subject = "Sending with SendGrid is Fun";
            //    //var to = new EmailAddress("j.veret@hotmail.fr", "Julien");
            //    //var plainTextContent = String.Format("une course de {0} à {1} a la date suivante : {2} confimer avec la personne au {3}", formulaireModel.Depart, formulaireModel.Destination, formulaireModel.Date, formulaireModel.NumeroTelephone);
            //    //var htmlContent = "<h1>Reservation entrante</h1>";
            //    //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //    //var response = await client.SendEmailAsync(msg);

            //    //var sendGridClient = new SendGridClient("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");
            //    //var from = new EmailAddress(formulaireModel.Email, formulaireModel.Name);
            //    //var subject = "subject";
            //    //var to = new EmailAddress("j.veret@hotmail.fr", "Julien");
            //    //var plainContent = String.Format("une course de {0} à {1} a la date suivante : {2} confimer avec la personne à {3}", formulaireModel.AdresseDepart, formulaireModel.AdresseDestination, formulaireModel.DateReservation, formulaireModel.SelectTime);
            //    //var htmlContent = "<h1>Reservation entrante</h1>";
            //    //var mailMessage = MailHelper.CreateSingleEmail(from, to, subject, plainContent, htmlContent);
            //    //await sendGridClient.SendEmailAsync(mailMessage);



            //    //await _context.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //var apiKey = Environment.GetEnvironmentVariable("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");
            var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse(formulaireModel.Email));
            email.From.Add(MailboxAddress.Parse("j.veret@hotmail.fr"));
            email.To.Add(MailboxAddress.Parse("j.veret@hotmail.fr"));
           //email.Subject = String.Format("une course de {0} à {1} a la date suivante : {2} confimer avec la personne à {3}", formulaireModel.AdresseDepart, formulaireModel.AdresseDestination, formulaireModel.DateReservation, formulaireModel.SelectTime);
            email.Subject = String.Format("test des emails");
           // email.Body = new TextPart(TextFormat.Plain) { Text = String.Format("une course de {0} à {1} a la date suivante : {2} confimer avec la personne à {3}", formulaireModel.AdresseDepart, formulaireModel.AdresseDestination, formulaireModel.DateReservation, formulaireModel.SelectTime) };
            email.Body = new TextPart(TextFormat.Plain) { Text = "teste body" };

            // send email
            using var smtp = new SmtpClient();
            //smtp.Host = "";
            //smtp.Port = "";
            //smtp.Credentials = "";
            smtp.Connect("smtp.sendgrid.net", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("apikey","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");
            smtp.Send(email);
            smtp.Disconnect(true);
            return RedirectToAction("Index");

        }

        public IActionResult ReserverCourse()
        {
            return View();
        }
    }
}
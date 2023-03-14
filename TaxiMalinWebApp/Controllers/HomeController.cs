using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Utilities;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReservation([Bind("Id,Name,Email,NumeroTelephone,NbrePassager,AdresseDepart,AdresseDestination,DateReservation,SelectTime,AgreementIsChecked")] Reservation formulaireModel)
        {

            if (ModelState.IsValid)
            {
                //formulaireModel.Id = Guid.NewGuid();
                //_context.Add(formulaireModel);
                //creation email
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("j.veret@hotmail.fr"));
                email.To.Add(MailboxAddress.Parse("taximalin91@gmail.com"));
                email.Subject = String.Format("Reservation");
                email.Body = new TextPart(TextFormat.Plain) { Text = String.Format("reservation recu de {0} pour le {1} a {2},  a venir chercher a {3} et a emmener a {4} pour {5} personnes, a confirmer avec aux {6} ou par courriel aux {7}", formulaireModel.Name, formulaireModel.DateReservation, formulaireModel.SelectTime, formulaireModel.AdresseDepart, formulaireModel.AdresseDestination, formulaireModel.NbrePassager.ToString(), formulaireModel.NumeroTelephone, formulaireModel.Email) };
                // send email
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.sendgrid.net", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("apikey", "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");
                smtp.Send(email);
                smtp.Disconnect(true);

                //_context.SaveChanges();
               // ModelState.Clear();
                return  RedirectToAction("ReservationAjouter");
            }
            return RedirectToAction("Index");
        }
        //public MimeMessage CreerCourrielReservation(string? nom, DateTime? date, DateTime? temps, string? telephone,string? email, string? pointDeDepart, string? Destination, int? nbrepassager)
        //{
        //    var mess = new MimeMessage();
        //    mess.From.Add(MailboxAddress.Parse("j.veret@hotmail.fr"));
        //    mess.To.Add(MailboxAddress.Parse("mfshack0@gmail.com"));
        //    mess.Subject = String.Format("Reservation");
        //    mess.Body = new TextPart(TextFormat.Plain) { Text = String.Format("reservation recu de {0} pour le {1} a {2}, \n a venir chercher a {3} et a emmener a {4} pour {5} personnes, a confirmer avec aux {6} ou par courriel aux {}", nom, date, temps, pointDeDepart,Destination, nbrepassager, telephone, email) };
        //    return mess;
        //}

        public IActionResult ReserverCourse()
        {
            
            return View();
        }

        //public async Task<IActionResult> Contact([Bind("Id,Nom,Email,NumeroTelephone,Sujet,Message")] ObjetPerduMessageModel ObjetPerdu)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    Message.Id = Guid.NewGuid();
        //    //    _context.Add(Message);
        //    //    _context.SaveChanges();
        //    //}
        //    return View();
        //}
        public IActionResult Contact()
        {
            
            return View();
        }
        public IActionResult ReservationAjouter()
        {
            return View();
        }

        public IActionResult MentionsLegales()
        {
            return View();
        }
        public IActionResult PolitiquesConfidentialites()
        {
            return View();
        }
        public IActionResult Apropos()
        {
            return View();
        }
        public IActionResult Faq()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
    }
}
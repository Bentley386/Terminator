using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TerminiDostave.Models;

namespace TerminiDostave.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Kontakti")]
        public ActionResult Kontakti()
        {
            ViewBag.Message = "Kontaktne informacije.";

            return View();
        }
        [Authorize]
        [Route("Termini")]
        public ActionResult Termini()
        {
            string UserId = User.Identity.Name;
            var db = new ApplicationDbContext();
            var comp = db.Users.Where(i => i.UserName == UserId).First().Company;
            ViewBag.company = comp;
            var data = TermModel.LoadFromDatabase();
            return View(data);
        }

        [Route("TerminIzbriši")]
        public ActionResult TerminIzbrisi(TermModel model)
        {
            TermModel.DeleteFromDatabase(model.TrackingNumber);
            return RedirectToAction("Termini");

        }
        [Route("TerminPotrdi")]
        public ActionResult TerminPotrdi(TermModel model)
        {
            TermModel.UpdateDatabaseStatus("Sprejeto",model.TrackingNumber);
            return RedirectToAction("Termini");
        }

        [Route("TerminZavrni")]
        public ActionResult TerminZavrni(TermModel model)
        {
            TermModel.UpdateDatabaseStatus("Zavrnjeno", model.TrackingNumber);
            return RedirectToAction("Termini");
        }

        [Route("TerminUredi")]
        public ActionResult TerminUredi(TermModel model)
        {
            return View(TermModel.LoadFromDatabaseByTrack(model.TrackingNumber));
        }

        [Route("TerminUredi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TerminUredi2(TermModel model)
        {
            if (User.IsInRole("Skladiscnik")) model.UpdateDatabaseSklad();
            else model.UpdateDatabase();
            return RedirectToAction("Termini");
        }

        [Route("TerminPodrobnosti")]
        public ActionResult TerminPodrobnosti(TermModel model)
        {
            return View(TermModel.LoadFromDatabaseByTrack(model.TrackingNumber));
        }

        [Route("NovTermin")]
        public ActionResult NarediTermin()
        {
            if (Request.IsAuthenticated)
            {
                string UserId = User.Identity.Name;
                var db = new ApplicationDbContext();
                var juzer = db.Users.Where(i => i.UserName == UserId).First();
                TermModel TModel = new TermModel
                {
                    FirstName = juzer.FirstName,
                    Lastname = juzer.LastName,
                    Company = juzer.Company,
                    Telephone = juzer.Telephone,
                    DeliveryTime = DateTime.Now.AddDays(2)
                };
                return View(TModel);
            }
            return View();
        }

        [Route("NovTermin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NarediTermin(TermModel model)
        {
            if (ModelState.IsValid)
            {
                model.InsertIntoDatabase();
                int Ident = TermModel.LoadFromDatabaseLast();
                int trackNum = TermModel.GetTrackFromId(Ident);
                return RedirectToAction("TerminPodrobnosti", new { TrackingNumber = trackNum });
            }

            return View();
        }
        [Route("Novzaposleni")]
        public ActionResult DodajZaposlenega()
        {
            return View();
        }

        [Route("Novzaposleni")]
        [HttpPost]
        public ActionResult DodajZaposlenega(string Email, string roles)
        {
            var db = new ApplicationDbContext();
            var user = db.Users.Where(i => i.UserName == Email).First();
            if (user is null)
            {
                return View();

            }
            else
            {
                if (roles == "Administrator") ApplicationUser.giveRole(user.Id, "1");
                else if (roles == "Skladiscnik") ApplicationUser.giveRole(user.Id, "2");

            }
            return View();
        }
    }

}
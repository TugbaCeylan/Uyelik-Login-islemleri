using MVCUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUser.Controllers
{
    public class HomeController : Controller
    {
        TDesignEntities db = new TDesignEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User item)
        {

            if (ModelState.IsValid)
            {
                item.RoleID = 1;
                item.IsDeleted = false;
                item.CreateDate= DateTime.Now;

                db.Users.Add(item);
                bool sonuc = db.SaveChanges() > 0;
                if (sonuc)
                {
                    TempData["Message"] = FxFonksiyon.GetInformation(MessageFormat.OK);
                    return RedirectToAction("Create", "Home");
                }
                else
                {
                    TempData["Message"] = FxFonksiyon.GetInformation(MessageFormat.Err);
                }
            }
            else
            {
                TempData["Message"] = FxFonksiyon.GetInformation(MessageFormat.Val);
            }
            return View(item);
        }

        public ActionResult Login(User _model)
        {
            if (db.Users.Any(u => u.UserName == _model.UserName && u.Password == _model.Password))
            {
                //TODO : 1. si yeterli cast etmelisin.
                User girisYapan = db.Users.Where(u => u.UserName == _model.UserName && u.Password == _model.Password).FirstOrDefault();
                Session["oturum"] = girisYapan;
                Session["ad"] = girisYapan.FirstName;
                Session["soyad"] = girisYapan.LastName;
                Session["id"] = girisYapan.UserID;
                Session["rolId"] = girisYapan.RoleID;


                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Exit()
        {
            Session.Abandon();
            return RedirectToAction("Create", "Home");
        }

        public ActionResult Forget(User _model)
        {
            if (db.Users.Any(u => u.UserName == _model.UserName && u.Email == _model.Email && u.PasswordQuestion == _model.PasswordQuestion && u.PaswordAnswer == _model.PaswordAnswer))
            {

                User sifreUnutan = db.Users.Where(u => u.UserName == _model.UserName && u.Email == _model.Email && u.PasswordQuestion == _model.PasswordQuestion && u.PaswordAnswer == _model.PaswordAnswer).FirstOrDefault();


                TempData["Message"] = Convert.ToString(sifreUnutan.Password);
                return View();
      
            }
            TempData["Message"] = "Tekrar Deneyiniz";
            return View();

        }

	}


}
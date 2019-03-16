using Projekt.Models;
using Projekt.Models.BusinessLayer;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projekt.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM vm, string ReturnUrl)
        {
            UzytkownikBL newBL = new UzytkownikBL();
            if (newBL.isValidUser(vm.Username, vm.Passwrd))
            {
                FormsAuthentication.SetAuthCookie(vm.Username, false);
                if (ReturnUrl == null)
                    ReturnUrl = Url.Action("Index","Home");
                return Redirect(ReturnUrl);
            }
            ModelState.AddModelError("CredentialError", "Niepoprawna nazwa użytkownika lub hasło");
            return View("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            RegisterVM tmp = new RegisterVM();
            return View(tmp);
        }

        [HttpPost]
        public ActionResult Create(RegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                if(!(vm.Passwrd == vm.PowtorzonePasswrd))
                {
                    vm.WrongPowtorzenieMassege = "Błednie powtorzone hasło!";
                    vm.ExistsUserMassege = "";
                    return View(vm);
                }
                UzytkownikBL userBL = new UzytkownikBL();

                if(userBL.IfExistsUzytkownikOfUsername(vm.Username))
                {
                    vm.ExistsUserMassege = "Użytkownik o takim nicku już istnieje!";
                    vm.WrongPowtorzenieMassege = "";
                    return View(vm);
                }

                userBL.AddUzytkownik(
                    new Uzytkownik {
                        Username = vm.Username,
                        Email = vm.Email,
                        Name = vm.Name,
                        Surname = vm.Surname,
                        IsAdmin = false,
                        PhoneNumber = vm.PhoneNumber,
                        HashedPasswrd = FormsAuthentication.HashPasswordForStoringInConfigFile(vm.Passwrd, "md5")
                    });

                return RedirectToAction("Index","Home");
            }

            vm.WrongPowtorzenieMassege = "";
            vm.ExistsUserMassege = "";

            return View(vm);
        }
    }
}
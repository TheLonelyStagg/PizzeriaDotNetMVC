using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Projekt.DAL;
using Projekt.Models;
using Projekt.Models.BusinessLayer;
using Projekt.ViewModels;

namespace Projekt.Controllers
{
    [Authorize]
    public class UzytkowniksController : Controller
    {

        // GET: Produkts
        public ActionResult Index()
        {
            UzytkownikBL uzytkownikBL = new UzytkownikBL();
            if (uzytkownikBL.getRoleOfUser(User.Identity.Name) == "Admin")
            {
                UzytkowniksListVM vm = new UzytkowniksListVM();
                vm.uzytkowniks = uzytkownikBL.GetUzytkowniks();

                return View(vm);
            }
            return View("Error");

        }

        public ActionResult Create()
        {
            UzytkownikBL uzytkownikBL = new UzytkownikBL();
            if (uzytkownikBL.getRoleOfUser(User.Identity.Name) == "Admin")
            {
                UzytkowniksCreateVM vm = new UzytkowniksCreateVM();
                vm.IsAdmin = false;
                return View(vm);
            }
            return View("Error");

        }

        [HttpPost]
        public ActionResult Create(UzytkowniksCreateVM vm)
        {

            if (ModelState.IsValid)
            {
                UzytkownikBL userBL = new UzytkownikBL();
                if (userBL.IfExistsUzytkownikOfUsername(vm.Username))
                {
                    vm.ExistsUserMassege = "Użytkownik o takim nicku już istnieje!";
                    return View(vm);
                }
                userBL.AddUzytkownik(
                    new Uzytkownik
                    {
                        Username = vm.Username,
                        Email = vm.Email,
                        Name = vm.Name,
                        Surname = vm.Surname,
                        IsAdmin = vm.IsAdmin,
                        PhoneNumber = vm.PhoneNumber,
                        HashedPasswrd = FormsAuthentication.HashPasswordForStoringInConfigFile(vm.Passwrd, "md5")
                    });

                return RedirectToAction("Index");
            }
            
            vm.ExistsUserMassege = "";

            return View(vm);
        }

        public ActionResult Edit(int id)
        {
            UzytkownikBL uzytkownikBL = new UzytkownikBL();
            if (uzytkownikBL.getRoleOfUser(User.Identity.Name) == "Admin")
            {

                UzytkowniksEditVM vm = new UzytkowniksEditVM();
                vm.uzytkownik = uzytkownikBL.FindUzytkownikByID(id);
                
                return View("Edit", vm);
            }
            return View("Error");

        }


        [HttpPost]
        public ActionResult Edit(UzytkowniksEditVM vm)
        {

            if (ModelState.IsValid)
            {
                UzytkownikBL uzytkownikBL = new UzytkownikBL();
                
                uzytkownikBL.EditUzytkownik(vm.uzytkownik); 
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            UzytkownikBL uzytkownikBL = new UzytkownikBL();
            if (uzytkownikBL.getRoleOfUser(User.Identity.Name) == "Admin")
            {
                
                if (uzytkownikBL.IfExistsUzytkownikOfID(id))
                {
                    uzytkownikBL.RemoveUzytkownik(id);
                    return RedirectToAction("Index");
                }
                else
                    return RedirectToAction("Index");
            }
            return View("Error");


        }
    }
}

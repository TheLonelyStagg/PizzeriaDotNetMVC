using Projekt.DAL;
using Projekt.Models.BusinessLayer;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }

        [ChildActionOnly]
         public ActionResult ZawartoscDropdownMenu()
        {
            UzytkownikBL uzytkownikBL = new UzytkownikBL();

            switch (uzytkownikBL.getRoleOfUser(User.Identity.Name))
            {
                case "Admin":
                    {
                        if (Session["Koszyk"] == null)
                        {
                            Session["Koszyk"] = new KoszykVM();
                        }
                        return PartialView("_NavDropdownMenuAdmin");
                    }
                    
                case "User":
                    {
                        if(Session["Koszyk"] == null)
                        {
                            Session["Koszyk"] = new KoszykVM();
                        }

                        LoggedUserVM loggedUVM = new LoggedUserVM {
                            LoggedUserUsername = User.Identity.Name,
                            iloscProduktowWKoszyku = (Session["Koszyk"] as KoszykVM).iloscRazem
                        };

                        return PartialView("_NavDropdownMenuUser",loggedUVM);
                    }
                    
                default:
                    return PartialView("_NavDropdownMenu");
            }
            
        }

        public ActionResult Menu()
        {
            UzytkownikBL uzytkownikBL = new UzytkownikBL();

            switch (uzytkownikBL.getRoleOfUser(User.Identity.Name))
            {
                case "Admin":
                        return RedirectToAction("Index", "Produkts", new { area = "" });
                case "User":
                    {
                        ProduktBL produktBL = new ProduktBL();
                        MenuUserVM vm = new MenuUserVM(produktBL.GetProdukts());
                        if(!String.IsNullOrEmpty((Session["Koszyk"] as KoszykVM).massege))
                        {
                            vm.massage = (Session["Koszyk"] as KoszykVM).massege;
                            (Session["Koszyk"] as KoszykVM).massege = "";
                        }
                        return View("MenuUser", vm);
                    }
                default:
                    return RedirectToAction("MenuDefault");
                    
            }
            
        }

        

        public ActionResult MenuDefault()
        {
            ProduktBL produktBL = new ProduktBL();
            MenuUserVM vm = new MenuUserVM(produktBL.GetProdukts());
            return View("MenuDefault", vm);
        }

        [Authorize]
        public ActionResult AddToKoszyk(int id)
        {
            (Session["Koszyk"] as KoszykVM).AddToKoszyk(id);
            (Session["Koszyk"] as KoszykVM).massege = "Dodano pozycję do koszyka.";
            return RedirectToAction("Menu");
        }

        [Authorize]
        public ActionResult Koszyk()
        {
            if (Session["Koszyk"] == null)
            {
                Session["Koszyk"] = new KoszykVM();
            }

            KoszykListVM vm = new KoszykListVM();
            vm.idProduktu_Ilosc = (Session["Koszyk"] as KoszykVM).koszyk.ilosciProduktow;
            vm.produktBL = new ProduktBL();
            vm.kwotaRazem = (Session["Koszyk"] as KoszykVM).kosztaRazem;
            
            
            
            return View(vm);
        }

        [Authorize]
        public ActionResult KoszykAdd(int id)
        {
            if (Session["Koszyk"] == null)
            {
                Session["Koszyk"] = new KoszykVM();
            }

            (Session["Koszyk"] as KoszykVM).AddToKoszyk(id);

            return RedirectToAction("Koszyk");
        }

        [Authorize]
        public ActionResult KoszykRemove(int id)
        {
            if (Session["Koszyk"] == null)
            {
                Session["Koszyk"] = new KoszykVM();
            }

            (Session["Koszyk"] as KoszykVM).RemoveFromKoszyk(id);

            return RedirectToAction("Koszyk");
        }
    }
}
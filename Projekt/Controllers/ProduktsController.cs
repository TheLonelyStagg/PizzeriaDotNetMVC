using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekt.DAL;
using Projekt.Models;
using Projekt.Models.BusinessLayer;
using Projekt.ViewModels;

namespace Projekt.Controllers
{
    [Authorize]
    public class ProduktsController : Controller
    {

        // GET: Produkts
        public ActionResult Index()
        {
            UzytkownikBL uzytkownikBL = new UzytkownikBL();
            if (uzytkownikBL.getRoleOfUser(User.Identity.Name)=="Admin")
            {
                ProduktBL produktBL = new ProduktBL();

                ProduktsListVM vm = new ProduktsListVM();
                vm.produkts = produktBL.GetProdukts().OrderBy( x => x.Category).ToList();

                return View(vm);
            }
            return View("Error");

        }

        public ActionResult Create()
        {
            UzytkownikBL uzytkownikBL = new UzytkownikBL();
            if (uzytkownikBL.getRoleOfUser(User.Identity.Name) == "Admin")
            {
                ProduktsCreateVM vm = new ProduktsCreateVM();
                return View(vm);
            }
            return View("Error");

        }

        [HttpPost]
        public ActionResult Create(ProduktsCreateVM vm)
        {
            
            if (ModelState.IsValid)
            {
                ProduktBL produktBL = new ProduktBL();
                if (produktBL.NumberForKategoriaProduktu(vm.produkt.Category) == 0)
                    vm.produkt.Category = "" + produktBL.NewNumberForKategoriaProduktu() + "_" + vm.produkt.Category;
                else
                    vm.produkt.Category = "" + produktBL.NumberForKategoriaProduktu(vm.produkt.Category) + "_" + vm.produkt.Category;
                produktBL.AddProdukt(vm.produkt);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        public ActionResult Edit(int id)
        {
            UzytkownikBL uzytkownikBL = new UzytkownikBL();
            if (uzytkownikBL.getRoleOfUser(User.Identity.Name) == "Admin")
            {
                ProduktBL produktBL = new ProduktBL();
                ProduktsCreateVM vm = new ProduktsCreateVM();

                vm.produkt = produktBL.FindProduktByID(id);

                vm.produkt.Category = produktBL.NazwaKategorii(vm.produkt.Category);

                return View("Edit",vm);
            }
            return View("Error");

        }


        [HttpPost]
        public ActionResult Edit(ProduktsCreateVM vm)
        {

            if (ModelState.IsValid)
            {
                ProduktBL produktBL = new ProduktBL();
                if(produktBL.NumberForKategoriaProduktu(vm.produkt.Category)==0)
                    vm.produkt.Category = "" + produktBL.NewNumberForKategoriaProduktu()+"_"+ vm.produkt.Category;
                else
                    vm.produkt.Category = "" + produktBL.NumberForKategoriaProduktu(vm.produkt.Category) + "_" + vm.produkt.Category;
                
                produktBL.EditProdukt(vm.produkt);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            UzytkownikBL uzytkownikBL = new UzytkownikBL();
            if (uzytkownikBL.getRoleOfUser(User.Identity.Name) == "Admin")
            {
                ProduktBL produktBL = new ProduktBL();
                if (produktBL.IfExistsProduktOfID(id))
                {
                    produktBL.RemoveProdukt(id);
                    return RedirectToAction("Index");
                }
                else
                    return RedirectToAction("Index");
            }
            return View("Error");


        }
    }
}

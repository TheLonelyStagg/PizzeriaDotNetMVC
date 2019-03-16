using Projekt.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Models.BusinessLayer
{
    public class ProduktBL
    {
        public List<Produkt> GetProdukts()
        {
            DaneContext db = new DaneContext();
            return db.Produkts.ToList();
        }

        public void AddProdukt(Produkt p)
        {
            DaneContext db = new DaneContext();
            db.Produkts.Add(p);
            db.SaveChanges();
        }

        public Produkt FindProduktByID(int id_)
        {
            DaneContext db = new DaneContext();
            Produkt tmp = db.Produkts.Where(u => u.ProduktId == id_).Single();
            return tmp;
        }

        public bool IfExistsProduktOfID(int id_)
        {
            DaneContext db = new DaneContext();
            return db.Produkts.ToList().Exists(u => u.ProduktId == id_);
        }

        public void RemoveProdukt(int id_)
        {
            DaneContext db = new DaneContext();
            Produkt tmp = db.Produkts.Where(u => u.ProduktId == id_).Single();
            db.Produkts.Remove(tmp);
            db.SaveChanges();
        }

        public void EditProdukt(Produkt u)
        {
            DaneContext db = new DaneContext();
            db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public int NumberForKategoriaProduktu(string _kategoria) //zwrocone 0 - brak takiej kategorii
        {
            DaneContext db = new DaneContext();
            if(db.Produkts.ToList().Exists(u => u.Category.EndsWith(_kategoria)))
            {
                Produkt tmp = db.Produkts.Where(u => u.Category.EndsWith(_kategoria)).First();
                int i_tmp;
                Int32.TryParse((tmp.Category.Split('_'))[0],out i_tmp);
                return i_tmp;
            }
            return 0;
        }

        public int NewNumberForKategoriaProduktu()
        {
            DaneContext db = new DaneContext();
            if(db.Produkts.Count()!=0)
            {
                string last = db.Produkts.ToList().OrderBy(a => a.Category).Last().Category;
                int i_tmp;
                Int32.TryParse((last.Split('_'))[0], out i_tmp);
                return i_tmp + 1;
            }
            return 1;  
        }

        public string NazwaKategorii(string _kategoria)
        {
            if(!String.IsNullOrWhiteSpace(_kategoria))
            {
                return _kategoria.Split('_')[1];
            }
            return "";
        }
    }
}
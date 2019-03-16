using Projekt.Models;
using Projekt.Models.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.ViewModels
{
    public class KoszykListVM
    {
        public Dictionary<int, int> idProduktu_Ilosc { get; set; }
        public double kwotaRazem { get; set; }
        
        public ProduktBL produktBL { get; set; }

        public Dictionary<Produkt,int> produkt_Ilosc {
            get
            {
                Dictionary<Produkt, int> tmp = new Dictionary<Produkt, int>();
                ProduktBL pBL = new ProduktBL();
                foreach (var x in idProduktu_Ilosc)
                {
                    tmp.Add(pBL.FindProduktByID(x.Key), x.Value);
                }
                return tmp;
            }
        }
    }
}
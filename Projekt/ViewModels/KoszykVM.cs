using Projekt.Models;
using Projekt.Models.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.ViewModels
{
    public class KoszykVM 
    {
        public Koszyk koszyk = new Koszyk();
        public string massege = "";

        public double kosztaRazem
        {
            get
            {
                if (koszyk.ilosciProduktow.Count() == 0)
                    return 0;
                double suma = 0;
                ProduktBL produktBL = new ProduktBL();
                foreach (var x in koszyk.ilosciProduktow)
                {
                    suma = suma + (x.Value * produktBL.FindProduktByID(x.Key).basePrice);
                }
                return suma;
            }
        }

        public int iloscRazem
        {
            get
            {
                if (koszyk.ilosciProduktow==null)
                    return 0;
                int tmp=0;
                foreach (var x in koszyk.ilosciProduktow)
                {
                    tmp = tmp + x.Value;
                }
                return tmp;
            }
        }

        public void AddToKoszyk (int _idProduktu)
        {
            if(koszyk.ilosciProduktow.ContainsKey(_idProduktu))
            {
                koszyk.ilosciProduktow[_idProduktu]++;
                return;
            }
            koszyk.ilosciProduktow.Add(_idProduktu, 1);
            return;
        }

        public void RemoveFromKoszyk(int _idProduktu)
        {
            if (koszyk.ilosciProduktow.ContainsKey(_idProduktu))
            {
                if(koszyk.ilosciProduktow[_idProduktu]<=1)
                {
                    koszyk.ilosciProduktow.Remove(_idProduktu);
                    return;
                }
                koszyk.ilosciProduktow[_idProduktu]--;
                return;
            }
            return;
        }

    }
}
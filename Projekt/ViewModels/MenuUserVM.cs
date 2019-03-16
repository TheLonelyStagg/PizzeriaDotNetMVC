using Projekt.Models;
using Projekt.Models.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.ViewModels
{
    public class MenuUserVM
    {
        public MenuUserVM()
        { }

        public MenuUserVM(List<Produkt> _produkts)
        {
            produktBL = new ProduktBL();
            produkts = _produkts;
            dicKategoriaProdukt = new Dictionary<string, List<Produkt>>();
            massage = "";
            
            foreach (var x in produkts.OrderBy(x => x.Category))
            {
                if (!dicKategoriaProdukt.ContainsKey(x.Category))
                {
                    dicKategoriaProdukt.Add(x.Category, new List<Produkt>());
                    dicKategoriaProdukt[x.Category].Add(x);
                }
                else
                {
                    dicKategoriaProdukt[x.Category].Add(x);
                }
            }
        }

        public List<Produkt> produkts { get; set; }

        public Dictionary<string, List<Produkt>> dicKategoriaProdukt { get; set; }

        public ProduktBL produktBL { get; set; }

        public string massage { get; set; }
    }
}
using Projekt.Models.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Koszyk
    {
        public Koszyk() { ilosciProduktow = new Dictionary<int, int>(); }
        public Dictionary<int, int> ilosciProduktow { get; set; }




    }
}
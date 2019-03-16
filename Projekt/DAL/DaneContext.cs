using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projekt.DAL
{
    public class DaneContext : DbContext
    {
        public DaneContext() : base("ProduktyConnectionString")
        { }

        public DbSet<Produkt> Produkts { get; set; }
        public DbSet<Uzytkownik> Uzytkowniks { get; set; }
    }
}
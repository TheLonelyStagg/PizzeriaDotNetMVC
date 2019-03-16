using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Produkt
    {
        [Key]
        [Display(Name = "ID")]
        public int ProduktId { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage ="Wymagana nazwa produktu!")]
        [StringLength(35)]
        public string Name { get; set; }

        [Display(Name = "Składniki")]
        [StringLength(150)]
        public string Description { get; set; }

        [Display(Name = "Kategoria")]
        [StringLength(35)]
        public string Category { get; set; } //numer_nazwa np 1_Pizza, 2_Salatka

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Wymagana cena produktu!")]
        public double basePrice { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana!")]
        [StringLength(35)]
        public string Username { get; set; }

        [Display(Name = "Haslo")]
        [Required(ErrorMessage = "Hasło jest wymagane!")]
        [StringLength(35)]
        public string Passwrd { get; set; }

        [Display(Name = "Adres e-mail")]
        [Required(ErrorMessage = "Adres e-mail jest wymagany!")]
        [EmailAddress(ErrorMessage = "Zły format adresu e-mail")]
        public string Email { get; set; }

        [Display(Name = "Imię")]
        [StringLength(35)]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [StringLength(35)]
        public string Surname { get; set; }

        [Display(Name = "Numer telefonu")]
        [Required(ErrorMessage = "Numer telefonu jest wymagany!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Zły format numeru telefonu!")]
        public string PhoneNumber { get; set; }

        //---------------------------------------------------------------------

        [Display(Name = "Powtórz haslo")]
        [Required(ErrorMessage = "Powtórzenie jest wymagane!")]
        [StringLength(35)]
        public string PowtorzonePasswrd { get; set; }

        public string WrongPowtorzenieMassege { get; set; }

        public string ExistsUserMassege { get; set; }
    }
}
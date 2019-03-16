using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana!")]
        [StringLength(35)]
        public string Username { get; set; }

        [Display(Name = "Haslo")]
        [Required(ErrorMessage = "Hasło jest wymagane!")]
        [StringLength(35)]
        public string Passwrd { get; set; }


    }
}
using Projekt.Models;
using Projekt.Models.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.ViewModels
{
    public class LoggedUserVM
    {

        public string LoggedUserUsername { get; set; }

        public int iloscProduktowWKoszyku { get; set; }

        public string UserCalling
        {
            get
            {
                UzytkownikBL uBL = new UzytkownikBL();
                Uzytkownik tmp = uBL.FindUzytkownikByUsername(LoggedUserUsername);
                string result="";
                if(!String.IsNullOrWhiteSpace(tmp.Name)&&!String.IsNullOrWhiteSpace(tmp.Surname))
                {
                    result = "" + tmp.Name + " " + tmp.Surname[0] + ". ";
                    if (result.Length > 10)
                        result = "";
                }

                result = result + "(" + tmp.Username + ")";
                if (result.Length > 25)
                    result = "";
                return result;
            }
        }

    }
}
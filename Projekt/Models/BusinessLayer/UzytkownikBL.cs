using Projekt.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Projekt.Models.BusinessLayer
{
    public class UzytkownikBL
    {

        public List<Uzytkownik> GetUzytkowniks()
        {
            DaneContext db = new DaneContext();
            return db.Uzytkowniks.ToList();
        }

        public void AddUzytkownik(Uzytkownik p)
        {
            DaneContext db = new DaneContext();
            db.Entry(p).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }

        public Uzytkownik FindUzytkownikByID(int id_)
        {
            DaneContext db = new DaneContext();
            Uzytkownik tmp = db.Uzytkowniks.Where(u => u.UzytkownikId == id_).Single();
            return tmp;
        }

        
        public Uzytkownik FindUzytkownikByUsername(string _username)
        {
            DaneContext db = new DaneContext();
            Uzytkownik tmp = db.Uzytkowniks.Where(u => u.Username == _username).Single();
            return tmp;
        }

        public bool IfExistsUzytkownikOfID(int id_)
        {
            DaneContext db = new DaneContext();
            return db.Uzytkowniks.ToList().Exists(u => u.UzytkownikId == id_);
        }

        public bool IfExistsUzytkownikOfUsername(string _username)
        {
            DaneContext db = new DaneContext();
            return db.Uzytkowniks.ToList().Exists(u => u.Username == _username);
        }

        public void RemoveUzytkownik(int id_)
        {
            DaneContext db = new DaneContext();
            Uzytkownik tmp = db.Uzytkowniks.Where(u => u.UzytkownikId == id_).Single();
            db.Uzytkowniks.Remove(tmp);
            db.SaveChanges();
        }

        public void EditUzytkownik(Uzytkownik u)
        {
            DaneContext db = new DaneContext();
            db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public bool isValidUser(string username, string plainPassword)
        {
            DaneContext db = new DaneContext();

            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(plainPassword))
            {
                string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(plainPassword, "md5");
                if (db.Uzytkowniks.ToList().Exists(u => u.Username == username && u.HashedPasswrd == hashedPassword))
                {
                    return true;
                }
            }
            return false;
        }

        public string getRoleOfUser(string username)
        {
            DaneContext db = new DaneContext();
            if (!String.IsNullOrEmpty(username) && db.Uzytkowniks.ToList().Exists(u => u.Username == username))
            {
                string tmp="";
                if (db.Uzytkowniks.Where(u => u.Username == username).Single().IsAdmin)
                    tmp = "Admin";
                else tmp = "User";

                return tmp;
            }
            return null;
        }




    }
}
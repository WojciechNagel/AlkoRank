using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication11.Models
{
    public class Wino
    {
        public int WinoId { get; set; }
        public string Nazwa { get; set; }
        [SprawdzRok] public int RokProdukcji { get; set; }
        public int Ocena { get; set; }
        public int Cena { get; set; }
    }

    public class SprawdzRok : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int rok = (int) value;
            if (rok < 1500 || rok > System.DateTime.Now.Year)
            {
                return false;
            }
            else
                return true;
        }

        public SprawdzRok()
        {
            ErrorMessage = "W tym roku nie stworzono zadnego wina";
        }




    }
}
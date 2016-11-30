using AutoReservation.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoReservation.Dal.Entities;



namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TESDT");
            using (var db = new AutoReservationContext())
            {
               var Kunde = new Kunde { Id = 1, Nachname = "Hans", Vorname = "Ueli", Geburtsdatum = new DateTime(1999,10,12)};
                var Auto = new LuxusAuto { Id = 1, Marke = "BMW", Tagestarif = 10, Basistarif = 10};
                db.Kunden.Add(Kunde);
                db.Autos.Add(Auto);
                Console.WriteLine("TEST2");
                db.SaveChanges();
               
            }
        }
    }
}

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
               var Kunde = new Kunde { Id = 1, Nachname = "Spast", Vorname = "Ueli", Geburtsdatum = new DateTime(1999,10,12)};
                db.Kunden.Add(Kunde);
                Console.WriteLine("TEST2");
                db.SaveChanges();

   

               
            }
        }
    }
}

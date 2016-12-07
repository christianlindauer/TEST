using AutoReservation.Dal;
using AutoReservation.Dal.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {
 

        private static LocalOptimisticConcurrencyException<T> CreateLocalOptimisticConcurrencyException<T>(AutoReservationContext context, T entity)
            where T : class
        {
            var dbEntity = (T)context.Entry(entity)
                .GetDatabaseValues()
                .ToObject();

            return new LocalOptimisticConcurrencyException<T>($"Update {typeof(Auto).Name}: Concurrency-Fehler", dbEntity);
        }


        // Car
        public List<Auto> getAllCars() {
            List<Auto> listOfAllCars = new List<Auto>();
            using (var db = new AutoReservationContext()) {
                var query = from Auto auto in db.Autos
                                           select auto;
                foreach(Auto car in query){
                    listOfAllCars.Add(car);
                }                                             
                return listOfAllCars;                                       
            }
        }
        public Auto getCarByPrimaryKey(int key) {            
            using (var db = new AutoReservationContext())
            {
                var query = from Auto auto in db.Autos
                            where auto.Id == key
                            select auto;

                foreach (Auto car in query) {
                    return car;
                }
                return null;
            }
        }

        public void addCar(Auto car) {
            using (var db = new AutoReservationContext())
            {
                db.Entry(car).State = EntityState.Added;
                db.Autos.Add(car);
                db.SaveChanges();
            }
        }

        public void updateCar(Auto car) {
            using (var db = new AutoReservationContext())
            {
                try
                {
                    db.Entry(car).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw CreateLocalOptimisticConcurrencyException(db, car);
                }
            }
        }

        public void deleteCar(Auto car) {
            using (var db = new AutoReservationContext())
            {
                db.Entry(car).State = EntityState.Deleted;
                db.Autos.Remove(car);
                db.SaveChanges();
            }
        }

        // Customer
        public List<Kunde> getAllCustomers() {
            List<Kunde> listOfAllCustomers = new List<Kunde>();
            using (var db = new AutoReservationContext())
            {
                var query = from Kunde kunde in db.Kunden
                            select kunde;
                foreach (Kunde customer in query)
                {
                    listOfAllCustomers.Add(customer);
                }
                return listOfAllCustomers;
            }
        }

        public Kunde getCustomerByPrimaryKey(int key) {
            using (var db = new AutoReservationContext())
            {
                var query = from Kunde kunde in db.Kunden
                            where kunde.Id == key
                            select kunde;

                foreach (Kunde customer in query)
                {
                    return customer;
                }
                return null;
            }
        }

        public void addCustomer(Kunde customer) {
            using (var db = new AutoReservationContext())
            {
                db.Entry(customer).State = EntityState.Added;
                db.Kunden.Add(customer);
                db.SaveChanges();
            }
        }

        public void updateCustomer(Kunde customer) {
            using (var db = new AutoReservationContext())
            {
                try
                {
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw CreateLocalOptimisticConcurrencyException(db, customer);
                }
            }
        }

        public void deleteCustomer(Kunde customer) {
            using (var db = new AutoReservationContext())
            {
                db.Entry(customer).State = EntityState.Deleted;
                db.Kunden.Remove(customer);
                db.SaveChanges();
            }
        }

        // Reservation
        public List<Reservation> getAllReservations() {
            List<Reservation> listOfReservations = new List<Reservation>();
            using (var db = new AutoReservationContext())
            {
                var query = from Reservation res in db.Reservationen
                            select res;
                foreach (Reservation res in query)
                {
                    listOfReservations.Add(res);
                }
                return listOfReservations;
            }
        }

        public Reservation getReservationByPrimaryKey(int key) {
            using (var db = new AutoReservationContext())
            {
                var query = from Reservation res in db.Reservationen
                            where res.ReservationsNr == key
                            select res;

                foreach (Reservation res in query)
                {
                    return res;
                }
                return null;
            }
        }

        public void addReservation(Reservation reservation) {
            using (var db = new AutoReservationContext())
            {
                db.Entry(reservation).State = EntityState.Added;
                db.Reservationen.Add(reservation);
                db.SaveChanges();
            }
        }

        public void updateReservation(Reservation reservation) {
            using (var db = new AutoReservationContext())
            {
                try
                {
                    db.Entry(reservation).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw CreateLocalOptimisticConcurrencyException(db, reservation);
                }
            }
        }

        public void deleteReservation(Reservation reservation) {
            using (var db = new AutoReservationContext())
            {
                db.Entry(reservation).State = EntityState.Deleted;
                db.Reservationen.Remove(reservation);
                db.SaveChanges();
            }
        }
    }
}
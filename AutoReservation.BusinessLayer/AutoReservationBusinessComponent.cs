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
        public List<Kunde> getAllCustomers() { return null; }

        public Kunde getCustomerByPrimaryKey(int key) { return null; }

        public void addCustomer(Kunde customer) { }

        public void updateCustomer(Kunde customer) { }

        public void deleteCustomer(Kunde customer) { }

        // Reservation
        public List<Reservation> getAllReservations() { return null; }

        public Reservation getReservationByPrimaryKey(int key) { return null; }

        public void addReservation(Reservation reservation) { }

        public void updateReservation(Reservation reservation) { }

        public void deleteReservation(Reservation reservation) { }
    }
}
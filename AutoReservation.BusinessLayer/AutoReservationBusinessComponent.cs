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
        public List<Auto> getAllCars() { return null; }
        public Auto getCarByPrimaryKey(int key) { return null; }

        public void addCar(Auto car) { }

        public void updateCar(Auto car) { }

        public void deleteCar(Auto car) { }

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
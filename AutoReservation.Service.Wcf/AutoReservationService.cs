using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.BusinessLayer;
using AutoReservation.Dal.Entities;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        AutoReservationBusinessComponent Component;

        public AutoReservationService()
        {
            Component = new AutoReservationBusinessComponent();
        }
        
        private static void WriteActualMethod()
        {
            Console.WriteLine($"Calling: {new StackTrace().GetFrame(1).GetMethod().Name}");
        }

        public void addCar(AutoDto car)
        {
            WriteActualMethod();
            Component.addCar(DtoConverter.ConvertToEntity(car));
   
        }

        public void addCustomer(KundeDto customer)
        {
            WriteActualMethod();
            Component.addCustomer(DtoConverter.ConvertToEntity(customer));
        }

        public void addReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            Component.addReservation(DtoConverter.ConvertToEntity(reservation));
        }

        public void deleteCar(AutoDto car)
        {
            WriteActualMethod();
            Component.deleteCar(DtoConverter.ConvertToEntity(car));
        }

        public void deleteCustomer(KundeDto customer)
        {
            WriteActualMethod();
            Component.deleteCustomer(DtoConverter.ConvertToEntity(customer));
        }

        public void deleteReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            Component.deleteReservation(DtoConverter.ConvertToEntity(reservation));
        }

        public List<AutoDto> getAllCars()
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDtos(Component.getAllCars());
        }

        public List<KundeDto> getAllCustomers()
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDtos(Component.getAllCustomers());
        }

        public List<ReservationDto> getAllReservations()
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDtos(Component.getAllReservations());
        }

        public AutoDto getCarByPrimaryKey(int key)
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDto(Component.getCarByPrimaryKey(key));
        }

        public KundeDto getCustomerByPrimaryKey(int key)
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDto(Component.getCustomerByPrimaryKey(key));
        }

        public ReservationDto getReservationByPrimaryKey(int key)
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDto(Component.getReservationByPrimaryKey(key));
        }

        public void updateCar(AutoDto car)
        {
            WriteActualMethod();
            try
            {
                Component.updateCar(DtoConverter.ConvertToEntity(car));
            }
            catch (LocalOptimisticConcurrencyException<Auto> ex)
            {
                throw new FaultException<LocalOptimisticConcurrencyException<Auto>>(ex, ex.Message);
            }
           
        }

        public void updateCustomer(KundeDto customer)
        {
            WriteActualMethod();
            try
            {
                Component.updateCustomer(DtoConverter.ConvertToEntity(customer));
            }
            catch(LocalOptimisticConcurrencyException<Kunde> ex)
            {
                throw new FaultException<LocalOptimisticConcurrencyException<Kunde>>(ex, ex.Message);
            }
            
        }

        public void updateReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            try
            {
                Component.updateReservation(DtoConverter.ConvertToEntity(reservation));
            }
            catch (LocalOptimisticConcurrencyException<Reservation> ex)
            {
                throw new FaultException<LocalOptimisticConcurrencyException<Reservation>>(ex,ex.Message);
            }
           
        }
    }
}
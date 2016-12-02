using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.BusinessLayer;
using AutoReservation.Dal.Entities;

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
            throw new NotImplementedException();
        }

        public void addReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        public void deleteCar(AutoDto car)
        {
            WriteActualMethod();
            Component.deleteCar(DtoConverter.ConvertToEntity(car));
        }

        public void deleteCustomer(KundeDto customer)
        {
            throw new NotImplementedException();
        }

        public void deleteReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        public List<AutoDto> getAllCars()
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDtos(Component.getAllCars());
        }

        public List<KundeDto> getAllCustomers()
        {
            throw new NotImplementedException();
        }

        public List<ReservationDto> getAllReservations()
        {
            throw new NotImplementedException();
        }

        public AutoDto getCarByPrimaryKey(int key)
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDto(Component.getCarByPrimaryKey(key));
        }

        public KundeDto getCustomerByPrimaryKey(int key)
        {
            throw new NotImplementedException();
        }

        public ReservationDto getReservationByPrimaryKey(int key)
        {
            throw new NotImplementedException();
        }

        public void updateCar(AutoDto car)
        {
            WriteActualMethod();
            Component.updateCar(DtoConverter.ConvertToEntity(car));
        }

        public void updateCustomer(KundeDto customer)
        {
            throw new NotImplementedException();
        }

        public void updateReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }
    }
}
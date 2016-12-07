//using System;
//using System.Collections.Generic;
//using AutoReservation.Common.DataTransferObjects;
//using AutoReservation.Common.Interfaces;

//namespace AutoReservation.Ui.Factory
//{
//    public class NullServiceFactory : IServiceFactory
//    {
//        public IAutoReservationService GetService()
//        {
//            return new NullAutoReservationService();
//        }
//    }

//    public class NullAutoReservationService : IAutoReservationService
//    {
//        public List<AutoDto> getAllCars() => new List<AutoDto>();
//        public List<KundeDto> getAllCustomers() => new List<KundeDto>();
//        public List<ReservationDto> getAllReservations() => new List<ReservationDto>();
//        public AutoDto getCarByPrimaryKey(int key) => null;
//        public KundeDto getCustomerByPrimaryKey(int key) => null;
//        public ReservationDto getReservationByPrimaryKey(int key) => null;
//        //public AutoDto addCar(AutoDto car) => null;
//        //public KundeDto addCustomer(KundeDto customer) => null;
//        //public ReservationDto addReservation(ReservationDto reservation) => null;
//        //public AutoDto updateCar(AutoDto car) => null;
//        //public KundeDto updateCustomer(KundeDto customer) => null;
//        //public ReservationDto updateReservation(ReservationDto reservation) => null;
//        public void deleteCar(AutoDto car) { }
//        public void deleteCustomer(KundeDto customer) { }
//        public void deleteReservation(ReservationDto reservation) { }

//        void IAutoReservationService.addCar(AutoDto car)
//        {
//        }

//        void IAutoReservationService.updateCar(AutoDto car)
//        {
//        }

//        void IAutoReservationService.addCustomer(KundeDto customer)
//        {
//        }

//        void IAutoReservationService.updateCustomer(KundeDto customer)
//        {
//        }

//        void IAutoReservationService.addReservation(ReservationDto reservation)
//        {
//        }

//        void IAutoReservationService.updateReservation(ReservationDto reservation)
//        {
//        }
//    }
//}

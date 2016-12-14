using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Dal.Entities;
using System.Collections.Generic;
using System.ServiceModel;


namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        // Car
        [OperationContract]
        List<AutoDto> getAllCars();

        [OperationContract]
        AutoDto getCarByPrimaryKey(int key);

        [OperationContract]
        void addCar(AutoDto car);

        [OperationContract]
        [FaultContract(typeof(LocalOptimisticConcurrencyException<Auto>))]
        void updateCar(AutoDto car);

        [OperationContract]
        void deleteCar(AutoDto car);

        // Customer
        [OperationContract]
        List<KundeDto> getAllCustomers();

        [OperationContract]
        KundeDto getCustomerByPrimaryKey(int key);

        [OperationContract]
        void addCustomer(KundeDto customer);

        [OperationContract]
        [FaultContract(typeof(LocalOptimisticConcurrencyException<Kunde>))]
        void updateCustomer(KundeDto customer);

        [OperationContract]
        void deleteCustomer(KundeDto customer);

        // Reservation
        [OperationContract]
        List<ReservationDto> getAllReservations();

        [OperationContract]
        ReservationDto getReservationByPrimaryKey(int key);

        [OperationContract]
        void addReservation(ReservationDto reservation);

        [OperationContract]
        [FaultContract(typeof(LocalOptimisticConcurrencyException<Reservation>))]
        void updateReservation(ReservationDto reservation);

        [OperationContract]
        void deleteReservation(ReservationDto reservation);
    }
}

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
        void addCar(Auto car);

        [OperationContract]
        void updateCar(Auto car);

        [OperationContract]
        void deleteCar(Auto car);

        // Customer
        [OperationContract]
        List<KundeDto> getAllCustomers();

        [OperationContract]
        KundeDto getCustomerByPrimaryKey(int key);

        [OperationContract]
        void addCustomer(Kunde customer);

        [OperationContract]
        void updateCustomer(Kunde customer);

        [OperationContract]
        void deleteCustomer(Kunde customer));

        // Reservation
        [OperationContract]
        List<ReservationDto> getAllReservations();

        [OperationContract]
        ReservationDto getReservationByPrimaryKey(int key);

        [OperationContract]
        void addReservation(Reservation reservation);

        [OperationContract]
        void updateReservation(Reservation reservation);

        [OperationContract]
        void deleteReservation(Reservation reservation);
    }
}

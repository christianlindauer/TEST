using AutoReservation.Common.DataTransferObjects;
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
        void updateCar(AutoDto car);

        [OperationContract]
        void deleteCar(AutoDto car);

        // Customer
        [OperationContract]
        List<KundeDto> getAllCustomers();

        [OperationContract]
        KundeDto getCustomerByPrimaryKey(int key);

        [OperationContract]
        void addCustomer(KundeDto car);

        [OperationContract]
        void updateCustomer(KundeDto car);

        [OperationContract]
        void deleteCustomer(KundeDto car);

        // Reservation
        [OperationContract]
        List<ReservationDto> getAllReservations();

        [OperationContract]
        ReservationDto getReservationByPrimaryKey(int key);

        [OperationContract]
        void addReservation(ReservationDto car);

        [OperationContract]
        void updateReservation(ReservationDto car);

        [OperationContract]
        void deleteReservation(ReservationDto car);
    }
}

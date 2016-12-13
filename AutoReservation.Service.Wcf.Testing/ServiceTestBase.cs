using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoReservation.Dal.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }
        AutoReservationService Service;
        const double DELTA = 0.1;

        [TestInitialize]
        public void InitializeTestData()
        {
            Service = new AutoReservationService();
            TestEnvironmentHelper.InitializeTestData();
        }

        #region Read all entities

        [TestMethod]
        public void GetAutosTest()
        {
            List<AutoDto> allCars = new List<AutoDto>();
            allCars = Service.getAllCars();

            Assert.AreEqual(3, allCars.Count, DELTA);
        }

        [TestMethod]
        public void GetKundenTest()
        {
            List<KundeDto> allCustomers = new List<KundeDto>();
            allCustomers = Service.getAllCustomers();

            Assert.AreEqual(4, allCustomers.Count, DELTA);
        }

        [TestMethod]
        public void GetReservationenTest()
        {
            List<ReservationDto> allReserverations = new List<ReservationDto>();
            allReserverations = Service.getAllReservations();

            Assert.AreEqual(3, allReserverations.Count, DELTA);
        }

        #endregion

        #region Get by existing ID

        [TestMethod]
        public void GetAutoByIdTest()
        {
            int id = 1;
            Assert.AreEqual(id, Service.getCarByPrimaryKey(id).Id, DELTA);
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            int id = 1;
            Assert.AreEqual(id, Service.getCustomerByPrimaryKey(id).Id, DELTA);
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            int id = 1;
            Assert.AreEqual(id, Service.getReservationByPrimaryKey(id).ReservationsNr, DELTA);
        }

        #endregion

        #region Get by not existing ID

        [TestMethod]
        public void GetAutoByIdWithIllegalIdTest()
        {
            int id = 0;
            Assert.AreSame(null, Service.getCarByPrimaryKey(id));
        }

        [TestMethod]
        public void GetKundeByIdWithIllegalIdTest()
        {
            int id = 0;
            Assert.AreSame(null, Service.getCustomerByPrimaryKey(id));
        }

        [TestMethod]
        public void GetReservationByNrWithIllegalIdTest()
        {
            int id = 0;
            Assert.AreSame(null, Service.getReservationByPrimaryKey(id));
        }

        #endregion

        #region Insert

        [TestMethod]
        public void InsertAutoTest()
        {
            AutoDto car = new AutoDto();
            car.Marke = "HarambeCar";
            car.Tagestarif = 200;
            car.Id = 4;
            car.AutoKlasse = AutoKlasse.Mittelklasse;
            Service.addCar(car);
            AutoDto testingCar = Service.getCarByPrimaryKey(4);
            Assert.AreEqual(testingCar.Id, 4);
            Assert.AreEqual(testingCar.Marke, "HarambeCar");
            Assert.AreEqual(testingCar.Tagestarif, 200);
            Assert.AreEqual(testingCar.AutoKlasse, AutoKlasse.Mittelklasse);
                        
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            KundeDto customer = new KundeDto();
            customer.Id = 5;
            customer.Nachname = "Obama";
            customer.Vorname = "Barack";
            customer.Geburtsdatum = new DateTime(1981, 05, 05);
            Service.addCustomer(customer);
            KundeDto testingCustomer = Service.getCustomerByPrimaryKey(5);
            Assert.AreEqual(testingCustomer.Id, 5);
            Assert.AreEqual(testingCustomer.Nachname, "Obama");
            Assert.AreEqual(testingCustomer.Vorname, "Barack");
            Assert.AreEqual(testingCustomer.Geburtsdatum, new DateTime(1981, 05, 05));
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            ReservationDto reservation = new ReservationDto();
            reservation.Auto = Service.getCarByPrimaryKey(1);
            reservation.Kunde = Service.getCustomerByPrimaryKey(1);
            
            reservation.Von = new DateTime(1981, 05, 05);
            reservation.Bis = new DateTime(1981, 05, 05);
            Service.addReservation(reservation);
            ReservationDto testingReservation = Service.getReservationByPrimaryKey(4);
            Assert.AreEqual(testingReservation.ReservationsNr, 4);
            Assert.AreEqual(testingReservation.Kunde.Id, 1);
            Assert.AreEqual(testingReservation.Kunde.Nachname, "Nass");
            Assert.AreEqual(testingReservation.Von, new DateTime(1981, 05, 05));
            Assert.AreEqual(testingReservation.Bis, new DateTime(1981, 05, 05));
        }

        #endregion

        #region Delete  

        [TestMethod]
        public void DeleteAutoTest()
        {
            AutoDto testingCar = Service.getCarByPrimaryKey(3);
            Service.deleteCar(testingCar);
            Assert.IsNull(Service.getCarByPrimaryKey(3));

        }

        [TestMethod]
        public void DeleteKundeTest()
        {
            KundeDto testingCustomer = Service.getCustomerByPrimaryKey(3);
            Service.deleteCustomer(testingCustomer);
            Assert.IsNull(Service.getCustomerByPrimaryKey(3));
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            ReservationDto testingReservation = Service.getReservationByPrimaryKey(3);
            Service.deleteReservation(testingReservation);
            Assert.IsNull(Service.getReservationByPrimaryKey(3));
        }

        #endregion

        #region Update

        [TestMethod]
        public void UpdateAutoTest()
        {
            AutoDto testingCar = Service.getCarByPrimaryKey(2);
            testingCar.Marke = "KimJongUnCar";
            Service.updateCar(testingCar);
            Assert.AreEqual(Service.getCarByPrimaryKey(2).Marke, "KimJongUnCar");
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            KundeDto testingCustomer = Service.getCustomerByPrimaryKey(1);
            testingCustomer.Nachname = "KimJongUn";
            Service.updateCustomer(testingCustomer);
            Assert.AreEqual(Service.getCustomerByPrimaryKey(1).Nachname, "KimJongUn");
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            ReservationDto testingReservation = Service.getReservationByPrimaryKey(1);
            testingReservation.Kunde = Service.getCustomerByPrimaryKey(2);
            Service.updateReservation(testingReservation);
            Assert.AreEqual(Service.getReservationByPrimaryKey(1).Kunde.Id, 2, DELTA);
        }

        #endregion

        #region Update with optimistic concurrency violation

        [TestMethod]
        [ExpectedException(typeof(LocalOptimisticConcurrencyException<Auto>))]
        public void UpdateAutoWithOptimisticConcurrencyTest()
        {
            AutoDto testingCar1 = Service.getCarByPrimaryKey(1);
            AutoDto testingCar2 = Service.getCarByPrimaryKey(1);
            testingCar1.Marke = "Trabant";
            testingCar2.Marke = "DominikCar";
            Service.updateCar(testingCar1);
            Service.updateCar(testingCar2);
        }

        [TestMethod]
        [ExpectedException(typeof(LocalOptimisticConcurrencyException<Kunde>))]
        public void UpdateKundeWithOptimisticConcurrencyTest()
        {
            KundeDto testingCustomer1 = Service.getCustomerByPrimaryKey(1);
            KundeDto testingCustomer2 = Service.getCustomerByPrimaryKey(1);
            testingCustomer1.Nachname = "Clinton";
            testingCustomer2.Nachname = "Gollum";
            Service.updateCustomer(testingCustomer1);
            Service.updateCustomer(testingCustomer2);
        }

        [TestMethod]
        [ExpectedException(typeof(LocalOptimisticConcurrencyException<Reservation>))]
        public void UpdateReservationWithOptimisticConcurrencyTest()
        {
            ReservationDto testingReservation1 = Service.getReservationByPrimaryKey(1);
            ReservationDto testingReservation2 = Service.getReservationByPrimaryKey(1);
            testingReservation1.Kunde = Service.getCustomerByPrimaryKey(2);
            testingReservation2.Kunde = Service.getCustomerByPrimaryKey(3);
            Service.updateReservation(testingReservation1);
            Service.updateReservation(testingReservation2);
        }

        #endregion
    }
}

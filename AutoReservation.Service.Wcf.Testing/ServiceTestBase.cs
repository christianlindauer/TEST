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

            Assert.AreEqual(3, allCars.Count, 0.1);
        }

        [TestMethod]
        public void GetKundenTest()
        {
            //Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void GetReservationenTest()
        {
            //Assert.Inconclusive("Test not implemented.");
        }

        #endregion

        #region Get by existing ID

        [TestMethod]
        public void GetAutoByIdTest()
        {
            int id = 1;

            Assert.AreEqual(id, Service.getCarByPrimaryKey(id).Id, 0.1);
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            //Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            //Assert.Inconclusive("Test not implemented.");
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
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void GetReservationByNrWithIllegalIdTest()
        {
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
            testingCar.RowVersion = null;
            Assert.AreEqual(testingCar.Id, 4);
            Assert.AreEqual(testingCar.Marke, "HarambeCar");
            Assert.AreEqual(testingCar.Tagestarif, 200);
            Assert.AreEqual(testingCar.AutoKlasse, AutoKlasse.Mittelklasse);
                        
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            //Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            Assert.Inconclusive("Test not implemented.");
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
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            Assert.Inconclusive("Test not implemented.");
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
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Assert.Inconclusive("Test not implemented.");
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
        public void UpdateKundeWithOptimisticConcurrencyTest()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void UpdateReservationWithOptimisticConcurrencyTest()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        #endregion
    }
}

using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {

        private AutoReservationBusinessComponent target;
        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }
        
        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void UpdateAutoTest()
        {
            Auto car = Target.getCarByPrimaryKey(1);
            car.Marke = "BMW";
            Target.updateCar(car);
            car = Target.getCarByPrimaryKey(1);
            Assert.AreEqual("BMW", car.Marke);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            Kunde customer = Target.getCustomerByPrimaryKey(1);
            customer.Nachname = "Hampelmann";
            Target.updateCustomer(customer);
            customer = Target.getCustomerByPrimaryKey(1);
            Assert.AreEqual("Hampelmann", customer.Nachname);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Reservation reservation = Target.getReservationByPrimaryKey(1);
            reservation.Von = new DateTime(2010, 12, 10);
            Target.updateReservation(reservation);
            reservation = Target.getReservationByPrimaryKey(1);
            Assert.AreEqual(new DateTime(2010, 12, 10), reservation.Von);            
        }
    }
}

using AirportDispatcher.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AirportDispatcherLibraryTests
{
    [TestClass]
    public class RegFlightTest
    {
        [TestMethod]
        public void RegFlight_TrueString_True()
        {
            //Accert
            int idAirline = 2;
            DateTime day = DateTime.Today.AddDays(14);
            string all = "150";
            string remain = "80";
            int airportTo = 2;
            int airportFrom = 1;
            //Act
            RegFlights obj = new RegFlights();
            bool res = obj.RegFlight(idAirline,airportFrom, airportTo, all, remain, day);
            //Assert
            Assert.IsTrue(res);
        }
    }
}

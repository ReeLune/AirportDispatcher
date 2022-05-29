using AirportDispatcher.ViewModel;
using AirportDispatcherLibraryTests.ModelTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AirportDispatcherLibraryTests
{
    [TestClass]
    public class RegFlightTests
    {
        [TestMethod]
        public void RegFlight_EmptyString_Exception()
        {
            /// <summary>
            /// Проверка регистрации авиарейса
            /// </summary>
            /// <param>
            /// int airline = 0; int airportFrom = 0; int airportTo = 0; string allPlaces = String.Empty; string remainPlaces = String.Empty; DateTime dateTime = new DateTime();
            /// </param>
            /// <return>
            /// Исключение, так как пустые строки
            /// </return>
            //Accept
            int airline = 0;
            int airportFrom = 0;
            int airportTo = 0;
            string allPlaces = String.Empty;
            string remainPlaces = String.Empty;
            DateTime dateTime = new DateTime();
            //Act
            RegFlights obj = new RegFlights();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.RegFlight(airline, airportFrom, airportTo, allPlaces, remainPlaces, dateTime));
        }
        [TestMethod]
        public void RegFlight_CorrectString_True()
        {
            /// <summary>
            /// Проверка количества мест в самолет
            /// </summary>
            /// <param>
            /// int airline = 1; int airportFrom = 2; int airportTo = 3; string allPlaces = "150"; string remainPlaces = "50"; DateTime dateTime = DateTime.Today.AddDays(2).AddHours(15).AddMinutes(43);
            /// </param>
            /// <return>
            /// True
            /// </return>
            //Accept
            int airline = 1;
            int airportFrom = 2;
            int airportTo = 3;
            string allPlaces = "150";
            string remainPlaces = "50";
            DateTime dateTime = DateTime.Today.AddDays(2).AddHours(15).AddMinutes(43);
            //Act
            RegFlights obj = new RegFlights();
            bool res = obj.RegFlight(airline, airportFrom, airportTo, allPlaces, remainPlaces, dateTime);
            //Assert
            Assert.IsTrue(res);
            bool delete = obj.DeleteFlight(dateTime);
        }
        [TestMethod]
        public void RegFlight_SameAirport_Exception()
        {
            /// <summary>
            /// Проверка регистрации авиарейса
            /// </summary>
            /// <param>
            /// int airline = 1; int airportFrom = 1; int airportTo = 1; string allPlaces = String.Empty; string remainPlaces = String.Empty; 
            /// DateTime dateTime = new DateTime();
            /// </param>
            /// <return>
            /// Исключение, так как пустые строки
            /// </return>
            //Accept
            int airline = 1;
            int airportFrom = 1;
            int airportTo = 1;
            string allPlaces = "200";
            string remainPlaces = "100";
            DateTime dateTime = DateTime.Today.AddDays(3).AddHours(12).AddMinutes(41);
            //Act
            RegFlights obj = new RegFlights();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.RegFlight(airline, airportFrom, airportTo, allPlaces, remainPlaces, dateTime));
        }
        [TestMethod]
        public void RegFlight_MissingPart_Exception()
        {
            /// <summary>
            /// Проверка регистрации авиарейса
            /// </summary>
            /// <param>
            /// int airline = 1; int airportFrom = 1; int airportTo = 1; string allPlaces = String.Empty; string remainPlaces = String.Empty; 
            /// DateTime dateTime = new DateTime();
            /// </param>
            /// <return>
            /// Исключение, так как есть пустая строка
            /// </return>
            //Accept
            int airline = 1;
            int airportFrom = 2;
            int airportTo = 1;
            string allPlaces = String.Empty;
            string remainPlaces = "100";
            DateTime dateTime = DateTime.Today.AddDays(3).AddHours(12).AddMinutes(41);
            //Act
            RegFlights obj = new RegFlights();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.RegFlight(airline, airportFrom, airportTo, allPlaces, remainPlaces, dateTime));
        }
    }
}

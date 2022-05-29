using AirportDispatcher.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherLibraryTests
{
    [TestClass]
    public class RegPassengersTests
    {
        /// <summary>
        /// Проверка метода регистрацию пассажира
        /// </summary>
        /// <param>
        /// String.Epmty x3, datetime
        /// </param>
        /// <return>
        /// Исключение, так как строки пустые
        /// </return>
        [TestMethod]
        public void RegPassengers_StringEmpty_Exception()
        {
            //Accept
            string numberPassport = String.Empty;
            string placeGiven = String.Empty;
            DateTime dateGiven = new DateTime();
            string fullName = String.Empty;
            DateTime birthDay = new DateTime();
            //Act
            RegPassengers obj = new RegPassengers();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.RegPassenger(numberPassport, placeGiven, dateGiven, fullName, birthDay));
        }

        /// <summary>
        /// Проверка метода регистрацию пассажира
        /// </summary>
        /// <param>
        /// string numberPassport = "1234-653123"; string placeGiven = "Город Екатеринбург"; DateTime dateGiven = new DateTime(2020, 12, 19); 
        /// string fullName = "Леунов Кирилл Александрович"; DateTime birthDay = new DateTime(2002, 12, 19);
        /// </param>
        /// <return>
        /// Исключение, так как такой пассажир уже зарегестрирован
        /// </return>
        [TestMethod]
        public void RegPassengers_AlreadyEx_True()
        {
            //Accept
            string numberPassport = "1234-653123";
            string placeGiven = "Город Екатеринбург";
            DateTime dateGiven = new DateTime(2020, 12, 19);
            string fullName = "Леунов Кирилл Александрович";
            DateTime birthDay = new DateTime(2002, 12, 19);
            //Act
            RegPassengers obj = new RegPassengers();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.RegPassenger(numberPassport, placeGiven, dateGiven, fullName, birthDay));
        }
        /// <summary>
        /// Проверка метода регистрацию пассажира
        /// </summary>
        /// <param>
        /// numberPassport = "7532-613822"; placeGiven = "Город Екатеринбург"; dateGiven = new DateTime(2020, 12, 19, 0, 0, 0); 
        /// fullName = "Иванов Иван Иванович"; /// birthDay = new DateTime(2002, 12, 19, 0, 0, 0);
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void RegPassengers_CorrectString_True()
        {
            //Accept
            string numberPassport = "7532-613822";
            string placeGiven = "Город Екатеринбург";
            DateTime dateGiven = new DateTime(2020, 12, 19, 0, 0, 0);
            string fullName = "Иванов Иван Иванович";
            DateTime birthDay = new DateTime(2002, 12, 19, 0, 0, 0);
            //Act
            RegPassengers obj = new RegPassengers();
            bool res = obj.RegPassenger(numberPassport, placeGiven, dateGiven, fullName, birthDay);
            //Assert
            Assert.IsTrue(res);
            bool del = obj.DeletePassenger(numberPassport);
        }
    }
}

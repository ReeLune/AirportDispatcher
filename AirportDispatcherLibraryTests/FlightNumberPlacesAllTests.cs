using AirportDispatcherLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherLibraryTests
{
    [TestClass]
    public class FlightNumberPlacesAllTests
    {
        /// <summary>
        /// Проверка количества мест в самолет
        /// </summary>
        /// <param>
        /// String.Empty x2
        /// </param>
        /// <return>
        /// Исключение, так как пустая строка
        /// </return>
        [TestMethod]
        public void FlightNumberPlacesAll_StringEmpty_Exception()
        {
            //Accept
            string placeRemain = String.Empty;
            string placeAll  = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FlightNumberPlacesAll(placeRemain, placeAll));
        }
        /// <summary>
        /// Проверка количества мест в самолет
        /// </summary>
        /// <param>
        /// Всего мест 200, а оставшихся 100
        /// </param>
        /// <return>
        /// True
        /// </return>
        [TestMethod]
        public void FlightNumberPlacesAll_StringCorrect_True()
        {
            //Accept
            string placeAll = "200";
            string placeRemain = "100";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.FlightNumberPlacesAll(placeAll,placeRemain);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка количества мест в самолет
        /// </summary>
        /// <param>
        /// Всего мест 100, а оставшихся 150
        /// </param>
        /// <return>
        /// Исключинеие, так как оставшихся мест больше чем есть всего
        /// </return>
        [TestMethod]
        public void FlightNumberPlacesAll_StringInCorrect_Exception()
        {
            //Accept
            string placeAll = "100";
            string placeRemain = "150";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FlightNumberPlacesAll(placeAll, placeRemain));
        }
        /// <summary>
        /// Проверка количества мест в самолет
        /// </summary>
        /// <param>
        /// Ноль
        /// </param>
        /// <return>
        /// Исключинеие, так как количество мест равны нули
        /// </return>
        [TestMethod]
        public void FlightNumberPlacesAll_Null_Exception()
        {
            //Accept
            string placeAll = "0";
            string placeRemain = "0";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FlightNumberPlacesAll(placeAll, placeRemain));
        }
        /// <summary>
        /// Проверка количества мест в самолет
        /// </summary>
        /// <param>
        /// Всего мест меньше 100
        /// </param>
        /// <return>
        /// Исключинеие, так как всего мест меньше 100
        /// </return>
        [TestMethod]
        public void FlightNumberPlacesAll_Less100_Exception()
        {
            //Accept
            string placeAll = "90";
            string placeRemain = "50";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FlightNumberPlacesAll(placeAll, placeRemain));
        }
        /// <summary>
        /// Проверка количества мест в самолет
        /// </summary>
        /// <param>
        /// Всего мест больше 350
        /// </param>
        /// <return>
        /// Исключинеие, так как всего мест больше 350
        /// </return>
        [TestMethod]
        public void FlightNumberPlacesAll_More350_Exception()
        {
            //Accept
            string placeAll = "360";
            string placeRemain = "50";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FlightNumberPlacesAll(placeAll, placeRemain));
        }
        /// <summary>
        /// Проверка количества мест в самолет
        /// </summary>
        /// <param>
        /// Некорректные символы
        /// </param>
        /// <return>
        /// Исключинеие, так как строки содержать некорректные символы
        /// </return>
        [TestMethod]
        public void FlightNumberPlacesAll_NotNumbers_Exception()
        {
            //Accept
            string placeAll = "ПростоНаборБукв1";
            string placeRemain = "ПростоНаборБукв1";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FlightNumberPlacesAll(placeAll, placeRemain));
        }
    }
}

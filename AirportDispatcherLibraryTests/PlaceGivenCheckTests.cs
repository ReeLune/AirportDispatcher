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
    public class PlaceGivenCheckTests
    {
        /// <summary>
        /// Проверка корректности места выдачи
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Исключение, так как пустая строка
        /// </return>
        [TestMethod]
        public void PlaceGivenCheck_StringEmpty_Exception()
        {
            //Accept
            string placeGiven = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.PlaceGivenCheck(placeGiven));
        }
        /// <summary>
        /// Проверка корректности места выдачи паспорта
        /// </summary>
        /// <param>
        /// Отделом внутренних дел 'Гольяново' гор. Москва
        /// </param>
        /// <return>
        /// True
        /// </return>
        [TestMethod]
        public void PlaceGivenCheck_RightString_True()
        {
            //Accept
            string author = "Отделом внутренних дел \"Гольяново\" гор. Москва";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.PlaceGivenCheck(author);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка корректности места выдачи
        /// </summary>
        /// <param>
        /// Отделом /внутренних дел 'Гольяново' гор. Москва
        /// </param>
        /// <return>
        /// Исключение, так как присутствует недопустимый символ
        /// </return>
        [TestMethod]
        public void PlaceGivenCheck_Incorrect_Exception()
        {
            //Accept
            string placeGiven = "Отделом /внутренних дел 'Гольяново' гор. Москва";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.PlaceGivenCheck(placeGiven));
        }
        /// <summary>
        /// Проверка корректности места выдачи
        /// </summary>
        /// <param>
        /// -Отделом внутренних дел \"Гольяново\" гор. Москва
        /// </param>
        /// <return>
        /// Исключение, так как начинается с дефиса
        /// </return>
        [TestMethod]
        public void PlaceGivenCheck_StartDefis_Exception()
        {
            //Accept
            string author = "-Отделом внутренних дел \"Гольяново\" гор. Москва";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FullNameCheck(author));
        }
    }
}

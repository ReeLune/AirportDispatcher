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
    public class BirthdayCheckTests
    {
        /// <summary>
        /// Проверка корректности введённого дня рождения
        /// </summary>
        /// <param>
        /// 19 декабря 2002 года
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void BirthdayCheck_RightString_True()
        {
            //Accept
            DateTime day = new DateTime(2002, 12, 19, 0, 0, 0);
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.BirthdayCheck(day);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка корректности введённого дня рождения
        /// </summary>
        /// <param>
        /// Сегодняшняя дата с вычитанием 12 лет
        /// </param>
        /// <return>
        /// Исключение, так как не может быть такого пользователя
        /// </return>
        [TestMethod]
        public void BirthdayCheck_Today_Exception()
        {
            //Accept
            DateTime day = DateTime.Today.AddYears(-12);
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.BirthdayCheck(day));
        }
        /// <summary>
        /// Проверка корректности введённого дня рождения
        /// </summary>
        /// <param>
        /// Сегодняшняя дата с вычитанием 2 лет
        /// </param>
        /// <return>
        /// Исключение, так как не может быть такого пользователя
        /// </return>
        [TestMethod]
        public void BirthdayCheck_Young_Exception()
        {
            //Accept
            DateTime day = DateTime.Today.AddYears(-2);
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.BirthdayCheck(day));
        }
        /// <summary>
        /// Проверка корректности введённого дня рождения
        /// </summary>
        /// <param>
        /// 12 декабря 1900 года
        /// </param>
        /// <return>
        /// Исключение, так как человек столько не может прожить
        /// </return>
        [TestMethod]
        public void BirthdayCheck_Year1900_Exception()
        {
            //Accept
            DateTime day = new DateTime(1900, 12, 12, 0, 0, 0);
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.BirthdayCheck(day));
        }
    }
}

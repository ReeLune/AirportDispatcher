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
    public class DateTimeFlight
    {
        /// <summary>
        /// Проверка правильной даты для регистрации рейса
        /// </summary>
        /// <param>
        /// Сегодняшняя дата + 2 дня и + 15 часов, и + 43 минуты
        /// </param>
        /// <return>
        /// True
        /// </return>
        [TestMethod]
        public void DateTimeFlight_CorrectString_True()
        {
            //Accept
            DateTime day = DateTime.Today.AddDays(2).AddHours(15).AddMinutes(43);
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.DateTimeFlight(day);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка правильной даты для регистрации рейса
        /// </summary>
        /// <param>
        /// Сегодняшняя дата
        /// </param>
        /// <return>
        /// Исключение, так как стоит сегодняшняя дата
        /// </return>
        [TestMethod]
        public void DateTimeFlight_InCorrectString_Exception()
        {
            //Accept
            DateTime day = DateTime.Today;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.DateTimeFlight(day));
        }
        /// <summary>
        /// Проверка правильной даты для регистрации рейса
        /// </summary>
        /// <param>
        /// Пустота
        /// </param>
        /// <return>
        /// Исключение, так как пусто
        /// </return>
        [TestMethod]
        public void DateTimeFlight_EmptyString_Exception()
        {
            //Accept
            DateTime day = new DateTime();
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.DateTimeFlight(day));
        }
        /// <summary>
        /// Проверка правильной даты для регистрации рейса
        /// </summary>
        /// <param>
        /// Сегодняшняя дата + 15 лет
        /// </param>
        /// <return>
        /// Исключение, так как на такую дату нельзя зарегестрировать рейс
        /// </return>
        [TestMethod]
        public void DateTimeFlight_FutureDate_Exception()
        {
            //Accept
            DateTime day = DateTime.Today.AddYears(15);
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.DateTimeFlight(day));
        }
    }
}

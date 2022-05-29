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
    public class DateGivenCheckTests
    {
        /// <summary>
        /// Проверка даты выдачи паспорта
        /// </summary>
        /// <param>
        /// Сегодняшняя дата -2 года -15 дней
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void DateGivenCheck_CorrectString_True()
        {
            //Accept
            DateTime day = DateTime.Today.AddYears(-2).AddDays(-15);
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.DateGivenCheck(day);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка даты выдачи паспорта
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
    }
}

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
    public class NumberPassportCheckTests
    {
        /// <summary>
        /// Проверка корректности паспорта
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Исключение, так как пустая строка
        /// </return>
        [TestMethod]
        public void NumberPassport_StringEmpty_Exception()
        {
            //Accept
            string number = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.NumberPassport(number));
        }
        /// <summary>
        /// Проверка корректности паспорта
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void NumberPassport_Correct_True()
        {
            //Accept
            string number = "1234-652153";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.NumberPassport(number);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка корректности паспорта
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Исключение, так как некорректный символ
        /// </return>
        [TestMethod]
        public void NumberPassport_WrongSym_Exception()
        {
            //Accept
            string number = "12З4-652153";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.NumberPassport(number));
        }
        /// <summary>
        /// Проверка корректности паспорта
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Исключение, так как некорректный символ
        /// </return>
        [TestMethod]
        public void NumberPassport_WrongLength_Exception()
        {
            //Accept
            string number = "12345-652153";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.NumberPassport(number));
        }
        /// <summary>
        /// Проверка корректности паспорта
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void NumberPassport_Incorrect_True()
        {
            //Accept
            string number = "-1234652153";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.NumberPassport(number));
        }
    }
}

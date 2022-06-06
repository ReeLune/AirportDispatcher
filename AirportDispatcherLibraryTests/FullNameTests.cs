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
    public class FullNameTests
    {
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// Иванов Иван Иванович
        /// </param>
        /// <return>
        /// True
        /// </return>
        [TestMethod]
        public void FullNameCheck_RightString_True()
        {
            //Accept
            string name = "Иванов Иван Иванович";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.FullNameCheck(name);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Исключение, так как пустая строка
        /// </return>
        [TestMethod]
        public void FullNameCheck_StringEmpty_Exception()
        {
            //Accept
            string name = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FullNameCheck(name));
        }
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// иванов иван иванович
        /// </param>
        /// <return>
        /// Исключение, так как ввод со строчной буквы
        /// </return>
        [TestMethod]
        public void FullNameCheck_LowerString_Exception()
        {
            //Accept
            string name = "иванов иван иванович";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FullNameCheck(name));
        }
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// Иванов Ивaн Иванович
        /// </param>
        /// <return>
        /// Исключение, так как "a" из латинского алфавита
        /// </return>
        [TestMethod]
        public void FullNameCheck_FalseString_Exception()
        {
            //Accept
            string name = "Иванов Ивaн Иванович";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FullNameCheck(name));
        }
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// -Иванов Иван Иванович
        /// </param>
        /// <return>
        /// Исключение, так как начинается с дефиса
        /// </return>
        [TestMethod]
        public void FullNameCheck_StartDefis_Exception()
        {
            //Accept
            string name = "-Иванов Иван Иванович";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FullNameCheck(name));
        }
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// Иванов Иван Иванович-
        /// </param>
        /// <return>
        /// Исключение, так как заканчивается дефисом
        /// </return>
        [TestMethod]
        public void FullNameCheck_EndDefis_Exception()
        {
            //Accept
            string name = "Иванов Иван Иванович-";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FullNameCheck(name));
        }
    }
}

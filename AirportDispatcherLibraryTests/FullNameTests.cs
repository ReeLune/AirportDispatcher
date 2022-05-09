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
        /// Александр Сергеевич Пушкин
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void FullNameCheck_RightString_True()
        {
            //Accept
            string author = "Александр Сергеевич Пушкин";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.FullNameCheck(author);
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
        /// Expostion так как пустая строка
        /// </return>
        [TestMethod]
        public void FullNameCheck_StringEmpty_Expostion()
        {
            //Accept
            string author = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FullNameCheck(author));
        }
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// александр сергеевич пушкин
        /// </param>
        /// <return>
        /// Expostion так как ввод со строчной буквы
        /// </return>
        [TestMethod]
        public void FullNameCheck_LowerString_Expostion()
        {
            //Accept
            string author = "александр сергеевич пушкин";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FullNameCheck(author));
        }
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// Александp
        /// </param>
        /// <return>
        /// Expostion так как "p" из латинского алфавита
        /// </return>
        [TestMethod]
        public void FullNameCheck_FalseString_Expostion()
        {
            //Accept
            string author = "Александp";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FullNameCheck(author));
        }
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// -Александp
        /// </param>
        /// <return>
        /// Expostion так как начинается с дефис
        /// </return>
        [TestMethod]
        public void FullNameCheck_StartDefis_Expostion()
        {
            //Accept
            string author = "-Александр";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.FullNameCheck(author));
        }
    }
}

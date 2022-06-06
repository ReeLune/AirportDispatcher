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
    public class UsersViewModelTests
    {
        /// <summary>
        /// Проверка на наличие пользователей
        /// </summary>
        /// <param>
        /// String.Epmty x2
        /// </param>
        /// <return>
        /// Исключение, так как строки пустые
        /// </return>
        [TestMethod]
        public void UsersViewModel_StringEmpty_Exception()
        {
            //Accept
            string login = String.Empty;
            string password = String.Empty;
            //Act
            UsersViewModel obj = new UsersViewModel();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AuthUser(login, password));
        }
        /// <summary>
        /// Проверка на наличие пользователей
        /// </summary>
        /// <param>
        /// "ReeLune", "pass123"
        /// </param>
        /// <return>
        /// True
        /// </return>
        [TestMethod]
        public void UsersViewModel_CorrectUser_True()
        {
            //Accept
            string login = "ReeLune";
            string password = "pass123";
            //Act
            UsersViewModel obj = new UsersViewModel();
            bool res = obj.AuthUser(login,password);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка на наличие пользователей
        /// </summary>
        /// <param>
        /// "ReeLun", "pass123"
        /// </param>
        /// <return>
        /// Исключение, так как такого пользователя нет
        /// </return>
        [TestMethod]
        public void UsersViewModel_NotExist_Exception()
        {
            //Accept
            string login = "ReeLun";
            string password = "pass123";
            //Act
            UsersViewModel obj = new UsersViewModel();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AuthUser(login, password));
        }
        /// <summary>
        /// Проверка на наличие пользователей
        /// </summary>
        /// <param>
        /// "ReeLune", "pass1233"
        /// </param>
        /// <return>
        /// Исключение, так как неверный пароль
        /// </return>
        [TestMethod]
        public void UsersViewModel_WrongPass_Exception()
        {
            //Accept
            string login = "ReeLune";
            string password = "pass1233";
            //Act
            UsersViewModel obj = new UsersViewModel();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AuthUser(login, password));
        }
    }
}

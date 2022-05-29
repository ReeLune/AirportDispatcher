using AirportDispatcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcher.ViewModel
{
    public class UsersViewModel
    {
        public bool AuthUser(string login, string password)
        {
            if (login!=String.Empty && password !=String.Empty)
            {
                Core db = new Core();
                int count = db.context.Users.Where(x => x.Login == login).ToList().Count();
                if (count != 0)
                {

                    Users user = db.context.Users.Where(x => x.Login == login).First();
                    if (user.Login == login && user.Password == password)
                        return true;
                    else
                        throw new Exception("Неверный пароль");
                }
                else
                {
                    throw new Exception("Нет такого аккаунта");
                }
            }
            else
            {
                throw new Exception("Логин и/или пароль не введены");
            }
        }
    }
}

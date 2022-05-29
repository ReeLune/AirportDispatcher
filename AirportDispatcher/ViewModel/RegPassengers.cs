using AirportDispatcher.Model;
using AirportDispatcherLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcher.ViewModel
{
    public class RegPassengers
    {
        public bool RegPassenger(string numberPassport, string placeGiven, DateTime dateGiven, string fullName, DateTime birthDay)
        {
            Core db = new Core();
            CheckStringClass check = new CheckStringClass();
            try
            {
                if (check.NumberPassport(numberPassport) == true)
                {
                    int count = db.context.Passengers.Where(x => x.NumberPassport == numberPassport).ToList().Count();
                    if (count==0)
                    {
                        if (check.PlaceGivenCheck(placeGiven) == true)
                        {
                            if (check.DateGivenCheck(dateGiven) == true)
                            {
                                if (check.FullNameCheck(fullName) == true)
                                {
                                    if (check.BirthdayCheck(birthDay) == true)
                                    {
                                        Passengers passenger = new Passengers()
                                        {
                                            NumberPassport = numberPassport,
                                            PlaceGiven = placeGiven,
                                            DateGiven = dateGiven,
                                            FullName = fullName,
                                            Birthday = birthDay
                                        };
                                        db.context.Passengers.Add(passenger);
                                        db.context.SaveChanges();
                                        if (db.context.SaveChanges() == 0)
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Данный человек уже есть в базе");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

            return true;
        }
        public bool DeletePassenger(string numberPassport)
        {
            Core db = new Core();
            Passengers pass = db.context.Passengers.Where(x => x.NumberPassport == numberPassport).First();
            db.context.Passengers.Remove(pass);
            db.context.SaveChanges();
            return true;
        }
    }
}

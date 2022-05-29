using AirportDispatcher.Model;
using AirportDispatcherLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcher.ViewModel
{
    public class RegFlights
    {
        /// <summary>
        /// Регистрация рейса
        /// </summary>
        /// <param name="airline">Авиалинии</param>
        /// <param name="airportFrom">Аэропорт вылета</param>
        /// <param name="airportTo">Аэропорт прилета</param>
        /// <param name="allPlaces">Всего мест</param>
        /// <param name="remainPlaces">Оставшиеся места</param>
        /// <param name="dateTime">Времия вылета</param>
        /// <returns></returns>
        public bool RegFlight(int airline, int airportFrom, int airportTo, string allPlaces, string remainPlaces, DateTime dateTime)
        {
            int one = airportFrom;
            int two = airportTo;
            Core db = new Core();
            CheckStringClass check = new CheckStringClass();
            GenerationClass gen = new GenerationClass();

            if (check.FlightNumberPlacesAll(allPlaces, remainPlaces) == true)
            {
                if (check.DateTimeFlight(dateTime) == true)
                {
                    if (airline != -1 && airportFrom != -1 && airportTo != -1)
                    {
                        if (one == two)
                        {
                            throw new Exception("Пункт отбытия и прибытия совпадают!");
                            
                        }
                        else
                        {
                            string codeAirline = db.context.Airline.Where(x => x.IdAirline == airline).First().AirlineCode;
                            int count = db.context.Flight.ToList().Count() % 1000;
                            Flight qwery = new Flight()
                            {
                                NumberFlight = gen.NumberFlightGeneration(codeAirline, count),
                                IdNameAirline = airline,
                                DepartureDate = dateTime,
                                CountPlaceAll = Convert.ToInt32(allPlaces),
                                CountPlaceRemains = Convert.ToInt32(remainPlaces),
                                AirportFrom = airportFrom,
                                AirportTo = airportTo
                            };
                            //Избежание повтора первичного ключа, если удалялись авиарейсы
                            int ext = db.context.Flight.Where(x => x.NumberFlight == qwery.NumberFlight).ToList().Count();
                            while (ext != 0)
                            {
                                count++;
                                qwery.NumberFlight = gen.NumberFlightGeneration(codeAirline, count);
                                ext = db.context.Flight.Where(x => x.NumberFlight == qwery.NumberFlight).ToList().Count();
                            }
                            db.context.Flight.Add(qwery);
                            try
                            {
                                db.context.SaveChanges();
                                if (db.context.SaveChanges() == 0)
                                {
                                    return true;
                                }
                            }
                            catch (DbEntityValidationException ex)
                            {
                                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                                {
                                    foreach (DbValidationError err in validationError.ValidationErrors)
                                    {
                                        string messageError = validationError.Entry.Entity.ToString();
                                        throw new Exception(err.ErrorMessage + "");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Вы не все выбрали!");
                }
            }

            return true;
        }
        /// <summary>
        /// Удаление рейса
        /// </summary>
        /// <returns>
        /// True
        /// </returns>
        public bool DeleteFlight(DateTime datetime)
        {
            Core db = new Core();
            Flight flighD = db.context.Flight.Where(x => x.DepartureDate==datetime).First();
            db.context.Flight.Remove(flighD);
            db.context.SaveChanges();
            return true;
        }
    }
}

using AirportDispatcher.Model;
using AirportDispatcherLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcher.ViewModel
{
    public class Tickets
    {
        /// <summary>
        /// Добавление билета пассажиру
        /// </summary>
        /// <returns>
        /// True
        /// </returns>
        public bool TicketAdd(string numberFlight, string passport)
        {
            Core db = new Core();
            GenerationClass gen = new GenerationClass();
            int count = db.context.Ticket.Where(x => x.NumberPassengerPassport == passport).Where(x => x.NumberFlightTicket == numberFlight).ToList().Count();
            if (count==0)
            {
                Ticket ticket = new Ticket()
                {
                    NumberBooking = gen.TicketGeneration(),
                    NumberPassengerPassport = passport,
                    NumberFlightTicket = numberFlight
                };
                db.context.Ticket.Add(ticket);
                db.context.SaveChanges();
                if (db.context.SaveChanges() == 0)
                {
                    return true;
                }
            }
            else
                throw new Exception("Данный пасажир уже зарегестрирован на рейс");
            return true;
        }
    }
}

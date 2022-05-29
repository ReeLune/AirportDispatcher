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
        /// <returns></returns>
        public bool TicketAdd(string numberFlight, string passport)
        {
            Core db = new Core();
            GenerationClass gen = new GenerationClass();
            Ticket ticket = new Ticket() {
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
            return true;
        }
    }
}

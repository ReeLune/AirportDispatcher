using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherLibrary
{
    public class GenerationClass
    {
        public string NumberFlightGeneration(string airline, int count)
        {
            string number = airline +"-";
            count++;
            if (count<10)
                number += $"00{count}";
            else if (count<100)
                number += $"0{count}";
            else if (count==999)
                number += "001";

            return number;
        }
        public string TicketGeneration()
        {
            string ticket = "";
            string alf = "QAZXSWEDCVFRTGBNHYUJMKIOLP0123456789";
            Random x = new Random();
            int lenght = x.Next(alf.Length);
            for (int i = 0; i < 7; i++)
            {
                ticket += alf[lenght];
                lenght = x.Next(alf.Length);
            }
            return ticket;
        }
    }
}

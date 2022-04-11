using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherLibrary
{
    public class CheckStringClass
    {
        public bool FlightNumberPlacesAll(string allPlaces, string remainsPlaces) 
        {
            string correct = "1234567890";
            if (allPlaces == String.Empty || remainsPlaces == String.Empty)
                throw new Exception("Строка не может быть пустой");
            if (!allPlaces.All(x => correct.Contains(x)) || !remainsPlaces.All(x => correct.Contains(x)))
                throw new Exception("Строка содержит некорректные символы");
            int all = Convert.ToInt32(allPlaces);
            int remain = Convert.ToInt32(remainsPlaces);
            if (all<0 || remain<0)
                throw new Exception("Количество мест не может быть равно нулю");
            if (remain>all)
                throw new Exception("Количество оставших мест не может превышать количество всего мест");
            if (all<100 || all>350)
                throw new Exception("Некорректное введено количество мест");
            return true;
        }
        public bool DateTimeFlight(DateTime dateTime)
        {

            return true;
        }
    }
}

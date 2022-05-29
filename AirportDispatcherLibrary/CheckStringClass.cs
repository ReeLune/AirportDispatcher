using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherLibrary
{
    public class CheckStringClass
    {
        /// <summary>
        /// Проверка мест в самолете
        /// </summary>
        /// <param name="allPlaces">
        /// Всего мест в самолете
        /// </param>
        /// <param name="remainsPlaces">
        /// Оставшиеся места в самолете
        /// </param>
        /// <returns>
        /// true если введено верно
        /// false введено не верно
        /// </returns>
        public bool FlightNumberPlacesAll(string allPlaces, string remainsPlaces) 
        {
            string correct = "1234567890";
            if (allPlaces == String.Empty || remainsPlaces == String.Empty)
                throw new Exception("Строки количества мест должны быть заполнены");
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
        /// <summary>
        /// Проверка выбранной даты
        /// </summary>
        /// <param name="dateTime">
        /// Дата рейса
        /// </param>
        /// <returns>
        /// True если введено верно
        /// False введено не верно
        /// </returns>
        public bool DateTimeFlight(DateTime dateTime)
        {
            if (dateTime == null)
                throw new Exception("Нужно выбрать дату");
            if (dateTime < DateTime.Now)
                throw new Exception("Неверно выбранная дата");
            if (dateTime > DateTime.Today.AddYears(1))
                throw new Exception("Нельзя зарегестрировать рейс на этот период времени");
            return true;
        }
        /// <summary>
        /// Проверка серии и номера пасспорта
        /// </summary>
        /// <param name="number">
        /// Серия и номер паспорта
        /// </param>
        /// <returns>
        /// true если введено верно
        /// false введено не верно
        /// </returns>
        public bool NumberPassport(string number)
        {
            string correct = "1234567890-";
            if (number == String.Empty)
                throw new Exception("Вы не ввели серию и номер паспорта");
            if (!number.All(x => correct.Contains(x)))
                throw new Exception("Строка серии и номера паспорта содержит некорректные символы");
            if (number.Length != 11)
                throw new Exception("Неверная длина строки с серией и номером паспорта");
            if (number[4] != '-')
                throw new Exception("Серия и номер должны быть разделены дефисом");
            if (number[0] == '-' || number[1] == '-' || number[2] == '-' || number[3] == '-'
                || number[5] == '-' || number[6] == '-' || number[7] == '-' || number[8] == '-' || number[9] == '-' || number[10] == '-')
                throw new Exception("Дефис в неположенном месте в номере паспорта");
            return true;
        }
        /// <summary>
        /// Проверка дня рождения
        /// </summary>
        /// <param name="birthday">
        /// День рождения
        /// </param>
        /// <returns>
        /// true если введено верно
        /// false введено не верно
        /// </returns>
        public bool BirthdayCheck(DateTime birthday)
        {
            DateTime today = DateTime.Now;
            int yearNow = today.Year;
            int year = birthday.Year;
            if (year > (yearNow - 14))
            {
                throw new Exception("Вы слишком молоды");
            }
            if (year < 1903)
            {
                throw new Exception("Вы нежилец");
            }
            return true;
        }
        /// <summary>
        /// Проверка ФИО
        /// </summary>
        /// <param name="name">
        /// Полное ФИО
        /// </param>
        /// <returns>
        /// true если введено верно
        /// false введено не верно
        /// </returns>
        public bool FullNameCheck(string name)
        {
            string correctSymbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя- ";
            string nameOne = name;
            name = name.ToLower();
            if (!name.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("ФИО содержит недоступные символы. Писать на кириллице");
            }
            if (name == String.Empty)
            {
                throw new Exception("Вы не ввели ФИО полностью");
            }
            if (name.EndsWith("-") || name.StartsWith("-"))
            {
                throw new Exception("ФИО содержит знак 'дефис' только в середине");
            }
            name = nameOne;
            char symbol = name[0];
            if (Char.IsLower(symbol))
            {
                throw new Exception("ФИО должно начинаться с заглавной буквы");
            }
            return true;
        }
        /// <summary>
        /// Проверка корректности ввода места выдачи паспорта
        /// </summary>
        /// <param name="placeGiven">
        /// Место выдачи
        /// </param>
        /// <returns>
        /// true если введено верно
        /// false введено не верно
        /// </returns>
        public bool PlaceGivenCheck(string placeGiven)
        {
            string nameOne = placeGiven;
            if (placeGiven == String.Empty)
            {
                throw new Exception("Вы не ввели место выдачи паспорта");
            }
            string correctSymbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя.-\"\" ";
            placeGiven = placeGiven.ToLower();
            if (!placeGiven.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("Место выдачи содержит недоступные символы");
            }
            if (placeGiven.EndsWith("-") || placeGiven.StartsWith("-"))
            {
                throw new Exception("Поле содержит знак 'дефис' в начале либо в конце");
            }
            placeGiven = nameOne;
            char symbol = placeGiven[0];
            if (Char.IsLower(symbol))
            {
                throw new Exception("Поле должно начинаться с заглавной буквы");
            }
            return true;
        }
        /// <summary>
        /// Проверка корректности ввода даты выдачи паспорта
        /// </summary>
        /// <param name="dateGiven">
        /// Дата выдачи паспорта
        /// </param>
        /// <returns>
        /// true если введено верно
        /// false введено не верно
        /// </returns>
        public bool DateGivenCheck(DateTime dateGiven)
        {
            DateTime today = DateTime.Now;
            int yearNow = today.Year;
            int monthNow = today.Month;
            int dayNow = today.Day;
            int year = dateGiven.Year;
            int month = dateGiven.Month;
            int day = dateGiven.Day;

            if (dateGiven == null)
            {
                throw new Exception("Вы не ввели дату выдачи паспорта");
            }

            return true;
        }
    }
}

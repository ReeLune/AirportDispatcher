using AirportDispatcher.Model;
using AirportDispatcher.View.Pages;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirportDispatcher.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPassengerPage.xaml
    /// </summary>
    public partial class RegistrationPassengerPage : Page
    {
        //Подключение к БД
        Core db = new Core();
        public RegistrationPassengerPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Генерация для ListView
        /// </summary>
        public void WindowLoaded(object sender, RoutedEventArgs e)
        {
            AirlineListView.Items.Clear();
            AirportDispatcherEntities obj = new AirportDispatcherEntities();
            var query =
                from Flight in obj.Flight
                join AirportTo in obj.AirportTo on Flight.AirportTo equals AirportTo.IdAirportTo
                join AirportFrom in obj.AirportFrom on Flight.AirportFrom equals AirportFrom.IdAirportFrom
                join Airline in obj.Airline on Flight.IdNameAirline equals Airline.IdAirline
                select new { Flight.NumberFlight, Airline.AirlineName, Flight.DepartureDate, Flight.CountPlaceAll, Flight.CountPlaceRemains, AirportFrom.AirportNameFrom, AirportTo.AirportNameTo };

            if (query.Count()!=0)
            {
                foreach (var item in query)
                {
                    Flights flight = new Flights()
                    {
                        NumberFlingt = item.NumberFlight,
                        Airline = item.AirlineName,
                        DepartureDate = item.DepartureDate,
                        AllPlace = item.CountPlaceAll,
                        RemainPlace = item.CountPlaceRemains,
                        AirportFName = item.AirportNameFrom,
                        AirportTName = item.AirportNameTo
                    };
                    AirlineListView.Items.Add(flight);
                }
            }
        }

        /// <summary>
        /// Кнопка удаления
        /// </summary>
        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Flights dFlight = button.DataContext as Flights;
            Flight flinght = db.context.Flight.Where(x => x.NumberFlight == dFlight.NumberFlingt).First();
            int count = db.context.Ticket.Where(x => x.NumberFlightTicket == flinght.NumberFlight).ToList().Count();
            string message = $"Вы хотите удалить этот рейс?";
            string title = "Удаление рейса";
            MessageBoxResult res = MessageBox.Show(message, title, MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                for (int i = 0; i < count; i++)
                {
                    Ticket ticket = db.context.Ticket.Where(x => x.NumberFlightTicket == dFlight.NumberFlingt).First();
                    db.context.Ticket.Remove(ticket);
                }
                db.context.Flight.Remove(flinght);
                db.context.SaveChanges();
                if (db.context.SaveChanges() == 0)
                {
                    MessageBox.Show("Удаление рейса произошло успешно");
                    AirportDispatcherEntities obj = new AirportDispatcherEntities();
                    AirlineListView.Items.Clear();
                    var query =
                        from Flight in obj.Flight
                        join AirportTo in obj.AirportTo on Flight.AirportTo equals AirportTo.IdAirportTo
                        join AirportFrom in obj.AirportFrom on Flight.AirportFrom equals AirportFrom.IdAirportFrom
                        join Airline in obj.Airline on Flight.IdNameAirline equals Airline.IdAirline
                        select new { Flight.NumberFlight, Airline.AirlineName, Flight.DepartureDate, Flight.CountPlaceAll, Flight.CountPlaceRemains, AirportFrom.AirportNameFrom, AirportTo.AirportNameTo };

                    if (query.Count() != 0)
                    {
                        foreach (var item in query)
                        {
                            Flights flight = new Flights()
                            {
                                NumberFlingt = item.NumberFlight,
                                Airline = item.AirlineName,
                                DepartureDate = item.DepartureDate,
                                AllPlace = item.CountPlaceAll,
                                RemainPlace = item.CountPlaceRemains,
                                AirportFName = item.AirportNameFrom,
                                AirportTName = item.AirportNameTo
                            };
                            AirlineListView.Items.Add(flight);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Кнопка добавления пассажиров
        /// </summary>
        private void AddPassengerButtonClick(object sender, RoutedEventArgs e)
        {
            Button flight = sender as Button;
            Flights dFlight = flight.DataContext as Flights;
            Flight activeFlight = db.context.Flight.Where(x => x.NumberFlight == dFlight.NumberFlingt).First();
            Properties.Settings.Default.NumberFlight = activeFlight.NumberFlight;
            this.NavigationService.Navigate(new AllPassengersViewPage());
        }

        /// <summary>
        /// Поиск
        /// </summary>
        private void SearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            AirlineListView.Items.Clear();
            string search = SearchTextBox.Text;
            search = search.ToLower();
            AirportDispatcherEntities obj = new AirportDispatcherEntities();
            var query =
                from Flight in obj.Flight
                join AirportTo in obj.AirportTo on Flight.AirportTo equals AirportTo.IdAirportTo
                join AirportFrom in obj.AirportFrom on Flight.AirportFrom equals AirportFrom.IdAirportFrom
                join Airline in obj.Airline on Flight.IdNameAirline equals Airline.IdAirline
                where Flight.NumberFlight.ToLower().Contains(search) || Airline.AirlineName.ToLower().Contains(search) || Flight.DepartureDate.ToString().ToLower().Contains(search) || 
                    Flight.CountPlaceAll.ToString().ToLower().Contains(search) || Flight.CountPlaceRemains.ToString().ToLower().Contains(search) || 
                    AirportFrom.AirportNameFrom.ToLower().Contains(search) || AirportTo.AirportNameTo.ToLower().Contains(search)
                select new { Flight.NumberFlight, Airline.AirlineName, Flight.DepartureDate, Flight.CountPlaceAll, Flight.CountPlaceRemains, AirportFrom.AirportNameFrom, AirportTo.AirportNameTo };

            if (query.Count() != 0)
            {
                foreach (var item in query)
                {
                    Flights flight = new Flights()
                    {
                        NumberFlingt = item.NumberFlight,
                        Airline = item.AirlineName,
                        DepartureDate = item.DepartureDate,
                        AllPlace = item.CountPlaceAll,
                        RemainPlace = item.CountPlaceRemains,
                        AirportFName = item.AirportNameFrom,
                        AirportTName = item.AirportNameTo
                    };
                    AirlineListView.Items.Add(flight);
                }
            }
        }

        /// <summary>
        /// Кнопка просмотра пассажиров
        /// </summary>
        private void ListPassengerButtonClick(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            Flights flight = activeButton.DataContext as Flights;
            Properties.Settings.Default.NumberFlight = flight.NumberFlingt;
            this.NavigationService.Navigate(new AddedPassengersOnFlight());
        }
    }

    /// <summary>
    /// Таблица для формирования полётов
    /// </summary>
    public class Flights
    {
        public string NumberFlingt { get; set;}
        public string Airline { get; set;}
        public DateTime DepartureDate { get; set;}
        public int AllPlace { get; set;}
        public int RemainPlace { get; set;}
        public string AirportFName { get; set;}
        public string AirportTName { get; set;}

    }
}

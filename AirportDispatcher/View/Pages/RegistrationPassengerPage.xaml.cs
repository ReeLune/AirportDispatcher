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
        //Подключение к бд
        Core db = new Core();
        public RegistrationPassengerPage()
        {
            InitializeComponent();
        }

        public void WindowLoaded(object sender, RoutedEventArgs e)
        {
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


        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Flights dFlight = button.DataContext as Flights;
            Flight flinght = db.context.Flight.Where(x => x.NumberFlight == dFlight.NumberFlingt).First();
            string message = $"Вы хотите удалить этот рейс?";
            string title = "Удаление рейса";
            MessageBoxResult res = MessageBox.Show(message, title, MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
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

        private void AddPassengerButtonClick(object sender, RoutedEventArgs e)
        {
            Button flight = sender as Button;
            Flights dFlight = flight.DataContext as Flights;
            Flight activeFlight = db.context.Flight.Where(x => x.NumberFlight == dFlight.NumberFlingt).First();
            Properties.Settings.Default.NumberFlight = activeFlight.NumberFlight;
            this.NavigationService.Navigate(new RegistrationOnFlightPage());
        }

        private void ResultTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
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

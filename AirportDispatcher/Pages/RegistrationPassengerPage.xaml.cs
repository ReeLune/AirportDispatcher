using AirportDispatcher.Model;
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
        List<Flight> arrayFlight;
        public RegistrationPassengerPage()
        {
            InitializeComponent();
            //Подключение БД к ListView
            arrayFlight = db.context.Flight.ToList();
            AirlineListView.ItemsSource = arrayFlight;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            AirportEntities obj = new AirportEntities();
            //DbSet<Flight> FlightTable 
            //{
            //    string Number { get; set;}
            //};
            var query =
                from Flight in obj.Flight
                join Airline in obj.Airline on Flight.Id_Name_Airline equals Airline.Id_Airline
                join Airport_Name in obj.Airport_Name on Flight.Airport_From equals Airport_Name.Id_Airport
                select new { Flight.Number_Flight, Airline.Airline_Name, Flight.Departure_Date, Flight.Count_Place_Remains, Airport_Name.Airport_Name1};
            if (query.Count()!=0)
            {
                //FlightTable.Add(new Flight()
                //{

                //});
            }
        }
    }
}

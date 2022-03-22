using AirportDispatcher.Model;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для RegistrationAirlinePage.xaml
    /// </summary>
    public partial class RegistrationAirlinePage : Page
    {
        Core db = new Core();
        List<Airport_Name> arrayAirport;
        List<Airline> arrayAirline;
        public RegistrationAirlinePage()
        {
            InitializeComponent();
            arrayAirport = db.context.Airport_Name.ToList();
            arrayAirline = db.context.Airline.ToList();
            List<int> indexAirline = new List<int> { };
            List<int> indexAirport = new List<int> { };
            foreach (var item in arrayAirline)
            {
                int i = 0;
                AirlineComboBox.Items.Add(item.Airline_Name);
                indexAirline.Add(item.Id_Airline);
                i++;
            }
            foreach (var item in arrayAirport)
            {
                int i = 0;
                AirportFromComboBox.Items.Add(item.Airport_Name1);
                AirportToComboBox.Items.Add(item.Airport_Name1);
                indexAirport.Add(item.Id_Airport);
                i++;
            }
            int idAirline = AirlineComboBox.SelectedIndex;
            int idAirportFrom = AirportFromComboBox.SelectedIndex;
            int idAirportTo = AirportToComboBox.SelectedIndex;
            //Flight flight = new Flight()
            //{
            //    Number_Flight = IndexFlightTextBox.Text,
            //    Id_Name_Airline = indexAirline[idAirline],
            //    //Departure_Date = ,
            //    Count_Place_All = Convert.ToInt32(CountPlaceAllTextBox.Text),
            //    Count_Place_Remains = Convert.ToInt32(CountPlaceRemainsTextBox.Text),
            //    Airport_From = indexAirport[idAirportFrom],
            //    Airport_To = indexAirport[idAirportTo]
            //};
            //db.context.Flight.Add(flight);
            //db.context.SaveChanges();
        }


        private void RegButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}

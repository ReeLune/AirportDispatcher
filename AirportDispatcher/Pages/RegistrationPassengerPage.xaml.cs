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
    }
}

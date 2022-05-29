using AirportDispatcher.View.Pages;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Кнопка навигации на регистрацию рейса
        /// </summary>
        private void RegAirButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationAirlinePage());
        }
        /// <summary>
        /// Кнопка навицагии на регистрацию на рейс
        /// </summary>
        private void RegPassButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationOnFlightPage());
        }
        /// <summary>
        /// Кнопка навигации для всех пассажиров
        /// </summary>
        private void ViewPassButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AllPassengersViewPage());
        }
        /// <summary>
        /// Кнопка навигации на показ всех авиарейсов
        /// </summary>
        private void ShowAirButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationPassengerPage());
        }
    }
}

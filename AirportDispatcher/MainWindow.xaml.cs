using AirportDispatcher.Pages;
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

namespace AirportDispatcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigatedFrame.Navigate(new MainPage());
        }

        private void MainFrameNavigated(object sender, NavigationEventArgs e)
        {

        }


        private void RegAirlineTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigatedFrame.Navigate(new RegistrationAirlinePage());
        }

        private void RegPassengerTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigatedFrame.Navigate(new RegistrationPassengerPage());
        }
    }
}

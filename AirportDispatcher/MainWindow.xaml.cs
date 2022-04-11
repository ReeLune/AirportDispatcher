using AirportDispatcher.Pages;
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
            NavigatedFrame.Navigate(new AuthPage());
            
        }

        private void MainFrameNavigated(object sender, NavigationEventArgs e)
        {

            var activePage = e.Content;
            if (activePage is AuthPage || activePage is MainPage)
            {
                BackButton.Visibility = Visibility.Hidden;
            }
            else
            {
                BackButton.Visibility = Visibility.Visible;
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            if (NavigatedFrame.CanGoBack)
            {
                NavigatedFrame.GoBack();
            }
        }
    }
}

using AirportDispatcher.Model;
using AirportDispatcher.Pages;
using AirportDispatcher.ViewModel;
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

namespace AirportDispatcher.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        //Подключение к БД
        Core db = new Core();
        public AuthPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Кнопка входа
        /// </summary>
        private void EnterButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                UsersViewModel check = new UsersViewModel();
                if (check.AuthUser(LoginTextBox.Text, PasswordPasswordBox.Password) == true)
                    this.NavigationService.Navigate(new MainPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

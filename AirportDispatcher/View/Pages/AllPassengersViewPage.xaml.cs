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
    /// Логика взаимодействия для AllPassengersViewPage.xaml
    /// </summary>
    public partial class AllPassengersViewPage : Page
    {
        //Подключение к БД
        Core db = new Core();
        public AllPassengersViewPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Генерация для ListView
        /// </summary>
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            AirportDispatcherEntities obj = new AirportDispatcherEntities();
            var query =
                from Passengers in obj.Passengers
                select new { Passengers.NumberPassport, Passengers.PlaceGiven, Passengers.DateGiven, Passengers.FullName, Passengers.Birthday };

            if (query.Count() != 0)
            {
                foreach (var item in query)
                {
                    PassengersT pass = new PassengersT()
                    {
                        NumberPassportP = item.NumberPassport,
                        PlaceGiven = item.PlaceGiven,
                        DateGiven = item.DateGiven,
                        FullName = item.FullName,
                        Birthday = item.Birthday
                    };
                    PassengersListView.Items.Add(pass);
                }
            }
        }

        /// <summary>
        /// Кнопка удаления
        /// </summary>
        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            PassengersT dbPassenger = button.DataContext as PassengersT;
            string number = dbPassenger.NumberPassportP;
            Passengers passenger = db.context.Passengers.Where(x => x.NumberPassport == number).First();
            string message = $"Вы хотите удалить этого пассажира?";
            string title = "Удаление пассажира";
            MessageBoxResult res = MessageBox.Show(message, title, MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                db.context.Passengers.Remove(passenger);
                db.context.SaveChanges();

                if (db.context.SaveChanges()==0)
                {
                    MessageBox.Show("Удаление пассажира прошло успешно!");
                    AirportDispatcherEntities obj = new AirportDispatcherEntities();
                    PassengersListView.Items.Clear();
                    var query =
                from Passengers in obj.Passengers
                select new { Passengers.NumberPassport, Passengers.PlaceGiven, Passengers.DateGiven, Passengers.FullName, Passengers.Birthday };

                    if (query.Count() != 0)
                    {
                        foreach (var item in query)
                        {
                            PassengersT pass = new PassengersT()
                            {
                                NumberPassportP = item.NumberPassport,
                                PlaceGiven = item.PlaceGiven,
                                DateGiven = item.DateGiven,
                                FullName = item.FullName,
                                Birthday = item.Birthday
                            };
                            PassengersListView.Items.Add(pass);
                        }
                    }
                }
            }

        }
        /// <summary>
        /// Поиск
        /// </summary>
        private void SearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            PassengersListView.Items.Clear();
            string search = SearchTextBox.Text;
            search = search.ToLower();
            AirportDispatcherEntities obj = new AirportDispatcherEntities();
            var query =
                from Passengers in obj.Passengers
                where Passengers.NumberPassport.ToLower().Contains(search) || Passengers.PlaceGiven.ToLower().Contains(search) || Passengers.FullName.ToLower().Contains(search) || 
                    Passengers.Birthday.ToString().ToLower().Contains(search)
                select new { Passengers.NumberPassport, Passengers.PlaceGiven, Passengers.DateGiven, Passengers.FullName, Passengers.Birthday };

            if (query.Count() != 0)
            {
                foreach (var item in query)
                {
                    PassengersT pass = new PassengersT()
                    {
                        NumberPassportP = item.NumberPassport,
                        PlaceGiven = item.PlaceGiven,
                        DateGiven = item.DateGiven,
                        FullName = item.FullName,
                        Birthday = item.Birthday
                    };
                    PassengersListView.Items.Add(pass);
                }
            }
        }
        /// <summary>
        /// Кнопка добавления пассажира
        /// </summary>
        private void AddPassButtonClick(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            PassengersT activePass = activeButton.DataContext as PassengersT;
            string number = activePass.NumberPassportP;
            Tickets obj = new Tickets();
            try
            {
                bool res = obj.TicketAdd(Properties.Settings.Default.NumberFlight, number);
                if (res==true)
                {
                    MessageBox.Show("Вы успешно добавили пассажира на рейс");
                    Properties.Settings.Default.NumberFlight = String.Empty;
                    this.NavigationService.Navigate(new MainPage());
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
    public class PassengersT
    {
        public string NumberPassportP { get; set; }
        public string PlaceGiven { get; set; }
        public DateTime DateGiven { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public Visibility AddButton
        {
            get
        {
                if (Properties.Settings.Default.NumberFlight == String.Empty)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
        public Visibility DeleteButton
        {
            get
            {
                if (Properties.Settings.Default.NumberFlight == String.Empty)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }
    }
}


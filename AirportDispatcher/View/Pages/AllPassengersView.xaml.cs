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

namespace AirportDispatcher.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllPassengersView.xaml
    /// </summary>
    public partial class AllPassengersView : Page
    {
        Core db = new Core();
        public AllPassengersView()
        {
            InitializeComponent();
        }

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
                            Passengers pass = new Passengers()
                            {
                                NumberPassport = item.NumberPassport,
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
        private void SearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            PassengersListView.Items.Clear();
            string search = SearchTextBox.Text;
            AirportDispatcherEntities obj = new AirportDispatcherEntities();
            var query =
                from Passengers in obj.Passengers
                where Passengers.NumberPassport.Contains(search) || Passengers.PlaceGiven.Contains(search) || Passengers.FullName.Contains(search) || Passengers.Birthday.ToString().Contains(search)
                select new { Passengers.NumberPassport, Passengers.PlaceGiven, Passengers.DateGiven, Passengers.FullName, Passengers.Birthday };

            if (query.Count() != 0)
            {
                foreach (var item in query)
                {
                    Passengers pass = new Passengers()
                    {
                        NumberPassport = item.NumberPassport,
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
    public class PassengersT
    {
        public string NumberPassportP { get; set; }
        public string PlaceGiven { get; set; }
        public DateTime DateGiven { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }

    }
}

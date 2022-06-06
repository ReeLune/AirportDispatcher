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
    /// Логика взаимодействия для AddedPassengersOnFlight.xaml
    /// </summary>
    public partial class AddedPassengersOnFlight : Page
    {
        //Подключение к БД
        Core db = new Core();
        public AddedPassengersOnFlight()
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
                from Ticket in obj.Ticket
                join Passengers in obj.Passengers on Ticket.NumberPassengerPassport equals Passengers.NumberPassport
                where Ticket.NumberFlightTicket == Properties.Settings.Default.NumberFlight
                select new {Ticket.NumberBooking, Ticket.NumberFlightTicket, Passengers.NumberPassport, Passengers.FullName };

            if (query.Count() != 0)
            {
                foreach (var item in query)
                {
                    TicketCode ticket = new TicketCode() {
                        NumberBooking = item.NumberBooking,
                        NumberFlightTicket = item.NumberFlightTicket,
                        NumberPassengerPassport = item.NumberPassport,
                        FullName = item.FullName
                    };
                    PassengersListView.Items.Add(ticket);
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
                from Ticket in obj.Ticket
                join Passengers in obj.Passengers on Ticket.NumberPassengerPassport equals Passengers.NumberPassport
                where Ticket.NumberFlightTicket == Properties.Settings.Default.NumberFlight
                where Ticket.NumberBooking.ToLower().Contains(search) || Ticket.NumberFlightTicket.ToLower().Contains(search) || Ticket.NumberPassengerPassport.ToLower().Contains(search) || 
                Passengers.FullName.ToLower().Contains(search)
                select new { Ticket.NumberBooking, Ticket.NumberFlightTicket, Ticket.NumberPassengerPassport, Passengers.FullName};

            if (query.Count() != 0)
            {
                foreach (var item in query)
                {
                    TicketCode ticket = new TicketCode()
                    {
                        NumberBooking = item.NumberBooking,
                        NumberFlightTicket = item.NumberFlightTicket,
                        NumberPassengerPassport = item.NumberPassengerPassport,
                        FullName = item.FullName
                    };
                    PassengersListView.Items.Add(ticket);
                }
            }
        }
        /// <summary>
        /// Кнопка удаления пассажира
        /// </summary>
        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            TicketCode dbTicket = button.DataContext as TicketCode;
            string number = dbTicket.NumberBooking;
            Ticket ticket = db.context.Ticket.Where(x => x.NumberBooking == number).First();
            string message = $"Вы хотите удалить этого пассажира?";
            string title = "Удаление пассажира";
            MessageBoxResult res = MessageBox.Show(message, title, MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                db.context.Ticket.Remove(ticket);
                db.context.SaveChanges();

                if (db.context.SaveChanges() == 0)
                {
                    MessageBox.Show("Удаление пассажира прошло успешно!");
                    AirportDispatcherEntities obj = new AirportDispatcherEntities();
                    PassengersListView.Items.Clear();
                    var query =
                from Ticket in obj.Ticket
                join Passengers in obj.Passengers on Ticket.NumberPassengerPassport equals Passengers.NumberPassport
                where Ticket.NumberFlightTicket == Properties.Settings.Default.NumberFlight
                select new { Ticket.NumberBooking, Ticket.NumberFlightTicket, Ticket.NumberPassengerPassport, Passengers.FullName};

                    if (query.Count() != 0)
                    {
                        foreach (var item in query)
                        {
                            TicketCode tickets = new TicketCode()
                            {
                                NumberBooking = item.NumberBooking,
                                NumberFlightTicket = item.NumberFlightTicket,
                                NumberPassengerPassport = item.NumberPassengerPassport,
                                FullName = item.FullName
                            };
                            PassengersListView.Items.Add(tickets);
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Таблица для формирования билетов
    /// </summary>
    public class TicketCode
    {
        public string NumberBooking { get; set; }
        public string NumberPassengerPassport { get; set; }
        public string NumberFlightTicket { get; set; }
        public string FullName { get; set; }
    }
}

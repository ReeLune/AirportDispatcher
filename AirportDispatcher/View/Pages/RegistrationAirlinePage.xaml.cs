using AirportDispatcher.Model;
using AirportDispatcher.ViewModel;
using AirportDispatcherLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// 
    public partial class RegistrationAirlinePage : Page
    {
        //Подключение к БД
        Core db = new Core();
        List<Airline> arrayAirline;
        List<AirportFrom> arrayAirportFrom;
        List<AirportTo> arrayAirportTo;
        int idAirportTo = -1;
        int idAirportFrom = -1;
        int idAirline = -1;
        List<int> indexAirline = new List<int> { };
        List<int> indexAirportFrom = new List<int> { };
        List<int> indexAirportTo = new List<int> { };
        public RegistrationAirlinePage()
        {
            InitializeComponent();
            //arrayAirport = db.context.AirportName.ToList();
            arrayAirline = db.context.Airline.ToList();
            arrayAirportFrom = db.context.AirportFrom.ToList();
            arrayAirportTo = db.context.AirportTo.ToList();
            foreach (var item in arrayAirline)
            {
                AirlineComboBox.Items.Add(item.AirlineName);
                indexAirline.Add(item.IdAirline);
            }
            foreach (var item in arrayAirportFrom)
            {
                AirportFromComboBox.Items.Add(item.AirportNameFrom);
                indexAirportFrom.Add(item.IdAirportFrom);
            }
            foreach (var item in arrayAirportTo)
            {
                AirportToComboBox.Items.Add(item.AirportNameTo);
                indexAirportTo.Add(item.IdAirportTo);
            }
        }

        /// <summary>
        /// Кнопка регистрации
        /// </summary>
        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            RegFlights obj = new RegFlights();
            DateTime newDate = new DateTime();
            if (DateDeparture.SelectedDate != null && TimeDeparture.SelectedTime != null)
            {
                int year = DateDeparture.SelectedDate.Value.Year;
                int month = DateDeparture.SelectedDate.Value.Month;
                int day = DateDeparture.SelectedDate.Value.Day;
                int hour = TimeDeparture.SelectedTime.Value.Hour;
                int minute = TimeDeparture.SelectedTime.Value.Minute;
                newDate = new DateTime(year, month, day, hour, minute, 0);
            }
            else
                MessageBox.Show("Нужно выбрать дату и время");
            if (AirlineComboBox.SelectedItem != null)
            {
                idAirline = indexAirline[AirlineComboBox.SelectedIndex];
                if (AirportFromComboBox.SelectedItem != null)
                {
                    idAirportFrom = indexAirportFrom[AirportFromComboBox.SelectedIndex];
                    if (AirportToComboBox.SelectedItem != null)
                    {
                        idAirportTo = indexAirportTo[AirportToComboBox.SelectedIndex];
                        try
                        {
                            if (obj.RegFlight(idAirline, idAirportFrom, idAirportTo, CountPlaceAllTextBox.Text, CountPlaceRemainsTextBox.Text, newDate) == true)
                            {
                                MessageBox.Show("Вы успешно зарегистрировали рейс");
                                this.NavigationService.Navigate(new MainPage());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show("Вы не выбрали Аэропорт прибытия");
                }
                else
                    MessageBox.Show("Вы не выбрали Аэропорт отправления");
            }
            else
                MessageBox.Show("Вы не выбрали Авиакомпанию");
        }
    }
}

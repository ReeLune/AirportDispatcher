using AirportDispatcher.Model;
using AirportDispatcher.Pages;
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

namespace AirportDispatcher.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationOnFlightPage.xaml
    /// </summary>
    public partial class RegistrationOnFlightPage : Page
    {
        //Подключение к БД
        Core db = new Core();
        List<Passengers> arrayPassengers;
        public RegistrationOnFlightPage()
        {
            InitializeComponent();
            arrayPassengers = db.context.Passengers.ToList();
        }
        /// <summary>
        /// Кнопка регистрации
        /// </summary>
        private void RegPassButtonClick(object sender, RoutedEventArgs e)
        {
            Core db = new Core();
            CheckStringClass check = new CheckStringClass();
            try
            {
                if (check.NumberPassport(NumPassportTextBox.Text) == true)
                {
                    int count = db.context.Passengers.Where(x => x.NumberPassport == NumPassportTextBox.Text).ToList().Count();
                    if (count == 0)
                    {
                        if (check.PlaceGivenCheck(PlaceGiveTextBox.Text) == true)
                        {
                            if (check.DateGivenCheck(DateGiveDatePicker.DisplayDate) == true)
                            {
                                if (check.FullNameCheck(FullNameTextBox.Text) == true)
                                {
                                    if (check.BirthdayCheck(BirthdayDatePicker.DisplayDate) == true)
                                    {
                                        Passengers passenger = new Passengers()
                                        {
                                            NumberPassport = NumPassportTextBox.Text,
                                            PlaceGiven = PlaceGiveTextBox.Text,
                                            DateGiven = DateGiveDatePicker.DisplayDate,
                                            FullName = FullNameTextBox.Text,
                                            Birthday = BirthdayDatePicker.DisplayDate
                                        };
                                        db.context.Passengers.Add(passenger);
                                        try
                                        {
                                            db.context.SaveChanges();
                                            if (db.context.SaveChanges() == 0)
                                            {
                                                MessageBox.Show("Вы успешно добавили пассажира");
                                                this.NavigationService.Navigate(new MainPage());
                                            }
                                        }
                                        catch (DbEntityValidationException ex)
                                        {
                                            foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                                            {
                                                MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                                                foreach (DbValidationError err in validationError.ValidationErrors)
                                                {
                                                    MessageBox.Show(err.ErrorMessage + "");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данный человек уже есть в базе");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

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
using System.Windows.Shapes;

namespace CRUD
{
    /// <summary>
    /// Klasa odpowiadajaca za stworzenie zamowienia.
    /// </summary>
    public partial class InsertPage : Window
    {
        private string FirstNameTextBox => firstNameTextBox.Text;
        private string LastNameTextBox => lastNameTextBox.Text;
        private string PhoneNumberTextBox => phoneNumberTextBox.Text;
        private string OrderDateTextBox => orderDateTextBox.Text;
        private string ProductNameTextBox => productNameTextBox.Text;
        private string QuantityTextBox => quantityTextBox.Text;

        public InsertPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda która przesyła wprowadzone przez użytkownika dane do bazy danych po kliknięciu przycisku AddButton
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CreateOrder();
        }

        /// <summary>
        /// Metoda która przesyła wprowadzone przez użytkownika dane do bazy danych po naciśnięciu Enter na przycisku AddButton
        /// </summary>
        private void AddButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CreateOrder();
            }
        }

        /// <summary>
        /// Stworzenie zamowienia
        /// </summary>
        private void CreateOrder()
        {
            try
            {
                OrderDbHandler.CreateOrder(ProductNameTextBox, FirstNameTextBox, LastNameTextBox,
                    PhoneNumberTextBox, OrderDateTextBox, QuantityTextBox);

                MessageBox.Show("Zamówienie dodane !");
                this.Hide();
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); // Komunikat o błędzie w przypadku wystąpienia pobierany z klasy InputCheck 
            }
        }
    }
}



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
    /// Klasa odpowiadajaca za aktualizowanie zamowienia.
    /// </summary>
    public partial class UpdatePage : Window
    {


        private int OrderId { get; set; }

        public string ProductNameTextBox => productNameTextBox.Text;
        public string FirstNameTextBox => firstNameTextBox.Text;
        public string LastNameTextBox => lastNameTextBox.Text;
        public string PhoneNumberTextBox => phoneNumberTextBox.Text;
        public string OrderDateTextBox => orderDateTextBox.Text;
        public string OrderEndDateTextBox => orderEndDateTextBox.Text;

        public string QuantityTextBox => quantityTextBox.Text;

        public UpdatePage(int orderId)   // Konstruktor klasy updatePage(pobiera wartość orderId z UpdateButton_Click)
        {
            InitializeComponent();
            OrderId = orderId;               //  Przypisanie wartości orderId do zmiennej id
            FillinTextBox();            //  Wywołanie metody
        }

        private void FillinTextBox()    // Metoda która wpisuje do TextBoxów odpowiednie dane z bazy danych bazując na id
        {
            Order updateOrder = OrderDbHandler.ReadOrder(OrderId);

            productNameTextBox.Text = updateOrder.Product;
            quantityTextBox.Text = Convert.ToString(updateOrder.Quantity);
            firstNameTextBox.Text = updateOrder.FirstName;
            lastNameTextBox.Text = updateOrder.LastName;
            phoneNumberTextBox.Text = updateOrder.PhoneNumber;
            orderDateTextBox.Text = updateOrder.OrderDate;
            orderEndDateTextBox.Text = updateOrder.OrderEndDate;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) //Metoda która przesyła wprowadzone przez użytkownika dane do bazy danych po kliknięciu przycisku UpdateButton
        {
            UpdateOrder();
            Hide();
        }

        private void UpdateButton_KeyDown(object sender, KeyEventArgs e)//Metoda która przesyła wprowadzone przez użytkownika dane do bazy danych po naciśnięciu Enter na przycisku UpdateButton
        {
            if (e.Key == Key.Enter)
            {
                UpdateOrder();
                Hide();
            }
        }

        private void UpdateOrder()
        {
            try
            {
                OrderDbHandler.UpdateOrder(ProductNameTextBox, FirstNameTextBox, LastNameTextBox, PhoneNumberTextBox, OrderDateTextBox, OrderEndDateTextBox, QuantityTextBox, OrderId);
                MessageBox.Show("Zamówienie zaktualizowane !");
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); // Komunikat o błędzie w przypadku wystąpienia pobierany z klasy InputCheck 
            }
        }
    }
}

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
 
    public partial class UpdatePage : Window
    {

        CrudWPF _db = new CrudWPF();
        int id;
        public UpdatePage(int orderId)   // Konstruktor klasy updatePage(pobiera wartość orderId z UpdateButton_Click)
        {
            InitializeComponent();
            id = orderId;               //  Przypisanie wartości orderId do zmiennej id
            FillinTextBox();            //  Wywołanie metody

        }

        private void FillinTextBox()    // Metoda która wpisuje do TextBoxów odpowiednie dane z bazy danych bazując na id
        {
            Order updateOrder = (from m in _db.Order
                                 where m.OrderId == id
                                 select m).Single();

            productNameTextBox.Text = updateOrder.Product;
            quantityTextBox.Text = Convert.ToString(updateOrder.Quantity);
            firstNameTextBox.Text = updateOrder.FirstName;
            lastNameTextBox.Text = updateOrder.LastName;
            phoneNumberTextBox.Text = updateOrder.PhoneNumber;
            orderDateTextBox.Text = updateOrder.OrderDate;
            orderEndDateTextBox.Text = updateOrder.OrderEndDate;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) //Metoda która przesyła wprowadzone przez użytkownika dane do bazy danych bazując na id
        {

            //klasa wywolujaca zapisanie do bazy


            Order updateOrder = (from m in _db.Order
                                 where m.OrderId == id
                                 select m).Single();

            updateOrder.Product = productNameTextBox.Text;
            updateOrder.Quantity = Int32.Parse(quantityTextBox.Text);
            updateOrder.FirstName = firstNameTextBox.Text;
            updateOrder.LastName = lastNameTextBox.Text;
            updateOrder.PhoneNumber = phoneNumberTextBox.Text;
            updateOrder.OrderDate = orderDateTextBox.Text;
            updateOrder.OrderEndDate = orderEndDateTextBox.Text;

            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Order.ToList();




            this.Hide();

        }

        private void UpdateButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //klasa wywolujaca zapisanie do bazy
            }
        }
    }
}

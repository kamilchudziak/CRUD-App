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

        public string ProductNameTextBox
        {
            get { return productNameTextBox.Text; }



        }
        public string FirstNameTextBox
        {
            get { return firstNameTextBox.Text; }


        }
        public string LastNameTextBox
        {
            get { return lastNameTextBox.Text; }


        }
        public string PhoneNumberTextBox
        {
            get { return phoneNumberTextBox.Text; }


        }
        public string OrderDateTextBox
        {
            get { return orderDateTextBox.Text; }



        }

        public string OrderEndDateTextBox
        {
            get { return orderEndDateTextBox.Text; }
        }

        public string QuantityTextBox
        {
            get { return quantityTextBox.Text; }


        }












        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            int insertOrUpdate = 2; // '2' means Update Order in SaveToDb class



            //klasa wywolujaca zapisanie do bazy
            try
            {


                SaveToDb DbInsert = new SaveToDb(ProductNameTextBox, FirstNameTextBox, LastNameTextBox, PhoneNumberTextBox, OrderDateTextBox, OrderEndDateTextBox, QuantityTextBox, insertOrUpdate, id);
                MessageBox.Show("Zamówienie zaktualizowane !");
                this.Hide();
            }

            catch (ArgumentException error)
            {
                MessageBox.Show(Convert.ToString(error));
            }


        }

        private void UpdateButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int insertOrUpdate = 2; // '2' means Update Order in SaveToDb class



                //klasa wywolujaca zapisanie do bazy
                try
                {


                    SaveToDb DbInsert = new SaveToDb(ProductNameTextBox, FirstNameTextBox, LastNameTextBox, PhoneNumberTextBox, OrderDateTextBox, OrderEndDateTextBox, QuantityTextBox, insertOrUpdate, id);
                    MessageBox.Show("Zamówienie zaktualizowane !");
                    this.Hide();
                }

                catch (ArgumentException error)
                {
                    MessageBox.Show(Convert.ToString(error.Message));
                }
            }
        }
    }
}

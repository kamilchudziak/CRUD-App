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

    public partial class InsertPage : Window
    {


        //CrudWPF _db = new CrudWPF();
        public InsertPage()
        {
            InitializeComponent();

        }

        private string ProductNameTextBox
        {
            get { return productNameTextBox.Text; }



        }
        private string FirstNameTextBox
        {
            get { return firstNameTextBox.Text; }


        }
        private string LastNameTextBox
        {
            get { return lastNameTextBox.Text; }


        }
        private string PhoneNumberTextBox
        {
            get { return phoneNumberTextBox.Text; }


        }
        private string OrderDateTextBox
        {
            get { return orderDateTextBox.Text; }


        }

        private string OrderEndDateTextBox
        {
            get { return null; }
        }

        private string QuantityTextBox
        {
            get { return quantityTextBox.Text; }


        }







        private void AddButton_Click(object sender, RoutedEventArgs e) //Metoda która przesyła wprowadzone przez użytkownika dane do bazy danych po kliknięciu przycisku AddButton
        {
            int insertOrUpdate = 1; // '1' oznacza dodanie nowego zamówienia w klasie SaveTo Db
            int id = 0; // tylko dla przesłania zmiennej



            try
            {


                SaveToDb DbInsert = new SaveToDb(ProductNameTextBox, FirstNameTextBox, LastNameTextBox, PhoneNumberTextBox, OrderDateTextBox, OrderEndDateTextBox, QuantityTextBox, insertOrUpdate, id);
                MessageBox.Show("Zamówienie dodane !");
                this.Hide();

            }

            catch (ArgumentException error)
            {
                MessageBox.Show(Convert.ToString(error.Message)); // Komunikat o błędzie w przypadku wystąpienia pobierany z klasy InputCheck 
            }





        }


        private void AddButton_KeyDown(object sender, KeyEventArgs e)//Metoda która przesyła wprowadzone przez użytkownika dane do bazy danych po naciśnięciu Enter na przycisku AddButton
        {

            if (e.Key == Key.Enter)
            {
                int insertOrUpdate = 1; // '1' oznacza dodanie nowego zamówienia w klasie SaveTo Db
                int id = 0; // tylko dla przesłania zmiennej

                try
                {


                    SaveToDb DbInsert = new SaveToDb(ProductNameTextBox, FirstNameTextBox, LastNameTextBox, PhoneNumberTextBox, OrderDateTextBox, OrderEndDateTextBox, QuantityTextBox, insertOrUpdate, id);
                    MessageBox.Show("Zamówienie dodane !");
                    this.Hide();

                }

                catch (ArgumentException error)
                {
                    MessageBox.Show(Convert.ToString(error.Message)); // Komunikat o błędzie w przypadku wystąpienia pobierany z klasy InputCheck 
                }
            }

        }
    }









}



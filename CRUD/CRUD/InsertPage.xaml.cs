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







        private void AddButton_Click(object sender, RoutedEventArgs e) //Metoda która przesyła wprowadzone przez użytkownika dane do bazy danych
        {
            int insertOrUpdate = 1; // '1' means Insert new Order in SaveToDb class
            int id = 0; // not used int this case


            //klasa wywolujaca zapisanie do bazy
            try
            {


                SaveToDb DbInsert = new SaveToDb(ProductNameTextBox, FirstNameTextBox, LastNameTextBox, PhoneNumberTextBox, OrderDateTextBox, OrderEndDateTextBox, QuantityTextBox, insertOrUpdate, id);
                MessageBox.Show("Zamówienie dodane !");
                this.Hide();

            }

            catch (ArgumentException error)
            {
                MessageBox.Show(Convert.ToString(error.Message));
            }





        }


        private void AddButton_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                int insertOrUpdate = 1; // '1' means Insert new Order in SaveToDb class
                int id = 0; // not used int this case


                //klasa wywolujaca zapisanie do bazy
                try
                {


                    SaveToDb DbInsert = new SaveToDb(ProductNameTextBox, FirstNameTextBox, LastNameTextBox, PhoneNumberTextBox, OrderDateTextBox, OrderEndDateTextBox, QuantityTextBox, insertOrUpdate, id);
                    MessageBox.Show("Zamówienie dodane !");
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



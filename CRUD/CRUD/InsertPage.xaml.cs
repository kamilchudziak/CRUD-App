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


        CrudWPF _db = new CrudWPF();
        public InsertPage()
        {
            InitializeComponent();
        }
       


            public string ProductNameTextBox
            {
                get { return productNameTextBox.Text; }
                set { productNameTextBox.Text = value; }
            }
            public string FirstNameTextBox
            {
                get { return firstNameTextBox.Text; }
                set { firstNameTextBox.Text = value; }
            }
            public string LastNameTextBox
            {
                get { return lastNameTextBox.Text; }
                set { lastNameTextBox.Text = value; }
            }
            public string PhoneNumberTextBox
            {
                get { return phoneNumberTextBox.Text; }
                set { phoneNumberTextBox.Text = value; }
            }
            public string OrderDateTextBox
            {
                get { return orderDateTextBox.Text; }
                set { orderDateTextBox.Text = value; }

            }

            public string QuantityTextBox
            {
                get { return quantityTextBox.Text; }
                set { quantityTextBox.Text = value; }
            }

        
            

        

       
        private void AddButton_Click(object sender, RoutedEventArgs e) //Metoda która przesyła wprowadzone przez użytkownika dane do bazy danych
        {



            //klasa wywolujaca zapisanie do bazy


            SaveToDb();

        }

       
        private void AddButton_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.Key == Key.Enter)
            {
                //klasa wywolujaca zapisanie do bazy
            }

        }
    }

    public class Test : Window
    {
        public Test() {
            string product = productNameTextBox.Text;
            int quantity = Int32.Parse(quantityTextBox.Text);
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string phoneNumber = phoneNumberTextBox.Text;
            string orderDate = orderDateTextBox.Text;
}
     
       
    
      
    


    }

}

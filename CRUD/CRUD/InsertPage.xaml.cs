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

            public string QuantityTextBox
            {
                get { return quantityTextBox.Text; }
                
            }

        
            

        

       
        private void AddButton_Click(object sender, RoutedEventArgs e) //Metoda która przesyła wprowadzone przez użytkownika dane do bazy danych
        {

            //MessageBox.Show(Convert.ToString(FirstNameTextBox)); // dziala

            //klasa wywolujaca zapisanie do bazy
            try
            {
            SaveToDb DbInsert = new SaveToDb();
            }
            
            catch (ArgumentException error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
            finally
            {
            this.Hide();
            }

            

        }

       
        private void AddButton_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.Key == Key.Enter)
            {
                //klasa wywolujaca zapisanie do bazy
            }

        }
    }

   
     
       
    
      
    


    }



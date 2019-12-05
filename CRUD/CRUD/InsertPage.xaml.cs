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
    /// Interaction logic for InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    {


        WPFCrud _db = new WPFCrud();
        public InsertPage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Client newClient= new Client()
            {
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                PhoneNumber = Int32.Parse(phoneNumberTextBox.Text)

            };
            _db.Client.Add(newClient);
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Client.ToList();

            Order newOrder = new Order()
            {
                ProductName = productNameTextBox.Text,
                Quantity = Int32.Parse(quantityTextBox.Text)
                

            };
            _db.Order.Add(newOrder);
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Order.ToList();
            this.Hide();
            
        }
    }
}

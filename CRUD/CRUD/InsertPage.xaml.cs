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


        CrudWPF _db = new CrudWPF();
        public InsertPage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {



            Order newOrder = new Order()
            {
                Product = productNameTextBox.Text,
                Quantity = Int32.Parse(quantityTextBox.Text),
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                PhoneNumber = phoneNumberTextBox.Text,
                OrderDate = orderDateTextBox.Text
            };
            _db.Order.Add(newOrder);
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Order.ToList();
            this.Hide();

        }
    }
}

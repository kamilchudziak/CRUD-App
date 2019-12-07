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
    /// Interaction logic for updatePage.xaml
    /// </summary>
    public partial class updatePage : Window
    {

        WPFCrud _db = new WPFCrud();
        int Id;
        public updatePage(int OrderId)
        {
            InitializeComponent();
            Id = OrderId;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Order updateOrder = (from m in _db.Order
                                 where m.OrderId == Id
                                 select m).Single();
            updateOrder.ProductName = productNameTextBox.Text;
            updateOrder.Quantity = Int32.Parse(quantityTextBox.Text);

            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Order.ToList();


            Client updateClient = (from k in _db.Client
                                   where k.ClientId == Id
                                   select k).Single();
            updateClient.FirstName = firstNameTextBox.Text;
            updateClient.LastName = lastNameTextBox.Text;
            updateClient.PhoneNumber = phoneNumberTextBox.Text;

            

            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Order.ToList();

            this.Hide();

        }
    }
}

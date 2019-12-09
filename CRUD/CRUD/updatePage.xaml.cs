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

        CrudWPF _db = new CrudWPF();
        int Id;
        public updatePage(int OrderId)
        {
            InitializeComponent();
            Id = OrderId;
            FillinTextBox();

        }

        private void FillinTextBox()
        {
            Order updateOrder = (from m in _db.Order
                                 where m.OrderId == Id
                                 select m).Single();

            productNameTextBox.Text = updateOrder.Product;
            quantityTextBox.Text = Convert.ToString(updateOrder.Quantity);
            firstNameTextBox.Text = updateOrder.FirstName;
            lastNameTextBox.Text = updateOrder.LastName;
            phoneNumberTextBox.Text = updateOrder.PhoneNumber;
            orderDateTextBox.Text = updateOrder.OrderDate;
            orderEndDateTextBox.Text = updateOrder.OrderEndDate;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Order updateOrder = (from m in _db.Order
                                 where m.OrderId == Id
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
    }
}

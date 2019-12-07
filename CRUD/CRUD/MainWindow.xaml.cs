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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CrudWPF _db = new CrudWPF(); //WPFCrud - Entity Container Name
        public static DataGrid datagrid;

      

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            myDataGrid.ItemsSource = _db.Order.ToList();
            datagrid = myDataGrid;
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertPage Ipage = new InsertPage();
            Ipage.ShowDialog();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as Order).OrderId;
            updatePage Upage = new updatePage(Id);
            Upage.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as Order).OrderId;
            var deleteOrder = _db.Order.Where(m => m.OrderId == Id).Single();
            _db.Order.Remove(deleteOrder);
            _db.SaveChanges();
            myDataGrid.ItemsSource = _db.Order.ToList();
        }
    }
}

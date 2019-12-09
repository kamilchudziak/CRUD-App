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
 
    public partial class MainWindow : Window
    {

        CrudWPF _db = new CrudWPF(); // WPFCrud - Nazwa Entity Container 
        public static DataGrid datagrid;

      

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            DataTable.ItemsSource = _db.Order.ToList();
            datagrid = DataTable;
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertPage AddRecord = new InsertPage();
            AddRecord.ShowDialog();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            

            if(DataTable.SelectedItem != null)
            {
                int Id = (DataTable.SelectedItem as Order).OrderId;
                updatePage EditRecord = new updatePage(Id);
                EditRecord.ShowDialog();
            }
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataTable.SelectedItem != null)
            {
                int Id = (DataTable.SelectedItem as Order).OrderId;
                var deleteOrder = _db.Order.Where(m => m.OrderId == Id).Single();
                _db.Order.Remove(deleteOrder);
                _db.SaveChanges();
                DataTable.ItemsSource = _db.Order.ToList();
            }
        }
    }
}

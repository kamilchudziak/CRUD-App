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


            if (DataTable.SelectedItem != null)
            {
                int id = (DataTable.SelectedItem as Order).OrderId;
                UpdatePage EditRecord = new UpdatePage(id);
                EditRecord.ShowDialog();
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataTable.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Jesteś pewny, że chcesz usunąć wybrany rekord", "Potwiedzenie operacji", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        int id = (DataTable.SelectedItem as Order).OrderId;
                        var deleteOrder = _db.Order.Where(m => m.OrderId == id).Single();
                        _db.Order.Remove(deleteOrder);
                        _db.SaveChanges();
                        DataTable.ItemsSource = _db.Order.ToList();

                        MessageBox.Show("Rekord został usunięty pomyślnie", "Potwiedzenie operacji");
                        break;

                    case MessageBoxResult.No:
                        break;

                }

            }
        }
    }
}

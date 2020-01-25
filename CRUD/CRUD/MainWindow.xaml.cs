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
    /// Glowne okno programu
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DataGrid DataGrid { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                OrderDbHandler.OpenDatabaseConnection();
                LoadOrders();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        /// <summary>
        /// Zamkniecie glownego okna
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            OrderDbHandler.CloseDatabaseConnection();
        }

        /// <summary>
        /// Wczytanie zamowien z bazy danych i umieszczenie ich w tabeli
        /// </summary>
        private void LoadOrders()
        {
            DataTable.ItemsSource = OrderDbHandler.ReadAllOrders();//_db.Order.ToList();
            DataGrid = DataTable;
        }

        /// <summary>
        /// Otwarcie okna tworzenia zamowienia.
        /// </summary>
        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertPage AddRecord = new InsertPage();
            AddRecord.ShowDialog();
        }

        /// <summary>
        /// Otwarcie okna aktualizacji zamowienia
        /// </summary>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataTable.SelectedItem != null)
            {
                int id = (DataTable.SelectedItem as Order).OrderId;
                UpdatePage EditRecord = new UpdatePage(id);
                EditRecord.ShowDialog();
            }
        }

        /// <summary>
        /// Usuniecie, aktualnie zaznaczonego rekordu, z bazy danych
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataTable.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Jesteś pewny, że chcesz usunąć wybrany rekord", "Potwiedzenie operacji", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        RemoveOrder(DataTable.SelectedItem as Order);
                        LoadOrders();
                        MessageBox.Show("Rekord został usunięty pomyślnie", "Potwiedzenie operacji");
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        /// <summary>
        /// Usuniecie, rekordu o podanym identyfikatorze, z bazy danych.
        /// </summary>
        /// <param name="orderId">Identyfikator zamowienia</param>
        private void RemoveOrder(Order orderToRemove)
        {
            if (orderToRemove != null)
            {
                OrderDbHandler.DeleteOrder(orderToRemove.OrderId);
            }
            else
            {
                MessageBox.Show("Nie zaznaczono rekordu", "Warning");
            }
        }
    }
}

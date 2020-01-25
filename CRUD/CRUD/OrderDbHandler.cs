using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRUD
{
    /// <summary>
    /// Klasa odpowiedzialna za komunikacje z baza danych.
    /// </summary>
    public static class OrderDbHandler
    {
        private static CrudWPFEntities _db;

        /// <summary>
        /// Otwarcie polaczenia z baza danych
        /// </summary>
        public static void OpenDatabaseConnection()
        {
            _db = new CrudWPFEntities();
        }

        /// <summary>
        /// zamkniecie polaczenia z baza danych
        /// </summary>
        public static void CloseDatabaseConnection()
        {
            _db.Dispose();
            _db = null;
        }

        /// <summary>
        /// Stworzenie zamowienia poprzez pobranie zawartości TextBox z InsertPage.xaml.cs oraz zapisanie go w bazie danych.
        /// </summary>
        /// <param name="productName">Nazwa produktu</param>
        /// <param name="firstName">Imie zamawiajacego</param>
        /// <param name="lastName">Nazwisko zamawiajacego</param>
        /// <param name="phoneNumber">Numer telefonu zamawiajacego</param>
        /// <param name="orderDate">Data zamowienia</param>
        /// <param name="quantity">Ilosc</param>
        public static void CreateOrder(string productName, string firstName, string lastName, string phoneNumber,
            string orderDate, string quantity)
        {
            InputCheck inputCheckResult = CheckInputFields(productName, firstName, lastName, phoneNumber, orderDate, string.Empty, quantity);
            Order newOrder = CreateOrder(inputCheckResult);

            AddOrderToDatabase(newOrder);

            MainWindow.DataGrid.ItemsSource = _db.Order.ToList();
        }

        /// <summary>
        /// Wczytanie zamowienia z bazy danych
        /// </summary>
        /// <param name="orderId">Identyfikator zamowienia</param>
        /// <returns>Docelowe zamowienie</returns>
        public static Order ReadOrder(int orderId)
        {
            Order readOrder = _db.Order.First(x => x.OrderId == orderId);

            return readOrder;
        }

        /// <summary>
        /// Wczytanie wszystkich zamowien z bazy danych
        /// </summary>
        /// <returns>Wszystkie rekordy zamowien z bazy danych</returns>
        public static List<Order> ReadAllOrders()
        {
            return _db.Order.ToList();
        }

        /// <summary>
        /// Stworzenie zamowienia poprzez pobranie zawartości TextBox z InsertPage.xaml.cs oraz zapisanie go w bazie danych.
        /// </summary>
        /// <param name="productName">Nazwa produktu</param>
        /// <param name="firstName">Imie zamawiajacego</param>
        /// <param name="lastName">Nazwisko zamawiajacego</param>
        /// <param name="phoneNumber">Numer telefonu zamawiajacego</param>
        /// <param name="orderDate">Data zamowienia</param>
        /// <param name="orderEndDate">Data zamkniecia zamowienia</param>
        /// <param name="quantity">Ilosc</param>
        /// <param name="orderId">Identyfikator zamowienia</param>
        public static void UpdateOrder(string productName, string firstName, string lastName, string phoneNumber,
            string orderDate, string orderEndDate, string quantity, int orderId)
        {
            InputCheck inputCheckResult = CheckInputFields(productName, firstName, lastName, phoneNumber, orderDate, orderEndDate, quantity);

            Order orderToUpdate = _db.Order.First(x => x.OrderId == orderId);

            UpdateOrder(orderToUpdate, inputCheckResult);
            SaveChangesToDatabase();
            MainWindow.DataGrid.ItemsSource = _db.Order.ToList();
        }

        /// <summary>
        /// Usuniecie zamowienia z bazy danych
        /// </summary>
        /// <param name="orderId">Identyfikator zamowienia</param>
        public static void DeleteOrder(int orderId)
        {
            Order orderToRemove = ReadOrder(orderId);
            RemoveOrderFromDatabase(orderToRemove);
        }

        /// <summary>
        /// Stworzenie zamowienia
        /// </summary>
        /// <param name="productName">Nazwa produktu</param>
        /// <param name="firstName">Imie zamawiajacego</param>
        /// <param name="lastName">Nazwisko zamawiajacego</param>
        /// <param name="phoneNumber">Numer telefonu zamawiajacego</param>
        /// <param name="orderDate">Data zamowienia</param>
        /// <param name="quantity">Ilosc</param>
        /// <returns>Nowe zamowienie</returns>
        private static Order CreateOrder(InputCheck inputCheckResult)
        {
            Order newOrder = new Order()
            {
                Product = inputCheckResult.ProductNameChecked,
                FirstName = inputCheckResult.FirstNameChecked,
                LastName = inputCheckResult.LastNameChecked,
                PhoneNumber = inputCheckResult.PhoneNumberChecked,
                OrderDate = inputCheckResult.OrderDateChecked,
                Quantity = inputCheckResult.QuantityChecked,
            };

            return newOrder;
        }

        /// <summary>
        /// Zaktualizowanie danych w zamowieniu
        /// </summary>
        /// <param name="orderToUpdate">Zamowienie, ktore ma byc zaktualizowane</param>
        /// <param name="inputCheckResult">Sprawdzone wartosci wpisane przez uzytkownika</param>
        private static void UpdateOrder(Order orderToUpdate, InputCheck inputCheckResult)
        {
            orderToUpdate.Product = inputCheckResult.ProductNameChecked;
            orderToUpdate.FirstName = inputCheckResult.FirstNameChecked;
            orderToUpdate.LastName = inputCheckResult.LastNameChecked;
            orderToUpdate.PhoneNumber = inputCheckResult.PhoneNumberChecked;
            orderToUpdate.OrderDate = inputCheckResult.OrderDateChecked;
            orderToUpdate.OrderEndDate = inputCheckResult.OrderEndDateChecked;
            orderToUpdate.Quantity = inputCheckResult.QuantityChecked;
        }

        /// <summary>
        /// Sprawdzanie danych wpisanych przez uzytkownika
        /// </summary>
        /// <param name="productName">Nazwa produktu</param>
        /// <param name="firstName">Imie zamawiajacego</param>
        /// <param name="lastName">Nazwisko zamawiajacego</param>
        /// <param name="phoneNumber">Numer telefonu zamawiajacego</param>
        /// <param name="orderDate">Data zamowienia</param>
        /// <param name="orderEndDate">Data zamkniecia zamowienia</param>
        /// <param name="quantity">Ilosc</param>
        /// <param name="orderId">Identyfikator zamowienia</param>
        /// <returns>Zwraca wynikowy i sprawdzony InputCheck</returns>
        private static InputCheck CheckInputFields(string productName, string firstName, string lastName, string phoneNumber,
            string orderDate, string orderEndDate, string quantity)
        {
            InputCheck inputCheck = new InputCheck();

            inputCheck.ProductNameToCheck = productName;
            inputCheck.FirstNameToCheck = firstName;
            inputCheck.LastNameToCheck = lastName;
            inputCheck.PhoneNumberToCheck = phoneNumber;
            inputCheck.OrderDateToCheck = orderDate;
            inputCheck.OrderEndDateToCheck = orderEndDate;
            inputCheck.QuantityToCheck = quantity;

            inputCheck.CheckFields();

            return inputCheck;
        }

        /// <summary>
        /// Dodanie zamowienia do bazy danych
        /// </summary>
        /// <param name="orderToAdd">Zamowienie, ktore ma byc w bazie danych</param>
        private static void AddOrderToDatabase(Order orderToAdd)
        {
            _db.Order.Add(orderToAdd);
            SaveChangesToDatabase();
        }

        /// <summary>
        /// Usuniecie rekordu z bazy danych
        /// </summary>
        /// <param name="orderToRemove"></param>
        private static void RemoveOrderFromDatabase(Order orderToRemove)
        {
            _db.Order.Remove(orderToRemove);
            SaveChangesToDatabase();
        }

        /// <summary>
        /// Zapisanie zmian w bazie danych
        /// </summary>
        private static void SaveChangesToDatabase()
        {
            _db.SaveChanges();
        }
    }
}

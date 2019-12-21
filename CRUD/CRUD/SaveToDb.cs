using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRUD
{
    public class SaveToDb
    {


        public SaveToDb(string productName, string firstName, string lastName, string phoneNumber, string orderDate, string orderEndDate, string quantity, int insertOrUpdate, int id) // pobranie zawartości TextBox z InsertPage.xaml.cs
        {


            CrudWPF _db = new CrudWPF();

            InputCheck InsertCheck = new InputCheck();

            InsertCheck.ProductNameToCheck = productName;
            InsertCheck.FirstNameToCheck = firstName;
            InsertCheck.LastNameToCheck = lastName;
            InsertCheck.PhoneNumberToCheck = phoneNumber;
            InsertCheck.OrderDateToCheck = orderDate;
            InsertCheck.OrderEndDateToCheck = orderEndDate;
            InsertCheck.QuantityToCheck = quantity;

            InsertCheck.Test();


            if (insertOrUpdate == 1) // Add new Order
            {
                
                Order newOrder = new Order()
                {

                    Product = InsertCheck.ProductNameChecked,
                    FirstName = InsertCheck.FirstNameChecked,
                    LastName = InsertCheck.LastNameChecked,
                    PhoneNumber = InsertCheck.PhoneNumberChecked,
                    OrderDate = InsertCheck.OrderDateChecked,
                    Quantity = InsertCheck.QuantityChecked,
                };
                _db.Order.Add(newOrder);
                _db.SaveChanges();
                MainWindow.datagrid.ItemsSource = _db.Order.ToList();

            }


            if (insertOrUpdate == 2) // Update Order
              {
                
                Order updateOrder = (from m in _db.Order
                                     where m.OrderId == id
                                     select m).Single();

                updateOrder.Product = InsertCheck.ProductNameChecked;
                updateOrder.FirstName = InsertCheck.FirstNameChecked;
                updateOrder.LastName = InsertCheck.LastNameChecked;
                updateOrder.PhoneNumber = InsertCheck.PhoneNumberChecked;
                updateOrder.OrderDate = InsertCheck.OrderDateChecked;
                updateOrder.OrderEndDate = InsertCheck.OrderEndDateChecked;
                updateOrder.Quantity = InsertCheck.QuantityChecked;

               
                _db.SaveChanges();
                MainWindow.datagrid.ItemsSource = _db.Order.ToList();

                

            }
        }
    }
}

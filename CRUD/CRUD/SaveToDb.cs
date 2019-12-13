using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class SaveToDb
    {

        public SaveToDb()

            
            
        {
            try
            {
        Order newOrder = new Order()
        {
            Product = product,
            Quantity = quantityChecked,
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            OrderDate = orderDate
        };
            _db.Order.Add(newOrder);
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Order.ToList();
            this.Hide();
        }
            

    }
}

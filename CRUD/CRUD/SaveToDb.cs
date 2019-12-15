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

        public SaveToDb()
        {
            CrudWPF _db = new CrudWPF();

           
            InputCheck InsertCheck = new InputCheck();
            InsertCheck.Test();




            //Error = InsertCheck.ErrorTest;
            //MessageBox.Show("Error Test: " + InsertCheck.FirstNameChecked);
            //InsertPage DataCheck = new InsertPage();
            //MessageBox.Show(Convert.ToString(DataCheck.FirstNameTextBox));
            if (InsertCheck.ErrorTest == false)
            {

                
                Order newOrder = new Order()
                {
                    
                Product = InsertCheck.ProductNameChecked,
                    Quantity = InsertCheck.QuantityChecked,
                    FirstName = InsertCheck.FirstNameChecked,
                    LastName = InsertCheck.LastNameChecked,
                    PhoneNumber = InsertCheck.PhoneNumberChecked,
                    OrderDate = InsertCheck.OrderDateChecked
                };
                _db.Order.Add(newOrder);
                _db.SaveChanges();
                MainWindow.datagrid.ItemsSource = _db.Order.ToList();
            }
            else
            {
                //MessageBox.Show("Error - true");
                throw new ArgumentException("Error");
            }


            

         /*   private bool error;
            public bool Error
        {
            get { return error; }

            set { error = value; }
        }
        */



        }
    }
}

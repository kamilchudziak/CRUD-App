using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRUD
{


    public class InputCheck
    {
        InsertPage DataCheck = new InsertPage();
        private string quantityCheck;
        private string orderDateCheck;
        private string phoneNumberCheck;
        private string lastNameCheck;
        private string firstNameCheck;
        private string productNameCheck;

        private int quantityChecked; 
        private string orderDateChecked;
        private string phoneNumberChecked;
        private string lastNameChecked;
        private string firstNameChecked;
        private string productNameChecked;
        private bool errorTest = false;

        public InputCheck()
        {

            quantityCheck = DataCheck.QuantityTextBox;
            orderDateCheck = DataCheck.OrderDateTextBox;
            phoneNumberCheck = DataCheck.PhoneNumberTextBox;
            lastNameCheck = DataCheck.LastNameTextBox;
            firstNameCheck = DataCheck.FirstNameTextBox;
            productNameCheck = DataCheck.ProductNameTextBox;
        }


        
       

        public void Test()
        {


            int valueParsed;
            if (!string.IsNullOrEmpty(quantityCheck))
            {
                if (Int32.TryParse(quantityCheck.Trim(), out valueParsed))
                {
                    quantityChecked = Int32.Parse(quantityCheck);
                }
                else
                {
                    errorTest = true;
                }
            }
            else
            {
                errorTest = true;

            }

            if (!string.IsNullOrEmpty(orderDateCheck))
            {
                orderDateChecked = orderDateCheck;
            }
            else
            {
                errorTest = true;

            }

            if (!string.IsNullOrEmpty(phoneNumberCheck))
            {
                phoneNumberChecked = phoneNumberCheck;
            }
            else
            {
                errorTest = true;

            }

            if (!string.IsNullOrEmpty(lastNameCheck))
            {
                lastNameChecked = lastNameCheck;
            }
            else
            {
                errorTest = true;

            }

            if (!string.IsNullOrEmpty(firstNameCheck))
            {
                firstNameChecked = firstNameCheck;
            }
            else
            {
                errorTest = true;
                

            }

            if (!string.IsNullOrEmpty(productNameCheck))
            {
                productNameChecked = productNameCheck;
            }
            else
            {
                errorTest = true;

            }


        }


        public int QuantityChecked
        {
            get { return quantityChecked; }

        }

        public string OrderDateChecked
        {
            get { return orderDateChecked; }

        }

        public string PhoneNumberChecked
        {
            get { return phoneNumberChecked; }

        }
        public string LastNameChecked
        {
            get { return lastNameChecked; }


        }
        public string FirstNameChecked
        {
            get { return firstNameChecked; } 


        }

        public string ProductNameChecked
        {
            get { return productNameChecked; }


        }

        public bool ErrorTest
        {
            get { return errorTest; }


        }








    }
}

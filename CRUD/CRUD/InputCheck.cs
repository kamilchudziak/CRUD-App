using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected int quantityChecked;
        private string orderDateChecked;
        private string phoneNumberChecked;
        private string lastNameChecked;
        private string firstNameChecked;
        private string productNameChecked;

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
            if (quantityCheck != null)
            {
                if (Int32.TryParse(quantityCheck.Trim(), out valueParsed))
                {
                    quantityChecked = Int32.Parse(quantityCheck);
                }
                else
                {
                    throw new ArgumentException("NaN");
                }
            }
            else
            {
                throw new ArgumentNullException("Null");

            }

            if (orderDateCheck != null)
            {
                orderDateChecked = orderDateCheck;
            }
            else
            {
                throw new ArgumentNullException("Null");

            }

            if (phoneNumberCheck != null)
            {
                phoneNumberChecked = phoneNumberCheck;
            }
            else
            {
                throw new ArgumentNullException("Null");

            }

            if (lastNameCheck != null)
            {
                lastNameChecked = lastNameCheck;
            }
            else
            {
                throw new ArgumentNullException("Null");

            }

            if (firstNameCheck != null)
            {
                firstNameChecked = firstNameCheck;
            }
            else
            {
                throw new ArgumentNullException("Null");

            }

            if (productNameCheck != null)
            {
                productNameChecked = productNameCheck;
            }
            else
            {
                throw new ArgumentNullException("Null");

            }







        }


}
}

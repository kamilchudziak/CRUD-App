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


        public InputCheck()
        {

        }

        public string QuantityToCheck
        {

            get;
            set;


        }
        public string OrderEndDateToCheck
        {
            get;
            set;

        }
        public string OrderDateToCheck
        {
            get;
            set;

        }

        public string PhoneNumberToCheck
        {
            get;
            set;

        }
        public string LastNameToCheck
        {
            get;
            set;


        }
        public string FirstNameToCheck
        {
            get;
            set;


        }

        public string ProductNameToCheck
        {
            get;
            set;


        }




        public void Test()
        {




            int valueParsed;
            if (!string.IsNullOrEmpty(QuantityToCheck))
            {
                if ((Int32.TryParse(QuantityToCheck.Trim(), out valueParsed)) == false)
                {

                    throw new ArgumentException("Quantity field -> It is not a number!");
                }
            }
            else
            {
                throw new ArgumentException("Quantity -> Can not be empty");

            }

            if (string.IsNullOrEmpty(OrderDateToCheck))
            {

                throw new ArgumentException("Order date -> Can not be empty");

            }

            if (string.IsNullOrEmpty(PhoneNumberToCheck))
            {

                throw new ArgumentException("Phone number -> Can not be empty");

            }

            if (string.IsNullOrEmpty(LastNameToCheck))
            {

                throw new ArgumentException("Last name -> Can not be empty");

            }

            if (string.IsNullOrEmpty(FirstNameToCheck))
            {

                throw new ArgumentException("First name -> Can not be empty");


            }

            if (string.IsNullOrEmpty(ProductNameToCheck))
            {

                throw new ArgumentException("Product -> Can not be empty");

            }


        }


        public int QuantityChecked
        {

            get { return Int32.Parse(QuantityToCheck); }

        }
        public string OrderEndDateChecked
        {
            get { return OrderEndDateToCheck; }

        }
        public string OrderDateChecked
        {
            get { return OrderDateToCheck; }

        }

        public string PhoneNumberChecked
        {
            get { return PhoneNumberToCheck; }

        }
        public string LastNameChecked
        {
            get { return LastNameToCheck; }


        }
        public string FirstNameChecked
        {
            get { return FirstNameToCheck; }


        }

        public string ProductNameChecked
        {
            get { return ProductNameToCheck; }


        }










    }
}

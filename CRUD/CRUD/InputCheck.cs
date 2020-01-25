using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRUD
{
    /// <summary>
    /// klasa odpowiedzialna za sprawdzenie poprawnosci wartosci uzyskanych od uzytkownika.
    /// </summary>
    public class InputCheck
    {
        //before parse..
        public string QuantityToCheck { get; set;}
        public string OrderEndDateToCheck { get; set; }
        public string OrderDateToCheck { get; set; }
        public string PhoneNumberToCheck { get; set; }
        public string LastNameToCheck { get; set; }
        public string FirstNameToCheck { get; set; }
        public string ProductNameToCheck { get; set; }

        // after parse things..
        public int QuantityChecked => int.Parse(QuantityToCheck);
        public string OrderEndDateChecked => OrderEndDateToCheck;
        public string OrderDateChecked => OrderDateToCheck;
        public string PhoneNumberChecked => PhoneNumberToCheck;
        public string LastNameChecked => LastNameToCheck;
        public string FirstNameChecked => FirstNameToCheck;
        public string ProductNameChecked => ProductNameToCheck;


        /// <summary>
        /// Sprawdzenie wszystkich pol
        /// </summary>
        public void CheckFields()
        {
            CheckQuantityField();
            CheckOrderDateField();
            CheckPhoneNumberField();
            CheckLastNameField();
            CheckFirstNameField();
            CheckProductNameField();
        }

        /// <summary>
        /// Sprawdzenie pola ProductName
        /// </summary>
        public void CheckProductNameField()
        {
            if (string.IsNullOrEmpty(ProductNameToCheck))
            {
                throw new ArgumentException("Product -> Can not be empty");
            }
        }

        /// <summary>
        /// Sprawdzenie pola FirstName
        /// </summary>
        public void CheckFirstNameField()
        {
            if (string.IsNullOrEmpty(FirstNameToCheck))
            {
                throw new ArgumentException("First name -> Can not be empty");
            }
        }

        /// <summary>
        /// Sprawdzenie pola LastName
        /// </summary>
        public void CheckLastNameField()
        {
            if (string.IsNullOrEmpty(LastNameToCheck))
            {
                throw new ArgumentException("Last name -> Can not be empty");
            }
        }

        /// <summary>
        /// Sprawdzenie pola PhoneNumber
        /// </summary>
        public void CheckPhoneNumberField()
        {
            if (string.IsNullOrEmpty(PhoneNumberToCheck))
            {
                throw new ArgumentException("Phone number -> Can not be empty");
            }
        }

        /// <summary>
        /// Sprawdzenie pola OrderDate
        /// </summary>
        public void CheckOrderDateField()
        {
            if (string.IsNullOrEmpty(OrderDateToCheck))
            {
                throw new ArgumentException("Order date -> Can not be empty");
            }
        }

        /// <summary>
        /// Sprawdzenie pola Quantity
        /// </summary>
        public void CheckQuantityField()
        {
            int valueParsed;
            if (!string.IsNullOrEmpty(QuantityToCheck))
            {
                if ((int.TryParse(QuantityToCheck.Trim(), out valueParsed)) == false)
                {
                    throw new ArgumentException("Quantity field -> It is not a number!");
                }
            }
            else
            {
                throw new ArgumentException("Quantity -> Can not be empty");
            }
        }
    }
}

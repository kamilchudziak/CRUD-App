using System;
using CRUD;
using NUnit.Framework;

namespace Tests
{
    public class InputCheckTests
    {
        [TestCase("piec")]
        [TestCase("Dwa")]
        [TestCase("12Dw")]
        [TestCase("02Ds")]
        public void ThrowsArgumentExceptionWhen_WrongQuantityInput(string input)
        {
            //arrange
            InputCheck inputCheck = new InputCheck();
            ArgumentException actual = null;

            //act
            try
            {
                inputCheck.QuantityToCheck = input;
                inputCheck.CheckQuantityField();
            }
            catch (ArgumentException exception)
            {
                actual = exception;
            }

            //assert
            Assert.IsNotNull(actual);
        }

        [TestCase("2")]
        [TestCase("3")]
        [TestCase("12345")]
        [TestCase("64532")]
        public void PassesWhen_GoodQuantityInput(string input)
        {
            //arrange
            InputCheck inputCheck = new InputCheck();
            ArgumentException actual = null;

            //act
            try
            {
                inputCheck.QuantityToCheck = input;
                inputCheck.CheckQuantityField();
            }
            catch (ArgumentException exception)
            {
                actual = exception;
            }

            //assert
            Assert.IsNull(actual);
        }

        
        [Test]
        public void ThrowsArgumentExceptionWhen_EmptyFirstNameInput()
        {
            //arrange
            InputCheck inputCheck = new InputCheck();
            ArgumentException actual = null;

            //act
            try
            {
                inputCheck.FirstNameToCheck = "";
                inputCheck.CheckFirstNameField();;
            }
            catch (ArgumentException exception)
            {
                actual = exception;
            }

            //assert
            Assert.IsNotNull(actual);
        }

        [TestCase("Seba")]
        [TestCase("Adam")]
        [TestCase("Brian")]
        [TestCase("Jessica")]
        public void PassesWhen_GoodFirstNameInput(string input)
        {
            //arrange
            InputCheck inputCheck = new InputCheck();
            ArgumentException actual = null;

            //act
            try
            {
                inputCheck.FirstNameToCheck = input;
                inputCheck.CheckFirstNameField();
            }
            catch (ArgumentException exception)
            {
                actual = exception;
            }

            //assert
            Assert.IsNull(actual);
        }

        [Test]
        public void ThrowsArgumentExceptionWhen_EmptyLastNameInput()
        {
            //arrange
            InputCheck inputCheck = new InputCheck();
            ArgumentException actual = null;

            //act
            try
            {
                inputCheck.LastNameToCheck = "";
                inputCheck.CheckLastNameField();
            }
            catch (ArgumentException exception)
            {
                actual = exception;
            }

            //assert
            Assert.IsNotNull(actual);
        }

        [TestCase("Kowalski")]
        [TestCase("Einstein")]
        [TestCase("Malysz")]
        [TestCase("Kubica")]
        public void PassesWhen_GoodLastNameInput(string input)
        {
            //arrange
            InputCheck inputCheck = new InputCheck();
            ArgumentException actual = null;

            //act
            try
            {
                inputCheck.LastNameToCheck = input;
                inputCheck.CheckLastNameField();
            }
            catch (ArgumentException exception)
            {
                actual = exception;
            }

            //assert
            Assert.IsNull(actual);
        }

        [Test]
        public void ThrowsArgumentExceptionWhen_EmptyProductNameInput()
        {
            //arrange
            InputCheck inputCheck = new InputCheck();
            ArgumentException actual = null;

            //act
            try
            {
                inputCheck.ProductNameToCheck = "";
                inputCheck.CheckProductNameField();
            }
            catch (ArgumentException exception)
            {
                actual = exception;
            }

            //assert
            Assert.IsNotNull(actual);
        }

        [TestCase("Seba")]
        [TestCase("Adam")]
        [TestCase("Brian")]
        [TestCase("Jessica")]
        public void PassesWhen_GoodProductNameInput(string input)
        {
            //arrange
            InputCheck inputCheck = new InputCheck();
            ArgumentException actual = null;

            //act
            try
            {
                inputCheck.ProductNameToCheck = input;
                inputCheck.CheckProductNameField();
            }
            catch (ArgumentException exception)
            {
                actual = exception;
            }

            //assert
            Assert.IsNull(actual);
        }

        [Test]
        public void ThrowsArgumentExceptionWhen_EmptyPhoneNumberInput()
        {
            //arrange
            InputCheck inputCheck = new InputCheck();
            ArgumentException actual = null;

            //act
            try
            {
                inputCheck.PhoneNumberToCheck = "";
                inputCheck.CheckPhoneNumberField();
            }
            catch (ArgumentException exception)
            {
                actual = exception;
            }

            //assert
            Assert.IsNotNull(actual);
        }

        [TestCase("Seba")]
        [TestCase("Adam")]
        [TestCase("Brian")]
        [TestCase("Jessica")]
        public void PassesWhen_GoodPhoneNumberInput(string input)
        {
            //arrange
            InputCheck inputCheck = new InputCheck();
            ArgumentException actual = null;

            //act
            try
            {
                inputCheck.PhoneNumberToCheck = input;
                inputCheck.CheckPhoneNumberField();
            }
            catch (ArgumentException exception)
            {
                actual = exception;
            }

            //assert
            Assert.IsNull(actual);
        }

        [Test]
        public void ThrowsArgumentExceptionWhen_EmptyOrderDateInput()
        {
            //arrange
            InputCheck inputCheck = new InputCheck();
            ArgumentException actual = null;

            //act
            try
            {
                inputCheck.OrderDateToCheck = "";
                inputCheck.CheckOrderDateField();
            }
            catch (ArgumentException exception)
            {
                actual = exception;
            }

            //assert
            Assert.IsNotNull(actual);
        }

        [TestCase("24/01/2020")]
        [TestCase("04/01/2018")]
        [TestCase("30/01/2019")]
        [TestCase("15/11/2019")]
        public void PassesWhen_GoodOrderDateInput(string input)
        {
            //arrange
            InputCheck inputCheck = new InputCheck();
            ArgumentException actual = null;

            //act
            try
            {
                inputCheck.OrderDateToCheck = input;
                inputCheck.CheckOrderDateField();
            }
            catch (ArgumentException exception)
            {
                actual = exception;
            }

            //assert
            Assert.IsNull(actual);
        }
    }
}
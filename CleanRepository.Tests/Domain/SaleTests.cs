using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using NUnit.Framework;
using System;


namespace CleanRepository.Tests.Domain
{
    [TestFixture]
    public class SaleTests
    {
        private Sale _sale;
        private Customer _customer;
        private Employee _employee;
        private Product _product;

        private const int Id = 1;
        private static readonly DateTime Date = new DateTime(2001, 2, 3);
        private const decimal UnitPrice = 1.00m;
        private const int Quantity = 1;

        [SetUp]
        public void SetUp()
        {
            // Arrange

            _customer = new Customer();

            _employee = new Employee();

            _product = new Product();

            _sale = new Sale();
        }

        [Test]
        public void SaleTests_TestSetAndGetId_No_Error()
        {


            // Act
            _sale.Id = Id;

            // Assert
            Assert.That(_sale.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void SaleTests_TestSetAndGetDate_No_Error()
        {
            _sale.Date = Date;

            Assert.That(_sale.Date,
                Is.EqualTo(Date));
        }

        [Test]
        public void SaleTests_TestSetAndGetCustomer_No_Error()
        {
            _sale.Customer = _customer;

            Assert.That(_sale.Customer,
                Is.EqualTo(_customer));
        }

        [Test]
        public void SaleTests_TestSetAndGetEmployee_No_Error()
        {
            _sale.Employee = _employee;

            Assert.That(_sale.Employee,
                Is.EqualTo(_employee));
        }

        [Test]
        public void SaleTests_TestSetAndGetProduct_No_Error()
        {
            _sale.Product = _product;

            Assert.That(_sale.Product,
                Is.EqualTo(_product));
        }

        [Test]
        public void SaleTests_TestSetAndGetUnitPrice_No_Error()
        {
           
            _sale.UnitPrice = UnitPrice;

            Assert.That(_sale.UnitPrice,
                Is.EqualTo(UnitPrice));
        }

        [Test]
        public void SaleTests_TestSetAndGetQuantity_No_Error()
        {
            _sale.Quantity = Quantity;

            Assert.That(_sale.Quantity,
                Is.EqualTo(Quantity));
        }

        [Test]
        public void SaleTests_TestSetUnitPriceShouldRecomputeTotalPrice_No_Error()
        {
            _sale.Quantity = Quantity;

            _sale.UnitPrice = 1.23m;

            Assert.That(_sale.TotalPrice,
                Is.EqualTo(1.23));
        }

        [Test]
        public void SaleTests_TestSetQuantityShouldRecomputeTotalPrice_No_Error()
        {
            _sale.UnitPrice = UnitPrice;

            _sale.Quantity = 2;

            Assert.That(_sale.TotalPrice,
                Is.EqualTo(2.00m));
        }
    }
}
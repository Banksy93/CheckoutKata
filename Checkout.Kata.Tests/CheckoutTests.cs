using System;
using System.Collections.Generic;
using Checkout.Kata.Interfaces;
using Checkout.Kata.Models;
using Moq;
using NUnit.Framework;

namespace Checkout.Kata.Tests
{
	[TestFixture]
	public class CheckoutTests
	{
		private ICheckout _checkout;

		private Mock<IDiscount> _discountMock;

		[SetUp]
		public void Setup()
		{
			_discountMock = new Mock<IDiscount>();

			_checkout = new Checkout(_discountMock.Object);
		}

		[Test]
		public void Scan_Null_Throws_Argument_Null_Exception()
		{
			Assert.Throws<ArgumentNullException>(() => _checkout.Scan(null));
		}

		[Test]
		public void Scan_Item_Negative_Price_Throws_Argument_Exception()
		{
			// Arrange
			var invalidItem = new Item
			{
				SKU = "B15",
				Price = -0.5m
			};

			// Assert
			Assert.Throws<ArgumentException>(() => _checkout.Scan(invalidItem));
		}

		[Test]
		public void No_Items_Scanned_Total_Is_Zero()
		{
			// Act
			var total = _checkout.Total();

			// Assert
			Assert.AreEqual(0, total);

			_discountMock.Verify(dm => dm.CalculateDiscountAmount(It.IsAny<IEnumerable<Item>>()), Times.Never);
		}

		[Test]
		public void Scan_One_Item_Get_Total()
		{
			// Arrange
			var item = new Item
			{
				SKU = "A99",
				Price = 0.50m
			};

			// Act
			_checkout.Scan(item);

			var total = _checkout.Total();

			// Assert
			Assert.AreEqual(0.50m, total);
		}

		[Test]
		public void Scan_Multiple_Items_Get_Total_Of_All_No_Discount()
		{
			// Arrange
			var items = new List<Item>
			{
				new Item
				{
					SKU = "A99",
					Price = 0.50m
				},
				new Item
				{
					SKU = "B15",
					Price = 0.30m
				},
				new Item
				{
					SKU = "C40",
					Price = 0.60m
				}
			};

			_discountMock.Setup(dm => dm.CalculateDiscountAmount(It.IsAny<IEnumerable<Item>>()))
				.Returns(0);

			// Act
			foreach (var item in items)
			{
				_checkout.Scan(item);
			}

			var total = _checkout.Total();

			// Assert
			Assert.AreEqual(1.40m, total);
		}

		[Test]
		public void Scan_Items_Apply_Single_Discount()
		{
			// Arrange
			var items = new List<Item>
			{
				new Item {SKU = "A99", Price = 0.50m},
				new Item {SKU = "B15", Price = 0.30m},
				new Item {SKU = "C40", Price = 0.60m},
				new Item {SKU = "A99", Price = 0.50m},
				new Item {SKU = "A99", Price = 0.50m}
			};

			_discountMock.Setup(dm => dm.CalculateDiscountAmount(It.IsAny<IEnumerable<Item>>()))
				.Returns(0.2m);

			// Act
			foreach (var item in items)
			{
				_checkout.Scan(item);
			}

			var total = _checkout.Total();

			// Assert
			Assert.AreEqual(2.2m, total);

			_discountMock.Verify(dm => dm.CalculateDiscountAmount(It.IsAny<IEnumerable<Item>>()), Times.Once);
		}

		[Test]
		public void Scan_Items_Apply_Multiple_Discounts()
		{
			// Arrange
			var items = new List<Item>
			{
				new Item {SKU = "A99", Price = 0.50m},
				new Item {SKU = "B15", Price = 0.30m},
				new Item {SKU = "C40", Price = 0.60m},
				new Item {SKU = "A99", Price = 0.50m},
				new Item {SKU = "A99", Price = 0.50m},
				new Item {SKU = "A99", Price = 0.50m},
				new Item {SKU = "A99", Price = 0.50m},
				new Item {SKU = "A99", Price = 0.50m},
				new Item {SKU = "B15", Price = 0.30m}
			};

			_discountMock.Setup(dm => dm.CalculateDiscountAmount(It.IsAny<IEnumerable<Item>>()))
				.Returns(0.55m);

			// Act
			foreach (var item in items)
			{
				_checkout.Scan(item);
			}

			var total = _checkout.Total();

			// Assert
			Assert.AreEqual(3.65m, total);

			_discountMock.Verify(dm => dm.CalculateDiscountAmount(It.IsAny<IEnumerable<Item>>()), Times.Once);
		}
	}
}

﻿using System;
using System.Collections.Generic;
using Checkout.Kata.Interfaces;
using Checkout.Kata.Models;
using NUnit.Framework;

namespace Checkout.Kata.Tests
{
	[TestFixture]
	public class CheckoutTests
	{
		private ICheckout _checkout;

		[SetUp]
		public void Setup()
		{
			_checkout = new Checkout();
		}

		[Test]
		public void Scan_Null_Throws_Argument_Null_Exception()
		{
			Assert.Throws<ArgumentNullException>(() => _checkout.Scan(null));
		}

		[Test]
		public void Scan_Item_Negative_Price_Throws_Argument_Exception()
		{
			var invalidItem = new Item
			{
				SKU = "B15",
				Price = -0.5m
			};

			Assert.Throws<ArgumentException>(() => _checkout.Scan(invalidItem));
		}

		[Test]
		public void No_Items_Scanned_Total_Is_Zero()
		{
			var total = _checkout.Total();

			Assert.AreEqual(0, total);
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
		public void Scan_Multiple_Items_Get_Total_Of_All()
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

			// Act
			foreach (var item in items)
			{
				_checkout.Scan(item);
			}

			var total = _checkout.Total();

			// Assert
			Assert.AreEqual(1.40m, total);
		}
	}
}

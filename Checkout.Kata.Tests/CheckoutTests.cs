using System;
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
	}
}

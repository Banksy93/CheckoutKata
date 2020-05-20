using System.Collections.Generic;
using Checkout.Kata.Interfaces;
using Checkout.Kata.Models;
using NUnit.Framework;

namespace Checkout.Kata.Tests
{
	[TestFixture]
	public class DiscountTests
	{
		private IDiscount _discount;

		[SetUp]
		public void Setup()
		{
			_discount = new Discount();
		}

		[Test]
		public void Caclulate_Discount_No_Special_Offers_To_Be_Applied_Returns_Zero()
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
			var discount = _discount.CalculateDiscountAmount(items);

			// Assert
			Assert.AreEqual(0, discount);
		}

		[Test]
		public void Calculate_Discount_Single_Special_Offer_Applied()
		{
			// Arrange
			var items = new List<Item>
			{
				new Item { SKU = "A99", Price = 0.50m },
				new Item { SKU = "B15", Price = 0.30m },
				new Item { SKU = "C40", Price = 0.60m },
				new Item { SKU = "A99", Price = 0.50m },
				new Item { SKU = "A99", Price = 0.50m }
			};

			// Act
			var discount = _discount.CalculateDiscountAmount(items);

			// Assert
			Assert.AreEqual(0.20m, discount);
		}

		[Test]
		public void Cacluate_Discount_Multiple_Special_Offers_Applied()
		{
			// Arrange
			var items = new List<Item>
			{
				new Item { SKU = "A99", Price = 0.50m },
				new Item { SKU = "B15", Price = 0.30m },
				new Item { SKU = "C40", Price = 0.60m },
				new Item { SKU = "A99", Price = 0.50m },
				new Item { SKU = "A99", Price = 0.50m },
				new Item { SKU = "B15", Price = 0.30m },
				new Item { SKU = "A99", Price = 0.50m },
				new Item { SKU = "A99", Price = 0.50m },
				new Item { SKU = "A99", Price = 0.50m }
			};

			// Act
			var discount = _discount.CalculateDiscountAmount(items);

			// Assert
			Assert.AreEqual(0.55m, discount);
		}

		[Test]
		public void Calculate_Single_Discount_Applied_With_Five_One_Item()
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
				new Item {SKU = "A99", Price = 0.50m}
			};

			// Act
			var discount = _discount.CalculateDiscountAmount(items);

			// Assert
			Assert.AreEqual(0.20m, discount);
		}
	}
}

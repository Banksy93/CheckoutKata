using System;
using System.Collections.Generic;
using System.Linq;
using Checkout.Kata.Interfaces;
using Checkout.Kata.Models;

namespace Checkout.Kata
{
	public class Checkout : ICheckout
	{
		private readonly IDiscount _discount;

		private readonly IList<Item> _items = new List<Item>();

		public Checkout(IDiscount discount)
		{
			_discount = discount;
		}

		public void Scan(Item item)
		{
			if (item == null)
				throw new ArgumentNullException();

			if (item.Price < 0)
				throw new ArgumentException("Item price must be greater than zero.");

			_items.Add(item);
		}

		public decimal Total()
		{
			if (!_items.Any())
				return 0;

			var total = _items.Sum(item => item.Price);

			var discountAmount = _discount.CalculateDiscountAmount(_items);

			return total - discountAmount;
		}
	}
}

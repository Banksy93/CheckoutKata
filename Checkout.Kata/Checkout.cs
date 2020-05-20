﻿using System;
using System.Collections.Generic;
using System.Linq;
using Checkout.Kata.Interfaces;
using Checkout.Kata.Models;

namespace Checkout.Kata
{
	public class Checkout : ICheckout
	{
		private readonly IList<Item> _items = new List<Item>();

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
			return _items.Any() ? _items.Sum(item => item.Price) : 0;
		}
	}
}

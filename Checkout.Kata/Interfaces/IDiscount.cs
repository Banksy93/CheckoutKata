using System.Collections.Generic;
using Checkout.Kata.Models;

namespace Checkout.Kata.Interfaces
{
	public interface IDiscount
	{
		/// <summary>
		/// Calculate the discount (if any) to take off the basket total
		/// </summary>
		/// <param name="items"></param>
		/// <returns></returns>
		decimal CalculateDiscountAmount(IEnumerable<Item> items);
	}
}

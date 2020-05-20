using Checkout.Kata.Models;

namespace Checkout.Kata.Interfaces
{
	public interface ICheckout
	{
		/// <summary>
		/// Scan an item at the checkout
		/// </summary>
		/// <param name="item"></param>
		void Scan(Item item);
	}
}

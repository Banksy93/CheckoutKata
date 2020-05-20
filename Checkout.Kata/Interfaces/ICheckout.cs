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

		/// <summary>
		/// Get the total price of scanned items
		/// </summary>
		/// <returns></returns>
		decimal Total();
	}
}

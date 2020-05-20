using System.Collections.Generic;
using System.Linq;
using Checkout.Kata.Interfaces;
using Checkout.Kata.Models;

namespace Checkout.Kata
{
	public class Discount : IDiscount
	{
		public decimal CalculateDiscountAmount(IEnumerable<Item> items)
		{
			decimal totalDiscount = 0;

			var offers = GetSpecialOffers();

			foreach (var offer in offers)
			{
				var count = items.Count(item => item.SKU == offer.SKU);
				totalDiscount += (count / offer.Quantity) * offer.DiscountAmout;
			}

			return totalDiscount;
		}

		/// <summary>
		/// Get a list of current special offers
		/// </summary>
		/// <returns></returns>
		private static IList<SpecialOffer> GetSpecialOffers()
		{
			return new List<SpecialOffer>
			{
				new SpecialOffer {SKU = "A99", Quantity = 3, DiscountAmout = 0.20m},
				new SpecialOffer {SKU = "B15", Quantity = 2, DiscountAmout = 0.15m}
			};
		}
	}
}

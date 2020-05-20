using Checkout.Kata.Interfaces;
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
	}
}

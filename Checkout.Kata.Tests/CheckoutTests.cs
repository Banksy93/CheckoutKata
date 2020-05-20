using Checkout.Kata.Interfaces;
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
	}
}

using System.Collections.Generic;
using Xunit;

namespace CheckoutKataApp.Tests
{
    public class DefaultCheckout_GetTotalPrice_Should
    {
        [Fact]
        public void Return50ForOneA()
        {            
            var checkout = new DefaultCheckout(null);

            checkout.Scan("A");

            var total = checkout.GetTotalPrice();

            Assert.Equal(50, total);
        }

        [Fact]
        public void Return0ForNoItems()
        {
            var checkout = new DefaultCheckout(null);

            var total = checkout.GetTotalPrice();

            Assert.Equal(0, total);
        }

        [Fact]
        public void Return30ForOneB()
        {
            var checkout = new DefaultCheckout(null);

            checkout.Scan("B");

            var total = checkout.GetTotalPrice();

            Assert.Equal(30, total);
        }

        [Fact]
        public void Return100ForTwoAs()
        {
            var checkout = new DefaultCheckout(null);

            checkout.Scan("A");
            checkout.Scan("A");

            var total = checkout.GetTotalPrice();

            Assert.Equal(100, total);
        }

        [Fact]
        public void ReturnCorrectPriceForAConfiguredPrice()
        {
            var prices = new Dictionary<string, int>();
            prices["C"] = 20;

            var checkout = new DefaultCheckout(prices);

            checkout.Scan("C");
            
            var total = checkout.GetTotalPrice();

            Assert.Equal(20, total);
        }

    }
}

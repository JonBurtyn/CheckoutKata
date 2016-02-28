using System.Collections.Generic;
using Xunit;

namespace CheckoutKataApp.Tests
{
    public class DefaultCheckout_GetTotalPrice_Should
    {
        [Fact]
        public void Return50ForOneA()
        {
            var configuredPrices = new Dictionary<string, Prices>();
            configuredPrices["A"] = new Prices() { UnitPrice = 50 };
            var checkout = new DefaultCheckout(configuredPrices);
            checkout.Scan("A");

            var total = checkout.GetTotalPrice();

            Assert.Equal(50, total);
        }

        [Fact]
        public void Return0ForNoItems()
        {
            var configuredPrices = new Dictionary<string, Prices>();
            configuredPrices["A"] = new Prices() { UnitPrice = 50 };
            var checkout = new DefaultCheckout(configuredPrices);

            var total = checkout.GetTotalPrice();

            Assert.Equal(0, total);
        }

        [Fact]
        public void Return30ForOneB()
        {
            var configuredPrices = new Dictionary<string, Prices>();
            configuredPrices["B"] = new Prices() { UnitPrice = 30 };
            var checkout = new DefaultCheckout(configuredPrices);
            checkout.Scan("B");

            var total = checkout.GetTotalPrice();

            Assert.Equal(30, total);
        }

        [Fact]
        public void Return100ForTwoAs()
        {
            var configuredPrices = new Dictionary<string, Prices>();
            configuredPrices["A"] = new Prices() { UnitPrice = 50 };
            var checkout = new DefaultCheckout(configuredPrices);

            checkout.Scan("A");
            checkout.Scan("A");

            var total = checkout.GetTotalPrice();

            Assert.Equal(100, total);
        }

        [Fact]
        public void ReturnCorrectPriceForAConfiguredPrice()
        {
            var configuredPrices = new Dictionary<string, Prices>();
            configuredPrices["C"] = new Prices() { UnitPrice = 20 };
            var checkout = new DefaultCheckout(configuredPrices);
            checkout.Scan("C");
            
            var total = checkout.GetTotalPrice();

            Assert.Equal(20, total);
        }

        [Fact]
        public void ReturnSpecialPriceOf130ForThreeAs()
        {
            var configuredPrices = new Dictionary<string, Prices>();
            configuredPrices["A"] = new Prices() { UnitPrice = 50, SpecialPrice = new SpecialPrice() { Quantity = 3, Price = 130 }};
            var checkout = new DefaultCheckout(configuredPrices);

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            var total = checkout.GetTotalPrice();

            Assert.Equal(130, total);
        }
    }
}

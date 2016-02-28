﻿using System.Collections.Generic;
using Xunit;

namespace CheckoutKataApp.Tests
{
    public class DefaultCheckout_GetTotalPrice_Should
    {
        [Fact]
        public void Return50ForOneA()
        {
            var configuredPrices = new Dictionary<string, int>();
            configuredPrices["A"] = 50;
            var checkout = new DefaultCheckout(configuredPrices);
            checkout.Scan("A");

            var total = checkout.GetTotalPrice();

            Assert.Equal(50, total);
        }

        [Fact]
        public void Return0ForNoItems()
        {
            var configuredPrices = new Dictionary<string, int>();
            configuredPrices["A"] = 50;
            var checkout = new DefaultCheckout(configuredPrices);

            var total = checkout.GetTotalPrice();

            Assert.Equal(0, total);
        }

        [Fact]
        public void Return30ForOneB()
        {
            var configuredPrices = new Dictionary<string, int>();
            configuredPrices["B"] = 30;
            var checkout = new DefaultCheckout(configuredPrices);
            checkout.Scan("B");

            var total = checkout.GetTotalPrice();

            Assert.Equal(30, total);
        }

        [Fact]
        public void Return100ForTwoAs()
        {
            var configuredPrices = new Dictionary<string, int>();
            configuredPrices["A"] = 50;
            var checkout = new DefaultCheckout(configuredPrices);

            checkout.Scan("A");
            checkout.Scan("A");

            var total = checkout.GetTotalPrice();

            Assert.Equal(100, total);
        }

        [Fact]
        public void ReturnCorrectPriceForAConfiguredPrice()
        {
            var configuredPrices = new Dictionary<string, int>();
            configuredPrices["C"] = 20;
            var checkout = new DefaultCheckout(configuredPrices);
            checkout.Scan("C");
            
            var total = checkout.GetTotalPrice();

            Assert.Equal(20, total);
        }
    }
}

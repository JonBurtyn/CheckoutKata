using Xunit;

namespace CheckoutKataApp.Tests
{
    public class DefaultCheckout_GetTotalPrice_Should
    {
        [Fact]
        public void Return50ForOneA()
        {
            var checkout = new DefaultCheckout();

            checkout.Scan("A");

            var total = checkout.GetTotalPrice();

            Assert.Equal(50, total);
        }

        [Fact]
        public void Return0ForNoItems()
        {
            var checkout = new DefaultCheckout();

            var total = checkout.GetTotalPrice();

            Assert.Equal(0, total);
        }

    }
}

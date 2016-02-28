using System;
using Xunit;

namespace CheckoutKataApp.Tests
{
    public class DefaultPriceCalculator_Constructor_Should
    {
        [Fact]
        public void ThrowExceptionWhenConfiguredPricesAreNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new DefaultPriceCalculator(null));

            Assert.Equal("configuredPrices", ex.ParamName);
        }
    }
}

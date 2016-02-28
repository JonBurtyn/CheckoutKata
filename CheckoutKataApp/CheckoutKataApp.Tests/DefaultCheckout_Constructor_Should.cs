using System;
using Xunit;

namespace CheckoutKataApp.Tests
{
    public class DefaultCheckout_Constructor_Should
    {
        [Fact]
        public void ThrowExceptionWhenConfiguredPricesAreNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new DefaultCheckout(null));

            Assert.Equal("prices", ex.ParamName);
        }
    }
}

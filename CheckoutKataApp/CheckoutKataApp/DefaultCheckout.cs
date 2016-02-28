using System;

namespace CheckoutKataApp
{
    public class DefaultCheckout : ICheckout
    {
        public void Scan(string item)
        {
            throw new NotImplementedException();
        }

        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}

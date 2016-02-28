using System;

namespace CheckoutKataApp
{
    public class DefaultCheckout : ICheckout
    {
        public void Scan(string item)
        {
            
        }

        public int GetTotalPrice()
        {
            return 50;
        }
    }
}

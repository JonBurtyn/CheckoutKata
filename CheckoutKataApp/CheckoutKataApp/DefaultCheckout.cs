using System;
using System.Linq;
using System.Collections.Generic;

namespace CheckoutKataApp
{
    public class DefaultCheckout : ICheckout
    {
        private List<string> items = new List<string>();

        public void Scan(string item)
        {
            this.items.Add(item);
        }

        public int GetTotalPrice()
        {
            if (items.Any())
                return 50;

            return 0;
        }
    }
}

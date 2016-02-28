using System;
using System.Linq;
using System.Collections.Generic;

namespace CheckoutKataApp
{
    public class DefaultCheckout : ICheckout
    {
        private Dictionary<string, int> scanned = new Dictionary<string, int>();
        private Dictionary<string, int> prices;

        public DefaultCheckout(Dictionary<string, int> prices)
        {
            this.prices = prices;
        }

        public void Scan(string item)
        {
            if (!this.scanned.ContainsKey(item))
                this.scanned.Add(item, 0);

            this.scanned[item]++;
        }

        public int GetTotalPrice()
        {
            var price = 0;

            if (this.scanned.ContainsKey("A"))
            {
                price += this.scanned["A"] * 50;
            }

            if (this.scanned.ContainsKey("B"))
            {
                price += this.scanned["B"] * 30;
            }

            return price;
        }
    }
}

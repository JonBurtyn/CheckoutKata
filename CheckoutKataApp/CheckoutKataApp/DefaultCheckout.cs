using System;
using System.Linq;
using System.Collections.Generic;

namespace CheckoutKataApp
{
    public class DefaultCheckout : ICheckout
    {
        private Dictionary<string, int> scanned = new Dictionary<string, int>();
        private Dictionary<string, int> configuredPrices;

        public DefaultCheckout(Dictionary<string, int> configuredPrices)
        {
            if (configuredPrices == null) throw new ArgumentNullException("configuredPrices");

            this.configuredPrices = configuredPrices;
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

            foreach (var configuredPrice in this.configuredPrices)
            {
                if (this.scanned.ContainsKey(configuredPrice.Key))
                {
                    price += this.scanned[configuredPrice.Key] * configuredPrice.Value;
                }
            }

            return price;
        }
    }
}

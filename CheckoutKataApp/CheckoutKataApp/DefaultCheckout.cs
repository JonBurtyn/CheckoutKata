using System;
using System.Linq;
using System.Collections.Generic;

namespace CheckoutKataApp
{
    public class DefaultCheckout : ICheckout
    {
        private Dictionary<string, int> scanned = new Dictionary<string, int>();
        private IPriceCalculator priceCalculator;
        
        public DefaultCheckout(IPriceCalculator priceCalculator)
        {
            if (priceCalculator == null) throw new ArgumentNullException("priceCalculator");

            this.priceCalculator = priceCalculator;
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

            foreach (var keyValuePair in this.scanned)
            {
                price += this.priceCalculator.GetPrice(keyValuePair.Key, keyValuePair.Value);
            }



            //foreach (var configuredPrice in this.configuredPrices)
            //{
            //    if (this.scanned.ContainsKey(configuredPrice.Key))
            //    {
            //        var quantity = this.scanned[configuredPrice.Key];
            //        var specialPrice = configuredPrice.Value.SpecialPrice;

            //        if (specialPrice != null)
            //        {
            //            var specialPriceLots = quantity / specialPrice.Quantity;
            //            price += specialPriceLots * specialPrice.Price;
            //            quantity -= specialPriceLots * specialPrice.Quantity;
            //        }

            //        price += quantity * configuredPrice.Value.UnitPrice;
            //    }
            //}

            return price;
        }
    }
}

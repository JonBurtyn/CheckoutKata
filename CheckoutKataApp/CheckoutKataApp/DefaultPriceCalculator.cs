using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKataApp
{
    public class DefaultPriceCalculator : IPriceCalculator
    {
        private Dictionary<string, Prices> configuredPrices;

        public DefaultPriceCalculator(Dictionary<string, Prices> configuredPrices)
        {
            if (configuredPrices == null) throw new ArgumentNullException("configuredPrices");

            this.configuredPrices = configuredPrices;
        }

        public int GetPrice(string sku, int quantity)
        {
            var price = 0;

            //foreach (var configuredPrice in this.configuredPrices)
            //{
            if (this.configuredPrices.ContainsKey(sku))
                {
                    //var specialPriceQuantity = this.configuredPrices[sku].SpecialPrice.Quantity;
                    var specialPrice = this.configuredPrices[sku].SpecialPrice;

                    if (specialPrice != null)
                    {
                        var specialPriceLots = quantity / specialPrice.Quantity;
                        price += specialPriceLots * specialPrice.Price;
                        quantity -= specialPriceLots * specialPrice.Quantity;
                    }

                    price += quantity * this.configuredPrices[sku].UnitPrice;
                }
            //}

            return price;
        }
    }
}

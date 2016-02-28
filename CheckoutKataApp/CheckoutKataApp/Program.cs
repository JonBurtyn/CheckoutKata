using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKataApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Would use a DI container in production
            var checkout = new DefaultCheckout(new DefaultPriceCalculator(LoadPrices()));

            Console.WriteLine("Enter one SKU per line then # to calculate the total:");
            var input = Console.ReadLine();

            while (input != "#")
            {
                checkout.Scan(input);
                input = Console.ReadLine();
            }

            Console.WriteLine("Total: " + checkout.GetTotalPrice());
            Console.ReadLine();
        }

        private static Dictionary<string, Prices> LoadPrices()
        {
            // These might come from a database in production, but are hardcoded in this sample
            var configuredPrices = new Dictionary<string, Prices>();
            configuredPrices["A"] = new Prices() { UnitPrice = 50, SpecialPrice = new SpecialPrice() { Quantity = 3, Price = 130  } };
            configuredPrices["B"] = new Prices() { UnitPrice = 30, SpecialPrice = new SpecialPrice() { Quantity = 2, Price = 45 } };
            configuredPrices["C"] = new Prices() { UnitPrice = 20 };
            configuredPrices["D"] = new Prices() { UnitPrice = 15 };

            return configuredPrices;
        }
    }
}

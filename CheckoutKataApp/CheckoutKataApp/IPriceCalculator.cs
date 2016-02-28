
namespace CheckoutKataApp
{
    public interface IPriceCalculator
    {
        int GetPrice(string sku, int quantity);
    }
}

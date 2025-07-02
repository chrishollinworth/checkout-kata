using CheckoutService;
using System.Linq;

public class SkuAOfferLogic : IOfferLogic
{
    private const string OfferSkuTrigger = "A";
    private const int OfferQuantityTrigger = 3;
    private const int OfferPriceTrigger = 130;

    public int CalculateOffer(List<CheckoutItem> items)
    {
        var itemExists = items.Select(item => item.Sku == OfferSkuTrigger).Any();
        if (itemExists)
        {
            var item = items.Where(item => item.Sku == OfferSkuTrigger).First();
            item.LineTotal = item.UnitPrice;
            return item.UnitPrice;
        }

        return 0;
    }
}
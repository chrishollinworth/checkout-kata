using CheckoutService;
using System.Linq;

public class SkuAOfferLogic : IOfferLogic
{
    private const string OfferSkuTrigger = "A";
    private const int OfferQuantityTrigger = 3;
    private const int OfferPriceTrigger = 130;

    public int CalculateOffer(List<CheckoutItem> items)
    {
        var itemExists = items.First(item => item.Sku == OfferSkuTrigger);
        if (itemExists is not null)
        {
            itemExists.LineTotal = itemExists.Quantity % OfferQuantityTrigger == 0 ? (itemExists.Quantity / 3) * 130 : ((itemExists.Quantity / OfferQuantityTrigger) * OfferPriceTrigger) + ((itemExists.Quantity % OfferQuantityTrigger) * itemExists.UnitPrice);
        }

        return 0;
    }
}
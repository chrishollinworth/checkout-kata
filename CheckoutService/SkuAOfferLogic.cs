namespace CheckoutService
{
    public class SkuAOfferLogic : IOfferLogic
    {
        public const string OfferSkuTrigger = "A";
        public const int OfferQuantityTrigger = 3;
        public const int OfferPriceTrigger = 130;

        public void CalculateOffer(List<CheckoutItem> items)
        {
            var itemExists = items.Find(item => item.Sku == OfferSkuTrigger);
            if (itemExists is not null)
            {
                itemExists.LineTotal = itemExists.Quantity % OfferQuantityTrigger == 0 ? ((itemExists.Quantity / OfferQuantityTrigger) * OfferPriceTrigger) : ((itemExists.Quantity / OfferQuantityTrigger) * OfferPriceTrigger) + ((itemExists.Quantity % OfferQuantityTrigger) * itemExists.UnitPrice);
                itemExists.OfferApplied = true;
            }

            return;
        }
    }
}
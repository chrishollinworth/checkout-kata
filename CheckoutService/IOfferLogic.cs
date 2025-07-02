namespace CheckoutService
{
    public interface IOfferLogic
    {
        void CalculateOffer(List<CheckoutItem> items);
    }
}
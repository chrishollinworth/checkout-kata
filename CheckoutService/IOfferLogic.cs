namespace CheckoutService
{
    public interface IOfferLogic
    {
        int CalculateOffer(List<CheckoutItem> items);
    }
}
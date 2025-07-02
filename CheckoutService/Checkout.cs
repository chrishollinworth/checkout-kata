namespace CheckoutService
{

    public class Checkout : ICheckout
    {
        private readonly List<CheckoutItem> items;

        private readonly List<IOfferLogic> offersLogic;

        public void Scan(string item)
        {

        }

        public int GetTotalPrice()
        {

        }
    }
}
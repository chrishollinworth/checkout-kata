namespace CheckoutService
{
    using System.Linq;

    public class Checkout : ICheckout
    {
        private readonly List<CheckoutProduct> products;

        private readonly List<IOfferLogic> offersLogic;

        private List<CheckoutItem> items = new List<CheckoutItem>();

        public Checkout(List<CheckoutProduct> products, List<IOfferLogic> offersLogic)
        {
            this.products = products;
            this.offersLogic = offersLogic;
        }

        public void Scan(string item)
        {
            // lookup unit price (assume if no price found do not add to basket)
            var chosenProduct = this.products.Find(i => i.Sku == item);
            if (chosenProduct is null)
            {
                return;
            }

            if (!this.items.Select(i => i.Sku == item).Any())
                {
                    this.items.Add(new CheckoutItem(item, 1, chosenProduct.UnitPrice, 0));
                }
                else
                {
                    var updatedItem = this.items.Find(i => i.Sku == item);
                    if (updatedItem is not null)
                    {
                        updatedItem.Quantity = updatedItem.Quantity++;
                    }
                }
        }

        public int GetTotalPrice()
        {
            return 0;
        }
    }
}
namespace CheckoutService
{
    using System.Linq;

    public class Checkout : ICheckout
    {
        private List<CheckoutProduct> products = new List<CheckoutProduct>
        {
            new CheckoutProduct("A", 50),
            new CheckoutProduct("B", 30),
            new CheckoutProduct("C", 20),
            new CheckoutProduct("D", 15),
        };
        private readonly List<CheckoutItem> items;

        private readonly List<IOfferLogic> offersLogic;

        public void Scan(string item)
        {
            // lookup unit price (assume if no price found do not add to basket)
            var chosenProduct = products.Find(i => i.Sku == item);
            if (chosenProduct is null)
            {
                return;
            }

            if (!items.Select(i => i.Sku == item).Any())
                {
                    items.Add(new CheckoutItem(item, 1, chosenProduct.UnitPrice, 0));
                }
                else
                {
                    var updatedItem = items.Find(i => i.Sku == item);
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
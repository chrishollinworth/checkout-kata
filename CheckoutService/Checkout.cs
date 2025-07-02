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

            if (this.items.Where(i => i.Sku == item).Any())
            {
                var updatedItem = this.items.Find(i => i.Sku == item);
                if (updatedItem is not null)
                {
                    updatedItem.Quantity++;
                }
            }
            else
            {
                this.items.Add(new CheckoutItem(chosenProduct.Sku, chosenProduct.UnitPrice, 1, 0, false));
            }
        }

        public int GetTotalPrice()
        {
            this.items = this.items.Select(lineItem =>
            new CheckoutItem(
                lineItem.Sku,
                lineItem.UnitPrice,
                lineItem.Quantity,
                lineItem.LineTotal = this.CalculateLineTotal(lineItem.Quantity, lineItem.UnitPrice),
                false)).ToList();

            foreach (IOfferLogic offer in this.offersLogic)
            {
                offer.CalculateOffer(this.items);
            }

            return this.items.Sum(item => item.LineTotal);
        }

        private int CalculateLineTotal(int quantity, int unitPrice)
        {
            return quantity * unitPrice;
        }
    }
}
namespace CheckoutService
{
    public class CheckoutItem
    {
        public CheckoutItem(string sku, int unitPrice, int quantity, int lineTotal, bool offerApplied)
        {
            this.Sku = sku;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
            this.LineTotal = lineTotal;
            this.OfferApplied = offerApplied;
        }

        public string Sku { get; set; }

        public int UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int LineTotal { get; set; }

        public bool OfferApplied { get; set; }
    }
}

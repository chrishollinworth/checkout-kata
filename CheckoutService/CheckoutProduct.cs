namespace CheckoutService
{
    public class CheckoutProduct
    {
        public CheckoutProduct(string sku, int unitPrice)
        {
            this.Sku = sku;
            this.UnitPrice = unitPrice;
        }

        public string Sku { get; set; }

        public int UnitPrice { get; set; }
    }
}
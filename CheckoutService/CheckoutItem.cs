namespace CheckoutService
{
    public class CheckoutItem
    {
        public CheckoutItem(string sku, int unitprice, int quantity = 0, int linetotal = 0)
        {
            this.Sku = sku;
            this.UnitPrice = unitprice;
            this.Quantity = quantity;
            this.LineTotal = linetotal;
        }

        public string Sku { get; set; }

        public int UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int LineTotal { get; set; }
    }
}

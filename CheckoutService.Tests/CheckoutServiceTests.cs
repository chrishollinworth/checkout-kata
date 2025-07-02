namespace CheckoutService.Tests
{
    using CheckoutService;
    public class CheckoutServiceTests
    {
        private List<CheckoutProduct> testProducts = new List<CheckoutProduct>
        {
            new CheckoutProduct("A", 50),
            new CheckoutProduct("B", 30),
            new CheckoutProduct("C", 20),
            new CheckoutProduct("D", 15),
        };

        private List<IOfferLogic> offersLogic = new List<IOfferLogic>();

        [Fact]
        public void EmptyOrder()
        {
            // Act
            ICheckout checkoutService = new Checkout(this.testProducts, this.offersLogic);

            // Arrange
            var result = checkoutService.GetTotalPrice();

            // Assert
            Assert.Equal(0, result);

        }

        [Fact]
        public void AddUnknownItemNegative()
        {

        }


        public void AddKnownItemPositive()
        {

        }
    }
}
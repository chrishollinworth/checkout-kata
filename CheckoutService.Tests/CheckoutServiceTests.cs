namespace CheckoutService.Tests
{
    public class CheckoutServiceTests
    {
        private List<CheckoutProduct> testProducts = new List<CheckoutProduct>
        {
            new CheckoutProduct("A", 50),
            new CheckoutProduct("B", 30),
            new CheckoutProduct("C", 20),
            new CheckoutProduct("D", 15),
        };


        [Fact]
        public void EmptyOrder()
        {
            // Act

            // Arrange
            // Assert
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
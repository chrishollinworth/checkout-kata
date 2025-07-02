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

        private List<IOfferLogic> offersLogic = new List<IOfferLogic>
        {
           new SkuAOfferLogic(),
        };

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
            // Act
            ICheckout checkoutService = new Checkout(this.testProducts, this.offersLogic);

            // Arrange
            checkoutService.Scan("E");
            var result = checkoutService.GetTotalPrice();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void AddKnownItemPositive()
        {
            // Act
            string testProduct = "A";
            ICheckout checkoutService = new Checkout(this.testProducts, this.offersLogic);

            // Arrange
            checkoutService.Scan(testProduct);
            var result = checkoutService.GetTotalPrice();

            // Assert
            int expectedTotal = this.testProducts.Where(item => item.Sku == testProduct).First().UnitPrice;
            Assert.Equal(expectedTotal, result);
        }

        [Fact]
        public void TriggerSkuAOfferPositive()
        {
            // Act
            string testProduct = "A";
            ICheckout checkoutService = new Checkout(this.testProducts, this.offersLogic);

            // Arrange
            checkoutService.Scan(testProduct);
            checkoutService.Scan(testProduct);
            checkoutService.Scan(testProduct);
            var result = checkoutService.GetTotalPrice();

            // Assert
            int expectedTotal = SkuAOfferLogic.OfferPriceTrigger;
            Assert.Equal(expectedTotal, result);
        }

        [Fact]
        public void TriggerSkuAOffer2Positive()
        {
            // Act
            string testProduct = "A";
            ICheckout checkoutService = new Checkout(this.testProducts, this.offersLogic);

            // Arrange
            checkoutService.Scan(testProduct);
            checkoutService.Scan(testProduct);
            checkoutService.Scan(testProduct);
            checkoutService.Scan(testProduct);
            checkoutService.Scan(testProduct);
            checkoutService.Scan(testProduct);
            var result = checkoutService.GetTotalPrice();

            // Assert
            int expectedTotal = SkuAOfferLogic.OfferPriceTrigger * 2;
            Assert.Equal(expectedTotal, result);
        }

        [Fact]
        public void TriggerSkuAOfferBoundaryPositive()
        {
            // Act
            string testProduct = "A";
            ICheckout checkoutService = new Checkout(this.testProducts, this.offersLogic);

            // Arrange
            checkoutService.Scan(testProduct);
            checkoutService.Scan(testProduct);
            checkoutService.Scan(testProduct);
            checkoutService.Scan(testProduct);
            checkoutService.Scan(testProduct);
            checkoutService.Scan(testProduct);
            checkoutService.Scan(testProduct);
            var result = checkoutService.GetTotalPrice();

            // Assert
            int expectedTotal = (SkuAOfferLogic.OfferPriceTrigger * 2) + this.testProducts.First(item => item.Sku == testProduct).UnitPrice;
            Assert.Equal(expectedTotal, result);
        }

        [Fact]
        public void TriggerSkuAOfferBoundaryMultiProducts()
        {
            // Act
            string testProductA = "A";
            string testProductB = "B";
            ICheckout checkoutService = new Checkout(this.testProducts, this.offersLogic);

            // Arrange
            checkoutService.Scan(testProductA);
            checkoutService.Scan(testProductA);
            checkoutService.Scan(testProductA);
            checkoutService.Scan(testProductA);
            checkoutService.Scan(testProductA);
            checkoutService.Scan(testProductA);
            checkoutService.Scan(testProductA);
            checkoutService.Scan(testProductB);
            var result = checkoutService.GetTotalPrice();

            // Assert
            int expectedTotal = (SkuAOfferLogic.OfferPriceTrigger * 2) + this.testProducts.First(item => item.Sku == testProductA).UnitPrice + this.testProducts.First(item => item.Sku == testProductB).UnitPrice;
            Assert.Equal(expectedTotal, result);
        }

    }
}
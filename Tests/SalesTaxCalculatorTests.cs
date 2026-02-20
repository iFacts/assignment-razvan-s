using System.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class SalesTaxCalculatorTests
    {
        [Test]
        public void FirstExample()
        {
            var receiptDetails = SalesTaxCalculator.Process(
                new Item("Magazine", 10.49m, Category.Magazines),
                new Item("Shirt", 34.99m),
                new Item("Package of milk", 0.85m, Category.Food));
            var receiptItems = receiptDetails.ReceiptItems.ToList();
            Assert.That(receiptItems[0].PriceIncludingSalesTax, Is.EqualTo(10.49m));
            Assert.That(receiptItems[1].PriceIncludingSalesTax, Is.EqualTo(40.24m));
            Assert.That(receiptItems[2].PriceIncludingSalesTax, Is.EqualTo(0.85m));
            Assert.That(receiptDetails.SalesTax, Is.EqualTo(5.25m));
            Assert.That(receiptDetails.Total, Is.EqualTo(51.58m));
        }

        [Test]
        public void SecondExample()
        {
            var receiptDetails = SalesTaxCalculator.Process(
                new Item("Imported box of chocolates", 10m, Category.Food, true),
                new Item("Imported bottle of perfume", 47.50m, true));
            var receiptItems = receiptDetails.ReceiptItems.ToList();
            Assert.That(receiptItems[0].PriceIncludingSalesTax, Is.EqualTo(11.00m));
            Assert.That(receiptItems[1].PriceIncludingSalesTax, Is.EqualTo(59.38m));
            Assert.That(receiptDetails.SalesTax, Is.EqualTo(12.88m));
            Assert.That(receiptDetails.Total, Is.EqualTo(70.38m));
        }

        [Test]
        public void ThirdExample()
        {
            var receiptDetails = SalesTaxCalculator.Process(
                new Item("Imported bottle of perfume", 27.99m, true),
                new Item("Bottle of perfume", 18.99m),
                new Item("USB drive", 9.75m, Category.Electronics),
                new Item("Box of imported chocolates", 11.25m, Category.Food, true));
            var receiptItems = receiptDetails.ReceiptItems.ToList();
            Assert.That(receiptItems[0].PriceIncludingSalesTax, Is.EqualTo(34.99m));
            Assert.That(receiptItems[1].PriceIncludingSalesTax, Is.EqualTo(21.84m));
            Assert.That(receiptItems[2].PriceIncludingSalesTax, Is.EqualTo(9.75m));
            Assert.That(receiptItems[3].PriceIncludingSalesTax, Is.EqualTo(12.38m));
            Assert.That(receiptDetails.SalesTax, Is.EqualTo(10.97m));
            Assert.That(receiptDetails.Total, Is.EqualTo(78.95m));
        }
    }
}

using Assignment.Entities;
using Assignment.Services;

namespace Tests
{
    [TestFixture]
    public class SalesTaxCalculatorTests
    {
        [Test]
        public void FirstExample()
        {
            var receiptDetails = SalesTaxCalculator.Process(
                new Item("Magazine", 10.49m, category: Category.Magazines),
                new Item("Shirt", 34.99m),
                new Item("Package of milk", 0.85m, category: Category.Food));
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
                new Item("Imported box of chocolates", 10m, category: Category.Food, isImported: true),
                new Item("Imported bottle of perfume", 47.50m, isImported: true));
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
                new Item("Imported bottle of perfume", 27.99m, isImported: true),
                new Item("Bottle of perfume", 18.99m),
                new Item("USB drive", 9.75m, category: Category.Electronics),
                new Item("Box of imported chocolates", 11.25m, category: Category.Food, isImported: true));
            var receiptItems = receiptDetails.ReceiptItems.ToList();
            Assert.That(receiptItems[0].PriceIncludingSalesTax, Is.EqualTo(34.99m));
            Assert.That(receiptItems[1].PriceIncludingSalesTax, Is.EqualTo(21.84m));
            Assert.That(receiptItems[2].PriceIncludingSalesTax, Is.EqualTo(9.75m));
            Assert.That(receiptItems[3].PriceIncludingSalesTax, Is.EqualTo(12.38m));
            Assert.That(receiptDetails.SalesTax, Is.EqualTo(10.97m));

            // In a real scenario for me this rounding strategy could be a little strange.
            // Our total on recipt does not equal all the items prices ( including sales tax) 78.96 != 78.95
            Assert.That(receiptDetails.Total, Is.EqualTo(78.95m));
        }

        [Test]
        public void MyExample_WithQuantity()
        {
            var receiptDetails = SalesTaxCalculator.Process(
                new Item("Shirt", 10.00m, quantity: 2),
                new Item("Imported box of chocolates", 5.00m, quantity: 3, category: Category.Food, isImported: true));

            var receiptItems = receiptDetails.ReceiptItems.ToList();

            var firstReciptItem = receiptItems[0];
            Assert.That(firstReciptItem.Name, Is.EqualTo("Shirt"));
            Assert.That(firstReciptItem.Quantity, Is.EqualTo(2));
            Assert.That(firstReciptItem.PriceIncludingSalesTax, Is.EqualTo(23.00m));

            var secondReciptItem = receiptItems[1];
            Assert.That(secondReciptItem.Name, Is.EqualTo("Imported box of chocolates"));
            Assert.That(secondReciptItem.Quantity, Is.EqualTo(3));
            Assert.That(secondReciptItem.PriceIncludingSalesTax, Is.EqualTo(16.50m));

            Assert.That(receiptDetails.SalesTax, Is.EqualTo(4.50m));
            Assert.That(receiptDetails.Total, Is.EqualTo(39.50m));
        }
    }
}

using Assignment.Entities;

namespace Assignment.Services
{
    public class SalesTaxCalculator
    {
        private const decimal SALES_TAX = 0.15m;
        private const decimal IMPORT_TAX = 0.10m;

        public static ReceiptDetails Process(params Item[] items)
        {
            ReceiptDetails receiptDetails = new();
            decimal salesTaxTotalNotRounded = 0m;

            for (int i = 0; i < items.Length; i++)
            {
                Item item = items[i];
                decimal lineBasePrice = item.Price * item.Quantity;
                decimal lineItemTaxNotRounded = CalculateSalesTax(item) + CalculateImportTax(item);

                receiptDetails.ReceiptItems.Add(new ReciptItem
                {
                    Name = item.Name,
                    Quantity = item.Quantity,
                    // based on tests we expect this price to include the price + tax rounded 
                    PriceIncludingSalesTax = lineBasePrice + RoundCurrency(lineItemTaxNotRounded)
                });

                // We first calculate the sales tax without rounding because based on tests we expect the sales tax to only be rounnded once at the end.
                salesTaxTotalNotRounded += lineItemTaxNotRounded;
            }

            receiptDetails.SalesTax = RoundCurrency(salesTaxTotalNotRounded);
            receiptDetails.Total = items.Sum(i => i.Price * i.Quantity) + receiptDetails.SalesTax; 

            return receiptDetails;
        }

        private static decimal CalculateSalesTax(Item item)
        {
            if (item.Category == Category.Other)
            {
                return item.Price * item.Quantity * SALES_TAX;
            }
            return 0m;
        }

        private static decimal CalculateImportTax(Item item)
        {
            if (item.IsImported)
            {
                return item.Price * item.Quantity * IMPORT_TAX;
            }
            return 0m;
        }

        private static decimal RoundCurrency(decimal amount)
        {
            return Math.Round(amount, 2, MidpointRounding.AwayFromZero);
        }
    }
}

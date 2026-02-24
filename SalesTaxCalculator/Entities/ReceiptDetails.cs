namespace Assignment.Entities
{
    public class ReceiptDetails
    {
        public List<ReciptItem> ReceiptItems { get; set; } = new();

        public decimal SalesTax { get; set; }

        public decimal Total { get; set; }
    }
}

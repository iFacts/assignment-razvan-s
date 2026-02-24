namespace Assignment.Entities
{
    public class Item
    {
        // I decided to use one ctor with defaults instead of having many overloads for the ctor.
        // That meant I had to use named arguments in the tests.
        // I preffered to make a small change on test file, then having this file really (in my opinion) very messy
        public Item(string name, decimal price, int quantity = 1, Category category = Category.Other, bool isImported = false) 
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(quantity, 1);

            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
            IsImported = isImported;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Category Category { get; set; }

        public bool IsImported { get; set; }
    }
}
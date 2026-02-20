## Sales Tax assignment

Sales tax is applicable at a rate of 15% on all goods, except magazines, food, and electronics that have 0% sales tax.
Import tax is an additional tax applicable on all imported goods at a rate of 10%, with no exceptions.

When purchasing items the customer receives a receipt which lists the name of all the items and their price (including tax), finishing with the total cost of items, and the total amount of tax paid.

Implement the logic that calculates receipt details for shopping carts containing items. Input/output for some example carts:

### Input 1:

```
1 Magazine at 10.49
1 Shirt at 34.99
1 Package of milk at 0.85
```

### Input 2:

```
1 Imported box of chocolates at 10.00
1 Imported bottle of perfume at 47.50
```

### Input 3:

```
1 Imported bottle of perfume at 27.99
1 Bottle of perfume at 18.99
1 USB drive at 9.75
1 Box of imported chocolates at 11.25
```

Once calculated the following result should be returned.

### Output 1:

```
1 Magazine : 10.49
1 Shirt: 40.24
1 Package of milk: 0.85
Sales Taxes: 5.25
Total: 51.58
```

### Output 2:

```
1 Imported box of chocolates: 11.00
1 Imported bottle of perfume: 59.38
Sales Taxes: 12.88
Total: 70.38
```

### Output 3:

```
1 Imported bottle of perfume: 34.99
1 Bottle of perfume: 21.84
1 USB drive: 9.75
1 Imported box of chocolates: 12.38
Sales Taxes: 10.97
Total: 78.95
```

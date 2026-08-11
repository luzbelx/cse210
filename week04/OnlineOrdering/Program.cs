```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        // -------------------------
        // ORDER 1
        // -------------------------

        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "NY",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        Product product1 = new Product(
            "Laptop",
            "P001",
            899.99,
            1
        );

        Product product2 = new Product(
            "Wireless Mouse",
            "P002",
            29.99,
            2
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // -------------------------
        // ORDER 2
        // -------------------------

        Address address2 = new Address(
            "Calle Duarte 45",
            "Santo Domingo",
            "Distrito Nacional",
            "Dominican Republic"
        );

        Customer customer2 = new Customer(
            "Maria Garcia",
            address2
        );

        Product product3 = new Product(
            "Keyboard",
            "P003",
            49.99,
            1
        );

        Product product4 = new Product(
            "Headphones",
            "P004",
            79.99,
            2
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // -------------------------
        // DISPLAY ORDER 1
        // -------------------------

        Console.WriteLine("=================================");
        Console.WriteLine("ORDER 1");
        Console.WriteLine("=================================");

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}");

        // -------------------------
        // DISPLAY ORDER 2
        // -------------------------

        Console.WriteLine();
        Console.WriteLine("=================================");
        Console.WriteLine("ORDER 2");
        Console.WriteLine("=================================");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
    }
}
```

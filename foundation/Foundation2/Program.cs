using System;
using System.Collections.Generic;

// Product class
class Product
{
    // Private member variables
    private string name;
    private string productId;
    private float price;
    private int quantity;

    // Constructor
    public Product(string name, string productId, float price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    // Method to calculate total cost of the product
    public float getTotalCost()
    {
        return price * quantity;
    }

    // Getter methods for name and productId (useful for packing label)
    public string getName()
    {
        return name;
    }

    public string getProductId()
    {
        return productId;
    }
}

// Address class
class Address
{
    // Private member variables
    private string streetAddress;
    private string city;
    private string stateOrProvince;
    private string country;

    // Constructor
    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    // Method to determine if the address is in the USA
    public bool isInUSA()
    {
        return country.ToLower() == "usa";
    }

    // Method to get the full address as a formatted string
    public string getFullAddress()
    {
        return $"{streetAddress}\n{city}, {stateOrProvince}\n{country}";
    }
}

// Customer class
class Customer
{
    // Private member variables
    private string name;
    private Address address;  // Association with Address class

    // Constructor
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Method to check if customer is in the USA
    public bool isInUSA()
    {
        return address.isInUSA();
    }

    // Getter methods for name and address (useful for shipping label)
    public string getName()
    {
        return name;
    }

    public Address getAddress()
    {
        return address;
    }
}

// Order class
class Order
{
    // Private member variables
    private Customer customer;
    private List<Product> products;

    // Constructor
    public Order(Customer customer, List<Product> products)
    {
        this.customer = customer;
        this.products = products;
    }

    // Method to calculate total cost (products cost + shipping)
    public float getTotalCost()
    {
        float totalCost = 0;

        // Add up the total cost of all products
        foreach (Product product in products)
        {
            totalCost += product.getTotalCost();
        }

        // Add shipping cost
        float shippingCost = customer.isInUSA() ? 5 : 35;
        totalCost += shippingCost;

        return totalCost;
    }

    // Method to get packing label (product name and product id)
    public string getPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in products)
        {
            packingLabel += $"{product.getName()} (ID: {product.getProductId()})\n";
        }
        return packingLabel;
    }

    // Method to get shipping label (customer name and address)
    public string getShippingLabel()
    {
        return $"{customer.getName()}\n{customer.getAddress().getFullAddress()}";
    }
}

// Main program to create and test the order system
class Program
{
    static void Main(string[] args)
    {
        // Create some products
        Product product1 = new Product("Laptop", "123ABC", 800, 1);
        Product product2 = new Product("Mouse", "456DEF", 20, 2);

        // Create an address
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");

        // Create a customer
        Customer customer1 = new Customer("John Doe", address1);

        // Create an order
        Order order1 = new Order(customer1, new List<Product> { product1, product2 });

        // Display packing label, shipping label, and total price
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.getPackingLabel());
        Console.WriteLine();

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.getShippingLabel());
        Console.WriteLine();

        Console.WriteLine("Total Price: $" + order1.getTotalCost());

        // You can create additional orders with different customers/products if needed.
    }
}

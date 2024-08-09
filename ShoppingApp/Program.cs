using System;
using System.Collections.Generic;
using ShoppingApp.Model;

namespace ShoppingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Shopping Application!");

            
            List<Product> products = new List<Product>
            {
                new Product(1, "Milk", 100, 10),
                new Product(2, "Laptop", 200, 20),
                new Product(3, "Book", 300, 15)
            };

            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();
            Customer customer = new Customer(customerId, customerName);

            
            Console.Write("Enter Order ID: ");
            int orderId = int.Parse(Console.ReadLine());
            Order order = new Order(orderId, DateTime.Now);

            bool addingItems = true;
            while (addingItems)
            {
                Console.WriteLine("\nAvailable Products:");
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.ProductPrice}, Discount: {product.ProductDiscountPercentage}%");
                }

                Console.Write("Enter Product ID to add to order: ");
                int productId = int.Parse(Console.ReadLine());
                Product selectedProduct = products.Find(p => p.ProductId == productId);

                if (selectedProduct != null)
                {
                    Console.Write("Enter Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    LineItem lineItem = new LineItem(order.Items.Count + 1, quantity, selectedProduct);
                    order.Items.Add(lineItem);
                }
                else
                {
                    Console.WriteLine("Invalid Product ID. Try again.");
                }

                Console.Write("Do you want to add another item? (y/n): ");
                string response = Console.ReadLine().ToLower();
                addingItems = response == "y";
            }

            
            customer.Orders.Add(order);

            
            PrintBill(customer, order);
        }

        static void PrintBill(Customer customer, Order order)
        {
            Console.WriteLine("\n************ BILL ************");
            Console.WriteLine($"Customer ID: {customer.CustomerId}");
            Console.WriteLine($"Customer Name: {customer.CustomerName}");
            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Order Date: {order.DateTime}\n");

            Console.WriteLine(new string('-', 133));

            Console.WriteLine($"{"LineItem",-10} | {"Product Id",-10} | {"Item",-10} | {"Qty",5} | {"Unit Price",15} | {"Discount %",20} | {"Discounted Price",25} | {"Total Cost",15} | ");
            Console.WriteLine(new string('-', 133));
            foreach (var item in order.Items)
            {
                Console.WriteLine($"{item.LineItemId,-10} | {item.Product.ProductId,-10} | {item.Product.ProductName,-10} | {item.Quantity,5} | {item.Product.ProductPrice,15} | {item.Product.ProductDiscountPercentage,19}% | {item.Product.CalculateDiscountedPrice(),25} | {item.CalculateLineItemCost(),15} | ");
            }

            Console.WriteLine(new string('-', 133));
            Console.WriteLine($"{"Total Order Price:",-60}{order.CalculateOrderPrice(),71}");
            Console.WriteLine(new string('-', 133));
            Console.WriteLine();
            Console.WriteLine("********** Thank you For Shopping with us! ***********");
        }
    }
}

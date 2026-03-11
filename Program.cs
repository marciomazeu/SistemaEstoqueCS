using System;
using System.Collections.Generic;

class Program
{
    // Estas listas PRECISAM ser static para serem usadas nos métodos abaixo
    static List<string> productNames = new List<string>();
    static List<int> productQuantities = new List<int>();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- INVENTORY MANAGEMENT ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. List Inventory");
            Console.WriteLine("3. Update Stock");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    ListInventory();
                    break;
                case "3":
                    UpdateStock();
                    break;
                case "4": 
                    RemoveProduct(); 
                    break;
                case "5": 
                    running = false; 
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    static void AddProduct()
    {
        Console.Write("Product name: ");
        string name = Console.ReadLine();

        Console.Write("Quantity: ");
        if (int.TryParse(Console.ReadLine(), out int qty) && qty >= 0)
        {
            productNames.Add(name);
            productQuantities.Add(qty);
            Console.WriteLine("Added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid quantity.");
        }
    }

    static void UpdateStock()
    {
        Console.Write("\nEnter product name to update: ");
        string searchName = Console.ReadLine();
        bool found = false;

        for (int i = 0; i < productNames.Count; i++)
        {
            // Comparação ignorando maiúsculas/minúsculas para facilitar para o usuário
            if (productNames[i].Equals(searchName, StringComparison.OrdinalIgnoreCase))
            {
                Console.Write($"Current quantity is {productQuantities[i]}. Enter new quantity: ");
                if (int.TryParse(Console.ReadLine(), out int newQty) && newQty >= 0)
                {
                    productQuantities[i] = newQty;
                    Console.WriteLine("Stock updated successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid quantity.");
                }
                found = true;
                break;
            }
        }

        if (!found) Console.WriteLine("Product not found.");
    }

    static void RemoveProduct()
    {
        Console.Write("\nEnter product name to remove: ");
        string nameToRemove = Console.ReadLine();
        bool found = false;

        for (int i = 0; i < productNames.Count; i++)
        {
            if (productNames[i].Equals(nameToRemove, StringComparison.OrdinalIgnoreCase))
            {
                // Remove de AMBAS as listas para manter o sincronismo
                productNames.RemoveAt(i);
                productQuantities.RemoveAt(i);
                
                Console.WriteLine("Product removed from inventory.");
                found = true;
                break;
            }
        }

        if (!found) Console.WriteLine("Product not found.");
    }
    static void ListInventory()
    {
        Console.WriteLine("\n--- Current Inventory ---");
        
        // Critério do curso: Uso de LAÇO (for)
        if (productNames.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
        }
        else
        {
            for (int i = 0; i < productNames.Count; i++)
            {
                // Usamos o índice 'i' para acessar ambas as listas paralelas
                Console.WriteLine($"{i + 1}. Name: {productNames[i]} | Quantity: {productQuantities[i]}");
            }
        }
    }
}
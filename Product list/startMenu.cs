using System;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Menus
{
    public static void startMenu(List<string> products)
    {
        Console.Clear();
        Console.WriteLine("Start menu");
        Console.WriteLine();
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. View Products");
        Console.WriteLine("3. Search Product");
        Console.WriteLine("4. Delete Product");
        Console.WriteLine("5. Stastistics");
        Console.WriteLine("6. Exit");
        Console.WriteLine();
        Console.WriteLine("press 1-6: ");

        int.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out int menuChoice);

        switch (menuChoice)
        {
            case 1:
                enterProducts(products);
                break;
            case 2:
                viewProducts(products);
                break;
            case 3:
                searchProducts(products);
                break;
            case 4:
                DeleteProducts(products);
                break;
            case 5:
                Stastistics(products);
                break;
            case 6:
                exitProgram(products);
                break;
            default:
                break;
        }
    }

    private static void Stastistics(List<string> products)
    {
        Console.WriteLine("Total products: " + products.Count());
        int[] productNumbers = new int[products.Count()];
        int i = 0;
        foreach (string product in products)
        {
            string[] parts = product.Split('-');
            productNumbers[i] = int.Parse(parts[1]);
            i++;
        }

        Console.WriteLine("Highest product number: " + productNumbers.Max());
        Console.WriteLine("Lowest product number: " + productNumbers.Min());
        Console.WriteLine("Average product number: " + productNumbers.Average());

        Console.WriteLine("Press a key to return to the menu");
        Console.ReadKey();
        startMenu(products);
    }

    static void exitProgram(List<string> products)
    {
        Console.WriteLine("Are you sure you want to leave this wonderful app? if so press Y");
        string yesNo = Console.ReadKey(intercept: true).KeyChar.ToString();
        if (yesNo.ToLower() == "y")
        {
            Environment.Exit(0);
        }
        startMenu(products);
    }

    static void DeleteProducts(List<string> products)
    {
        Console.WriteLine("Enter product to delete: ");
        var deleteProduct = Console.ReadLine();
        bool isDeleted = products.Remove(deleteProduct.Trim());
        if (isDeleted)
        {
            Console.WriteLine("Product is deleted");
        }
        else
        {
            Console.WriteLine("Product was not in the database");
        }
        Console.WriteLine("Press a key to return to the menu");
        Console.ReadKey();
        startMenu(products);
    }

    static void searchProducts(List<string> products)
    {
        Console.WriteLine("Search by product name or number: ");
        string searchString = Console.ReadLine();

        products.Contains(searchString);
        Console.WriteLine();
        Console.WriteLine("Found products");
        foreach (string product in products)
        {
            string[] parts = product.Split('-');
            if (parts.Contains(searchString))
            {
                Console.WriteLine(product);
            }
        }

        Console.WriteLine("Press a key to return to the menu");
        Console.ReadKey();

        startMenu(products);
    }

    static void enterProducts(List<string> products)
    {
        Console.Clear();
        Console.WriteLine("enterProducts product name.");
        Console.WriteLine("Type 'exit' to finish.");
        string product = new string("");
        string pattern = @"^[A-Z]+-(?:[2-4][0-9]{2}|500)$";

        while (product != "exit")
        {
            Console.Write("product: ");

            product = Console.ReadLine().Trim();
            if (product.ToLower() == "exit") { break; }

            bool isValid = Regex.IsMatch(product, pattern, RegexOptions.IgnoreCase);
            if (isValid)
            {
                if (products.Contains(product))
                {
                    Console.WriteLine("product already entered");
                }
                else
                {
                    products.Add(product);
                }
            }
            else
            {
                errorHandling(product);
            }
        }
        startMenu(products);
    }

    static void errorHandling(string product)
    {
        if (product == "") Console.WriteLine("Product cannot be empty.");
        if (!product.Contains('-'))
            Console.WriteLine("Product must contain a dash");
        else
        {
            string[] parts = product.Split('-');
            string leftSidePattern = @"^[A-Z]+$";
            string rightSidePattern = @"([2-4][0-9]{2}|500)$";
            bool leftSideOK = Regex.IsMatch(parts[0], leftSidePattern, RegexOptions.IgnoreCase);
            bool rightSideOK = Regex.IsMatch(parts[1], rightSidePattern);
            if (!leftSideOK)
            {
                Console.WriteLine("Left side must contain only letters");
            }
            bool isint = int.TryParse(parts[1], out int number);
            if (!isint)
            {
                Console.WriteLine("The rigt side must contain only numbers");
            }

            if (!rightSideOK)
            {
                Console.WriteLine("Right side must be between 200 and 500");
            }
        }
    }


    static void viewProducts(List<string> products)
    {
        products.Sort();
        Console.WriteLine("products entered: ");

        foreach (var prod in products)
        {
            Console.WriteLine($"{prod}");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to return to the menu");
        Console.ReadKey();
        startMenu(products);
    }
}
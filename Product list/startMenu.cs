using System;
using System.Text.RegularExpressions;

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
        Console.WriteLine("5. Exit");
        Console.WriteLine();
        Console.WriteLine("press 1-5: ");

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
                exitProgram(products);
                break;
            default:
                break;
        }
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
        throw new NotImplementedException();
    }

    static void searchProducts(List<string> products)
    {
        throw new NotImplementedException();
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
        //Console.BackgroundColor = ConsoleColor.Green;
        if (product == "") Console.WriteLine("Product cannot be empty.");
        if (!product.Contains('-'))
            Console.WriteLine("Product must contain a dash");
        else
        {
            string[] parts = product.Split('-');
            string leftSidePattern = @"^[A-Z]";
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
using System.Text.RegularExpressions;

List<string> products = new List<string>();
Console.BackgroundColor = ConsoleColor.Black;
enterProducts(products);

printList(products);


void enterProducts(List<string> products)
{
    Console.WriteLine("enterProducts product name.");
    Console.WriteLine("Type 'exit' to finish.");
    string product = new string("");
    string pattern = @"^[A-Z]+-(?:[2-4][0-9]{2}|500)$";
    //string pattern = @"^[A-Z]-(?:[2-4][0-9]{2}|500)$";
    while (product != "exit")
    {
        Console.Write("product: ");

        product = Console.ReadLine().Trim();
        if (product.ToLower() == "exit") { break; }

        bool isValid = Regex.IsMatch(product, pattern, RegexOptions.IgnoreCase);
        if (isValid)
        {
            products.Add(product);

        }
        else
        {
            errorHandling(product);
        }
    }
}
void errorHandling(string product)
{
    //Console.BackgroundColor = ConsoleColor.Green;
    if (product == "") Console.WriteLine("Product cannot be empty.");
    if (!product.Contains('-'))
        Console.WriteLine("Product must contain a dash");
    else
    {
        string[] parts = product.Split('-');
        string leftSidePattern = @"^[A-Z]";
        string rightSidePattern = @"([2-4][0-9]{2}|500)";
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

    //switch (product)
    //{
    //    case "":
    //        Console.WriteLine("Input cannot be empty.");
    //    case :
    //        Console.WriteLine(".");
    //    case "":
    //        Console.WriteLine(".");
    //    case "":
    //        Console.WriteLine(".");
    //    case "":
    //        Console.WriteLine(".");

    //    default:
    //        break;
    //}


}



static void printList(List<string> products)
{
    products.Sort();
    Console.WriteLine("products entered: ");

    foreach (var prod in products)
    {
        Console.WriteLine($"{prod}");
    }
}




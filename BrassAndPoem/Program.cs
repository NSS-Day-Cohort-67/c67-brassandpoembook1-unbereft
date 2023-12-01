
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

Product[] products = new Product[]
{
    new Product {Name = "Antique Trombone", Price = 199.99m, ProductTypeId = 1},
    new Product {Name = "Alto Saxophone", Price = 149.99m, ProductTypeId = 1},
    new Product {Name = "Gulliver's Travels", Price = 299.99m, ProductTypeId = 2},
    new Product {Name = "Walden", Price = 19.99m, ProductTypeId = 2},
    new Product {Name = "Sonnets", Price = 9.99m, ProductTypeId = 2},
    new Product {Name = "French Horn", Price = 249.99m, ProductTypeId = 1},
    new Product {Name = "Sousaphone", Price = 999.99m, ProductTypeId = 1}
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Id = 1,
        Title = "Brass"
    },
    new ProductType()
    {
        Id = 2,
        Title = "Poem"
    }
};

//put your greeting here
Console.WriteLine(@"
Welcome to Brass & Poem
Your destination for words & music");
DisplayMenu();

//implement your loop here

void DisplayMenu()
{
    string choice = null;
    while (choice != "0")
    {
    Console.WriteLine(@"
    Please choose an option:
    1. Display all products 
    2. Add new product 
    3. Update product details 
    4. Delete a product
    5. Exit");
        choice = Console.ReadLine();
        if (choice == "0")
        {
            Console.WriteLine(@"Invalid choice. Please choose a number between 1 and 5.");
        }
        else if (choice == "1")
        {
            DisplayAllProducts(products.ToList(), productTypes);
        }
        else if (choice == "2")
        {
            // AddProduct();
        }
        else if (choice == "3")
        {
            // UpdateProduct();
        }
        else if (choice == "4")
        {
            DeleteProduct(products.ToList(), productTypes);
        }
        else if (choice == "5")
        {
            Console.WriteLine("See you again soon!");
            break;
        }
    }

}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine(@"
    Here is a list of our current products:
    ");

    List<string> productDescriptions = products
        .Select((product, index) =>
        $"{index + 1}. {product.Name} - ${product.Price}")
        .ToList();

    foreach (var description in productDescriptions)
    {
        Console.WriteLine(description);
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine(@"
    Select the number of the product you would like to delete:
    ");

    List<string> productDescriptions = products
        .Select((product, index) =>
        $"{index + 1}. {product.Name}")
        .ToList();

    foreach (var description in productDescriptions)
    {
        Console.WriteLine(description);
    }

    int response;
    while (!int.TryParse(Console.ReadLine().Trim(), out response) || response < 1 || response > products.Count)
    {
        Console.WriteLine("Choose a valid number");
    }

    Product chosenProduct = products[response - 1];
    Console.WriteLine(@$"
    You chose: {chosenProduct.Name}
    Are you sure you want to delete this product?
    Enter Y for YES, enter any other key for NO. ");
    string input = Console.ReadLine().Trim().ToUpper();

    if (input == "Y")
    {
        products.RemoveAt(response - 1);
        Console.WriteLine($"{chosenProduct.Name} has been deleted");
    }
    else
    {
        Console.WriteLine("Product not deleted. Back to the Main Menu.");
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{

}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{

}




// don't move or change this!
public partial class Program { }

//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

List<Product> products = new List<Product>()
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
            DisplayAllProducts(products, productTypes);
        }
        else if (choice == "2")
        {
            AddProduct(products, productTypes);
        }
        else if (choice == "3")
        {
            UpdateProduct(products, productTypes);
        }
        else if (choice == "4")
        {
            DeleteProduct(products, productTypes);
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
    Product product = new Product();
    string name = "";

    while (true)
    {
        Console.WriteLine(@"
        What is the name of the new product?");
        name = Console.ReadLine().Trim();

        if (!string.IsNullOrWhiteSpace(name) && !name.Any(char.IsDigit))
        {
            break;
        }
        Console.WriteLine(@"
        Invalid input. Please enter a valid name without numbers.");
    }
    product.Name = name;

    Console.WriteLine(@"
    What is the price of this product (in 00.00 format)?");

    string priceInput = Console.ReadLine().Trim();
    if (decimal.TryParse(priceInput, out decimal price))
    {
        if (price > 0)
        {
            product.Price = price;
        }
        else
        {
            Console.WriteLine(@"Invalid input. Price cannot be negative.");
            return;
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Enter a valid decimal value.");
        return;
    }

    Console.WriteLine(@"What type of product is this?
    1. Brass
    2. Poem");

    string productTypeIdInput = Console.ReadLine().Trim();

    while (int.TryParse(productTypeIdInput, out int productTypeId))
    {
        if (productTypeId > 0 && productTypeId < 3)
        {
            product.ProductTypeId = productTypeId;
            break;
        }
        Console.WriteLine("Invalid input. Try again.");
        productTypeIdInput = Console.ReadLine().Trim();
    }

    Console.Write(@"Please verify the information you entered is correct: 
    ");
    Console.WriteLine($@"
    Product Name: {product.Name}
    Product Price: ${product.Price}
    Product Type: {product.ProductTypeId}");

    Console.WriteLine("Is this information correct? (Y/N)");
    if (Console.ReadLine().Trim().ToUpper() == "Y")
    {
        products.Add(product);
        Console.WriteLine("Product submitted successfully. Back to Main Menu.");
    }
    else
    {
        Console.WriteLine("Try again!");
    }
}

// todo: Prompt the user to enter the updated name, price and product type for the product (in that order). If the user presses enter without typing anything, leave the property unchanged.

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine(@"Please choose the number of the product you'd like to update: ");
    products.Select((product, index) => $"{index + 1}. {product.Name}")
            .ToList()
            .ForEach(Console.WriteLine);
    
    int response;
    while (!int.TryParse(Console.ReadLine().Trim(), out response) || response < 1 || response > products.Count)
    {
        Console.WriteLine("Choose a valid number.");
    }

    Product chosenProduct = products[response - 1];
    Console.WriteLine(@$"You chose: {chosenProduct.Name}
    What property would you like to update?
    1. Name
    2. Price
    3. Product Type");

    int choice;
    while (!int.TryParse(Console.ReadLine().Trim(), out choice) || choice < 1 || choice > 3)
    {
        Console.WriteLine("Choose a valid number.");
    }

    switch (choice)
    {
        case 1:
            UpdateName(chosenProduct);
            break;
        case 2:
            // UpdatePrice(chosenProduct);
            break;
        case 3:
            // UpdateProductTypeId(chosenProduct);
            break;
    }
}

void UpdateName(Product product)
{
    Console.WriteLine("What would you like to change the name to?");
    string name = Console.ReadLine().Trim();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Please enter a valid name.");
        return;
    }
    else if (name.Any(char.IsDigit))
    {
        Console.WriteLine("Invalid input. Name should not contain numbers");
        return;
    }

    product.Name = name;
}




// don't move or change this!
public partial class Program { }
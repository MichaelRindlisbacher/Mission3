using Mission3;
class Program
{
    static void Main(string[] args)
    {
        // Condition to leave the loop
        bool exit = false;
        // Default to display options
        string userInput = "0";
        List<FoodItem> foodItems = new List<FoodItem>();
        Console.WriteLine("Welcome to the Food Bank!");
        // Keep displaying and asking for options until told othewise
        while (!exit)
        {
            // Defaut display options
            if (userInput.Equals("0"))
            {
                Console.WriteLine("What would you like to do?\n1: Add Food Item\n2: Delete Food Item\n3: Print List of Food Items\n4: Exit the program");
                userInput = Console.ReadLine();
            }
            else if (userInput.Equals("1"))
            {
                // Create a FoodItem object and add it to the list
                string name = " ";
                string category = " ";
                string quantitystr = " ";
                int quantity = 0;
                string expirationDate = " ";
                bool isValid = true;

                while (string.IsNullOrWhiteSpace(name)) // no void
                {
                    Console.WriteLine("Enter the name of your food item: ");
                    name = Console.ReadLine().ToLower();
                }

                while (string.IsNullOrWhiteSpace(category)) // no void
                {
                    Console.WriteLine("Enter the category of your food item: ");
                    category = Console.ReadLine().ToLower();
                }

                do
                {
                    Console.WriteLine("Enter the quantity of your food item (enter a positive number): ");
                    quantitystr = Console.ReadLine();
                    isValid = int.TryParse(quantitystr, out quantity);
                    if (!isValid || quantity <= 0) // no void or negative
                    {
                        Console.WriteLine("Invalid input. Please enter a positive integer.");
                        isValid = false;
                    }
                } while (!isValid);

                while (string.IsNullOrWhiteSpace(expirationDate)) // no void
                {
                    Console.WriteLine("Enter the expiration date of your food item: ");
                    expirationDate = Console.ReadLine();
                }

                // create foodItem object and append to list
                FoodItem currentItem = new FoodItem(name, category, quantity, expirationDate);
                foodItems.Add(currentItem);
                Console.WriteLine("Your food item was added successfully!");
                userInput = "0"; // loop
            }
            else if (userInput.Equals("2"))
            {
                // Find the item with the matching name and remove it from the list
                string name = " ";
                Console.WriteLine("Enter the name of the food item you would like to delete: ");
                name = Console.ReadLine().ToLower();
                foodItems.RemoveAll(item => item.Name.Equals(name));
                Console.WriteLine("The food item was deleted successfully!");
                userInput = "0";
            }
            else if (userInput.Equals("3"))
            {
                // Loop through the list and display all the information about all of the food items.
                for (int i = 0; i < foodItems.Count; i++)
                {
                    Console.WriteLine("Name: " + foodItems[i].Name + "\nCategory: " + foodItems[i].Category + "\nQuantity: " + foodItems[i].Quantity + "\nExpiration Date: " + foodItems[i].ExpirationDate);
                }
                userInput = "0";
            }
            else if (userInput.Equals("4"))
            { // Jump out of the loop
                exit = true;
            }
            else
            { // Error handling if user inputs anything other than 1, 2, 3 or 4
                Console.WriteLine("Invalid input. Enter a number 1-4.");
                userInput = "0";
            }
        }
        Console.WriteLine("Thank you for using the Food Bank!");
    }
}
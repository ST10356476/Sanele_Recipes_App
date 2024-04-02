using SaneleRecipes;

public class Program
{
    static void Main(string[] args)
    {

        try
        {

            // Output the welcome message
            Console.WriteLine("===============================");
            Console.WriteLine("Welcome to Sanele's Recipe App!");
            Console.WriteLine("===============================");

            // Instantiate the object
            Recipe[] recipes = new Recipe[50];


            bool exit = false;      // will be used to check if the user wants to exit the program.

            while (!exit)
            {
                // Output the menu the user can selct from.
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. View Recipes");
                Console.WriteLine("2. Add New Recipe");
                Console.WriteLine("3. Clear All Data");
                Console.WriteLine("4. Exit");
                Console.WriteLine("===============================");

                Console.Write("Enter your choice: ");           // Asks the user to enter their choice of task from the menu above
                int choice = int.Parse(Console.ReadLine());         // allow the user to enter their choice

                Console.WriteLine("===============================");

                // Switch method used to loop through the user's choice from the menu
                switch (choice)
                {
                    // The user is able to display the recipe details they want and are able to scale the recipe if needed.
                    case 1:
                        Recipe.DisplayExistingRecipes(recipes);
                        break;

                    // User can add new recipes
                    case 2:
                        Recipe.AddNewRecipe(recipes);
                        break;

                    // User can clear all data(recipes) stored in the program
                    case 3:
                        Recipe.ClearAllData(recipes);
                        Console.WriteLine("All recipe data has been cleared.");
                        break;

                    // Exits/terminate the program
                    case 4:
                        exit = true;
                        break;

                    // Output necessary message if invalid input has been entered
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }

            // Output the goodbye message after exiting/terminating the program
            Console.WriteLine("\nThank you for using Sanele's Recipe App!");
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
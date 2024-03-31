using SaneleRecipes;

public class Program
{
    static void Main(string[] args)
    {

        try
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Welcome to Sanele's Recipe App!");
            Console.WriteLine("===============================");

            Recipe[] recipes = new Recipe[50];

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. View Recipes");
                Console.WriteLine("2. Add New Recipe");
                Console.WriteLine("3. Clear All Data");
                Console.WriteLine("4. Exit");
                Console.WriteLine("===============================");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("===============================");

                switch (choice)
                {
                    case 1:
                        Recipe.DisplayExistingRecipes(recipes);
                        break;
                    case 2:
                        Recipe.AddNewRecipe(recipes);
                        break;
                    case 3:
                        Recipe.ClearAllData(recipes);
                        Console.WriteLine("All recipe data has been cleared.");
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }

            Console.WriteLine("\nThank you for using Sanele's Recipe App!");
        }

        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

}


//Remember to create a tag in your REPO for part 1.
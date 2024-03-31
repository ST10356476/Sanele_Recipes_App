using SaneleRecipes;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Recipe App!");

        // Input recipe details
        Console.Write("Enter the number of ingredients: ");
        int ingredientCount = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of steps: ");
        int stepCount = int.Parse(Console.ReadLine());

        Recipe recipe = new Recipe(ingredientCount, stepCount);

        for (int i = 0; i < ingredientCount; i++)
        {
            Console.Write($"Enter name of ingredient {i + 1}: ");
            string name = Console.ReadLine();

            Console.Write($"Enter quantity of {name}: ");
            double quantity = double.Parse(Console.ReadLine());

            Console.Write($"Enter unit of measurement for {name}: ");
            string unit = Console.ReadLine();

            recipe.Ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
        }

        for (int i = 0; i < stepCount; i++)
        {
            Console.Write($"Enter step {i + 1}: ");
            string description = Console.ReadLine();
            recipe.Steps[i] = new Step { Description = description };
        }

        // Display the recipe
        recipe.DisplayRecipe();

        // Scale the recipe
        Console.Write("\nEnter scaling factor (0.5 for half, 2 for double, 3 for triple): ");
        double factor = double.Parse(Console.ReadLine());
        recipe.ScaleRecipe(factor);

        Console.WriteLine("\nScaled Recipe:");
        recipe.DisplayRecipe();

        // Reset quantities
        // recipe.ResetQuantities();

        // Clear all data
        // recipe = null;

        Console.WriteLine("\nThank you for using Recipe App!");
    }
}
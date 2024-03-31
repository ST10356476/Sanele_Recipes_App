using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneleRecipes
{
    class Recipe
    {
        public Ingredient[] Ingredients { get; set; }
        public Step[] Steps { get; set; }

        public Recipe(int ingredientCount, int stepCount)
        {
            Ingredients = new Ingredient[ingredientCount];
            Steps = new Step[stepCount];
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe Details:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i].Description}");
            }
        }

        public static void DisplayExistingRecipes(Recipe[] recipes)
        {
            Console.WriteLine("\nExisting Recipes:");
            bool hasRecipes = false;
            for (int i = 0; i < recipes.Length; i++)
            {
                if (recipes[i] != null)
                {
                    Console.WriteLine($"Recipe {i + 1}");
                    hasRecipes = true;
                }
            }

            if (!hasRecipes)
            {
                Console.WriteLine("There are no existing recipes!");
                return;
            }

            Console.Write("Enter the recipe number to view details (or 0 to go back to the menu): ");
            int recipeNumber;
            if (!int.TryParse(Console.ReadLine(), out recipeNumber) || recipeNumber < 0 || recipeNumber > recipes.Length)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            if (recipeNumber != 0 && recipes[recipeNumber - 1] != null)
            {
                recipes[recipeNumber - 1].DisplayRecipe();

                Console.Write("\nDo you want to scale the recipe? (Y/N): ");
                string scaleChoice = Console.ReadLine().Trim().ToUpper();
                if (scaleChoice == "Y")
                {
                    Console.Write("Enter scaling factor (0.5 for half, 2 for double, 3 for triple): ");
                    double factor;
                    if (!double.TryParse(Console.ReadLine(), out factor) || factor <= 0)
                    {
                        Console.WriteLine("Invalid input.");
                        return;
                    }
                    recipes[recipeNumber - 1].ScaleRecipe(factor);
                    Console.WriteLine("\nScaled Recipe:");
                    recipes[recipeNumber - 1].DisplayRecipe();
                }
                else if (scaleChoice != "N")
                {
                    Console.WriteLine("Invalid choice. Recipe displayed without scaling.");
                }
            }
            else
            {
                Console.WriteLine("Invalid recipe number.");
            }

            Console.WriteLine("===============================");

        }


        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public static void AddNewRecipe(Recipe[] recipes)
        {
            Console.Write("Enter the number of ingredients: ");
            int ingredientCount;
            if (!int.TryParse(Console.ReadLine(), out ingredientCount) || ingredientCount <= 0)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            Console.Write("Enter the number of steps: ");
            int stepCount;
            if (!int.TryParse(Console.ReadLine(), out stepCount) || stepCount <= 0)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            Recipe recipe = new Recipe(ingredientCount, stepCount);

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write($"Enter name of ingredient {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter quantity of {name}: ");
                double quantity;
                if (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid input.");
                    return;
                }

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

            Console.WriteLine("===============================");
            // Find an empty slot in the recipes array to store the new recipe
            int emptyIndex = Array.FindIndex(recipes, r => r == null);
            if (emptyIndex != -1)
            {
                recipes[emptyIndex] = recipe;
                Console.WriteLine("Recipe added successfully.");
            }
            else
            {
                Console.WriteLine("Recipe storage is full. Cannot add new recipe.");
            }

            Console.WriteLine("===============================");
        }


        public static void ClearAllData(Recipe[] recipes)
        {
            for (int i = 0; i < recipes.Length; i++)
            {
                recipes[i] = null;
            }
        }
    }
}

using ImTheOneWhoCooks.Contracts;
using ImTheOneWhoCooks.Contracts.Factories;
using ImTheOneWhoCooks.Models.Recipes;

namespace ImTheOneWhoCooks
{
    public class RecipeFactory : IRecipeFactory
    {

        //TODO Create recipe by type
        public IRecipe CreateDrinkableRecipe(string name, decimal price)
        {
            return new DrinkableRecipe(name, price);
        }

        public IRecipe CreateRawRecipe(string name, decimal price, int preparingTime)
        {
            return new RawRecipe(name, price, preparingTime);
        }

        public IRecipe CreateFriedRecipe(string name, decimal price, int preparingTime)
        {
            return new FriedRecipe(name, price, preparingTime);
        }

        public IRecipe CreateBoiledRecipe(string name, decimal price, int preparingTime)
        {
            return new BakedRecipe(name, price, preparingTime);
        }

        public IRecipe CreateGrilledRecipe(string name, decimal price, int preparingTime)
        {
            return new GrilledRecipe(name, price, preparingTime);
        }
    }
}

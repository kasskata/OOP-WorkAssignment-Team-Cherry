using ImTheOneWhoCooks.Contracts;
using ImTheOneWhoCooks.Contracts.Factories;
using ImTheOneWhoCooks.Models.Recipes;

namespace ImTheOneWhoCooks
{
    public class RecipeFactory : IRecipeFactory
    {

        public IRecipe CreateDrinkableRecipe(string name)
        {
            return new DrinkableRecipe(name);
        }

        public IRecipe CreateRawRecipe(string name, int preparingTime)
        {
            return new RawRecipe(name, preparingTime);
        }

        public IRecipe CreateFriedRecipe(string name, int preparingTime)
        {
            return new FriedRecipe(name, preparingTime);
        }

        public IRecipe CreateBoiledRecipe(string name, int preparingTime)
        {
            return new BoiledRecipe(name, preparingTime);
        }

        public IRecipe CreateGrilledRecipe(string name, int preparingTime)
        {
            return new GrilledRecipe(name, preparingTime);
        }
    }
}

namespace ImTheOneWhoCooks.Contracts.Factories
{
    public interface IRecipeFactory
    {
        IRecipe CreateDrinkableRecipe(string name, decimal price);
        IRecipe CreateRawRecipe(string name, decimal price, int preparingTime);
        IRecipe CreateFriedRecipe(string name, decimal price, int preparingTime);
        IRecipe CreateBoiledRecipe(string name, decimal price, int preparingTime);
        IRecipe CreateGrilledRecipe(string name, decimal price, int preparingTime);
    }
}

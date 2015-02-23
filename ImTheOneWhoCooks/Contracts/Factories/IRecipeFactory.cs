namespace ImTheOneWhoCooks.Contracts.Factories
{
    public interface IRecipeFactory
    {
        IRecipe CreateDrinkableRecipe(string name);
        IRecipe CreateRawRecipe(string name, int preparingTime);
        IRecipe CreateFriedRecipe(string name, int preparingTime);
        IRecipe CreateBoiledRecipe(string name, int preparingTime);
        IRecipe CreateGrilledRecipe(string name, int preparingTime);
    }
}

namespace ImTheOneWhoCooks.Models.Recipes
{
    public class FriedRecipe : RawRecipe
    {
        public FriedRecipe(string name, decimal price, int preparingTime) 
            : base(name, price, preparingTime)
        {
        }

        public override string Cook()
        {
            throw new System.NotImplementedException();
        }
    }
}

namespace ImTheOneWhoCooks.Models.Recipes {     public class FriedRecipe : RawRecipe     {
        public FriedRecipe(string name, int preparingTime, decimal price)
            : base(name, preparingTime, price)         {         }

        public FriedRecipe(string name, int preparingTime)
            : base(name, preparingTime, 0)
        {
        }          public override string Cook()         {             throw new System.NotImplementedException();         }     } } 
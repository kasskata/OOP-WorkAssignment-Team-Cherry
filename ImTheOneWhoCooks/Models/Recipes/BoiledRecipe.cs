using System; using System.Collections.Generic; using System.Linq; using System.Text;  namespace ImTheOneWhoCooks.Models.Recipes {     public class BoiledRecipe : RawRecipe     {         public BoiledRecipe(string name, int preparingTime, decimal price)
            : base(name, preparingTime, price)         {         }

        public BoiledRecipe(string name, int preparingTime)
            : base(name, preparingTime, 0)
        {
        }          public override string Cook()         {             throw new NotImplementedException();         }     } } 
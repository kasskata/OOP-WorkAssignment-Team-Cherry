using System; using System.Collections.Generic; using System.Linq; using System.Text;  namespace ImTheOneWhoCooks.Models.Recipes {     public class GrilledRecipe : RawRecipe     {         public GrilledRecipe(string name, int preparingTime, decimal price)              : base(name, preparingTime, price)         {         }

        public GrilledRecipe(string name, int preparingTime)
            : this(name, preparingTime, 0)
        {
        }          public override string Cook()         {             throw new NotImplementedException();         }     } } 
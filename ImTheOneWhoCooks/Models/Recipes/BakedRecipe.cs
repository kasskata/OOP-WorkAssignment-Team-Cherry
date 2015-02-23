using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImTheOneWhoCooks.Models.Recipes
{
    public class BakedRecipe : RawRecipe
    {
        public BakedRecipe(string name, int preparingTime) 
            : base(name, preparingTime)
        {
        }

        public override string Cook()
        {
            throw new NotImplementedException();
        }
    }
}

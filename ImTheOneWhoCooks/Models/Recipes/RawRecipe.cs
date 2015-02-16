using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImTheOneWhoCooks.Contracts;

namespace ImTheOneWhoCooks.Models.Recipes
{
    public class RawRecipe : Recipe, IEatableRecipe
    {
        private int preparingTime;

        public int PreparingTime
        {
            get { return preparingTime; }
        }

        public override string Cook()
        {
            throw new NotImplementedException();
        }
    }
}

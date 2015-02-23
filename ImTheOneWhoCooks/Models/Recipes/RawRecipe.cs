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

        public RawRecipe(string name, int preparingTime, decimal price)
            : base(name, price)
        {
            this.PreparingTime = preparingTime;
        }

        public RawRecipe(string name, int preparingTime)
            : this(name, preparingTime, 0)
        {
        }

        public int PreparingTime
        {
            get { return preparingTime; }
            private set { preparingTime = value; }
        }

        public override string Cook()
        {
            throw new NotImplementedException();
        }
    }
}

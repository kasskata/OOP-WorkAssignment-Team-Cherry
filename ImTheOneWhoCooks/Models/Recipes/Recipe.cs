using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImTheOneWhoCooks.Contracts;
using ImTheOneWhoCooks.Models;

namespace ImTheOneWhoCooks.Models.Recipes
{
    public abstract class Recipe : KitchenObject, IRecipe
    {
        private readonly IList<IProduct> products;

        protected Recipe(string name) 
            : base(name, 0)
        {
            this.products = new List<IProduct>();
        }

        public IList<IProduct> Products
        {
            get { return products; }
        }

        public override decimal Price
        {
            get
            {
                return 5;
            }
        }

        public abstract string Cook();
    }
}

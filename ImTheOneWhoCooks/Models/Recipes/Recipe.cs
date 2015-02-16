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
        private IList<IProduct> products;

        public IList<IProduct> Products
        {
            get { return products; }
        }

        public abstract string Cook();
    }
}

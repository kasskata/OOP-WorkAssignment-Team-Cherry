using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImTheOneWhoCooks.Contracts;
using ImTheOneWhoCooks.Models;
using ImTheOneWhoCooks.Models.Products;

namespace ImTheOneWhoCooks.Models.Recipes
{
    public abstract class Recipe : KitchenObject, IRecipe
    {
        private readonly IList<IProduct> products;

        protected Recipe(string name, decimal price)
            : base(name, price)
        {
            this.products = new List<IProduct>();
        }

        public IList<IProduct> Products
        {
            get { return products; }
        }

        public abstract string Cook();
    }
}

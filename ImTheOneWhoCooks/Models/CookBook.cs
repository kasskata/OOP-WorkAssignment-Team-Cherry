using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImTheOneWhoCooks.Contracts;

namespace ImTheOneWhoCooks.Models
{
    public class CookBook : ICookBook
    {
        private IList<IRecipe> recipes;

        public CookBook()
        {
            this.Recipes = new List<IRecipe>();
        }

        public IList<IRecipe> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }

        
    }
}

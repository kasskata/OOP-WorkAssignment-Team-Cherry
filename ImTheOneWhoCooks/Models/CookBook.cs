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
            private set { this.recipes = value; }
        }


        public void AddRecipe(IRecipe recipe)
        {
            var cookbookRecipe = this.Recipes.FirstOrDefault(r => r.Name == recipe.Name);
            if (cookbookRecipe != null)
            {
                throw new InvalidOperationException(Messages.);
            }
            this.Recipes.Add();
        }
        
    }
}

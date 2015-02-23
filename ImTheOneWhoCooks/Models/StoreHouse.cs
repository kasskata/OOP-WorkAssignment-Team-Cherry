using System.Collections.Generic;
using System.Linq;
using ImTheOneWhoCooks.Contracts;
using ImTheOneWhoCooks.Enums;

namespace ImTheOneWhoCooks.Models
{
    public class StoreHouse : IStoreHouse
    {
        public StoreHouse()
        {
            this.products = new List<IProduct>();
        }

        private IList<IProduct> products;

        public void Add(IProduct product)
        {
            this.products.Add(product);
        }

        public void Remove(IProduct product)
        {
            this.products.Remove(product);
        }

        public void AddProduct(IProduct product)
        {
            var duplicate = this.products.FirstOrDefault(r => r.Name == product.Name);

            if (duplicate != null)
            {
                duplicate.Price =
                    (duplicate.Price * (decimal)duplicate.Quantity + product.Price * (decimal)product.Quantity) /
                        (decimal)(duplicate.Quantity + product.Quantity);
                duplicate.Quantity = duplicate.Quantity + product.Quantity;
            }
            else
            {
                this.products.Add(product);
            }
        }

        public string List()
        {
            var sortedListProducts = this.products.OrderBy(p => p.ProductType)
                .ThenBy(p => p.Price)
                .ThenBy(p => p.Name)
                .ToList();

            var stringResult = string.Join("\n  ", sortedListProducts);

            return stringResult;
        }

        public string List(ProductType type)
        {
            var listByType = this.products.Where(p => p.ProductType == type).OrderBy(p => p.Name).ThenBy(p => p.Price);

            var stringResult = string.Join("\n  ", listByType);

            return stringResult;
        }

        public string List(string name)
        {
            var listByType = this.products.Where(p => p.Name == name.ToLower()).OrderBy(p => p.Name).ThenBy(p => p.Price);

            var stringResult = string.Join("\n  ", listByType);

            return stringResult;
        }

        //public string PrintMenu()
        //{
        //    var menu = new StringBuilder();
        //    menu.AppendLine(String.Format("***** {0} - {1} *****", this.Name, this.Location));

        //    if (this.Recipes.Count == 0)
        //    {
        //        menu.AppendLine("No recipes... yet");
        //        return menu.ToString().Trim();
        //    }

        //    menu.Append(GetMenuRecipesOfType<Drink>("~~~~~ DRINKS ~~~~~"));
        //    menu.Append(GetMenuRecipesOfType<Salad>("~~~~~ SALADS ~~~~~"));
        //    menu.Append(GetMenuRecipesOfType<MainCourse>("~~~~~ MAIN COURSES ~~~~~"));
        //    menu.Append(GetMenuRecipesOfType<Dessert>("~~~~~ DESSERTS ~~~~~"));

        //    return menu.ToString().Trim();
        //}

        //private string GetMenuRecipesOfType<T>(string menuTitle)
        //{
        //    var submenu = new StringBuilder();


        //    var selectedRecipes = this.Recipes
        //        .OrderBy(r => r.Name)
        //        .OfType<T>();

        //    if (selectedRecipes.Count() == 0)
        //    {
        //        return String.Empty;
        //    }

        //    submenu.AppendLine(menuTitle);
        //    foreach (var recipe in selectedRecipes)
        //    {
        //        submenu.AppendLine(recipe.ToString());
        //    }

        //    return submenu.ToString();
        //}
    }
}

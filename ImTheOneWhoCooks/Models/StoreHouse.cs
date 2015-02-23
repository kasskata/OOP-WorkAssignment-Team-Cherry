using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using ImTheOneWhoCooks.Contracts;
using ImTheOneWhoCooks.Enums;

namespace ImTheOneWhoCooks.Models
{
    public class StoreHouse : IStoreHouse
    {
        public StoreHouse()
        {
            this.Products = new List<IProduct>();
        }

        private IList<IProduct> products;

        public IList<IProduct> Products
        {
            get { return products; }
            set { products = value; }
        }

        public void Remove(IProduct product)
        {
            this.Products.Remove(product);
        }

        public void AddProduct(IProduct product)
        {
            var duplicate = this.Products.FirstOrDefault(r => r.Name == product.Name);

            if (duplicate != null)
            {
                duplicate.Price = 
                    (duplicate.Price * (decimal) duplicate.Quantity + product.Price * (decimal) product.Quantity) /
                        (decimal)( duplicate.Quantity + product.Quantity);
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

            var stringResult = string.Join("\n", sortedListProducts);

            return stringResult;
        }

        public string List(ProductType type)
        {
            var listByType = this.products.Where(p => p.ProductType == type).OrderBy(p => p.Name).ThenBy(p => p.Price);

            var stringResult = string.Join("\n", listByType);

            return stringResult;
        }

        public string List(string name)
        {
            var listByType = this.products.Where(p => p.Name == name.ToLower()).OrderBy(p => p.Name).ThenBy(p => p.Price);

            var stringResult = string.Join("\n", listByType);

            return stringResult;
        }

    }
}

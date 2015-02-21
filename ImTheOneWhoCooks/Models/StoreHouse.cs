using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using ImTheOneWhoCooks.Contracts;

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

        public void Add(IProduct product)
        {
            this.Products.Add(product);
        }

        public void Remove(IProduct product)
        {
            this.Products.Remove(product);
        }

        public void IsDuplicate(IProduct product)
        {
            var duplicate = this.Products.FirstOrDefault(r => r.Name == product.Name);

            if (duplicate != null)
            {
                duplicate.Price = (duplicate.Price + product.Price) / 2;
                duplicate.Quantity = duplicate.Quantity + product.Quantity;
                this.Remove(duplicate);
                this.Add(product);
            }
            else
            {
                this.Add(product);
            }
        }

    }
}

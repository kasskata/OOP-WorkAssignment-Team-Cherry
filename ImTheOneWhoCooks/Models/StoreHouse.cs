using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImTheOneWhoCooks.Contracts;

namespace ImTheOneWhoCooks.Models
{
    public class StoreHouse : IStoreHouse
    {
        private IList<IProduct> products;

        public IList<IProduct> Products
        {
            get { return products; }
            set { products = value; }
        }
    }
}

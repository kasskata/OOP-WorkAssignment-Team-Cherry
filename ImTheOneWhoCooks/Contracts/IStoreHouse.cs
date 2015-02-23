using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImTheOneWhoCooks.Contracts;
using ImTheOneWhoCooks.Enums;

namespace ImTheOneWhoCooks.Contracts
{
    public interface IStoreHouse
    {
        void AddProduct(IProduct product);

        void Remove(IProduct product);

        string List();

        string List(ProductType type);

        string List(string name);
    }
}

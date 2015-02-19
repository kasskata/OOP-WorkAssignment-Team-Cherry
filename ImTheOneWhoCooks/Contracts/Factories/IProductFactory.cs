using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImTheOneWhoCooks.Enums;

namespace ImTheOneWhoCooks.Contracts.Factories
{
    internal interface IProductFactory
    {
        IProduct CreatProduct(string name, decimal price, double quantity, UnitOfMeasurement unitOfMeasurement,
            ProductType productType);

        IProduct CreatEatableProduct(string name, decimal price, double quantity, UnitOfMeasurement unitOfMeasurement,
            ProductType productType, int calories);
    }
}
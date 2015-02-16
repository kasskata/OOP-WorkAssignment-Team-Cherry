using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImTheOneWhoCooks.Contracts;
using ImTheOneWhoCooks.Enums;
using ImTheOneWhoCooks.Models;

namespace ImTheOneWhoCooks.Models.Products
{
    public class Product : KitchenObject, IProduct
    {
        private double quantity;
        private UnitOfMeasurement unitOfMeasurement;
        private ProductType productType;

        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public UnitOfMeasurement UnitOfMeasurement
        {
            get { return unitOfMeasurement; }
            set { unitOfMeasurement = value; }
        }

        public ProductType ProductType
        {
            get { return productType; }
            set { productType = value; }
        }
    }
}

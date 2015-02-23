using ImTheOneWhoCooks.Contracts;
using ImTheOneWhoCooks.Enums;

namespace ImTheOneWhoCooks.Models.Products
{
    public class EatableProduct : Product, ICaloriable
    {
        private int calories;


        public EatableProduct(string name, decimal price, double quantity, UnitOfMeasurement unitOfMeasurement, ProductType productType, int calories)
            : base(name, price, quantity, unitOfMeasurement, productType)
        {
            this.Calories = calories;
        }

        public EatableProduct(string name, double quantity, UnitOfMeasurement unitOfMeasurement)
            : this(name, 0, quantity, unitOfMeasurement, ProductType.Other, 0)
        {
        }


        public int Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        public override string ToString()
        {
            return string.Format("{0},{1}",
              base.ToString(),this.calories);
        }
    }
}

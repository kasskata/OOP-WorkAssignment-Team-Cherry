using ImTheOneWhoCooks.Contracts;
using ImTheOneWhoCooks.Contracts.Factories;
using ImTheOneWhoCooks.Enums;
using ImTheOneWhoCooks.Models.Products;

namespace ImTheOneWhoCooks
{
    public class ProductFactory :IProductFactory
    {
        public IProduct CreateProduct(string name, decimal price, double quantity, UnitOfMeasurement unitOfMeasurement,
            ProductType productType)
        {
            return new Product(name, price, quantity, unitOfMeasurement, productType);
        }

        public IProduct CreateEatableProduct(string name, decimal price, double quantity, UnitOfMeasurement unitOfMeasurement,
            ProductType productType, int calories)
        {
            return new EatableProduct(name, price, quantity, unitOfMeasurement, productType, calories);
        }

        public IProduct CreateEatableProductWithoutPriceAndCalories(string name, double quantity, UnitOfMeasurement unitOfMeasurement,
            ProductType productType)
        {
            return new EatableProduct(name, quantity, unitOfMeasurement, productType);
        }
    }
}

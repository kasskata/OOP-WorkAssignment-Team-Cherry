using ImTheOneWhoCooks.Enums;

namespace ImTheOneWhoCooks.Contracts.Factories
{
    internal interface IProductFactory
    {
        IProduct CreateProduct(string name, decimal price, double quantity, UnitOfMeasurement unitOfMeasurement,
            ProductType productType);

        IProduct CreateEatableProduct(string name, decimal price, double quantity, UnitOfMeasurement unitOfMeasurement,
            ProductType productType, int calories);
    }
}
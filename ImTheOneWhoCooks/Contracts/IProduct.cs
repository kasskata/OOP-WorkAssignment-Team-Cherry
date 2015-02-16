using ImTheOneWhoCooks.Enums;

namespace ImTheOneWhoCooks.Contracts
{
    public interface IProduct : IKitchenObject
    {
        double Quantity { get; set; }
        UnitOfMeasurement UnitOfMeasurement { get; set; }
        ProductType ProductType { get; set; }
    }
}

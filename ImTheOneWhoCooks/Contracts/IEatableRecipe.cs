namespace ImTheOneWhoCooks.Contracts
{
    public interface IEatableRecipe : IRecipe
    {
        int PreparingTime { get; }
    }
}

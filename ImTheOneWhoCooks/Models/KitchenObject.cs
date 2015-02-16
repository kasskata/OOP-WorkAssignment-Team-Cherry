using ImTheOneWhoCooks.Contracts;

namespace ImTheOneWhoCooks.Models
{
    public abstract class KitchenObject : IKitchenObject
    {
        private string name;
        private decimal price;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}

using ImTheOneWhoCooks.Contracts;

namespace ImTheOneWhoCooks.Models
{
    public abstract class KitchenObject : IKitchenObject
    {
        private string name;
        private decimal price;

        protected KitchenObject(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}

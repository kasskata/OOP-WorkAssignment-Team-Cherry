using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImTheOneWhoCooks.Contracts
{
    public interface IRecipe : IKitchenObject 
    {
        IList<IProduct> Products { get; }
        string Cook();
    }
}

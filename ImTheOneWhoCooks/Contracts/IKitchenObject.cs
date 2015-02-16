using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImTheOneWhoCooks.Contracts
{
    public interface IKitchenObject
    {
        string Name { get; set; }
        decimal Price { get; set; }
    }
}

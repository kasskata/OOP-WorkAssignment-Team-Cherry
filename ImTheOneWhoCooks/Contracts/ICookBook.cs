using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImTheOneWhoCooks.Contracts;

namespace ImTheOneWhoCooks.Contracts
{
    public interface ICookBook
    {
        IList<IRecipe> Recipes { get; set; } 
    }
}

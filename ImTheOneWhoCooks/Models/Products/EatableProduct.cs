using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImTheOneWhoCooks.Contracts;

namespace ImTheOneWhoCooks.Models.Products
{
    public class EatableProduct : Product, ICaloriable
    {
        private int calories;

        public int Calories
        {
            get { return calories; }
            set { calories = value; }
        }
    }
}

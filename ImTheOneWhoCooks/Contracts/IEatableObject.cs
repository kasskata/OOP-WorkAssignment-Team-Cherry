using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ImTheOneWhoCooks.Contracts
{
    public interface ICaloriable
    {
        int Calories { get; set; }
    }
}

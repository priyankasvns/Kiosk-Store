using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamProject
{
    public interface IShipItem
    {
        bool Ship { get; set; }

        int ShipItem();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamProject
{
    public class WindshieldWipers : Item, IShipItem
    {
        private int wiperLength;
        private bool ship;


        public int WiperLength
        {
            get => this.wiperLength;
            set => this.wiperLength = value;
        }

        public bool Ship
        {
            get => this.ship;
            set => this.ship = value;
        }

        public WindshieldWipers()
        {

        }

        public WindshieldWipers(int itemNumber, int itemCost, int itemWeight, string itemName, int wiperLength)
            : base(itemNumber, itemCost, itemWeight, itemName)
        {
            this.ItemNumber = itemNumber;
            this.ItemCost = itemCost;
            this.ItemWeight = itemWeight;
            this.ItemName = itemName;
            this.WiperLength = wiperLength;
        }

        public int ShipItem()
        {
            return 10;
        }
    }
}

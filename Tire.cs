using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamProject
{
    public class Tire : Item
    {
        private string tireModelName;
        private int wheelDiameter;

        public string TireModelName 
        { 
            get => this.tireModelName; 
            set => this.tireModelName = value;
        }

        public int WheelDiameter
        {
            get => this.wheelDiameter;
            set => this.wheelDiameter = value;
        }

        public Tire()
        {

        }

        public Tire(int itemNumber, int itemCost, int itemWeight, string itemName, string tireModelName, int wheelDiameter) 
            : base(itemNumber, itemCost, itemWeight, itemName)
        {
            this.ItemNumber = itemNumber;
            this.ItemCost = itemCost;
            this.ItemWeight = itemWeight;
            this.ItemName = itemName;
            this.TireModelName = tireModelName;
            this.WheelDiameter = wheelDiameter;
        }
    }
}

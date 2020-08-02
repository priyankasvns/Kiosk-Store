using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamProject
{
    public class Batteries : Item, IShipItem
    {
        private int batteryVoltage;
        private bool ship;

        public int BatteryVoltage
        {
            get => this.batteryVoltage;
            set => this.batteryVoltage = value;
        }

        public bool Ship
        {
            get => this.ship;
            set => this.ship = value;
        }

        public Batteries()
        {

        }

        public Batteries(int itemNumber, int itemCost, int itemWeight, string itemName, int batteryVoltage)
            : base(itemNumber, itemCost, itemWeight, itemName)
        {
            this.ItemNumber = itemNumber;
            this.ItemCost = itemCost;
            this.ItemWeight = itemWeight;
            this.ItemName = itemName;
            this.BatteryVoltage = batteryVoltage;
        }

        //renamed the function name from shipItem to shippingCostOfItem 
        public int ShipItem()
        {
            //inline variable - instead of using a variable to return the shipping cost 
            //removed it and sending the value itself
            return 30;
        }
    }
}

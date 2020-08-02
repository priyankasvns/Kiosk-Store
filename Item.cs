using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalExamProject
{
    [XmlRoot("Item")]
    [XmlInclude(typeof(Tire))]
    [XmlInclude(typeof(Batteries))]
    [XmlInclude(typeof(WindshieldWipers))]
    
    //extract superclass - this is a base class which is extracted from tire,
    //battery and windshieldwiper classes
    public class Item
    {
        //encapsulating variables
        private int itemNumber;
        private int itemCost;
        private int itemWeight;

        private string itemName;

        public int ItemNumber
        {
            get => this.itemNumber;
            set => this.itemNumber = value;
        }

        public int ItemCost 
        { 
            get => this.itemCost; 
            set => this.itemCost = value; 
        }

        public int ItemWeight
        {
            get => this.itemWeight;
            set => this.itemWeight = value;
        }

        public string ItemName
        {
            get => this.itemName;
            set => this.itemName = value;
        }

        public Item()
        {

        }

        public Item(int itemNumber, int itemCost, int itemWeight, string itemName)
        {
            this.itemNumber = itemNumber;
            this.ItemCost = itemCost;
            this.ItemWeight = itemWeight;
            this.ItemName = itemName;
        }
    }
}

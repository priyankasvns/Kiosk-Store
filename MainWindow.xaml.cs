using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;

namespace FinalExamProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [XmlArray("Item")]
        [XmlArrayItem("Item", typeof(Tire))]
        [XmlArrayItem("Item", typeof(Batteries))]
        [XmlArrayItem("Item", typeof(WindshieldWipers))]
        List<Item> itemsPurchased = new List<Item>();

        int currentTotalPrice = 0;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                itemListComboBox.Items.Add(new KeyValuePair<string, string>("Tire", "1"));
                itemListComboBox.Items.Add(new KeyValuePair<string, string>("Batteries", "2"));
                itemListComboBox.Items.Add(new KeyValuePair<string, string>("Windshield Wipers", "3"));

                itemListComboBox.DisplayMemberPath = "Key";
                itemListComboBox.SelectedValuePath = "Value";

                lblTireModelName.Visibility = Visibility.Hidden;
                lblWheelDiameter.Visibility = Visibility.Hidden;

                tbTireModelNameValue.Visibility = Visibility.Hidden;
                tbWheelDiameterValue.Visibility = Visibility.Hidden;

                lblBatteryVoltage.Visibility = Visibility.Hidden;
                tbBatteryVoltageValue.Visibility = Visibility.Hidden;

                lblWiperLength.Visibility = Visibility.Hidden;
                tbWiperLengthValue.Visibility = Visibility.Hidden;

                lblShippingAvailable.Visibility = Visibility.Hidden;
                rbShippingChargesYes.Visibility = Visibility.Hidden;
                rbShippingChargesNo.Visibility = Visibility.Hidden;

                lblShippingCharges.Visibility = Visibility.Hidden;
                lblShippingChargesValue.Visibility = Visibility.Hidden;

                lblTotalPrice.Content = currentTotalPrice;

                rbShippingChargesNo.IsChecked = false;
                rbShippingChargesYes.IsChecked = false;

                lblItemNumber.Content = "";
                lblItemCost.Content = "";
                lblItemWeight.Content = "";


            }
            catch (Exception)
            {
                MessageBox.Show("Loading problem in the initial screen!");
            }
            

        }

        private void ItemListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (itemListComboBox.SelectedItem != null)
                {
                    if (((KeyValuePair<string, string>)itemListComboBox.SelectedItem).Key == "Tire")
                    {
                        lblItemNumber.Content = "101";
                        lblItemCost.Content = "200";
                        lblItemWeight.Content = "30";

                        lblTireModelName.Visibility = Visibility.Visible;
                        lblWheelDiameter.Visibility = Visibility.Visible;

                        tbTireModelNameValue.Visibility = Visibility.Visible;
                        tbWheelDiameterValue.Visibility = Visibility.Visible;

                        lblBatteryVoltage.Visibility = Visibility.Hidden;
                        tbBatteryVoltageValue.Visibility = Visibility.Hidden;

                        lblShippingAvailable.Visibility = Visibility.Hidden;
                        rbShippingChargesYes.Visibility = Visibility.Hidden;
                        rbShippingChargesNo.Visibility = Visibility.Hidden;

                        lblShippingCharges.Visibility = Visibility.Hidden;
                        lblShippingChargesValue.Visibility = Visibility.Hidden;

                        lblWiperLength.Visibility = Visibility.Hidden;
                        tbWiperLengthValue.Visibility = Visibility.Hidden;



                    }
                    else if (((KeyValuePair<string, string>)itemListComboBox.SelectedItem).Key == "Batteries")
                    {
                        lblItemNumber.Content = "201";
                        lblItemCost.Content = "100";
                        lblItemWeight.Content = "10";

                        lblBatteryVoltage.Visibility = Visibility.Visible;
                        tbBatteryVoltageValue.Visibility = Visibility.Visible;

                        lblShippingAvailable.Visibility = Visibility.Visible;
                        rbShippingChargesYes.Visibility = Visibility.Visible;
                        rbShippingChargesNo.Visibility = Visibility.Visible;
                        rbShippingChargesNo.IsChecked = true;
                        rbShippingChargesYes.IsChecked = false;

                        lblTireModelName.Visibility = Visibility.Hidden;
                        lblWheelDiameter.Visibility = Visibility.Hidden;

                        tbTireModelNameValue.Visibility = Visibility.Hidden;
                        tbWheelDiameterValue.Visibility = Visibility.Hidden;

                        lblShippingCharges.Visibility = Visibility.Hidden;
                        lblShippingChargesValue.Visibility = Visibility.Hidden;

                        lblWiperLength.Visibility = Visibility.Hidden;
                        tbWiperLengthValue.Visibility = Visibility.Hidden;

                    }
                    else if (((KeyValuePair<string, string>)itemListComboBox.SelectedItem).Key == "Windshield Wipers")
                    {
                        lblItemNumber.Content = "101";
                        lblItemCost.Content = "15";
                        lblItemWeight.Content = "1";

                        lblWiperLength.Visibility = Visibility.Visible;
                        tbWiperLengthValue.Visibility = Visibility.Visible;

                        lblShippingAvailable.Visibility = Visibility.Visible;
                        rbShippingChargesYes.Visibility = Visibility.Visible;
                        rbShippingChargesNo.Visibility = Visibility.Visible;
                        rbShippingChargesNo.IsChecked = true;
                        rbShippingChargesYes.IsChecked = false;

                        lblShippingCharges.Visibility = Visibility.Hidden;
                        lblShippingChargesValue.Visibility = Visibility.Hidden;

                        lblTireModelName.Visibility = Visibility.Hidden;
                        lblWheelDiameter.Visibility = Visibility.Hidden;

                        tbTireModelNameValue.Visibility = Visibility.Hidden;
                        tbWheelDiameterValue.Visibility = Visibility.Hidden;

                        lblBatteryVoltage.Visibility = Visibility.Hidden;
                        tbBatteryVoltageValue.Visibility = Visibility.Hidden;


                    }
                    else
                    {
                        lblItemNumber.Content = "";
                        lblItemCost.Content = "";
                        lblItemWeight.Content = "";
                    }



                }
            }
            catch (Exception)
            {
                MessageBox.Show("An issue occured while selection changed event of the combobox!");
            }
            
        }

        private void BtnSubmitItemOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (itemListComboBox.SelectedItem != null)
                {
                    //consolidating two conditional statements since both of them lead to the same path
                    if (((KeyValuePair<string, string>)itemListComboBox.SelectedItem).Key == "Tire" && tbItemNameValue.Text.Trim() != "")
                    {
                        //if (tbItemNameValue.Text.Trim() != "")
                        //{
                            Regex regex = new Regex(@"^[a-zA-Z\s]+$");
                            if (regex.IsMatch(tbItemNameValue.Text.Trim()))
                            {
                                if (tbTireModelNameValue.Text.Trim() != "")
                                {
                                    if (regex.IsMatch(tbTireModelNameValue.Text.Trim()))
                                    {
                                        if (tbWheelDiameterValue.Text.Trim() != "")
                                        {
                                            Regex regexForDiameter = new Regex(@"^[0-9]+$");
                                            if (regexForDiameter.IsMatch(tbWheelDiameterValue.Text.Trim()))
                                            {
                                                //encapsulating record - this is where the values or data record is converted into class in this example it is tire class
                                                Tire tire = new Tire(Convert.ToInt32(lblItemNumber.Content), Convert.ToInt32(lblItemCost.Content), Convert.ToInt32(lblItemWeight.Content),
                                                            tbItemNameValue.Text.Trim(), tbTireModelNameValue.Text.Trim(), Convert.ToInt32(tbWheelDiameterValue.Text.Trim()));
                                                itemsPurchased.Add(tire);
                                                MessageBox.Show("Tire order successful");
                                                currentTotalPrice += Convert.ToInt32(lblItemCost.Content);
                                                lblTotalPrice.Content = currentTotalPrice;

                                            }

                                            else
                                            {
                                                MessageBox.Show("Only numbers allowed. Please enter wheel diameter in numbers only.");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Wheel Diameter is empty. Please enter the data!");
                                        }

                                    }

                                    else
                                    {
                                        MessageBox.Show("Only alphabets allowed. Please enter tire model name in alphabets only.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Tire Model name is empty. Please enter the data!");
                                }
                            }
                            else
                            {

                                MessageBox.Show("Only alphabets allowed. Please enter item name in alphabets only.");
                            }
                        //}
                        //else
                        //{
                         //   MessageBox.Show("Please enter the required data!!");
                        //}
                    }
                    else if (((KeyValuePair<string, string>)itemListComboBox.SelectedItem).Key == "Batteries")
                    {
                        if (tbItemNameValue.Text.Trim() != "")
                        {
                            Regex regex = new Regex(@"^[a-zA-Z\s]+$");
                            if (regex.IsMatch(tbItemNameValue.Text.Trim()))
                            {
                                if (tbBatteryVoltageValue.Text.Trim() != "")
                                {
                                    Regex regexForVolatage = new Regex(@"^[0-9]+$");
                                    if (regexForVolatage.IsMatch(tbBatteryVoltageValue.Text.Trim()))
                                    {
                                        Batteries batteries = new Batteries(Convert.ToInt32(lblItemNumber.Content), Convert.ToInt32(lblItemCost.Content), Convert.ToInt32(lblItemWeight.Content),
                                        tbItemNameValue.Text.Trim(), Convert.ToInt32(tbBatteryVoltageValue.Text.Trim()));
                                        itemsPurchased.Add(batteries);

                                        if (rbShippingChargesYes.IsChecked == true)
                                        {
                                            batteries.Ship = true;
                                            currentTotalPrice += batteries.ShipItem();
                                        }

                                        MessageBox.Show("Batteries order successful");
                                        currentTotalPrice += Convert.ToInt32(lblItemCost.Content);
                                        lblTotalPrice.Content = currentTotalPrice;

                                    }

                                    else
                                    {
                                        MessageBox.Show("Only numbers allowed. Please enter voltage in numbers only.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Voltage is empty. Please enter the data!");
                                }

                            }
                            else
                            {

                                MessageBox.Show("Only alphabets allowed. Please enter item name in alphabets only.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter the required data!!");
                        }
                    }

                    else if (((KeyValuePair<string, string>)itemListComboBox.SelectedItem).Key == "Windshield Wipers")
                    {
                        if (tbItemNameValue.Text.Trim() != "")
                        {
                            Regex regex = new Regex(@"^[a-zA-Z\s]+$");
                            if (regex.IsMatch(tbItemNameValue.Text.Trim()))
                            {
                                if (tbWiperLengthValue.Text.Trim() != "")
                                {
                                    Regex regexForWiperLength = new Regex(@"^[0-9]+$");
                                    if (regexForWiperLength.IsMatch(tbWiperLengthValue.Text.Trim()))
                                    {
                                        WindshieldWipers windshieldWipers = new WindshieldWipers(Convert.ToInt32(lblItemNumber.Content), Convert.ToInt32(lblItemCost.Content), Convert.ToInt32(lblItemWeight.Content),
                                                                            tbItemNameValue.Text.Trim(), Convert.ToInt32(tbWiperLengthValue.Text.Trim()));

                                        itemsPurchased.Add(windshieldWipers);

                                        if (rbShippingChargesYes.IsChecked == true)
                                        {
                                            windshieldWipers.Ship = true;
                                            currentTotalPrice += windshieldWipers.ShipItem();
                                        }

                                        MessageBox.Show("Windshield Wipers order successful");
                                        currentTotalPrice += Convert.ToInt32(lblItemCost.Content);
                                        lblTotalPrice.Content = currentTotalPrice;

                                    }
                                    else
                                    {
                                        MessageBox.Show("Only numbers allowed. Please enter wiper length in numbers only.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Wiper length is empty. Please enter the data!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Only alphabets allowed. Please enter item name in alphabets only.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter the required data!!");
                        }
                    }

                    itemListComboBox.SelectedIndex = -1;

                    lblTireModelName.Visibility = Visibility.Hidden;
                    lblWheelDiameter.Visibility = Visibility.Hidden;

                    tbTireModelNameValue.Visibility = Visibility.Hidden;
                    tbWheelDiameterValue.Visibility = Visibility.Hidden;
                    tbWheelDiameterValue.Clear();

                    lblBatteryVoltage.Visibility = Visibility.Hidden;

                    tbBatteryVoltageValue.Visibility = Visibility.Hidden;
                    tbBatteryVoltageValue.Clear();

                    lblWiperLength.Visibility = Visibility.Hidden;

                    tbWiperLengthValue.Visibility = Visibility.Hidden;
                    tbWiperLengthValue.Clear();

                    lblShippingAvailable.Visibility = Visibility.Hidden;

                    rbShippingChargesYes.IsChecked = false;
                    rbShippingChargesNo.IsChecked = true;

                    rbShippingChargesYes.Visibility = Visibility.Hidden;
                    rbShippingChargesNo.Visibility = Visibility.Hidden;

                    lblShippingCharges.Visibility = Visibility.Hidden;
                    lblShippingChargesValue.Visibility = Visibility.Hidden;

                    tbItemNameValue.Text = "";

                    lblItemNumber.Content = "";
                    lblItemCost.Content = "";
                    lblItemWeight.Content = "";

                }
                else
                {
                    MessageBox.Show("Please select an item from drop down inorder to purchase!!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("An issue occured while submitting the order. Please try again!!");
            }
            

        }

       

        private void RbShippingChargesYes_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                lblShippingCharges.Visibility = Visibility.Visible;
                lblShippingChargesValue.Visibility = Visibility.Visible;

                lblShippingChargesValue.Width = 120;
                lblShippingChargesValue.Height = 25;
                lblShippingChargesValue.Margin = new Thickness(607, 134, 0, 0);
                lblShippingChargesValue.Content = "";

                if (((KeyValuePair<string, string>)itemListComboBox.SelectedItem).Key == "Batteries")
                {
                    Batteries batteriesForShip = new Batteries();
                    lblShippingChargesValue.Content = batteriesForShip.ShipItem();

                }
                else if (((KeyValuePair<string, string>)itemListComboBox.SelectedItem).Key == "Windshield Wipers")
                {
                    WindshieldWipers windshieldForShip = new WindshieldWipers();
                    lblShippingChargesValue.Content = windshieldForShip.ShipItem();

                }
                else
                {
                    lblShippingCharges.Visibility = Visibility.Hidden;
                    lblShippingChargesValue.Visibility = Visibility.Hidden;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Some problem occurred during checking the yes button! ");
            }
            
        }

        private void BtnSaveItemHistory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (itemsPurchased.Count > 0)
                {
                    XmlSerializer itemsSerializer = new XmlSerializer(typeof(List<Item>));
                    StreamWriter itemsStreamWriter = new StreamWriter(".//ItemHistory.xml");
                    itemsSerializer.Serialize(itemsStreamWriter, itemsPurchased);
                    itemsStreamWriter.Close();
                    MessageBox.Show("Item History saved successfully!");
                }
                else
                {
                    MessageBox.Show("No items are purchased yet!!");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to save data. Write error while serializing the data.");
            }

        }

        private void BtnLoadItemHistory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlSerializer itemsSerializer = new XmlSerializer(typeof(List<Item>));
                StreamReader itemsStreamReader = new StreamReader(".//ItemHistory.xml");
                List<Item> deserializedItems = (List<Item>)itemsSerializer.Deserialize(itemsStreamReader);
                itemsStreamReader.Close();

                if (deserializedItems.Count > 0)
                {
                    itemsPurchased.Clear();
                    currentTotalPrice = 0;

                    foreach (Item item in deserializedItems)
                    {
                        itemsPurchased.Add(item);
                        if (item.GetType() == typeof(Tire))
                        {
                            currentTotalPrice += item.ItemCost;


                        }
                        else if (item.GetType() == typeof(Batteries))
                        {
                            currentTotalPrice += item.ItemCost;
                            Batteries battery = (Batteries)item;
                            if (battery.Ship == true)
                            {
                                currentTotalPrice += battery.ShipItem();
                            }


                        }
                        else if (item.GetType() == typeof(WindshieldWipers))
                        {
                            currentTotalPrice += item.ItemCost;
                            WindshieldWipers wiper = (WindshieldWipers)item;
                            if (wiper.Ship == true)
                            {
                                currentTotalPrice += wiper.ShipItem();
                            }

                        }
                    }
                    lblTotalPrice.Content = currentTotalPrice;
                    MessageBox.Show("Item History Loaded successfully!");

                }
                else
                {
                    MessageBox.Show("No items to load. Item History is empty!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load data. Read error while deserializing the data.");
            }
        }

        private void RbShippingChargesNo_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                lblShippingChargesValue.Visibility = Visibility.Visible;
                lblShippingCharges.Visibility = Visibility.Hidden;
                lblShippingChargesValue.Width = 250;
                lblShippingChargesValue.Height = 30;
                lblShippingChargesValue.Margin = new Thickness(480, 134, 0, 0);

                lblShippingChargesValue.Content = "You didnot opt for shipping to home option";
            }
            catch (Exception)
            {
                MessageBox.Show("Some problem occurred during checking the no button! ");
            }
            

        }

        private void BtnLinq1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (itemsPurchased.Count > 0)
                {
                    var tireCount = (from itemsOfTire in itemsPurchased
                                     where itemsOfTire.GetType() == typeof(Tire)
                                     select itemsOfTire).Count();

                    var batteriesCount = (from itemsOfBatteries in itemsPurchased
                                          where itemsOfBatteries.GetType() == typeof(Batteries)
                                          select itemsOfBatteries).Count();

                    var wipersCount = (from itemsOfWipers in itemsPurchased
                                       where itemsOfWipers.GetType() == typeof(WindshieldWipers)
                                       select itemsOfWipers).Count();

                    if (tireCount > batteriesCount && tireCount > wipersCount)
                    {
                        MessageBox.Show($"Item Name: Tire\nPurchase Count = {tireCount}");
                    }

                    else if (batteriesCount > tireCount && batteriesCount > wipersCount)
                    {
                        MessageBox.Show($"Item Name: Batteries\nPurchase Count = {batteriesCount}");
                    }
                    else if (wipersCount > tireCount && wipersCount > batteriesCount)
                    {
                        MessageBox.Show($"Item Name: Wipers\nPurchase Count = {wipersCount}");
                    }
                    else if (tireCount == batteriesCount && batteriesCount == wipersCount && wipersCount == tireCount)
                    {
                        MessageBox.Show($"Item Name: Tire -> Purchase Count = {tireCount}\nItem Name: Batteries -> Purchase Count = {batteriesCount}\n" +
                            $"Item Name: Wipers -> Purchase Count = {wipersCount}");
                    }
                    else if (tireCount == batteriesCount)
                    {
                        MessageBox.Show($"Item Name: Tire -> Purchase Count = {tireCount}\nItem Name: Batteries -> Purchase Count = {batteriesCount}");
                    }
                    else if (tireCount == wipersCount)
                    {
                        MessageBox.Show($"Item Name: Tire -> Purchase Count = {tireCount}\nItem Name: Wipers -> Purchase Count = {wipersCount}");
                    }
                    else if (wipersCount == batteriesCount)
                    {
                        MessageBox.Show($"Item Name: Wipers -> Purchase Count = {wipersCount}\nItem Name: Batteries -> Purchase Count = {batteriesCount}");
                    }
                }
                else
                {
                    MessageBox.Show("No purchased items yet inorder to perform the Linq query!!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Some error while performing the LINQ Query!");
            }



        }
    }
}

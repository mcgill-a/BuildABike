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
using System.Windows.Shapes;
using Business;

namespace Presentation
{
    public partial class OrderWindow : Window
    {
        Order order = new Order();
        
        // Order Window Constructor with bike list passed in
        public OrderWindow(List<Bike> input_bikes)
        {
            if (input_bikes != null && input_bikes.Count > 0)
            {
                // Set the order bike list to the list of bikes
                order.Bikes = new List<Bike>(input_bikes);
            }
            // Setup program
            InitializeComponent();
            populateBikesArray();
            showSpecTitles();
            setOrderText();
        }
        
        // Order Window Empty Constructor
        public OrderWindow()
        {
            InitializeComponent();
            populateBikesArray();
        }

        private void btnAddNewBike_Click(object sender, RoutedEventArgs e)
        {
            List<Bike> output_bikes = order.Bikes;
            // Switch to the bike customistation window
            BikeCustomiserWindow window = new BikeCustomiserWindow(output_bikes);
            this.Close();
            window.ShowDialog();

        }

        public void showSpecTitles()
        {
            lblSpecFrame.Visibility = Visibility.Visible;
            lblSpecGs.Visibility = Visibility.Visible;
            lblSpecWheels.Visibility = Visibility.Visible;
            lblSpecFs.Visibility = Visibility.Visible;
        }

        public void hideSpecTitles()
        {
            lblSpecFrame.Visibility = Visibility.Hidden;
            lblSpecGs.Visibility = Visibility.Hidden;
            lblSpecWheels.Visibility = Visibility.Hidden;
            lblSpecFs.Visibility = Visibility.Hidden;
        }

        // If there are bikes in the bike list, add them to the list box 
        public void populateBikesArray()
        {
            lstOrderBikes.Items.Clear();
            int count = 1;
            if(order.Bikes != null && order.Bikes.Count > 0)
            {
                showSpecTitles();
                
                for (int i = 0; i < order.Bikes.Count; i++)
                {
                    string type = order.Bikes[i].Type;

                    if(type.Equals("Mountain Bike"))
                    {
                        // Add the bike number + type + cost to the listbox
                        lstOrderBikes.Items.Add("Bike " + count + " (MTB) : £" + order.Bikes[i].BikeCost);
                    }
                    else
                    {
                        // Add the bike number + type + cost to the listbox
                        lstOrderBikes.Items.Add("Bike " + count + " (ROAD) : £" + order.Bikes[i].BikeCost);
                    }
                    
                    count++;
                }
                lstOrderBikes.SelectedIndex = 0;
            }
            else
            {
                // If there are no bikes, hide the specification labels
                hideSpecTitles();
            }
        }

        public void setOrderText()
        {
            if (order.Bikes == null || order.Bikes.Count == 0)
            {
                lblOrderTotal.Content = "";
                lblOrderDeliveryDate.Content = "";
            }
            else
            {
                lblOrderTotal.Content = "TOTAL COST: £" + order.TotalCost;
                lblOrderDeliveryDate.Content = "ESTIMATED COMPLETION DATE: " + order.EstimatedCompletionDate.ToShortDateString();
            }
        }

        private void lstOrderBikes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If a bike in the list box is selected
            if (lstOrderBikes.SelectedIndex != -1)
            {
                // Display the selected bike
                int index = lstOrderBikes.SelectedIndex;
                displayBike(getBikeAtIndex(index));
            }
        }

        public Bike getBikeAtIndex(int index)
        {
            return order.Bikes[index];
        }

        // Display all the details of the bike in the order window
        public void displayBike(Bike bike)
        {
            if(bike.Type.Equals("Mountain Bike"))
            {
                imgMtb.Visibility = Visibility.Visible;
                imgRoad.Visibility = Visibility.Hidden;
            }
            else if(bike.Type.Equals("Road Bike"))
            {
                imgRoad.Visibility = Visibility.Visible;
                imgMtb.Visibility = Visibility.Hidden;
            }


            txtFrameModel.Text = bike.Frame.Model;
            txtFrameColour.Text = "Colour: " + bike.Frame.Colour;
            int size = bike.Frame.Size;
            if(size == 15)
            {
                txtFrameSize.Text = "Size: 38cm (" + size.ToString() + "\")";
            }
            else if (size == 17)
            {
                txtFrameSize.Text = "Size: 43cm (" + size.ToString() + "\")";
            }
            else if (size == 19)
            {
                txtFrameSize.Text = "Size: 48cm (" + size.ToString() + "\")";
            }
            
            lblFramePrice.Content = "£" + bike.Frame.Cost.ToString();

            txtGroupSetModel.Text = bike.GroupSet.Model;
            lblGsPrice.Content = "£" + bike.GroupSet.Cost;

            txtWheelsModel.Text = bike.Wheels.Model;
            lblWheelsPrice.Content = "£" + bike.Wheels.Cost;

            txtFinishingSetModel.Text = bike.FinishingSet.Model;
            if(bike.WarrantyUpgrade)
            {
                txtWarrantyUpgrade.Text = "3 Year Warranty Upgrade";
                lblWarrantyPrice.Content = "£50";
            }
            else
            {
                txtWarrantyUpgrade.Text = "Standard 1 Year Warranty";
                lblWarrantyPrice.Content = "";
            }


            lblFsPrice.Content = "£" + bike.FinishingSet.Cost; 
            lblBikeSubTotal.Content = "SUB TOTAL: £" + bike.BikeCost;

            bool flag = false;
            bool everyComponentAvailable = true;
                if (!bike.allComponentsAvailable())
                {
                    everyComponentAvailable = false;
                }
                
                if (bike.containsUnavailableSpecialised())
                {
                    flag = true;
                }

                if (!everyComponentAvailable)
                {
                    int days = 0;
                    if (flag)
                    {
                        days = 14;
                    }
                    else
                    {
                        days = 7;
                    }
                    lblBikeDeliveryTime.Content = "DELIVERY TIME: " + days + " DAYS";
                }
                else
                {
                     lblBikeDeliveryTime.Content = "ALL PARTS IN STOCK";
                }
        }

        // Remove selected bike from order
        private void btnBikeRemove_Click(object sender, RoutedEventArgs e)
        {
            if(lstOrderBikes.SelectedIndex != -1)
            {
                int index = lstOrderBikes.SelectedIndex;
                // Unselect the bike from the listbox
                lstOrderBikes.SelectedIndex = -1;
                string sMessageBoxText = "Are you sure you want to remove this bike from the order?";
                string sCaption = "Build a Bike";
                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                MessageBoxImage icnMessageBox = MessageBoxImage.Question;
                
                MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
                if(rsltMessageBox == MessageBoxResult.Yes)
                {
                    List<Bike> bikes = new List<Bike>(order.Bikes);

                    bikes.RemoveAt(index);
                    // Update the order bike list and listbox
                    order.Bikes = new List<Bike>(bikes);
                    populateBikesArray();
                    resetAllText();
                    setOrderText();
                }
            }
            else
            {
                // If there are no bikes in the order
                if (order.Bikes == null || order.Bikes.Count == 0)
                {
                    string sMessageBoxText = "There are no bikes to remove";
                    string sCaption = "Build a Bike";
                    MessageBoxButton btnMessageBox = MessageBoxButton.OK;
                    MessageBoxImage icnMessageBox = MessageBoxImage.Error;

                    MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
                }
            }
            
        }

        public void resetAllText()
        {
            if (order.Bikes == null || order.Bikes.Count == 0)
            {
                hideSpecTitles();
                imgMtb.Visibility = Visibility.Hidden;
                imgRoad.Visibility = Visibility.Hidden;
                
                txtFrameModel.Text = "";
                txtFrameColour.Text = "";
                txtFrameSize.Text = "";

                lblFramePrice.Content = "";

                txtGroupSetModel.Text = "";
                lblGsPrice.Content = "";

                txtWheelsModel.Text = "";
                lblWheelsPrice.Content = "";

                txtFinishingSetModel.Text = "";
                lblFsPrice.Content = "";

                txtWarrantyUpgrade.Text = "";
                lblWarrantyPrice.Content = "";

                
                lblBikeSubTotal.Content = "";
                lblBikeDeliveryTime.Content = "";

                lblOrderTotal.Content = "";
                lblOrderDeliveryDate.Content = "";
            }
        }

        // Simulate order submission
        private void btnSubmitOrder_Click(object sender, RoutedEventArgs e)
        {
            string sMessageBoxText = "Are you sure you to submit this order?";
            string sCaption = "Build a Bike";
            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Question;
   
            if(order.Bikes != null && order.Bikes.Count > 0)
            {
                MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
                if (rsltMessageBox == MessageBoxResult.Yes)
                {
                    icnMessageBox = MessageBoxImage.Information;
                    btnMessageBox = MessageBoxButton.OK;
                    MessageBox.Show("Order successfully submitted!", sCaption, btnMessageBox, icnMessageBox);
                    // Reset everything
                    order = new Order();
                    lstOrderBikes.SelectedIndex = -1;
                    lstOrderBikes.Items.Clear();
                    resetAllText();
                    hideSpecTitles();
                }
            }
            else
            {
                icnMessageBox = MessageBoxImage.Error;
                btnMessageBox = MessageBoxButton.OK;
                MessageBox.Show("At least 1 bike required to submit an order", sCaption, btnMessageBox, icnMessageBox);
            }
        }
    }
}

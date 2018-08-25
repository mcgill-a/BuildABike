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
    /// <summary>
    /// Interaction logic for BikeCustomiserWindow.xaml
    /// </summary>
    public partial class BikeCustomiserWindow : Window
    {
        List<Bike> bikes = new List<Bike>();
        Bike bike = new Bike();

        List<BikeFrame> list_frames = new List<BikeFrame>();
        List<GroupSet> list_groupsets = new List<GroupSet>();
        List<Wheels> list_wheels = new List<Wheels>();
        List<FinishingSet> list_finishingsets = new List<FinishingSet>();
        Random rand = new Random();

        string bikeTypeChoice;
        bool frameCompleted = false;
        bool groupsetCompleted = false;
        bool wheelsCompleted = false;
        bool finishingsetCompleted = false;

        public BikeCustomiserWindow(List<Bike> input_bikes)
        {
            if(input_bikes != null && input_bikes.Count > 0)
            {
                bikes = new List<Bike>(input_bikes);
            }
            
            InitializeComponent();
            generateComponents();
            updateComponentLists();
            hideTabs();
        }

        public void hideTabs()
        {
            tabFrame.Visibility = Visibility.Collapsed;
            tabGroupSet.Visibility = Visibility.Collapsed;
            tabWheels.Visibility = Visibility.Collapsed;
            tabFinishingSet.Visibility = Visibility.Collapsed;
            tabSubmit.Visibility = Visibility.Collapsed;
        }

        public void unhideTabs()
        {
            tabFrame.Visibility = Visibility.Visible;
            tabGroupSet.Visibility = Visibility.Visible;
            tabWheels.Visibility = Visibility.Visible;
            tabFinishingSet.Visibility = Visibility.Visible;
            tabSubmit.Visibility = Visibility.Visible;
        }

        public void generateFrames()
        {
            List<BikeFrame> generated = new List<BikeFrame>();

            generated.Add(new BikeFrame("Nukeproof Scout 290 Frame 2018", 15, "Black", true, 340, true));
            generated.Add(new BikeFrame("Octane One Spark Frame 2017", 15, "White", false, 315, true));
            generated.Add(new BikeFrame("Nukeproof Pulse Team Frame 2017", 15, "Blue", true, 320, false));
            generated.Add(new BikeFrame("NS Bikes Clash JR Frame 2018", 15, "Black", false, 300, false));
            list_frames = new List<BikeFrame>(generated);
        }

        public void generateGroupset()
        {
            List<GroupSet> generated = new List<GroupSet>();

            generated.Add(new GroupSet("Shimano Ultegra 6800 11 Speed Groupset", "Shimano Venom 11 Speed Gears", "Shimano 6800 Elite Brakes", false, 240, false));
            generated.Add(new GroupSet("Shimano Tiagra 4700 11 Speed Groupset", "Renthal Carbon 11 Speed Gears", "Renthal Ultima Stoppers", true, 310, true));
            generated.Add(new GroupSet("SRAM X01 11 Speed Groupset", "SRAM Splash X34 Gear Set", "SRAM Pomodoro Edition", true, 210, false));
            generated.Add(new GroupSet("Campagnolo Chorus 11 Speed Groupset", "Campagnolo 2300 Gears", "Campagnolo Ignite Break Set", false, 220, true));

            list_groupsets = new List<GroupSet>(generated);
        }

        public void generateWheels()
        {
            List<Wheels> generated = new List<Wheels>();

            generated.Add(new Wheels("Nukeproof Neutron Wheelset", false, 155, true));
            generated.Add(new Wheels("Race Face Turbine R Wheelset", true, 180, true));
            generated.Add(new Wheels("Hope Tech Enduro - Pro 4 Wheels", false, 160, false));
            generated.Add(new Wheels("Mavic Crossride FTS-X Wheels 2017", true, 185, true));

            list_wheels = new List<Wheels>(generated);
        }

        public void generateFinishingSet()
        {
            List<FinishingSet> generated = new List<FinishingSet>();

            generated.Add(new FinishingSet("Nukeproof Warhead Finishing Set", "Nukeproof Elite 420 Handlebars", "Nukeproof Comfort 150 Saddle", true, 290, true));
            generated.Add(new FinishingSet("Renthal Carbon Riser Finishing Set", "Renthal Carbon Bars", "Renthal Dropper Saddle", true, 310, false));
            generated.Add(new FinishingSet("Kore Mega Handlebar + Stem Bundle", "Kore Kingpin Handlebars", "Kore Freeroam Seat", false, 260, true));
            generated.Add(new FinishingSet("LoveMud Aspect Roam Finishing Set", "LoveMud Roamer Handlebars", "LoveMud Final Edition Seat", false, 270, true));
            
            list_finishingsets = new List<FinishingSet>(generated);
        }

        public void generateComponents()
        {
            generateFrames();
            generateGroupset();
            generateWheels();
            generateFinishingSet();
        }

        public void updateComponentLists()
        {
            // Frame component list
            tabFrameLstModels.Items.Clear();
            foreach(BikeFrame frame in list_frames)
            {
                tabFrameLstModels.Items.Add(frame.Model);
            }

            // Group set component list
            tabGsLstModels.Items.Clear();
            foreach(GroupSet groupset in list_groupsets)
            {
                tabGsLstModels.Items.Add(groupset.Model);
            }

            // Wheels component list
            tabWheelsLstModels.Items.Clear();
            foreach(Wheels wheels in list_wheels)
            {
                tabWheelsLstModels.Items.Add(wheels.Model);
            }

            // Finishing set component list
            tabFsLstModels.Items.Clear();
            foreach(FinishingSet finishingset in list_finishingsets)
            {
                tabFsLstModels.Items.Add(finishingset.Model);
            }
        }

        private void tabFrameLstModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(tabFrameLstModels.SelectedIndex != -1)
            {
                displaySelectedFrame(tabFrameLstModels.SelectedItem.ToString());
            }
        }
        public void displaySelectedFrame(string model)
        {
            BikeFrame frame = findFrame(model);

            if(frame != null)
            {
                tabFrameTxtModel.Text = frame.Model;
                tabFrameTxtPrice.Text = "£" + frame.Cost.ToString();
                if(frame.IsSpecialised)
                {
                    tabFrameTxtSpecialised.Text = "Specialised Component";
                }
                else
                {
                    tabFrameTxtSpecialised.Text = "Standard Component";
                }
                if(frame.Availability)
                {
                    tabFrameTxtStock.Text = "In Stock!";
                }
                else
                {
                    tabFrameTxtStock.Text = "Out of Stock";
                }
            }
        }

        public BikeFrame findFrame(string model)
        {
            foreach(BikeFrame frame in list_frames)
            {
                if(frame.Model.Equals(model))
                {
                    return frame;
                }
            }
            return null;
        }

        private void tabFrameBtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string sCaption = "Build a Bike";
            MessageBoxButton btnMessageBox = MessageBoxButton.OK;
            MessageBoxImage icnMessageBox = MessageBoxImage.Information;
            string frame_errors = "";
            if (tabFrameLstModels.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a Frame Model", sCaption, btnMessageBox, icnMessageBox);
            }
            else
            {
                BikeFrame frame = new BikeFrame();

                // Make sure a size is selected
                int size = 0;
                string colour = "unselected";
                if (tabFrameSize38.IsChecked == true)
                {
                    size = 15;
                }
                else if (tabFrameSize43.IsChecked == true)
                {
                    size = 17;
                }
                else if (tabFrameSize48.IsChecked == true)
                {
                    size = 19;
                }

                // Make sure a colour is selected
                if (tabFrameColourBlack.IsChecked == true)
                {
                    colour = "Black";
                }
                else if (tabFrameColourBlue.IsChecked == true)
                {
                    colour = "Blue";
                }
                else if (tabFrameColourGreen.IsChecked == true)
                {
                    colour = "Green";
                }
                else if (tabFrameColourOrange.IsChecked == true)
                {
                    colour = "Orange";
                }
                else if (tabFrameColourRed.IsChecked == true)
                {
                    colour = "Red";
                }
                else if (tabFrameColourWhite.IsChecked == true)
                {
                    colour = "White";
                }
                bool allInputsValid = true;

                if (size == 0)
                {
                    frame_errors += "You need to select a Frame Size\n";
                    allInputsValid = false;
                }
                
                if (colour.Equals("unselected"))
                {

                    frame_errors += "You need to select a Frame Colour";
                    allInputsValid = false;
                }

                if (allInputsValid)
                {
                    try
                    {
                        frame = findFrame(tabFrameLstModels.SelectedItem.ToString());
                        frame.Colour = colour;
                        frame.Size = size;
                        bike.Frame = frame;
                        frameCompleted = true;

                        TextBlock header = new TextBlock();
                        header.Text = "Frame";
                        header.Background = Brushes.LightGreen;
                        tabFrame.Header = header;
                    }
                    catch (ArgumentException error)
                    {
                        MessageBox.Show(error.Message, sCaption, btnMessageBox, icnMessageBox);
                    }
                }
                else
                {
                    MessageBox.Show(frame_errors, sCaption, btnMessageBox, icnMessageBox);
                }
            }
        }

        private void tabGsLstModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabGsLstModels.SelectedIndex != -1)
            {
                displaySelectedGroupset(tabGsLstModels.SelectedItem.ToString());
            }
        }
        public void displaySelectedGroupset(string model)
        {
            GroupSet groupset = findGroupSet(model);

            if (groupset != null)
            {
                tabGsTxtModel.Text = groupset.Model;
                tabGsTxtPrice.Text = "£" + groupset.Cost.ToString();
                tabGsTxtBrakes.Text = groupset.Brakes;
                tabGsTxtGears.Text = groupset.Gears;

                if (groupset.IsSpecialised)
                {
                    tabGsTxtSpecialised.Text = "Specialised Component";
                }
                else
                {
                    tabGsTxtSpecialised.Text = "Standard Component";
                }
                if (groupset.Availability)
                {
                    tabGsTxtStock.Text = "In Stock!";
                }
                else
                {
                    tabGsTxtStock.Text = "Out of Stock";
                }
            }
        }

        public GroupSet findGroupSet(string model)
        {
            foreach (GroupSet groupset in list_groupsets)
            {
                if (groupset.Model.Equals(model))
                {
                    return groupset;
                }
            }
            return null;
        }

        private void tabWheelsLstModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabWheelsLstModels.SelectedIndex != -1)
            {
                displaySelectedWheels(tabWheelsLstModels.SelectedItem.ToString());
            }
        }
        public void displaySelectedWheels(string model)
        {
            Wheels wheels = findWheels(model);

            if (wheels != null)
            {
                tabWheelsTxtModel.Text = wheels.Model;
                tabWheelsTxtPrice.Text = "£" + wheels.Cost.ToString();

                if (wheels.IsSpecialised)
                {
                    tabWheelsTxtSpecialised.Text = "Specialised Component";
                }
                else
                {
                    tabWheelsTxtSpecialised.Text = "Standard Component";
                }
                if (wheels.Availability)
                {
                    tabWheelsTxtStock.Text = "In Stock!";
                }
                else
                {
                    tabWheelsTxtStock.Text = "Out of Stock";
                }
                tabWheelsTxtDetail.Text = "Lorem ipsum dolor sit amet, dolor natoque quisque " +
                "dictum mattis mattis diam elit, metus nam felis elit proident felis, mauris neque eget sit eros nec neque, " +
                "ut nec nec. Id malesuada dui, odio proin cum eros vel quis. Mollis dictumst, nullam suscipit auctor architecto";
            }
        }

        public Wheels findWheels(string model)
        {
            foreach (Wheels wheels in list_wheels)
            {
                if (wheels.Model.Equals(model))
                {
                    return wheels;
                }
            }
            return null;
        }

        private void tabTypeBtnMtb_Click(object sender, RoutedEventArgs e)
        {
            bikeTypeChoice = "Mountain Bike";
            bike.Type = bikeTypeChoice;
            tabTypeBtnMtb.Background = new SolidColorBrush(Color.FromRgb(157, 192, 249));
            tabTypeBtnRoad.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            unhideTabs();

            TextBlock header = new TextBlock();
            header.Text = "Type";
            header.Background = Brushes.LightGreen;
            tabType.Header = header;
        }

        private void tabTypeBtnRoad_Click(object sender, RoutedEventArgs e)
        {
            bikeTypeChoice = "Road Bike";
            bike.Type = bikeTypeChoice;
            tabTypeBtnMtb.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            tabTypeBtnRoad.Background = new SolidColorBrush(Color.FromRgb(157, 192, 249));
            unhideTabs();

            TextBlock header = new TextBlock();
            header.Text = "Type";
            header.Background = Brushes.LightGreen;
            tabType.Header = header;
        }

        private void tabFsLstModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabFsLstModels.SelectedIndex != -1)
            {
                displaySelectedFinishingSet(tabFsLstModels.SelectedItem.ToString());
            }
        }
        public void displaySelectedFinishingSet(string model)
        {
            FinishingSet finishingset = findFinishingSet(model);

            if (finishingset != null)
            {
                tabFsTxtModel.Text = finishingset.Model;
                tabFsTxtPrice.Text = "£" + finishingset.Cost.ToString();
                tabFsTxtHandlebars.Text = finishingset.Handlebars;
                tabFsTxtSaddle.Text = finishingset.Saddle;

                if (finishingset.IsSpecialised)
                {
                    tabFsTxtSpecialised.Text = "Specialised Component";
                }
                else
                {
                    tabFsTxtSpecialised.Text = "Standard Component";
                }
                if (finishingset.Availability)
                {
                    tabFsTxtStock.Text = "In Stock!";
                }
                else
                {
                    tabFsTxtStock.Text = "Out of Stock";
                }
            }
        }

        public FinishingSet findFinishingSet(string model)
        {
            foreach (FinishingSet finishingset in list_finishingsets)
            {
                if (finishingset.Model.Equals(model))
                {
                    return finishingset;
                }
            }
            return null;
        }

        private void tabGsBtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string sCaption = "Build a Bike";
            MessageBoxButton btnMessageBox = MessageBoxButton.OK;
            MessageBoxImage icnMessageBox = MessageBoxImage.Information;
            if (tabGsLstModels.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a Group Set Model", sCaption, btnMessageBox, icnMessageBox);
            }
            else
            {
                GroupSet groupset = findGroupSet(tabGsLstModels.SelectedItem.ToString());
                if(groupset != null)
                {
                    try
                    {
                        bike.GroupSet = groupset;
                        groupsetCompleted = true;

                        TextBlock header = new TextBlock();
                        header.Text = "Group Set";
                        header.Background = Brushes.LightGreen;
                        tabGroupSet.Header = header;
                    }
                    catch (ArgumentException error)
                    {
                        MessageBox.Show(error.Message, sCaption, btnMessageBox, MessageBoxImage.Error);
                    }
                }
                
            }
        }

        private void tabWheelsBtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string sCaption = "Build a Bike";
            MessageBoxButton btnMessageBox = MessageBoxButton.OK;
            MessageBoxImage icnMessageBox = MessageBoxImage.Information;
            if(tabWheelsLstModels.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a Wheels Model", sCaption, btnMessageBox, icnMessageBox);
            }
            else
            {
                Wheels wheels = findWheels(tabWheelsLstModels.SelectedItem.ToString());
                if(wheels != null)
                {
                    try
                    {
                        bike.Wheels = wheels;
                        wheelsCompleted = true;

                        TextBlock header = new TextBlock();
                        header.Text = "Wheels";
                        header.Background = Brushes.LightGreen;
                        tabWheels.Header = header;
                    }
                    catch(ArgumentException error)
                    {
                        MessageBox.Show(error.Message, sCaption, btnMessageBox, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void tabFsBtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string sCaption = "Build a Bike";
            MessageBoxButton btnMessageBox = MessageBoxButton.OK;
            MessageBoxImage icnMessageBox = MessageBoxImage.Information;
            if(tabFsLstModels.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a Finishing Set Model", sCaption, btnMessageBox, icnMessageBox);
            }
            else
            {
                FinishingSet finishingset = findFinishingSet(tabFsLstModels.SelectedItem.ToString());
                if(finishingset != null)
                {
                    try
                    {
                        bike.FinishingSet = finishingset;
                        finishingsetCompleted = true;

                        TextBlock header = new TextBlock();
                        header.Text = "Finishing Set";
                        header.Background = Brushes.LightGreen;
                        tabFinishingSet.Header = header;
                    }
                    catch(ArgumentException error)
                    {
                        MessageBox.Show(error.Message, sCaption, btnMessageBox, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void tabSubmitBtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string incomplete = "";
            if(bikeTypeChoice.Length < 1)
            {
                incomplete += "Bike type choice not selected\n";
            }
            if(!frameCompleted)
            {
                incomplete += "Frame not confirmed\n";
            }
            if(!groupsetCompleted)
            {
                incomplete += "Group Set not confirmed\n";
            }
            if(!wheelsCompleted)
            {
                incomplete += "Wheels not confirmed\n";
            }
            if(!finishingsetCompleted)
            {
                incomplete += "Finishing Set not confirmed";
            }

            string sMessageBoxText = "Are you sure you want to add this bike to the order?";
            string sCaption = "Build a Bike";
            MessageBoxButton btnError = MessageBoxButton.OK;
            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage error = MessageBoxImage.Error;
            MessageBoxImage icnMessageBox = MessageBoxImage.Question;
            

            if(incomplete.Length > 0)
            {
                MessageBoxResult rsltMessageBox = MessageBox.Show(incomplete, sCaption, btnError, error);
            }
            else
            {
                MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
                if(rsltMessageBox == MessageBoxResult.Yes)
                {
                    bikes.Add(bike);
                    this.Close();
                }
            }
        }

        private void tabSubmitBtnCancel_Click(object sender, RoutedEventArgs e)
        {
            string sMessageBoxText = "Are you sure you want to cancel this bike customisation?";
            string sCaption = "Build a Bike";
            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Question;
            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            if (rsltMessageBox == MessageBoxResult.Yes)
            {
                this.Close();

            }
        }

        public void updateSubmitPage()
        {
            int count = 0;
            if(frameCompleted)
            {
                tabSubmitTxtFrameModel.Text = bike.Frame.Model;
                tabSubmitTxtFrameColour.Text = "Colour: " + bike.Frame.Colour;
                int size = bike.Frame.Size;
                if (size == 15)
                {
                    tabSubmitTxtFrameSize.Text = "Size: 38cm (" + size.ToString() + "\")";
                }
                else if (size == 17)
                {
                    tabSubmitTxtFrameSize.Text = "Size: 43cm (" + size.ToString() + "\")";
                }
                else if (size == 19)
                {
                    tabSubmitTxtFrameSize.Text = "Size: 48cm (" + size.ToString() + "\")";
                }
                tabSubmitLblFramePrice.Content = "£" + bike.Frame.Cost.ToString();
                count++;
            }

            if(groupsetCompleted)
            {
                tabSubmitTxtGs.Text = bike.GroupSet.Model;
                tabSubmitLblGsPrice.Content = "£" + bike.GroupSet.Cost;
                count++;
            }

            if(wheelsCompleted)
            {
                tabSubmitTxtWheels.Text = bike.Wheels.Model;
                tabSubmitLblWheelsPrice.Content = "£" + bike.Wheels.Cost;
                count++;
            }

            if(finishingsetCompleted)
            {
                tabSubmitTxtFs.Text = bike.FinishingSet.Model;
                tabSubmitLblFsPrice.Content = "£" + bike.FinishingSet.Cost;
                count++;
            }
            int days = 0;
            if(count == 4 && bike != null)
            {
                tabSubmitLblSubTotal.Content = "SUB TOTAL: £" + bike.BikeCost;

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
                        if (flag)
                        {
                            days = 14;
                        }
                        else
                        {
                            days = 7;
                        }
                        tabSubmitLblDeliveryTime.Content = "DELIVERY TIME: " + days + " DAYS";
                    }
                    else
                    {
                        tabSubmitLblDeliveryTime.Content = "ALL PARTS IN STOCK";
                    }
                    
            }

        }

        private void tabSubmitChkWarranty_Checked(object sender, RoutedEventArgs e)
        {
            bike.WarrantyUpgrade = true;
            updateSubmitPage();
        }

        private void tabSubmitChkWarranty_Unchecked(object sender, RoutedEventArgs e)
        {
            bike.WarrantyUpgrade = false;
            updateSubmitPage();
        }

        private void tabSubmit_Selected(object sender, RoutedEventArgs e)
        {
            updateSubmitPage();
        }

        // When the current window is closed
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // If bikes list contains at least 1 bike
            if (bikes != null && bikes.Count > 0)
            {
                OrderWindow orderWindow = new OrderWindow(bikes);
                orderWindow.Show();
            }
            else
            {
                OrderWindow orderWindow = new OrderWindow();
                orderWindow.Show();
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }
    }
}

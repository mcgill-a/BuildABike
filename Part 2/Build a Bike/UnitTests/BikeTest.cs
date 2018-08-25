using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using System.Collections.Generic;


namespace UnitTests
{
    [TestClass]
    public class BikeTest
    {
        /*
         * Author:              40276245 (Alex McGill)
         * Description:         This is the bike test class which tests each part
         *                      of the bike to ensure it works as expected
         * Date last modified:  21/03/2017
         */
        Random rand = new Random();

        [TestMethod]
        public void FrameTest()
        {
            string model = "Nukeproof Scout 290 Frame 2018";
            string colour = "Red";
            int size = 17;
            bool isSpecialised = true;
            double cost = 349.99;
            bool availability = false;

            BikeFrame frame = new BikeFrame();
            frame.Model = model;
            frame.Colour = colour;
            frame.Size = size;
            frame.IsSpecialised = isSpecialised;
            frame.Cost = cost;
            frame.Availability = availability;

            Assert.AreEqual(model, frame.Model, "Frame Test - Model");
            Assert.AreEqual(colour, frame.Colour, "Frame Test - Colour");
            Assert.AreEqual(size, frame.Size, "Frame Test - Size");
            Assert.AreEqual(isSpecialised, frame.IsSpecialised, "Frame Test - Specialised");
            Assert.AreEqual(cost, frame.Cost, "Frame Test - Cost");
            Assert.AreEqual(availability, frame.Availability, "Frame Test - Availability");
        }

        [TestMethod]
        public void GroupSetTest()
        {
            string model = "Some model";
            string gears = "Some gears";
            string brakes = "Some brakes";
            double cost = 469.99;
            bool availability = true;

            GroupSet groupset = new GroupSet();
            groupset.Model = model;
            groupset.Gears = gears;
            groupset.Brakes = brakes;
            groupset.Cost = cost;
            groupset.Availability = availability;

            Assert.AreEqual(model, groupset.Model, "GroupSet Test - Model");
            Assert.AreEqual(gears, groupset.Gears, "GroupSet Test - Gears");
            Assert.AreEqual(brakes, groupset.Brakes, "GroupSet Test - Brakes");
            // default specialised is false (if nothing has been set)
            Assert.AreEqual(false, groupset.IsSpecialised, "GroupSet Test - Specialised");
            Assert.AreEqual(cost, groupset.Cost, "GroupSet Test - Cost");
            Assert.AreEqual(availability, groupset.Availability, "GroupSet Test - Availability");
        }

        [TestMethod]
        public void WheelsTest()
        {
            string model = "Some wheels";
            bool isSpecialised = true;
            double cost = 240.99;
            bool availability = true;

            Wheels wheels = new Wheels();
            wheels.Model = model;
            wheels.IsSpecialised = isSpecialised;
            wheels.Cost = cost;
            wheels.Availability = availability;

            Assert.AreEqual(model, wheels.Model, "Wheels Test - Model");
            Assert.AreEqual(isSpecialised, wheels.IsSpecialised, "Wheels Test - Specialised");
            Assert.AreEqual(cost, wheels.Cost, "Wheels Test - Cost");
            Assert.AreEqual(availability, wheels.Availability, "Wheels Test - Availability");
        }

        [TestMethod]
        public void FinishingSetTest()
        {
            string handlebars = "Some handlebars";
            string saddle = "Some saddle";
            double cost = 214.99;
            bool availability = true;

            FinishingSet finishingset = new FinishingSet();
            finishingset.Handlebars = handlebars;
            finishingset.Saddle = saddle;
            finishingset.Cost = cost;
            finishingset.Availability = availability;

            Assert.AreEqual(handlebars, finishingset.Handlebars, "FinishingSet Test - Handlebars");
            Assert.AreEqual(saddle, finishingset.Saddle, "FinishingSet Test - Saddle");
            // default specialised is false (if nothing has been set)
            Assert.AreEqual(false, finishingset.IsSpecialised, "FinishingSet Test - Specialised");
            Assert.AreEqual(cost, finishingset.Cost, "FinishingSet Test - Cost");
            Assert.AreEqual(availability, finishingset.Availability, "FinishingSet Test - Availability");
        }

        
        [TestMethod]
        public void _fullBikeTestPass()
        {
            // Frame
            string model = "Nukeproof Scout 290 Frame 2018";
            string colour = "Red";
            int size = 17;
            bool isSpecialised = true;
            double cost = 349.99;
            bool availability = false;

            BikeFrame frame = new BikeFrame();
            frame.Model = model;
            frame.Colour = colour;
            frame.Size = size;
            frame.IsSpecialised = isSpecialised;
            frame.Cost = cost;
            frame.Availability = availability;

            // Group Set
            string gears = "Some gears";
            string brakes = "Some brakes";
            isSpecialised = false;
            cost = 469.99;
            availability = true;

            GroupSet groupset = new GroupSet();
            groupset.Gears = gears;
            groupset.Brakes = brakes;
            groupset.Cost = cost;
            groupset.Availability = availability;

            // Wheels
            model = "Some wheels";
            isSpecialised = true;
            cost = 240.99;
            availability = false;

            Wheels wheels = new Wheels();
            wheels.Model = model;
            wheels.IsSpecialised = isSpecialised;
            wheels.Cost = cost;
            wheels.Availability = availability;

            // Finishing Set
            string handlebars = "Some handlebars";
            string saddle = "Some saddle";
            isSpecialised = false;
            cost = 214.99;
            availability = true;

            FinishingSet finishingset = new FinishingSet();
            finishingset.Handlebars = handlebars;
            finishingset.Saddle = saddle;
            finishingset.Cost = cost;
            finishingset.Availability = availability;

            string type = "Mountain Bike";
            bool warrantyUpgrade = true;

            Bike bike = new Bike();

            bike.Frame = frame;
            bike.GroupSet = groupset;
            bike.Wheels = wheels;
            bike.FinishingSet = finishingset;
            bike.Type = type;
            bike.WarrantyUpgrade = warrantyUpgrade;

            Assert.AreEqual(frame, bike.Frame, "FullBikeTest - Frame");
            Assert.AreEqual(groupset, bike.GroupSet, "FullBikeTest - Group Set");
            Assert.AreEqual(wheels, bike.Wheels, "FullBikeTest - Wheels");
            Assert.AreEqual(finishingset, bike.FinishingSet, "FullBikeTest - Finishing Set");
            Assert.AreEqual(type, bike.Type, "FullBikeTest - Type");
            Assert.AreEqual(warrantyUpgrade, bike.WarrantyUpgrade, "FullBikeTest - Warranty Upgrade");
            Assert.AreEqual(1325.96, bike.BikeCost, "FullBikeTest - Cost");
        }

        [TestMethod]
        public void _fullBikeTestFail()
        {
            // Frame
            string model = "Nukeproof Scout 290 Frame 2018";
            string invalid_colour = "Gray";
            int size = 17;
            bool isSpecialised = true;
            double cost = 349.99;
            bool availability = false;

            BikeFrame frame = new BikeFrame();
            try
            {
                frame.Model = model;
                frame.Colour = invalid_colour;
                frame.Size = size;
                frame.IsSpecialised = isSpecialised;
                frame.Cost = cost;
                frame.Availability = availability;
                Assert.Fail("No exception was thrown for an invalid colour");
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
                Assert.AreEqual("Colour '" + invalid_colour + "' not available", error.Message);
            }
            

            // Group Set
            string gears = "Some gears";
            string brakes = "Some brakes";
            isSpecialised = false;
            double invalid_cost = -50;
            availability = true;

            GroupSet groupset = new GroupSet();
            try
            {
                groupset.Gears = gears;
                groupset.Brakes = brakes;
                groupset.Cost = invalid_cost;
                groupset.Availability = availability;
                Assert.Fail("No exception was thrown for an invalid cost");
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
                Assert.AreEqual("Cost '" + invalid_cost + "' is not valid", error.Message);
            }

            // Wheels
            string invalid_model = "";
            isSpecialised = true;
            cost = 180;
            availability = false;

            Wheels wheels = new Wheels();
            try
            {
                wheels.Model = invalid_model;
                wheels.IsSpecialised = isSpecialised;
                wheels.Cost = cost;
                wheels.Availability = availability;
                Assert.Fail("No exception was thrown for an invalid model");
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
                Assert.AreEqual("Model '" + invalid_model + "' is not valid", error.Message);
            }
            

            // Finishing Set
            model = "Some model";
            string handlebars = "Some handlebars";
            string invalid_saddle = "";
            isSpecialised = false;
            cost = 214.99;
            availability = true;

            FinishingSet finishingset = new FinishingSet();
            try
            {
                finishingset.Availability = availability;
                finishingset.Handlebars = handlebars;
                finishingset.Saddle = invalid_saddle;
                finishingset.Cost = cost;
                finishingset.Availability = availability;
                Assert.Fail("No exception was thrown for an invalid saddle");
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
                Assert.AreEqual("Saddle '" + invalid_saddle + "' is not valid", error.Message);
            }

            string invalid_type = "invalid";
            bool warrantyUpgrade = true;

            Bike bike = new Bike();
            try
            {
                bike.Type = invalid_type;
                bike.WarrantyUpgrade = warrantyUpgrade;
                Assert.Fail("No exception was thrown for an invalid bike type");
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
                Assert.AreEqual("Type '" + invalid_type + "' is not available", error.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Bike
    {
        private string _type;
        private BikeFrame _frame;
        private GroupSet _groupset;
        private Wheels _wheels;
        private FinishingSet _finishingSet;
        private bool _warrantyUpgrade;
        private double _bikeCost;

        public Bike()
        {

        }

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                if(value.Equals("Mountain Bike") || value.Equals("Road Bike"))
                {
                    _type = value;
                }
                else
                {
                    throw new ArgumentException("Type '" + value + "' is not available");
                }
            }
        }

        public BikeFrame Frame
        {
            get
            {
                return _frame;
            }
            set
            {
                _frame = value;
            }
        }

        public GroupSet GroupSet
        {
            get
            {
                return _groupset;
            }
            set
            {
                _groupset = value;
            }
        }

        public Wheels Wheels
        {
            get
            {
                return _wheels;
            }
            set
            {
                _wheels = value;
            }
        }

        public FinishingSet FinishingSet
        {
            get
            {
                return _finishingSet;
            }
            set
            {
                _finishingSet = value;
            }
        }

        public bool WarrantyUpgrade
        {
            get
            {
                return _warrantyUpgrade;
            }
            set
            {
                _warrantyUpgrade = value;
            }
        }

        public double BikeCost
        {
            get
            {
                updatePrice();
                return _bikeCost;
            }
        }

        public bool allComponentsAvailable()
        {
            if (_frame.Availability && _groupset.Availability && _wheels.Availability && _finishingSet.Availability)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool containsUnavailableSpecialised()
        {
            // If component is not available and is specialised

            if (!_frame.Availability && _frame.IsSpecialised)
            {
                return true;
            }
            if (!_groupset.Availability && _groupset.IsSpecialised)
            {
                return true;
            }
            if (!_wheels.Availability && _wheels.IsSpecialised)
            {
                return true;
            }
            if (!_finishingSet.Availability && _finishingSet.IsSpecialised)
            {
                return true;
            }

            return false;
        }

        private void updatePrice()
        {
            double total = 0;
            total += Frame.Cost;
            total += GroupSet.Cost;
            total += Wheels.Cost;
            total += FinishingSet.Cost;

            if(_warrantyUpgrade)
            {
                total += 50;
            }
            _bikeCost = total;
        }
    }
}
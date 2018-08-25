using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class GroupSet
    {
        private string _model;
        private string _gears;
        private string _brakes;
        private bool _isSpecialised;
        private double _cost;
        private bool _availability;

        public GroupSet()
        {
            //default
            _isSpecialised = false;
        }

        public GroupSet(string model, string gears, string brakes, bool isSpecialised, double cost, bool availability)
        {
            Model = model;
            Gears = gears;
            Brakes = brakes;
            IsSpecialised = isSpecialised;
            Cost = cost;
            Availability = availability;
        }

        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (!(String.IsNullOrWhiteSpace(value)))
                {
                    _model = value;
                }
                else
                {
                    throw new ArgumentException("Model '" + value + "' is not valid");
                }
            }
        }
        public string Gears
        {
            get
            {
                return _gears;
            }
            set
            {
                if (!(String.IsNullOrWhiteSpace(value)))
                {
                    _gears = value;
                }
                else
                {
                    throw new ArgumentException("Gears '" + value + "' is not valid");
                }
            }
        }

        public string Brakes
        {
            get
            {
                return _brakes;
            }
            set
            {

                if (!(String.IsNullOrWhiteSpace(value)))
                {
                    _brakes = value;
                }
                else
                {
                    throw new ArgumentException("Brakes '" + value + "' is not valid");
                }
            }
        }


        public bool IsSpecialised
        {
            get
            {
                return _isSpecialised;
            }
            set
            {
                _isSpecialised = value;
            }
        }

        public double Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if(value > 0)
                {
                    _cost = value;
                }
                else
                {
                    throw new ArgumentException("Cost '" + value + "' is not valid");
                }
                
            }
        }

        public bool Availability
        {
            get
            {
                return _availability;
            }
            set
            {
                if (value != null)
                {
                    _availability = value;
                }
                else
                {
                    throw new ArgumentException("Availability value is not set");
                }

            }
        }



    }
}

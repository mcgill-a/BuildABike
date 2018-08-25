using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Wheels
    {
        private string _model;
        private bool _isSpecialised;
        private double _cost;
        private bool _availability;

        public Wheels(string model, bool isSpecialised, double cost, bool availability)
        {
            Model = model;
            IsSpecialised = isSpecialised;
            Cost = cost;
            Availability = availability;
        }

        public Wheels()
        {

        }

        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                if(!(String.IsNullOrWhiteSpace(value)))
                {
                    _model = value;
                }
                else
                {
                    throw new ArgumentException("Model '" + value + "' is not valid");
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
                if (value > 0)
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
                if(value != null)
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

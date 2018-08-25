using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class FinishingSet
    {
        private string _model;
        private string _handlebars;
        private string _saddle;
        private bool _isSpecialised;
        private double _cost;
        private bool _availability;


        public FinishingSet()
        {

        }

        public FinishingSet(string model, string handlebars, string saddle, bool isSpecialised, double cost, bool availability)
        {
            Model = model;
            Handlebars = handlebars;
            Saddle = saddle;
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

        public string Handlebars
        {
            get
            {
                return _handlebars;
            }
            set
            {
                if (!(String.IsNullOrWhiteSpace(value)))
                {
                    _handlebars = value;
                }
                else
                {
                    throw new ArgumentException("Handlebars '" + value + "' is not valid");
                }
                
            }
        }

        public string Saddle
        {
            get
            {
                return _saddle;
            }
            set
            {
                if (!(String.IsNullOrWhiteSpace(value)))
                {
                    _saddle = value;
                }
                else
                {
                    throw new ArgumentException("Saddle '" + value + "' is not valid");
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
                _cost = value;
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

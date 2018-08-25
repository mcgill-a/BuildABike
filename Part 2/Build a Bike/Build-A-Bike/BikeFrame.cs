using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    // Class is called 'BikeFrame' instead of 'Frame' because 'Frame' is taken
    // by the WPF Frame Class in 'System.Windows.Controls'
    public class BikeFrame
    {
        private string _model;
        private int _size;
        private string _colour;
        private bool _isSpecialised;
        private double _cost;
        private bool _availability;
        
        public BikeFrame()
        {
            
            // default
            _isSpecialised = false;
        }

        public BikeFrame(string model, int size, string colour, bool isSpecialised, double cost, bool availability)
        {
            Model = model;
            Size = size;
            Colour = colour;
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

        private bool sizeValid(int size)
        {
            List<int> sizes = new List<int>();
            sizes.Add(15);
            sizes.Add(17);
            sizes.Add(19);

            for(int i = 0; i < sizes.Count; i++)
            {
                if (sizes[i] == size)
                {
                    return true;
                }
            }
            return false;
        }

        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                if(sizeValid(value))
                {
                    _size = value;
                }
                else
                {
                    throw new ArgumentException("Size '" + value + "' not available");
                }
            }
        }

        private bool colourValid(string colour)
        {
            List<string> colours = new List<string>();
            colours.Add("Black");
            colours.Add("Red");
            colours.Add("Blue");
            colours.Add("White");
            colours.Add("Orange");
            colours.Add("Green");

            for(int i = 0; i < colours.Count; i++)
            {
                if (colours[i].Equals(colour))
                {
                    return true;
                }
            }
            return false;
        }

        public string Colour
        {
            get
            {
                return _colour;                
            }
            set
            {
                if(value.Length > 0 && colourValid(value))
                {
                    _colour = value;
                }
                else
                {
                    throw new ArgumentException("Colour '" + value + "' not available");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Order
    {
        private List<Bike> _bikes;
        private DateTime _estimatedCompletionDate;
        private double _totalCost;

        public Order()
        {
            
        }

        public List<Bike>Bikes
        {
            get
            {
                return _bikes;
            }
            set
            {
                _bikes = value;
            }
        }

        private DateTime calculateEstimatedCompletionDate()
        {
            DateTime estimatedDeliveryDate = DateTime.Now;
            bool flag = false;
            bool everyComponentAvailable = true;
            foreach (Bike current in Bikes)
            {
                if (!current.allComponentsAvailable())
                {
                    everyComponentAvailable = false;
                }

                if (current.containsUnavailableSpecialised())
                {
                    flag = true;
                }
            }

            if (!everyComponentAvailable)
            {
                if (flag)
                {
                    estimatedDeliveryDate = estimatedDeliveryDate.AddDays(14);
                }
                else
                {
                    estimatedDeliveryDate = estimatedDeliveryDate.AddDays(7);
                }
            }
            return estimatedDeliveryDate;
        }

        public DateTime EstimatedCompletionDate
        {
            get
            {
                _estimatedCompletionDate = calculateEstimatedCompletionDate();

                return _estimatedCompletionDate;
            }
            set
            {
                _estimatedCompletionDate = value;
            }
        }



        private double calculateTotalBikesCost()
        {
            double total = 0;
            foreach(Bike bike in Bikes)
            {
                total += bike.BikeCost;
            }

            return total;
        }

        public double TotalCost
        {
            get
            {
                _totalCost = calculateTotalBikesCost();
                
                return _totalCost;
            }
            set
            {
                _totalCost = value;
            }
        }
    }
}

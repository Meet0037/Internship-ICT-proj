using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingManagement        //DO NOT change the namespace name
{
    public class ShippingDetails    //DO NOT change the class name
    {
        //Implement code here
        public int ShippingId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public int Distance { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Priority { get; set; }

        public ShippingDetails() { }

        public ShippingDetails(int id, string sLocation, string eLocation, int distance, DateTime sdate, DateTime ddate, string priority)
        {
            this.ShippingId = id;
            this.StartLocation = sLocation;
            this.EndLocation = eLocation;
            this.Distance = distance;
            this.StartDate = sdate;
            this.DeliveryDate = ddate;
            this.Priority = priority;
        }
    }
}

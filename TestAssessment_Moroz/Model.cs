using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssessment_Moroz
{
    public class Model
    {
        //Just comment all unnecessary fields
        //public int VendorId { get; set; }
        public DateTime Pickup_datetime { get; set; }
        public DateTime Dropoff_datetime { get; set; }
        public int Passenger_count { get; set; }
        public double Trip_distance { get; set; }
        //public int RatecodeID { get; set; }
        public string Store_and_fwd_flag { get; set; }
        public int PULocationID { get; set; }
        public int DOLocationID { get; set; }
        //public int Payment_type { get; set; }
        public double Fare_amount { get; set; }
        //public double Extra { get; set; }
        //public double Mta_tax { get; set; }
        public double Tip_amount { get; set; }
        //public double Tolls_amount { get; set; }
        //public double Improvement_surcharge { get; set; }
        //public double Total_amount { get; set; }
        //public double Congestion_surcharge { get; set; }
    }
}

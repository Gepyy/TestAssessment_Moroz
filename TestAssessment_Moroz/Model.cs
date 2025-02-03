using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssessment_Moroz
{
    public class Model
    {
        public int Id { get; set; }
        [CsvHelper.Configuration.Attributes.Name("tpep_pickup_datetime")]
        public DateTime Pickup_datetime { get; set; }
        [CsvHelper.Configuration.Attributes.Name("tpep_dropoff_datetime")]
        public DateTime Dropoff_datetime { get; set; }
        [CsvHelper.Configuration.Attributes.TypeConverter(typeof(CustomInt32Converter))]
        [CsvHelper.Configuration.Attributes.Name("passenger_count")]
        public int? Passenger_count { get; set; }
        [CsvHelper.Configuration.Attributes.Name("trip_distance")]
        public double Trip_distance { get; set; }
        [CsvHelper.Configuration.Attributes.Name("store_and_fwd_flag")]
        public string Store_and_fwd_flag { get; set; }
        [CsvHelper.Configuration.Attributes.Name("PULocationID")]
        public int PULocationID { get; set; }
        [CsvHelper.Configuration.Attributes.Name("DOLocationID")]
        public int DOLocationID { get; set; }
        [CsvHelper.Configuration.Attributes.Name("fare_amount")]
        public double Fare_amount { get; set; }
        [CsvHelper.Configuration.Attributes.Name("tip_amount")]
        public double Tip_amount { get; set; }
    }
}

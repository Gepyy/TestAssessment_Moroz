namespace TestAssessment_Moroz
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new Context();
            var tasks = new Tasks(context);

            Console.WriteLine("Query 1: PULocationID with highest average tip:");
            Console.WriteLine(tasks.GetHighestAverageTipLocation());

            Console.WriteLine("\nQuery 2: Top 100 longest trips by distance:");
            foreach (var trip in tasks.GetTop100LongestTripsByDistance())
            {
                Console.WriteLine($"Trip ID: {trip.Id}, Distance: {trip.Trip_distance}");
            }

            Console.WriteLine("\nQuery 3: Top 100 longest trips by time:");
            foreach (var trip in tasks.GetTop100LongestTripsByTime())
            {
                var duration = (trip.Dropoff_datetime - trip.Pickup_datetime).TotalMinutes;
                Console.WriteLine($"Trip ID: {trip.Id}, Duration: {duration} minutes");
            }

            Console.WriteLine("\nQuery 4: Search trips by PULocationId (e.g., 1):");
            foreach (var trip in tasks.SearchTripsByPULocation(1))
            {
                Console.WriteLine($"Trip ID: {trip.Id}, Pickup Location: {trip.PULocationID}");
            }

            Console.WriteLine("\nTask 5: Bulk insert sample trips");
            var sampleTrips = new List<Model>
            {
                new Model { Pickup_datetime = DateTime.Now, Dropoff_datetime = DateTime.Now.AddMinutes(30), Passenger_count = 1, Trip_distance = 10.5, Store_and_fwd_flag = "N", PULocationID = 2, DOLocationID = 5, Fare_amount = 20.5, Tip_amount = 5.0 },
                new Model { Pickup_datetime = DateTime.Now, Dropoff_datetime = DateTime.Now.AddMinutes(15), Passenger_count = 2, Trip_distance = 5.2, Store_and_fwd_flag = "Y", PULocationID = 3, DOLocationID = 7, Fare_amount = 12.0, Tip_amount = 3.0 }
            };
            tasks.BulkInsertTrips(sampleTrips);

            Console.WriteLine("\nTask 6: Remove duplicates and save to CSV");
            tasks.RemoveDuplicatesAndSaveToCsv("duplicates.csv");
            Console.WriteLine("Duplicates saved to duplicates.csv if any.");

            Console.WriteLine("\nTask 7: Normalize Store_and_fwd_flag");
            tasks.NormalizeStoreAndFwdFlag();
            Console.WriteLine("Normalization completed.");

            Console.WriteLine("\nAll tasks executed.");
        }
    }
}
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssessment_Moroz
{
    public class Tasks
    {
        private readonly Context _context;

        public Tasks(Context context)
        {
            _context = context;
        }

        // 4.1
        public int GetHighestAverageTipLocation()
        {
            return _context.Models
                .GroupBy(t => t.PULocationID)
                .Select(g => new { PULocationID = g.Key, AverageTip = g.Average(t => t.Tip_amount) })
                .OrderByDescending(x => x.AverageTip)
                .FirstOrDefault()?.PULocationID ?? 0;
        }

        // 4.2
        public List<Model> GetTop100LongestTripsByDistance()
        {
            return _context.Models
                .OrderByDescending(t => t.Trip_distance)
                .Take(100)
                .ToList();
        }

        // 4.3
        public List<Model> GetTop100LongestTripsByTime()
        {
            return _context.Models
                .OrderByDescending(t => EF.Functions.DateDiffMinute(t.Pickup_datetime, t.Dropoff_datetime))
                .Take(100)
                .ToList();
        }

        // 4.4
        public List<Model> SearchTripsByPULocation(int puLocationId)
        {
            return _context.Models
                .Where(t => t.PULocationID == puLocationId)
                .ToList();
        }

        // 5
        public void BulkInsertTrips(List<Model> models)
        {
            _context.Models.AddRange(models);
            _context.SaveChanges();
        }

        // 6
        public void RemoveDuplicatesAndSaveToCsv(string csvPath)
        {
            var duplicates = _context.Models
                .GroupBy(t => new { t.Pickup_datetime, t.Dropoff_datetime, t.Passenger_count })
                .Where(g => g.Count() > 1)
                .SelectMany(g => g.Skip(1))
                .ToList();

            if (duplicates.Any())
            {
                using (var writer = new StreamWriter(csvPath))
                {
                    writer.WriteLine("Id,Pickup_datetime,Dropoff_datetime,Passenger_count,Trip_distance,Store_and_fwd_flag,PULocationID,DOLocationID,Fare_amount,Tip_amount");
                    foreach (var trip in duplicates)
                    {
                        writer.WriteLine($"{trip.Id},{trip.Pickup_datetime},{trip.Dropoff_datetime},{trip.Passenger_count},{trip.Trip_distance},{trip.Store_and_fwd_flag},{trip.PULocationID},{trip.DOLocationID},{trip.Fare_amount},{trip.Tip_amount}");
                    }
                }

                _context.Models.RemoveRange(duplicates);
                _context.SaveChanges();
            }
        }

        // 7
        public void NormalizeStoreAndFwdFlag()
        {
            var models = _context.Models
                .Where(t => t.Store_and_fwd_flag == "N" || t.Store_and_fwd_flag == "Y")
                .ToList();

            foreach (var model in models)
            {
                model.Store_and_fwd_flag = model.Store_and_fwd_flag == "N" ? "No" : "Yes";
            }

            _context.SaveChanges();
        }

        public void ImportCsvToDatabase(string csvFilePath)
        {
            List<Model> models;
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                models = csv.GetRecords<Model>().ToList();
            }

            if (models.Any())
            {
                _context.Models.AddRange(models);
                _context.SaveChanges();
            }
        }
    }
}

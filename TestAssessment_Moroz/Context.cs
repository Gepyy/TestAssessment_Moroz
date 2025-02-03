using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssessment_Moroz
{
    public class Context : DbContext
    {
        public DbSet<Model> Models { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-EH9PUDO;Initial Catalog=TripData;Integrated Security=True;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Pickup_datetime).IsRequired();
                entity.Property(t => t.Dropoff_datetime).IsRequired();
                entity.Property(t => t.Passenger_count).IsRequired();
                entity.Property(t => t.Trip_distance).IsRequired();
                entity.Property(t => t.Store_and_fwd_flag).HasMaxLength(1);
                entity.Property(t => t.PULocationID).IsRequired();
                entity.Property(t => t.DOLocationID).IsRequired();
                entity.Property(t => t.Fare_amount).IsRequired();
                entity.Property(t => t.Tip_amount).IsRequired();

                entity.HasIndex(t => t.PULocationID).HasDatabaseName("IX_Trips_PULocationID"); // Индекс для поиска по PULocationID
                entity.HasIndex(t => t.Trip_distance).HasDatabaseName("IX_Trips_TripDistance"); // Индекс для длинных поездок
                entity.HasIndex(t => new { t.Pickup_datetime, t.Dropoff_datetime }).HasDatabaseName("IX_Trips_TravelTime"); // Индекс по времени поездок
            });
        }
    }
}

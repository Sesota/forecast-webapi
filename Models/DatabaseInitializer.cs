using System;
using System.Linq;

namespace ForecastApi
{
  public static class DatabaseInitializer
  {
    public static void Initialize(DatabaseContext context)
    {
      context.Database.EnsureCreated();

      if (context.Regions.Any())
      {
        return;   // DB has been seeded
      }

      var regions = new Region[]
      {
        new Region { Latitude = 10.1M, Longitude = 10.1M},
        new Region { Latitude = 10.1M, Longitude = 10.2M},
        new Region { Latitude = 10.1M, Longitude = 10.3M},
        new Region { Latitude = 10.1M, Longitude = 10.4M},
        new Region { Latitude = 10.2M, Longitude = 10.1M},
        new Region { Latitude = 10.2M, Longitude = 10.2M},
        new Region { Latitude = 10.2M, Longitude = 10.3M},
        new Region { Latitude = 10.2M, Longitude = 10.4M},
        new Region { Latitude = 10.3M, Longitude = 10.1M},
        new Region { Latitude = 10.3M, Longitude = 10.2M},
        new Region { Latitude = 10.3M, Longitude = 10.3M},
        new Region { Latitude = 10.3M, Longitude = 10.4M},
        new Region { Latitude = 10.4M, Longitude = 10.1M},
        new Region { Latitude = 10.4M, Longitude = 10.2M},
        new Region { Latitude = 10.4M, Longitude = 10.3M},
        new Region { Latitude = 10.4M, Longitude = 10.4M}
      };

      context.Regions.AddRange(regions);
      context.SaveChanges();  // Why not using Async?

      var weathers = new Weather[]
      {
        new Weather{ Date = DateTime.Parse("1399-05-01"), Condition = ECondition.Sunny,   Region = regions[0]},
        new Weather{ Date = DateTime.Parse("1399-05-01"), Condition = ECondition.Cloudy,  Region = regions[1]},
        new Weather{ Date = DateTime.Parse("1399-05-01"), Condition = ECondition.Rainy,   Region = regions[2]},
        new Weather{ Date = DateTime.Parse("1399-05-01"), Condition = ECondition.Snowy,   Region = regions[3]},
        new Weather{ Date = DateTime.Parse("1399-05-02"), Condition = ECondition.Sunny,   Region = regions[0]},
        new Weather{ Date = DateTime.Parse("1399-05-02"), Condition = ECondition.Cloudy,  Region = regions[1]},
        new Weather{ Date = DateTime.Parse("1399-05-02"), Condition = ECondition.Rainy,   Region = regions[2]},
        new Weather{ Date = DateTime.Parse("1399-05-02"), Condition = ECondition.Snowy,   Region = regions[3]},
        new Weather{ Date = DateTime.Parse("1399-05-03"), Condition = ECondition.Sunny,   Region = regions[0]},
        new Weather{ Date = DateTime.Parse("1399-05-03"), Condition = ECondition.Cloudy,  Region = regions[1]},
        new Weather{ Date = DateTime.Parse("1399-05-03"), Condition = ECondition.Rainy,   Region = regions[2]},
        new Weather{ Date = DateTime.Parse("1399-05-03"), Condition = ECondition.Snowy,   Region = regions[3]},
      };

      context.Weathers.AddRange(weathers);
      context.SaveChanges();
    }
  }
}
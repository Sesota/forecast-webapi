using System;
using System.Text.Json.Serialization;

namespace ForecastApi
{
  public enum ECondition : int
  {
    Sunny = 1,
    Cloudy = 2,
    Rainy = 3,
    Snowy = 4,
  }
  public class Weather
  {
    public long Id { get; set; }
    public DateTime Date { get; set; }
    public ECondition Condition { get; set; }
    [JsonIgnore]  // Added to avoid Json reference looping
    public virtual Region Region { get; set; }
  }
}
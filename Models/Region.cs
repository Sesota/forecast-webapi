using System.Collections.Generic;
namespace ForecastApi
{
  public class Region
  {
    public long Id { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public virtual ICollection<Weather> Weathers { get; set; }
  }
}
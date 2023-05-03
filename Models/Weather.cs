namespace ManiWeather.Models
{
	public class Weather
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public double Generationtime_ms { get; set; }
		public int Utc_offset_seconds { get; set; }
		public string? Timezone { get; set; }
		public string? Timezone_abbreviation { get; set; }
		public double Elevation { get; set; }
		public DailyUnits? Daily_units { get; set; }
		public Daily? Daily { get; set; }
	}
}

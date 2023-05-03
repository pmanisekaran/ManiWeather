public class DailyUnits
{
	public string? Time { get; set; }
	public string? Temperature_2m_min { get; set; }
	public string? Temperature_2m_max { get; set; }
	public string? Snowfall_sum { get; set; }
}

public class Daily
{
	public List<string>? Time { get; set; }
	public List<double>? Temperature_2m_min { get; set; }
	public List<double>? Temperature_2m_max { get; set; }
	public List<double>? Snowfall_sum { get; set; }
}

public class RootObject
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

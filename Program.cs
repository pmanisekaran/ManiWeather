using ManiWeather.Models;
using ManiWeather.Validators;
using Newtonsoft.Json;

class Program
{
	static async Task Main(string[] args)
	{
		var validateInput = new ValidateInput(args);
		if (!validateInput.IsValid)
		{
			Console.WriteLine(validateInput.ValidationMessage);
			Console.WriteLine("Press any key to exit.");
			return;
		}
		string numDays = args[0];
		string latitude = args[1];
		string longitude = args[2];

		var client = new HttpClient();
		var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&daily=temperature_2m_min,temperature_2m_max,snowfall_sum&limit={numDays}&timezone=auto";

		try
		{
			var response = await client.GetAsync(url);
			response.EnsureSuccessStatusCode();

			var json = await response.Content.ReadAsStringAsync();
			var weatherData = JsonConvert.DeserializeObject<Weather>(json);

			var fileName = $"weatherExport_{DateTime.UtcNow:yyyyMMdd}.json";
			var jsonToSave = JsonConvert.SerializeObject(weatherData, Formatting.Indented);
			await File.WriteAllTextAsync(fileName, jsonToSave);

			Console.WriteLine($"Data saved to {fileName}");
			Console.WriteLine("Press any to exit.");
			Console.ReadKey();
		}
		catch (HttpRequestException e)
		{
			Console.WriteLine($"Error: {e.Message}");
			Console.WriteLine("Press any key to exit");
		}
	}
}
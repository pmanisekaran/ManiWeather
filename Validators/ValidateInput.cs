using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiWeather.Validators
{
	public class ValidateInput
	{
		private string? _validationMessage;
		public string? ValidationMessage => _validationMessage;

		public bool IsValid { get { return _validationMessage == null; } }

		public ValidateInput(string[] args)
		{
			if (args.Length != 3)
			{
				_validationMessage = "Usage: dotnet run <numDays> <lat> <long>";
				return;
			}

			int numDays;
			if (!int.TryParse(args[0], out numDays) || numDays < 1 || numDays > 7)
			{
				_validationMessage = "Error: numDays must be an integer between 1 and 7.";
				return;
			}

			if (!double.TryParse(args[1], out double lat) || lat < -90 || lat > 90)
			{
				_validationMessage = "Error: latitude must be a double between -90 and 90.";
				return;
			}

			if (!double.TryParse(args[2], out double lon) || lon < -180 || lon > 180)
			{
				_validationMessage = "Error: longitude must be a double between -180 and 180.";
				return;
			}
		}

	}
}

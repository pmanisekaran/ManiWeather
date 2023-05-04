using FluentAssertions;
using ManiWeather.Validators;
namespace ManiWeather.Tests.Validators
{

	public class ValidateInputTests
	{

		[Fact]
		public void TestWrongNumberOfArgs()
		{
			ValidateInput validator = new ValidateInput(new string[] { "1", "2" });
			validator.IsValid.Should().BeFalse();
			validator.ValidationMessage.Should().Be("Usage: dotnet run <numDays> <lat> <long>");
		}
		[Theory]
		[InlineData("0")]
		[InlineData("8")]
		public void TestInvalidNumDays(string numDays)
		{
			ValidateInput validator = new ValidateInput(new string[] { numDays, "0", "0" });
			validator.IsValid.Should().BeFalse();
			validator.ValidationMessage.Should().Be("Error: numDays must be an integer between 1 and 7.");

		}

		[Theory]
		[InlineData("-91")]
		[InlineData("91")]
		public void TestInvalidLatitude(string latitude)
		{
			ValidateInput validator = new ValidateInput(new string[] { "1", latitude, "78" });
			validator.IsValid.Should().BeFalse();
			validator.ValidationMessage.Should().Be("Error: latitude must be a double between -90 and 90.");

		}

		[Theory]
		[InlineData("-181")]
		[InlineData("181")]
		public void TestInvalidLongitude(string longitude)
		{
			ValidateInput validator = new ValidateInput(new string[] { "1", "22", longitude });
			validator.IsValid.Should().BeFalse();
			validator.ValidationMessage.Should().Be("Error: longitude must be a double between -180 and 180.");

		}
	}
}



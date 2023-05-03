using ManiWeather.Validators;
using NUnit.Framework;

namespace ManiWeather.Tests.Validators
{
	[TestFixture]
	public class ValidateInputTests
	{

		[Test]
		public void TestWrongNumberOfArgs()
		{
			ValidateInput validator = new ValidateInput(new string[] { "1", "2" });
			Assert.IsFalse(validator.IsValid);
			Assert.AreEqual("Usage: dotnet run <numDays> <lat> <long>", validator.ValidationMessage);
		}

		[TestCase("0")]
		[TestCase("8")]
		public void TestInvalidNumDays(string numDays)
		{
			ValidateInput validator = new ValidateInput(new string[] { numDays, "0", "0" });
			Assert.IsFalse(validator.IsValid);
			Assert.AreEqual("Error: numDays must be an integer between 1 and 7.", validator.ValidationMessage);

			validator = new ValidateInput(new string[] { numDays, "0", "0" });
			Assert.IsFalse(validator.IsValid);
			Assert.AreEqual("Error: numDays must be an integer between 1 and 7.", validator.ValidationMessage);
		}

		[TestCase("-91")]
		[TestCase("91")]
		public void TestInvalidLatitude(string latitude)
		{
			ValidateInput validator = new ValidateInput(new string[] { "1", latitude, "78" });
			Assert.IsFalse(validator.IsValid);
			Assert.AreEqual("Error: latitude must be a double between -90 and 90.", validator.ValidationMessage);

		}
		[TestCase("-181")]
		[TestCase("181")]
		public void TestInvalidLongitude(string longitude)
		{
			ValidateInput validator = new ValidateInput(new string[] { "1", "22", longitude });
			Assert.IsFalse(validator.IsValid);
			Assert.AreEqual("Error: longitude must be a double between -180 and 180.", validator.ValidationMessage);

		}
	}
}



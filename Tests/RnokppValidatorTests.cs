using Validator;

namespace Tests
{
    public class RnokppValidatorTests
    {
        readonly RnokppValidator validator = new();

        [Fact]
        public void HasOnly10Digits()
        {
            var testStr = "2345067812";

            var result = validator.Validate(testStr);

            Assert.True(result);
        }
        
        [Fact]
        public void HasNot10Digits()
        {
            var testStr1 = "23450678123";
            var testStr2 = "234506781";
            var testStr3 = "2345";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);

            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void HasNotOnlyDigits()
        {
            var testStr1 = "2345a67812";
            var testStr2 = "23450678$1";
            var testStr3 = "23-4245-7561";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);

            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void IsNullOrEmpty()
        {
            var testStr1 = "";
            var testStr2 = string.Empty;
            string? testStr3 = null;

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);

            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
        }
    }
}

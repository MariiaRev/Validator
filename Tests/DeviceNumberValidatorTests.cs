using Validator;

namespace Tests
{
    public class DeviceNumberValidatorTests
    {
        readonly DeviceNumberValidator validator = new();

        [Fact]
        public void HasAtoFOrDigitsTotally32()
        {
            var testStr1 = "3614435a-8b46-42de-a7b5-bf1d72c4b913";
            var testStr2 = "B5A648BA-262F-47BF-A0F5-4FDF68AC0C12";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);

            Assert.True(result1);
            Assert.True(result2);
        }
        
        [Fact]
        public void HasAtoFOrDigitsTotallyNot32()
        {
            var testStr1 = "361443fa5a-8b46-42de-a7b5-bf1d72c413";
            var testStr2 = "B5A648BA82-262F-47BF-A0F5-4FDF68C12";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);

            Assert.False(result1);
            Assert.False(result2);
        }
        
        [Fact]
        public void HasWrongLetters()
        {
            var testStr1 = "361443za5a-8b46-42de-a7b5-bf1p72c413";
            var testStr2 = "B5A648XA82-262F-47BF-A0F5-4FDF68C12";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);

            Assert.False(result1);
            Assert.False(result2);
        }
        
        [Fact]
        public void HasWrongSymbolsOrder()
        {
            var testStr1 = "36144-35a8b46-42de-a7b5bf1d-72c4b913";
            var testStr2 = "B5-A648BA-262F-47BF-A0F5-4FDF68AC-0C12";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);

            Assert.False(result1);
            Assert.False(result2);
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

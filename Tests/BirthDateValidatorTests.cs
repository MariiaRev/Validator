using Validator;

namespace Tests
{
    public class BirthDateValidatorTests
    {
        readonly BirthDateValidator validator = new();

        [Fact]
        public void IsCorrectForMonthWith31Days()
        {
            var testStr1 = "01.01.2023";
            var testStr2 = "14.03.2023";
            var testStr3 = "22.05.2023";
            var testStr4 = "30.07.2023";
            var testStr5 = "31.12.2023";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);
            var result4 = validator.Validate(testStr4);
            var result5 = validator.Validate(testStr5);

            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
            Assert.True(result4);
            Assert.True(result5);
        }
        
        [Fact]
        public void IsWrongForMonthWith31Days()
        {
            var testStr1 = "00.01.2023";
            var testStr2 = "4.03.2023";
            var testStr3 = "22.5.2023";
            var testStr4 = "32.07.2023";
            var testStr5 = "04.1.2023";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);
            var result4 = validator.Validate(testStr4);
            var result5 = validator.Validate(testStr5);

            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);
            Assert.False(result5);
        }
        
        [Fact]
        public void IsCorrectForMonthWith30Days()
        {
            var testStr1 = "01.11.2023";
            var testStr2 = "14.09.2023";
            var testStr3 = "22.09.2023";
            var testStr4 = "30.06.2023";
            var testStr5 = "30.04.2023";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);
            var result4 = validator.Validate(testStr4);
            var result5 = validator.Validate(testStr5);

            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
            Assert.True(result4);
            Assert.True(result5);
        }

        [Fact]
        public void IsWrongForMonthWith30Days()
        {
            var testStr1 = "00.11.2023";
            var testStr2 = "4.09.2023";
            var testStr3 = "22.9.2023";
            var testStr4 = "32.06.2023";
            var testStr5 = "31.04.2023";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);
            var result4 = validator.Validate(testStr4);
            var result5 = validator.Validate(testStr5);

            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);
            Assert.False(result5);
        }

        [Fact]
        public void IsCorrectForFebruary()
        {
            var testStr1 = "01.02.2023";
            var testStr2 = "14.02.2023";
            var testStr3 = "22.02.2023";
            var testStr4 = "29.02.2024";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);
            var result4 = validator.Validate(testStr4);

            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
            Assert.True(result4);
        }

        [Fact]
        public void IsWrongForFebruary()
        {
            var testStr1 = "00.02.2023";
            var testStr2 = "4.02.2023";
            var testStr3 = "22.2.2023";
            var testStr4 = "30.02.2023";
            var testStr5 = "027.02.2023";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);
            var result4 = validator.Validate(testStr4);
            var result5 = validator.Validate(testStr5);

            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);
            Assert.False(result5);
        }

        [Fact]
        public void IsLeapYear()
        {
            var testStr1 = "29.02.2020";
            var testStr2 = "29.02.2024";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);

            Assert.True(result1);
            Assert.True(result2);
        }
        
        [Fact]
        public void IsNotLeapYear()
        {
            var testStr1 = "29.02.2021";
            var testStr2 = "29.02.2023";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);

            Assert.False(result1);
            Assert.False(result2);
        }

        [Fact]
        public void HasWrongMonth()
        {
            var testStr1 = "02.00.2023";
            var testStr2 = "14.0.2023";
            var testStr3 = "22.2.2023";
            var testStr4 = "30.13.2023";
            var testStr5 = "27..2023";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);
            var result4 = validator.Validate(testStr4);
            var result5 = validator.Validate(testStr5);

            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);
            Assert.False(result5);
        }

        [Fact]
        public void HasCorrectYear()
        {
            var testStr1 = "02.01.2023";
            var testStr2 = "14.03.1800";
            var testStr3 = "22.09.2099";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);

            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void HasWrongYear()
        {
            var testStr1 = "02.01.23";
            var testStr2 = "14.03.1799";
            var testStr3 = "22.09.2100";
            var testStr4 = "30.12.999";
            var testStr5 = "27.04.0000";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);
            var result4 = validator.Validate(testStr4);
            var result5 = validator.Validate(testStr5);

            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);
            Assert.False(result5);
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

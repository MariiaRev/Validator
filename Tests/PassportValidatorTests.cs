using Validator;

namespace Tests
{
    public class PassportValidatorTests
    {

        readonly PassportValidator validator = new();

        [Fact]
        public void PassportHas2CyrilicSymbolsAnd6Numbers()
        {
            var testStr1 = "ВЛ873251";
            var testStr2 = "ФЮ873251";
            var testStr3 = "КР873251";
            var testStr4 = "НЯ873251";
            var testStr5 = "ШБ873251";

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
        public void PassportHas2CyrilicSymbolsButNot6Numbers()
        {
            var testStr1 = "ВЛ87321";
            var testStr2 = "ФЮ8732512";
            var testStr3 = "КР87325152";
            var testStr4 = "НЯ8732";
            var testStr5 = "ШБ873";

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
        public void PassportHasNot2CyrilicSymbolsAnd6Numbers()
        {
            var testStr1 = "ВЛА873251";
            var testStr2 = "Ф873251";
            var testStr3 = "КD873251";
            var testStr4 = "НЯJ873251";
            var testStr5 = "JS873251";

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
        public void PassportHasOnlyNumbers()
        {
            var testStr1 = "98А873251";
            var testStr2 = "73251";
            var testStr3 = "3251";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);

            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
        }
    
        [Fact]
        public void PassportHasOnlyCyrilicSymbols()
        {
            var testStr1 = "КР";
            var testStr2 = "ЛВРАУОАІ";
            var testStr3 = "СТ";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);

            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
        }
    
        [Fact]
        public void PassportHasInappropriateSymbols()
        {
            var testStr1 = "ВЛ87$251";
            var testStr2 = "СЬ873251";
            var testStr3 = "КР 873251";

            var result1 = validator.Validate(testStr1);
            var result2 = validator.Validate(testStr2);
            var result3 = validator.Validate(testStr3);

            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
        }
    
        [Fact]
        public void PassportHasWrongOrder()
        {
            var testStr = "873251СТ";

            var result = validator.Validate(testStr);

            Assert.False(result);
        }
    
        [Fact]
        public void PassportIsNullOrEmpty()
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
using System.Text.RegularExpressions;

namespace Validator
{
    public class RnokppValidator : IValidator
    {
        const string rnokppStr = "^\\d{10}$";
        public bool Validate(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            var regex = new Regex(rnokppStr);
            return regex.IsMatch(str);
        }
    }
}

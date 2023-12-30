using System.Text.RegularExpressions;

namespace Validator
{
    public class PassportValidator: IValidator
    {
        const string passportStr = "^[А-ЩЮЯ]{2}\\d{6}$";
        public bool Validate(string str)
        {
            if (string.IsNullOrEmpty(str))
            { 
                return false; 
            }

            var regex = new Regex(passportStr);
            return regex.IsMatch(str);
        }
    }
}

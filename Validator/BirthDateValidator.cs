using System.Text.RegularExpressions;

namespace Validator
{
    public class BirthDateValidator: IValidator
    {
        const string year = "(18|19|20)\\d{2}";                                         // from 1800 to 2099
        const string leapYear = "(18|19|20)(0[48]|[2468][048]|[13579][26]|2000)";       // from 1800 to 2099

        const string for31days = "(0[1-9]|[12][0-9]|3[01])\\.(0[13578]|1[02])";
        const string for30days = "(0[1-9]|[12][0-9]|30)\\.(0[469]|11)";
        const string forFebruary = "(0[1-9]|1[0-9]|2[0-8])\\.02";

        const string dateNotLeapYear = $"(({for31days})|({for30days})|({forFebruary}))\\.{year}";
        const string dateLeapYear = $"29\\.02\\.{leapYear}";

        const string birthDateStr = $"^{dateNotLeapYear}|{dateLeapYear}$";

        public bool Validate(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            var regex = new Regex(birthDateStr);
            return regex.IsMatch(str);
        }
    }
}

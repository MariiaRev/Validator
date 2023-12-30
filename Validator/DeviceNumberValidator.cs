using System.Text.RegularExpressions;

namespace Validator
{
    public class DeviceNumberValidator: IValidator
    {
        const string hex = "[A-Fa-f\\d]";
        const string deviceNumberStr = $"^({hex}{{8}}-{hex}{{4}}-{hex}{{4}}-{hex}{{4}}-{hex}{{12}})$";

        public bool Validate(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            var regex = new Regex(deviceNumberStr);
            return regex.IsMatch(str);
        }
    }
}

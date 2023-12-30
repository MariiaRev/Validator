namespace Validator
{
    internal class ValidatorFactory
    {
        public static IValidator GetValidator(string type) =>
            type.ToLower() switch
            {
                "passport" => new PassportValidator(),
                "rnokpp" => new RnokppValidator(),
                "birth_date" => new BirthDateValidator(),
                "device_number" => new DeviceNumberValidator(),
                _ => throw new ArgumentException("Invalid string value for validator type", nameof(type))
            };
    }
}

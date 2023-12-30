using System.Diagnostics.CodeAnalysis;
using Validator;

try
{
    var result = TryGetFirstTwoArgs(out (string, string)? parameters);
    if (result)
    {
        var validationType = parameters.Value.Item1;
        var validationStr = parameters.Value.Item2;

        IValidator validator = ValidatorFactory.GetValidator(validationType);
        var res = validator.Validate(validationStr);

        Console.WriteLine(res.ToString());
    }
    else
    {
        Console.WriteLine("False");
    }
}
catch
{
    Console.WriteLine("False");
}

bool TryGetFirstTwoArgs([NotNullWhen(returnValue: true)]out (string, string)? parameters)
{
    if (args is not null
        && args.Length == 2)
    {
        parameters = (args[0], args[1]);
        return true;
    }

    parameters = null;
    return false;
}
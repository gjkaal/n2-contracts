namespace N2;

public static class ExceptionFactory
{
    public static ContractException NullValue(string name)
    {
        return new ContractException("Value cannot be null.", name);
    }

    public static ContractException NullOrEmptyValue(string name)
    {
        return new ContractException("Value cannot be null or empty", name);
    }

    public static ContractException DefaultNotAllowed(string name)
    {
        return new ContractException("Value cannot be default", name);
    }

    public static ContractException MinLengthRequired(string name, int length)
    {
        return new ContractException($"Value must be at least {length} characters long", name);
    }

    public static ContractException MaxLengthRequired(string name, int length)
    {
        return new ContractException($"Value must be at most {length} characters long", name);
    }

    public static ContractException ExactLengthRequired(string name, int length)
    {
        return new ContractException($"Value must exactly {length} characters long", name);
    }
}


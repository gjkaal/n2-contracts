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
}


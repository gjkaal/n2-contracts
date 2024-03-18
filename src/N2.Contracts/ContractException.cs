namespace N2;

public class ContractException : ArgumentException
{
    public ContractException(string message, string paramName) : base(message, paramName)
    {
    }
}


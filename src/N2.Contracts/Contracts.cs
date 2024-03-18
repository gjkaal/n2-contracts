using System.Diagnostics.CodeAnalysis;

namespace N2;

public static class Contracts
{
    public static void NotNull<T>([NotNull] T? value, string name) where T : class
    {
        if (typeof(T) == typeof(string) && string.IsNullOrEmpty(value as string))
        {
            throw ExceptionFactory.NullOrEmptyValue(name);
        }

        if (value is null)
        {
            throw ExceptionFactory.NullValue(name);
        }
    }

    public static void NotDefault<T>(T value, string name) where T : struct, IEquatable<T>
    {
        var check = default(T);
        if (value.Equals(check))
        {
            throw ExceptionFactory.DefaultNotAllowed(name);
        }
    }
}


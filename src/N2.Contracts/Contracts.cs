using System.Diagnostics.CodeAnalysis;

namespace N2;

public static class Contracts
{
    public static void Requires<T>([NotNull] T? value, string name) where T : class
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

    public static void MinLength([NotNull] string? value, int minLength, string name)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw ExceptionFactory.NullOrEmptyValue(name);
        }
        if (value.Length < minLength)
        {
            throw ExceptionFactory.MinLengthRequired(name, minLength);
        }
    }

    public static void MaxLength(string? value, int maxLength, string name)
    {
        if (string.IsNullOrEmpty(value))
        {
            return;
        }
        if (value.Length > maxLength)
        {
            throw ExceptionFactory.MaxLengthRequired(name, maxLength);
        }
    }

    public static void RequireLengthBetween([NotNull] string? value, int minLength, int maxLength, string name)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw ExceptionFactory.NullOrEmptyValue(name);
        }
        if (value.Length < minLength)
        {
            throw ExceptionFactory.MinLengthRequired(name, minLength);
        }
        if (value.Length > maxLength)
        {
            throw ExceptionFactory.MaxLengthRequired(name, maxLength);
        }
    }

    public static void RequireLength([NotNull] string? value, int length, string name)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw ExceptionFactory.NullOrEmptyValue(name);
        }
        if (value.Length != length)
        {
            throw ExceptionFactory.ExactLengthRequired(name, length);
        }
    }

}


using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new Exception();
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        if (int.TryParse(input, out int output)) return output;
        return null;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        // could do it exactly the same as HandleErrorByReturningNullableType, but this time I won't cheat with TryParse
        try
        {
            result = int.Parse(input);
            return true;
        }
        catch (Exception)
        {
            result = -1;
            return false;
        }
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        using var disposable = disposableObject;
        throw new Exception();
    }
}

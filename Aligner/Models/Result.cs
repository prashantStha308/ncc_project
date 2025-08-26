
namespace Aligner.Models;

public class Result<T>
{
    public bool Success { get; init; }
    public T? Data;
    public string? Message { get; init; }

    public static Result<T> Ok(T data, string message = "")
    {
        return new()
        {
            Success = true,
            Data = data,
            Message = message
        };
    }

    // Overload Ok function, no Data required

    public static Result<T> Ok(string message = "Success")
    {
        return new()
        {
            Success = true,
            Message = message
        };
    }

    public static Result<T> Fail(string message)
    {
        return new()
        {
            Success = false,
            Message = message
        };
    }

    // Overload Fail function to account for Exception handeling
    public static Result<T> Fail(Exception e)
    {
        return new()
        {
            Success = false,
            Message = e.Message
        };
    }

    public T GetData()
    {
        if (!Success)
        {
            throw new InvalidOperationException($"Cannot get data of failed operation: {Message}");
        }
        return Data!;
    }


}

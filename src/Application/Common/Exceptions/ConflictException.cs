namespace Application.Common.Exceptions;

public class ConflictException : Exception
{
    public ConflictException(string name, object key)
        : base($"Conflict detected with Entity \"{name}\" ({key})")
    {
    }
}
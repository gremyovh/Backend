using System.Runtime.Serialization;

namespace gremy.ovh.Infrastructure.Exceptions;
[Serializable]
public class DbConfigurationException : Exception
{
  public DbConfigurationException()
  {
  }

  public DbConfigurationException(string? message)
    : base(message)
  {
  }

  public DbConfigurationException(string? message, Exception? innerException)
    : base(message, innerException)
  {
  }

  protected DbConfigurationException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}

using System.Data.Common;
using gremy.ovh.Infrastructure.Exceptions;

namespace gremy.ovh.Infrastructure.Config.DbConfig;
public class DatabaseConfig
{
  private static DatabaseConfig? _instance;

  private string _hostUrl = string.Empty;
  private string _hostPort = string.Empty;
  private string _name = string.Empty;
  private string _user = string.Empty;
  private string _password = string.Empty;

  public static DatabaseConfig GetInstance(bool withDefaultValues)
  {
    if (_instance is null)
    {
      _instance = new DatabaseConfig(withDefaultValues);
    }

    return _instance;
  }

  public string HostUrl
  {
    get
    {
      if (string.IsNullOrEmpty(_hostUrl))
      {
        _hostUrl = Environment.GetEnvironmentVariable("db_host_url")
          ?? throw new DbConfigurationException("env db_host_url is missing.");
      }

      return _hostUrl;
    }
  }

  public string HostPort
  {
    get
    {
      if (string.IsNullOrEmpty(_hostPort))
      {
        _hostPort = Environment.GetEnvironmentVariable("db_host_port")
          ?? throw new DbConfigurationException("env db_host_port is missing.");
      }

      return _hostPort;
    }
  }

  public string Name
  {
    get
    {
      if (string.IsNullOrEmpty(_name))
      {
        _name = Environment.GetEnvironmentVariable("db_name")
          ?? throw new DbConfigurationException("env db_name is missing.");
      }

      return _name;
    }
  }

  public string User
  {
    get
    {
      if (string.IsNullOrEmpty(_user))
      {
        _user = Environment.GetEnvironmentVariable("db_user")
          ?? throw new DbConfigurationException("env db_user is missing.");
      }

      return _user;
    }
  }

  public string Password
  {
    get
    {
      if (string.IsNullOrEmpty(_password))
      {
        _password = Environment.GetEnvironmentVariable("db_password")
          ?? throw new DbConfigurationException("env db_password is missing.");
      }

      return _password;
    }
  }

  private DatabaseConfig(bool withDefaultValues)
  {
    if (withDefaultValues)
    {
      _hostUrl = "localhost";
      _hostPort = "3306";
      _name = "gremy_ovh";
      _user = "user";
      _password = "password";
    }
  }

  public string GetConnectionString()
  {
    var sqlBuilder = new DbConnectionStringBuilder();
    sqlBuilder["Server"] = HostUrl;
    sqlBuilder["Port"] = HostPort;
    sqlBuilder["Database"] = Name;
    sqlBuilder["User"] = User;
    sqlBuilder["Password"] = Password;

    return sqlBuilder.ConnectionString;
  }
}

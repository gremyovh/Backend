using gremy.ovh.Infrastructure.Config.DbConfig;

namespace gremy.ovh.Infrastructure.Config;
public class AppConfiguration
{
  private static DatabaseConfig? _databaseConfig;

  public static DatabaseConfig GetDatabaseConfig(bool withDefaultValues)
  {
    if (_databaseConfig is null)
    {
      _databaseConfig = DatabaseConfig.GetInstance(withDefaultValues);
    }

    return _databaseConfig;
  }

  private AppConfiguration() { }
}

using MySqlConnector;

namespace RadioDJLocal.Data;

public class RadioDjConnectionFactory
{
    private readonly string _connectionString;

    public RadioDjConnectionFactory(IConfiguration configuration)
    {
        _connectionString =
            configuration.GetConnectionString("RadioDJ")
            ?? throw new InvalidOperationException(
                "A conexão RadioDJ não foi configurada.");
    }

    public MySqlConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}

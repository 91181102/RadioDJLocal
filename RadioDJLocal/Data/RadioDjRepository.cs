using Dapper;

namespace RadioDJLocal.Data;

public class RadioDjRepository
{
    private readonly RadioDjConnectionFactory _factory;

    public RadioDjRepository(RadioDjConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<int> TestarConexaoAsync()
    {
        await using var conexao = _factory.CreateConnection();
        await conexao.OpenAsync();

        return await conexao.QuerySingleAsync<int>("SELECT 1;");
    }

    public async Task<IEnumerable<string>> ListarTabelasAsync()
    {
        await using var conexao = _factory.CreateConnection();
        await conexao.OpenAsync();

        const string sql = """
        SELECT TABLE_NAME
        FROM information_schema.TABLES
        WHERE TABLE_SCHEMA = DATABASE()
        ORDER BY TABLE_NAME;
        """;

        return await conexao.QueryAsync<string>(sql);
    }
}

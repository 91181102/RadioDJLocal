using Dapper;
using RadioDJLocal.Models;

namespace RadioDJLocal.Data;

public class CategoryRepository
{
    private readonly RadioDjConnectionFactory _factory;

    public CategoryRepository(RadioDjConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<Category>> ListarAsync()
    {
        await using var conexao = _factory.CreateConnection();
        await conexao.OpenAsync();

        const string sql = """
            SELECT
                id,
                name
            FROM category
            ORDER BY name;
            """;

        return await conexao.QueryAsync<Category>(sql);
    }
}


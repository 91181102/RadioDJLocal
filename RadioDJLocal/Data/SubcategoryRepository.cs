using Dapper;
using RadioDJLocal.Models;

namespace RadioDJLocal.Data
{
    public class SubcategoryRepository
    {
        private readonly RadioDjConnectionFactory _factory;

        public SubcategoryRepository(RadioDjConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<Subcategory>> ListarAsync()
        {
            await using var conexao = _factory.CreateConnection();
            await conexao.OpenAsync();

            const string sql = """
            SELECT
                id,
                name,
                parentId
            FROM Subcategory
            ORDER BY name;
            """;

            return await conexao.QueryAsync<Subcategory>(sql);
        }
    }
}

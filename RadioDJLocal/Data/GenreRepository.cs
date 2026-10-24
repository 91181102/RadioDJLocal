using Dapper;
using RadioDJLocal.Models;

namespace RadioDJLocal.Data
{
    public class GenreRepository
    {
        private readonly RadioDjConnectionFactory _factory;

        public GenreRepository(RadioDjConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<Genre>> ListarAsync()
        {
            await using var conexao = _factory.CreateConnection();
            await conexao.OpenAsync();

            const string sql = """
            SELECT
                id,
                name
            FROM Genre
            ORDER BY name;
            """;

            return await conexao.QueryAsync<Genre>(sql);
        }
    }
}

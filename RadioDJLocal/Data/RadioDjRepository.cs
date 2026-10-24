using Dapper;
using RadioDJLocal.Models;

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

    /// <summary>
    /// Recupera até 100 músicas da base de dados com informações de artista, título, álbum, gênero e subcategoria,
    /// ordenadas por artista.
    /// </summary>
    /// <remarks>Abre uma conexão via factory, executa uma consulta SQL que faz LEFT JOIN em genre e
    /// subcategory, mapeia os campos para Song e limita o resultado a 100 registros.</remarks>
    /// <returns>Uma Task cujo resultado é um IEnumerable<Song> contendo as músicas recuperadas.</returns>
    /// <![CDATA[19/10/2026]]>
    public async Task<IEnumerable<Song>> ListarMusicasAsync()
    {
        await using var conexao = _factory.CreateConnection();
        await conexao.OpenAsync();

        const string sql = """
        SELECT
            S.id,
            S.start_date,
            S.end_date,
            S.artist,
            S.title,
            S.album,
            S.year,
            S.track_no,
            S.publisher,
            S.album_art,
            S.buy_link,
            S.song_type,
            T.parentId AS id_category,
            T.name AS Category,
            S.id_subcat,
            S.id_genre,
            COALESCE(G.name, '') AS genre,
            S.original_artist,
            S.copyright,
            S.path,
            S.enabled
        FROM songs S
        LEFT JOIN genre G
            ON G.id = S.id_genre
        LEFT JOIN subcategory T
            ON T.id = S.id_subcat
        ORDER BY S.artist
        LIMIT 100;
        """;

        return await conexao.QueryAsync<Song>(sql);
    }
}
